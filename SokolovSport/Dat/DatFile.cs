using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SokolovSport.Dat
{
    class DatFile: IDisposable
    {
        private readonly Dictionary<string, CalibrItem> calibrations = new Dictionary<string, CalibrItem>();
        public Dictionary<string, CalibrItem> Calibrations { get { return calibrations; } }
        public CalibrItem[] LogCalibrItems;
        public CalibrItem[] OnlineCalibrItems;

        public event EventHandler<CalibrChangeEventArgs> CalibrChange;
        public string Path { get; private set; }
        private readonly FileStream fileStream;
        private readonly StreamWriter writer;        

        public DatFile(string path)
        {
            Path = path;
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan);
            string source;
            using (var reader = new StreamReader(fileStream, Encoding.GetEncoding(866)))
            {
                source = reader.ReadToEnd();
                reader.Close();
            }
            fileStream.Close();

            fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan);
            writer = new StreamWriter(fileStream, Encoding.GetEncoding(866), 0x1000);

            var partIndex = 0;
            CalibrItem calibr = null;
            var items = source.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            foreach(var item in items)
            {
                if (partIndex == 0)
                {
                    calibr = new CalibrItem(this);
                    calibr.PropertyChanged += calibr_PropertyChanged;
                }

                calibr.LoadFromPartString(item);

                int stopPartIndex;
                var itemType = calibr.ItemInfo == null ? ItemTypes.Unknown : calibr.ItemInfo.ItemType;

                switch (itemType)
                {
                    case ItemTypes.Var:
                        stopPartIndex = 7;
                        break;

                    case ItemTypes.Table:
                    case ItemTypes.Teach:
                        stopPartIndex = 7 + calibr.ItemInfo.RowCount;
                        break;

                    case ItemTypes.Const:
                        stopPartIndex = 8;
                        break;

                    default:
                        stopPartIndex = int.MaxValue;
                        break;
                }

                if (partIndex == stopPartIndex)
                {                    
                    partIndex = 0;
                    calibrations.Add(calibr.Name, calibr);
                }
                else
                    partIndex++;
            }

            Prepare();
        }

        public void SaveToFile()
        {
            fileStream.Seek(0, SeekOrigin.Begin);

            writer.Write(ToString());
            writer.Flush();
        }

        private void Prepare()
        {
            foreach (var calibration in calibrations.Values)
            {
                if (calibrations.ContainsKey(calibration.AxisX))
                {
                    calibration.AxisXCalibrItem = calibrations[calibration.AxisX];
                }
                if (calibrations.ContainsKey(calibration.AxisY))
                {
                    calibration.AxisYCalibrItem = calibrations[calibration.AxisY];
                }
                if (calibrations.ContainsKey(calibration.VisualCalibr1Name))
                {
                    calibration.VisualCalibr1 = calibrations[calibration.VisualCalibr1Name];
                }
                if (calibrations.ContainsKey(calibration.VisualCalibr2Name))
                {
                    calibration.VisualCalibr2 = calibrations[calibration.VisualCalibr2Name];
                }
            }

            LogCalibrItems =
                calibrations.Values.Where(
                    item => item.ItemInfo.ItemType == ItemTypes.Var || item.ItemInfo.ItemType == ItemTypes.Table).
                    ToArray();

            OnlineCalibrItems = calibrations.Values.Where(item => item.ItemInfo.ItemType == ItemTypes.Var).ToArray();
        }

        void calibr_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var calibr = (CalibrItem) sender;
            DoCalibrChange(new CalibrChangeEventArgs(calibr, e.PropertyName));
        }

        public override string ToString()
        {
            return this.SaveToString();
        }

        public void Dispose()
        {            
            writer.Close();
            fileStream.Close();
        }

        private void DoCalibrChange(CalibrChangeEventArgs e)
        {
            var cc = CalibrChange;
            if (cc != null)
                cc(this, e);
        }
    }

    internal class CalibrChangeEventArgs : EventArgs
    {
        public CalibrItem Calibr { get; private set; }
        public string PropertyChange { get; private set; }

        public CalibrChangeEventArgs(CalibrItem calibr, string propertyChange)
        {
            Calibr = calibr;
            PropertyChange = propertyChange;
        }
    }
}

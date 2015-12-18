using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SokolovSport.Dat;
using SokolovSport.EcuComm;
using SokolovSport.Options;

namespace SokolovSport.Logs
{
    class CalibrLogger
    {
        private readonly DatFile datFile;
        private readonly EcuCommunication ecuCommunication;
        private StreamWriter logFile;
        private uint lineCount;

        public CalibrLogger(DatFile datFile, EcuCommunication ecuCommunication)
        {
            this.datFile = datFile;
            this.ecuCommunication = ecuCommunication;


            ecuCommunication.OnCalibrSync += EcuCommunicationOnOnCalibrSync;
            ecuCommunication.PropertyChanged += EcuCommunicationOnPropertyChanged;
        }

        private void EcuCommunicationOnOnCalibrSync(object sender, EventArgs e)
        {
            if (!OptionsHelper.Options.LogECU) return;

            if (logFile == null)
                Init();

            var dataLine = String.Join(",", datFile.LogCalibrItems.Select(item => item.ValueStr));
            logFile.WriteLine(dataLine);

            if (lineCount % 100 == 0) logFile.Flush();
        }

        private void EcuCommunicationOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsStarted":
                    if (!ecuCommunication.IsStarted && OptionsHelper.Options.NewLogOnConnectECU)
                        Close();
                    break;
            }
        }

        private void Init()
        {
            var startPath = Application.StartupPath;
            var datDir = Path.GetFileNameWithoutExtension(datFile.Path);
            var fileName = String.Format("{0}_{1}.csv", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss"));            
            var path = String.Format("{0}\\logs\\{1}\\{2}", startPath, datDir, fileName);
            var pathDir = Path.GetDirectoryName(path);

            if (!Directory.Exists(pathDir))
                Directory.CreateDirectory(pathDir);

            var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 2048);
            logFile = new StreamWriter(stream, Encoding.GetEncoding(1251), 2048);

            var header = String.Join(",", datFile.Calibrations.Values.Select(item => item.Description));            
            logFile.WriteLine(header);

            lineCount = 0;
        }

        public void Close()
        {
            if (logFile == null) return;

            logFile.Flush();
            logFile.Close();
            logFile = null;            
        }
    }
}

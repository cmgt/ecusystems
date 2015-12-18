using System;
using System.ComponentModel;
using System.Windows.Forms;
using CalibrTable;
using CtpMaps;
using CtpMaps.DataTypes;
using Helper.ProgressDialog;
using OpenOltTypes;

namespace RamTablePlugin
{
    internal class CaptureManager
    {
        internal const int captureAddress = 0xFE00;
        internal readonly IOnlineManager onlineManager;
        internal readonly TableValues<byte, float> table;
        private byte[] rawBuffer;
        internal ExInfo exInfo;
        private IWin32Window owner;

        public CaptureManager(IOnlineManager onlineManager)
        {
            this.onlineManager = onlineManager;

            table = new TableValues<byte, float>();
            table.ValueChanged += TableOnValueChanged;
            table.PropertyChanged += TableOnPropertyChanged;

            onlineManager.FirmwareManager.OnOpenFirmware += FirmwareManagerOnOpenFirmware;
            onlineManager.FirmwareManager.OnCloseFirmware += FirmwareManagerOnOpenFirmware;
            onlineManager.FirmwareManager.PropertyChanged += FirmwareManagerOnPropertyChanged;

            onlineManager.FirmwareManager.AutoCorrection += (sender, args) =>
                {
                    if (!onlineManager.EnabledRamOnlineCorrection) return;
                    if (CapturedTable == null || CapturedTable.Address != args.Address) return;
                                        
                    CapturedTable.SetSource(args.Index, args.Source);
                    args.Cancel = true;
                };

            SetEnabled();
        }

        private void TableOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Table") return;
            using (var progress = ProgressForm.ShowProgress(owner))
            {
                onlineManager.FirmwareManager.WriteRam(captureAddress, table.Address, table.GetRawBuffer(),
                                                       progress, true);
                progress.Close();
            }
        }

        private void FirmwareManagerOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CapturedTable == null) return;

            switch (e.PropertyName)
            {
                case "Rpm32ThrRtIndex":
                    if (exInfo.RtType != RtType.Rpm32Thr) return;
                    table.CurrentIndex = onlineManager.FirmwareManager.Rpm32ThrRtIndex;
                    break;

                case "RpmThrRtIndex":
                    if (exInfo.RtType != RtType.RpmThr) return;
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmThrRtIndex;
                    break;

                case "TwatRtIndex":
                    if (exInfo.RtType != RtType.Twat) return;
                    table.CurrentIndex = onlineManager.FirmwareManager.TwatRtIndex;
                    break;

                case "RpmRt32Index":
                    if (exInfo.RtType != RtType.Rpm32) return;
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmRt32Index;
                    break;

                case "RpmGbcRtIndex":
                    if (exInfo.RtType != RtType.RpmGbc) return;
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmGbcRtIndex;
                    break;

                case "RpmPressRtIndex":
                    if (exInfo.RtType != RtType.RpmPress) return;
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmPressRtIndex;
                    break;
            }
        }

        internal void SetCurrentIndex()
        {
            if (CapturedTable == null) return;
            switch (exInfo.RtType)
            {
                case RtType.Twat:
                    table.CurrentIndex = onlineManager.FirmwareManager.TwatRtIndex;
                    break;

                case RtType.RpmThr:
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmThrRtIndex;
                    break;

                case RtType.Rpm32Thr:
                    table.CurrentIndex = onlineManager.FirmwareManager.Rpm32ThrRtIndex;
                    break;

                case RtType.Rpm32:
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmRt32Index;
                    break;

                case RtType.RpmGbc:
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmGbcRtIndex;
                    break;

                case RtType.RpmPress:
                    table.CurrentIndex = onlineManager.FirmwareManager.RpmPressRtIndex;
                    break;
            }
        }

        private void TableOnValueChanged(object sender, ValueChangeArgs e)
        {
            var ramAddress = captureAddress + e.Index;
            var bufferAddress = table.CalcAddress(e.Index);
            onlineManager.FirmwareManager.WriteRam(ramAddress, bufferAddress, table[e.Index], true);
        }

        private void FirmwareManagerOnOpenFirmware(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void SetEnabled()
        {
            var value = onlineManager.FirmwareManager.IsOpened && onlineManager.FirmwareManager.J7esFlags.IsRamCaptureSupport;
            if (Enabled == value) return;

            Enabled = value;
            DoEnabledChange(EventArgs.Empty);
        }

        private void DoEnabledChange(EventArgs e)
        {
            if (OnEnabledChange == null) return;
            OnEnabledChange(this, e);
        }

        public TableValues<byte, float> CapturedTable { get; private set; }

        public bool Enabled { get; private set; }

        public event EventHandler OnCaptureTable;
        public event EventHandler OnEnabledChange;

        public void CaptureTable(MapEntry entry, IWin32Window owner)
        {
            var FirmwareManager = onlineManager.FirmwareManager;
            this.owner = owner;            

            switch ((MapEntryType)entry.Type)
            {
                case MapEntryType.Entry2D:
                    var entry2D = entry.Entry2D;
                    exInfo = entry2D.Convert.ExInfo;
                    table.Address = (int) entry2D.Addr;
                    table.AxisX = FirmwareManager.GetAxis(entry2D);
                    table.AxisY = null;
                    var converter = Source2Value(entry2D);
                    FillMinMax(table, entry2D.Const_type);
                    table.Init(entry2D.xPoints, 1, converter,
                               Value2Source(entry2D.Convert, table.RawMin, table.RawMax), FirmwareManager.Buffer);                    
                    table.FirstInit();                    
                    table.FillValues();
                    OpenOltHelper.FillMinMax(table, entry2D);
                    break;

                case MapEntryType.Entry3D:
                    var entry3D = entry.Entry3D;
                    exInfo = entry3D.Convert.ExInfo;
                    table.Address = (int)entry3D.Addr;
                    table.AxisX = FirmwareManager.GetAxisX(entry3D);
                    table.AxisY = FirmwareManager.GetAxisY(entry3D);
                    var converter3D = Source2Value(entry3D);
                    FillMinMax(table, entry3D.Const_type);
                    table.Init(entry3D.xPoints, entry3D.zPoints, converter3D,
                               Value2Source(entry3D.Convert, table.RawMin, table.RawMax), FirmwareManager.Buffer);                    
                    table.FirstInit();                    
                    table.FillValues();
                    OpenOltHelper.FillMinMax(table, entry3D);
                    break;

                default:
                    throw new NotSupportedException();
            }

            table.Name = entry.Name;
            table.Tag = entry;            
            CapturedTable = table;
            rawBuffer = table.GetRawBuffer();
            using (var progress = ProgressForm.ShowProgress(owner))
            {
                onlineManager.OltProtocol.StopCapture();
                onlineManager.OltProtocol.WriteRam(captureAddress, rawBuffer, progress);
                onlineManager.OltProtocol.StartCapture(exInfo.CaptureRamId);
                progress.Close();
            }

            onlineManager.EnabledRamOnlineCorrection = CapturedTable.Address == FirmwareHelper.GbcAddr ||
                                                       CapturedTable.Address == FirmwareHelper.KGbcAddr || 
                                                       CapturedTable.Address == FirmwareHelper.KGbcJ7esDadAddr;

            DoCaptureTable(EventArgs.Empty);                       
        }

        public void ReturnTable()
        {
            CapturedTable = null;
            DoCaptureTable(EventArgs.Empty);
        }

        private void DoCaptureTable(EventArgs e)
        {
            if (OnCaptureTable == null) return;
            OnCaptureTable(this, e);
        }

        private static Func<byte, float> Source2Value(EntryBase entry)
        {
            var convertInfo = entry.Convert;
            
            switch (entry.Const_type)
            {
                case 0:                    
                    return source => (float) Math.Round((convertInfo.Inverted == 0.0
                                                             ? (source - convertInfo.Offset1)*convertInfo.Step/convertInfo.Div_step -
                                                               convertInfo.Offset2
                                                             : convertInfo.Inverted/(source*convertInfo.Div_step)), 2, MidpointRounding.AwayFromZero);
                case 1:                    
                    return source => (float)Math.Round((convertInfo.Inverted == 0.0
                                                            ? ((sbyte)source - convertInfo.Offset1) * convertInfo.Step / convertInfo.Div_step -
                                                              convertInfo.Offset2
                                                            : convertInfo.Inverted / ((sbyte)source * convertInfo.Div_step)), 2, MidpointRounding.AwayFromZero);
                default:
                    throw new NotSupportedException();
            }
        }

        private static Func<float, byte> Value2Source(ConvertInfo convertInfo, int min, int max)
        {
            return value => (byte) Math.Round(Math.Max(min, Math.Min(max, convertInfo.Inverted == 0
                                                                              ? (value + convertInfo.Offset2)*
                                                                                convertInfo.Div_step/convertInfo.Step +
                                                                                convertInfo.Offset1
                                                                              : convertInfo.Inverted/
                                                                                (value*convertInfo.Div_step))),
                                              MidpointRounding.AwayFromZero);
        }

        private static void FillMinMax(ITableValues table, int dataType)
        {
            switch (dataType)
            {
                case 0:
                    table.RawMin = 0;
                    table.RawMax = 255;
                    break;

                case 1:
                    table.RawMin = -128;
                    table.RawMax = 127;
                    break;

                default:
                    throw new NotSupportedException();
            }  
        }

        public void RestoreTable(IWin32Window owner)
        {
            if (CapturedTable == null) return;                        
            CapturedTable.SetRawBuffer(rawBuffer);
            CapturedTable.FirstInit();
            CapturedTable.FillValues();

            using (var progress = ProgressForm.ShowProgress(owner))
            {
                onlineManager.FirmwareManager.WriteRam(captureAddress, table.Address, rawBuffer);
                onlineManager.OltProtocol.StartCapture(exInfo.CaptureRamId);
                progress.Close();
            } 
        }
    }
}
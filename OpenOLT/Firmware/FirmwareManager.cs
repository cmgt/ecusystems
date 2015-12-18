using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CalibrTable;
using CtpMaps;
using CtpMaps.DataTypes;
using EcuCommunication.Protocols;
using Helper.ProgressDialog;
using OpenOltTypes;
using WidebandLambdaCommunication;
using DataHelper = Helper.DataHelper;

namespace OpenOLT.Firmware
{
    public class FirmwareManager: IFirmwareManager
    {
        public event EventHandler<AutoCorrectionEventArgs> AutoCorrection;
 
        private const int firmwareSize = 0x10000;
        private readonly OpenFileDialog openFileDialog;
        private readonly byte[] buffer = new byte[firmwareSize];
        public byte[] Buffer
        {
            get { return buffer; }
        }

        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public bool IsOpened { get; private set; }
        public bool IsFastRpm { get; private set; }
        private int[] rpmRt32 = new int[16];
        private int[] rpmRt16 = new int[32];
        private readonly int[] twatRt = new int[39];
        private readonly float[] rpm16_16RtPoints = new float[16 * 16];
        private readonly float[] rpm32_16RtPoints = new float[32 * 16];
        private readonly int[] gbcRt = new int[16];
        private readonly float[] gbcRtPoints = new float[256];
        private readonly int[] thrRt = new int[16];
        private readonly float[] thrRtPoints = new float[256];
        private readonly int[] pressRt = new int[16];

        private TableValues<byte, short> gbc;
        private TableValues<byte, float> kgbc;        
        private TableValues<byte, float> kgbc_press;        

        private readonly byte[] thrSampling = new byte[101];
        public float minGbc;
        public float stepGbc;
        private int rpmRtIndex;
        private int rpmRt32Index;
        private int thrRtIndex;
        private int rpmThrRtIndex;
        private int gbcRtIndex;
        private int rpmGbcRtIndex;
        private int rpm32ThrRtIndex;
        private int twatRtIndex;
        private int rpmPressRtIndex;
        private readonly OnlineManager onlineManager;
        private int stabylityCount;
        private int oldRpmThrRtIndex;

        public uint SWDigest { get; private set; }

        private FileStream firmwareFile;
        private float kmin, kmax;
        private byte[] rpmSampling;
        public J7esFlags J7esFlags { get; private set; }

        #region indexes
        public int TwatRtIndex
        {
            get { return twatRtIndex; }
            private set
            {
                if (twatRtIndex == value) return;
                twatRtIndex = value;
                OnPropertyChanged("TwatRtIndex");
            }
        }

        public int RpmRtIndex
        {
            get { return rpmRtIndex; }
            private set
            {
                if (rpmRtIndex == value) return;
                rpmRtIndex = value;
                OnPropertyChanged("RpmRtIndex");
            }
        }

        public int RpmRt32Index
        {
            get { return rpmRt32Index; }
            private set
            {
                if (rpmRt32Index == value) return;
                rpmRt32Index = value;
                OnPropertyChanged("RpmRt32Index");
            }
        }

        public int ThrRtIndex
        {
            get { return thrRtIndex; }
            private set
            {
                if (thrRtIndex == value) return;
                thrRtIndex = value;
                OnPropertyChanged("ThrRtIndex");
            }
        }

        public int RpmThrRtIndex
        {
            get { return rpmThrRtIndex; }
            private set
            {
                if (rpmThrRtIndex == value) return;
                rpmThrRtIndex = value;
                OnPropertyChanged("RpmThrRtIndex");
            }
        }

        public int GbcRtIndex
        {
            get { return gbcRtIndex; }
            private set
            {
                if (gbcRtIndex == value) return;
                gbcRtIndex = value;
                OnPropertyChanged("GbcRtIndex");
            }
        }

        public int RpmGbcRtIndex
        {
            get { return rpmGbcRtIndex; }
            private set
            {
                if (rpmGbcRtIndex == value) return;
                rpmGbcRtIndex = value;
                OnPropertyChanged("RpmGbcRtIndex");
            }
        }

        public int Rpm32ThrRtIndex
        {
            get { return rpm32ThrRtIndex; }
            private set
            {
                if (rpm32ThrRtIndex == value) return;
                rpm32ThrRtIndex = value;
                OnPropertyChanged("Rpm32ThrRtIndex");
            }
        }

        public int RpmPressRtIndex
        {
            get { return rpmPressRtIndex; }
            private set
            {
                if (rpmPressRtIndex == value) return;
                rpmPressRtIndex = value;
                OnPropertyChanged("RpmPressRtIndex");
            }
        }

        public TableValues<byte, short> Gbc
        {
            get { return gbc; }
        }

        public TableValues<byte, float> Kgbc
        {
            get { return kgbc; }
        }

        public int[] RpmRt32
        {
            get { return rpmRt32; }
        }

        public int[] RpmRt16
        {
            get { return rpmRt16; }
        }

        public int[] TwatRt
        {
            get { return twatRt; }
        }

        public int[] GbcRt
        {
            get { return gbcRt; }
        }

        public int[] ThrRt
        {
            get { return thrRt; }
        }

        public int[] PressRt
        {
            get { return pressRt; }
        }

        public float[] Rpm16_16RtPoints
        {
            get { return rpm16_16RtPoints; }
        }

        public float[] Rpm32_16RtPoints
        {
            get { return rpm32_16RtPoints; }
        }

        public float[] GbcRtPoints
        {
            get { return gbcRtPoints; }
        }

        public float[] ThrRtPoints
        {
            get { return thrRtPoints; }
        }

        #endregion

        public event EventHandler<EventArgs> OnOpenFirmware;
        public event EventHandler<EventArgs> OnCloseFirmware;

        private void DoOpenFirmware(EventArgs e)
        {
            if (OnOpenFirmware == null) return;
            OnOpenFirmware(this, e);
        }

        private void DoCloseFirmware(EventArgs e)
        {
            if (OnCloseFirmware == null) return;
            OnCloseFirmware(this, e);
        }

        public FirmwareManager(OnlineManager onlineManager)
        {
            J7esFlags = new J7esFlags();
            this.onlineManager = onlineManager;
            Name = String.Empty;
            //var path = Application.StartupPath + @"\firmwares";
            openFileDialog = new OpenFileDialog
                                 {
                                     Filter = "firmware files|*.bir;*.bin|all files|*.*"
                                 };            
            kmin = 0.4f;
            kmax = 1.98f;
        }

        private void GBCOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Table") return;
            var address = gbc.Address;
            var tablebuffer = gbc.GetRawBuffer();
            WriteRam(address, address, tablebuffer);
        }

        private void KGBOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Table") return;
            var address = kgbc.Address;
            var tablebuffer = kgbc.GetRawBuffer();
            WriteRam(address, address, tablebuffer);
        }        

        public bool OpenDialog(IWin32Window owner)
        {                                    
            if (openFileDialog.ShowDialog(owner) != DialogResult.OK) return false;

            var path = openFileDialog.FileName;
            
            return Open(path, true, owner);
        }

        public bool Open(string path, bool showMessage = false, IWin32Window owner = null)
        {
            if (String.IsNullOrEmpty(path)) return false;
            
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                if (showMessage)
                    MessageBox.Show(owner, String.Format("Файл прошивки {0} не найден", path));
                return false;
            }

            if (fileInfo.Length != firmwareSize && !MapDataHelper.UnpackCtpFirmware(fileInfo, showMessage, owner))
            {
                return false;
            }

            OpenFirmwareFile(path);            
            return true;
        }

        public void Close()
        {
            CloseFirmwareFile();
        }

        private void OpenFirmwareFile(string path)
        {
            CloseFirmwareFile();

            firmwareFile = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            firmwareFile.Read(buffer, 0, firmwareSize);           
            FilePath = path;
            Name = Path.GetFileName(path);
            Prepare();
            IsOpened = true;

            onlineManager.settings.LastFirmwarePath = FilePath;

            DoOpenFirmware(EventArgs.Empty);
        }

        private void CloseFirmwareFile()
        {
            if (firmwareFile == null) return;
            firmwareFile.Flush(true);
            firmwareFile.Close();
            firmwareFile = null;
            DoCloseFirmware(EventArgs.Empty);
        }

        private void SaveToFile()
        {
            firmwareFile.Seek(0, SeekOrigin.Begin);
            firmwareFile.Write(buffer, 0, firmwareSize);
            firmwareFile.Flush();
        }

        private void Prepare()
        {
            SWDigest = DataHelper.CalculateCRC(buffer, 0, 0xB0);            
            IsFastRpm = DataHelper.IndexOf(buffer, new byte[] {0x90, 0x61, 0x3C, 0xE5, 0x55}) != -1;

            J7esFlags.Prepare(buffer);

            if (J7esFlags.IsDadMode && !J7esFlags.IsCommonKGBCTable)
                kgbc.Address = FirmwareHelper.KGbcJ7esDadAddr;

            FirmwareHelper.FillRpmRT(buffer, out rpmSampling, out rpmRt32, out rpmRt16);            
            FillThrRT();
            FillGbcRT();
            FillTWatRT();
            FillPressRT();

            FillPoints();

            FillGbc();
            FillKGbc();
            FillKGbcPress();            
        }

        private void FillPressRT()
        {
            var minPress = (buffer[FirmwareHelper.MinPressAddr] | (buffer[FirmwareHelper.MinPressAddr + 1] << 8))/6.0;
            var rangePress = 82485.0 / (buffer[FirmwareHelper.RangePressAddr] == 0 ? 1 : buffer[FirmwareHelper.RangePressAddr]);
            var stepPress = rangePress / (pressRt.Length - 1);

            for (var i = 0; i < pressRt.Length; i++)
            {
                pressRt[i] = (int)Math.Round(minPress + stepPress * i, MidpointRounding.AwayFromZero);
            }  
        }

        private void FillTWatRT()
        {
            var min = -40;
            var max = 150;
            var count = twatRt.Length;

            var step = (max - min)/(count - 1);
            
            for (int i = 0; i < count; i++)
            {
                twatRt[i] = min;
                min += step;
            }
        }

        private void FillPoints()
        {
            var index = 0;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    rpm16_16RtPoints[index] = j;// rpmRt32[j];
                    thrRtPoints[index] = i;// thrRt[i];
                    gbcRtPoints[index++] = i;// gbcRt[i];
                }
            }

            index = 0;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    rpm32_16RtPoints[index++] = j;// rpmRt32[j];
                }
            }
        }

        private void FillKGbc()
        {
            var colCount = J7esFlags.IsKgbc32_16 ? 32 : 16;
            kgbc = new TableValues<byte, float>(FirmwareHelper.KGbcAddr, colCount, 16,
                                                                            source =>
                                                                            (float)
                                                                            Math.Round(source/128f, 2,
                                                                                       MidpointRounding.AwayFromZero),
                                                                            value =>
                                                                            (byte)
                                                                            Math.Round((value > 1.992f ? 1.992f : value)*128f,
                                                                                       MidpointRounding.AwayFromZero));

            InitTable(kgbc, buffer);
            kgbc.PropertyChanged += KGBOnPropertyChanged;            
        }

        private void FillKGbcPress()
        {
            var colCount = J7esFlags.IsKgbcPress32_32 ? 32 : 16;
            var rowCount = colCount;

            kgbc_press = new TableValues<byte, float>(FirmwareHelper.KGbcPressAddr, colCount, rowCount,
                                                                            source =>
                                                                            (float)
                                                                            Math.Round(source / 128f, 2,
                                                                                       MidpointRounding.AwayFromZero),
                                                                            value =>
                                                                            (byte)
                                                                            Math.Round((value > 1.992f ? 1.992f : value) * 128f,
                                                                                       MidpointRounding.AwayFromZero));

            InitTable(kgbc_press, buffer);
        }

        private void FillGbc()
        {
            gbc = new TableValues<byte, short>(FirmwareHelper.GbcAddr, 16, 16,
                source =>
                    (short)
                        (Math.Round(source*8f/3f,
                            MidpointRounding.AwayFromZero)),
                value =>
                    (byte)
                        Math.Round(value*3f/8f,
                            MidpointRounding.AwayFromZero));

            InitTable(gbc, buffer);
            gbc.PropertyChanged += GBCOnPropertyChanged;
        }

        private void InitTable(ITableValues table, byte[] source)
        {
            var index = table.Address;

            for (int i = 0; i < table.RowCount; i++)
            {
                for (int j = 0; j < table.ColCount; j++)
                {
                    table.SetRawValue(j, i, source[index++]);
                }
            }

            table.FirstInit();
            table.FillValues();
        }

        private void FillGbcRT()
        {
            minGbc = buffer[FirmwareHelper.MinGbcAddr]/6f;
            var stepK = buffer[FirmwareHelper.StepGbcAddr];
            if (stepK == 0) stepK = 195;
            stepGbc = 341.13f/stepK;

            for (var i = 0; i < gbcRt.Length; i++)
            {
                gbcRt[i] = (int) (minGbc + stepGbc*i*16);
            }            
        }

        private void FillThrRT()
        {
            System.Buffer.BlockCopy(buffer, FirmwareHelper.ThrSamplingAddr, thrSampling, 0, thrSampling.Length);

            var index = 0;
            var value = index * 16;
            for (var i = 0; i < thrSampling.Length; i++)
            {
                var delta = thrSampling[i] - value;

                if (index == 0)
                {
                    if (delta <= 0) continue;
                    thrRt[index] = Math.Max(i - 1, 0);
                }
                else
                {
                    if (delta < 0) continue;
                    thrRt[index] = i;
                }

                index++;
                if (index == 16) break;
                value = index * 16;
            }
        }        

        private void CalcCurrentRT(DiagData diagData)
        {                                                            
            oldRpmThrRtIndex = RpmThrRtIndex;

            var j7esDiag = diagData as J7esDiagData;

            if (j7esDiag != null && j7esDiag.RPM_RT != 0)
            {
                ThrRtIndex = j7esDiag.THR_RT_16;
                GbcRtIndex = j7esDiag.GBC_RT_16;
                RpmRtIndex = j7esDiag.RPM_RT_16;
                RpmRt32Index = DataHelper.rl(DataHelper.Swap((byte) (j7esDiag.RPM_RT + 4))) & 0x1F;
                TwatRtIndex = j7esDiag.TWAT_RT;
                RpmThrRtIndex = j7esDiag.RPM_THR_RT;
                RpmPressRtIndex = (((byte) (j7esDiag.PRESS_RT + 8)) & 0xF0) + RpmRtIndex;                
            }
            else
            {
                ThrRtIndex = DataHelper.Swap((byte)(thrSampling[Math.Min(diagData.TRT, thrSampling.Length - 1)] + 8)) & 0xF;
                GbcRtIndex = DataHelper.NearCell(gbcRt, (int)Math.Round(diagData.GBC, MidpointRounding.AwayFromZero));
                RpmRtIndex = DataHelper.NearCell(rpmRt32, diagData.RPM);
                RpmRt32Index = DataHelper.NearCell(rpmRt16, diagData.RPM);
                TwatRtIndex = DataHelper.NearCell(twatRt, diagData.TWAT);
                RpmThrRtIndex = 16 * ThrRtIndex + RpmRtIndex;
            }

            Rpm32ThrRtIndex = 32 * ThrRtIndex + RpmRt32Index;
            RpmGbcRtIndex = onlineManager.OltProtocol.Version == OltProtocolVersion.OltDiagV1
                                ? diagData.RPM_GBC_RT
                                : 16*GbcRtIndex + RpmRtIndex;
        }        

        private void PrepareFuelCutoff()
        {            
            PrepareFuelCutoff(onlineManager.settings.DisabledTHRZeroFuelCutoff);
        }

        private void PrepareFuelCutoff(bool value)
        {
            var options = buffer[0x6051];
            //bit06 - признак постоянного включения топлива
            if (DataHelper.IsBitSet(options, 6) == value) return;
            DataHelper.BitSet(ref options, 6, value);
            onlineManager.OltProtocol.WriteRam(0x6051, new[] { options });
            buffer[0x6051] = options;
        }

        public void Add(DiagData diagData)
        {
            if (!IsOpened) return; 
            CalcCurrentRT(diagData);

            if (!onlineManager.EnabledOnlineCorrection) return;

            PrepareFuelCutoff();
            if (!TestStability(diagData)) return;

            var cellIndex = J7esFlags.IsKgbc32_16 ? Rpm32ThrRtIndex : RpmThrRtIndex;
            var cell = kgbc.Cell(cellIndex);
            if (!cell.StopStudy)
            {
                FuelCorrection(cellIndex, diagData);
            }

            if (onlineManager.settings.EnabledGBCCorrection && (!onlineManager.settings.TestAfrBeforeGBCCorrection || cell.StopStudy))
                AirCorrection(diagData);
        }

        private bool TestStability(DiagData diagData)
        {
            var stability = oldRpmThrRtIndex == RpmThrRtIndex && Math.Abs(diagData.DGTC_LEAN) < Single.Epsilon && Math.Abs(diagData.DGTC_RICH) < Single.Epsilon;

            if (!stability)
            {
                if (stabylityCount > 0)
                    stabylityCount = 0;
                return false;
            }

            stabylityCount++;
            return stabylityCount >= onlineManager.settings.FuelRtStability;
        }

        private void AirCorrection(DiagData diagData)
        {
            if (!TestAirCorrectionAvailable(diagData)) return;
            GBCCorrection(diagData);
            stabylityCount = -2;
        }

        private bool TestAirCorrectionAvailable(DiagData diagData)
        {
            return diagData.COEFF > 0.98f && diagData.COEFF < 1.02f;
        }

        private void FuelCorrection(int cellIndex, DiagData diagData)
        {
            if (!TestFuelCorrectionAvailable(diagData)) return;
            KGBCCorrection(cellIndex, diagData);
            stabylityCount = -2;
        }

        private bool TestFuelCorrectionAvailable(DiagData diagData)
        {
            //var errorFound = diagData.IsErrorFound;
            var thrThreshold = diagData.TRT >= onlineManager.settings.THRThresholdLineFuelCorrection;            
            var lambdaAvailable = onlineManager.LambdaAdapter.Connected && onlineManager.LambdaAdapter.Available && onlineManager.LambdaAdapter.State == LambdaState.LambdaValue;

            return /*errorFound &&*/ thrThreshold && lambdaAvailable;
        }

        private void KGBCCorrection(int cellIndex, DiagData diagData)
        {
            var cell = kgbc.Cell(cellIndex);
            //var k1 = kgbc.GetValue(cellIndex);
            var k1 = cell.StudyValue;
            var alf1 = diagData.ALF;
            var alf2 = diagData.LC1_ALF;
            var k2 = alf2*k1/alf1;

            var e = k2 - k1;
            
            cell.Error = e;
            cell.Tag = Math.Abs(e) < 0.02 ? Math.Max(5, cell.Tag + 1) : Math.Min(0, cell.Tag - 1);

            cell.StopStudy = cell.Tag > 4;
            if (cell.StopStudy) return;
            
            var e_1 = cell.E_1;
            var e_2 = cell.E_2;

            var Kp = onlineManager.settings.DisableFuelCorrectionProportional
                         ? 0f
                         : onlineManager.settings.FuelCorrectionProportional/100f;
            var Kd = onlineManager.settings.FuelCorrectionDifferential / 100f;
            var Ki = onlineManager.settings.FuelCorrectionIntegral / 100f;

            var pV = Kp*(e - e_1);
            var iV = Ki*e;
            var dV = Kd*(e - 2*e_1 + e_2);

            var k_new = k1 + pV + iV + dV;
            cell.StudyValue = k_new;

            var k_new_lim = Math.Max(kmin, Math.Min(kmax, k_new));
            kgbc.SetValue(cellIndex, k_new_lim);
            WriteKGBCValue(cellIndex);
            onlineManager.OltProtocol.OperationLog.AppendLine(String.Format("kgbc: {0} {1} {2} {3} {4} {5}|{6}|{7}",
                                                                        cellIndex, k1.ToString("0.##"),
                                                                        k2.ToString("0.##"), e.ToString("0.##"),
                                                                        k_new.ToString("0.##"), pV.ToString("0.##"),
                                                                        iV.ToString("0.##"), dV.ToString("0.##")));            
        }

        public void WriteKGBCValue(int index)
        {            
            var source = kgbc[index];
            var e = new AutoCorrectionEventArgs(kgbc.Address, index, source);
            OnAutoCorrection(e);
            if (e.Cancel) return;

            var address = kgbc.CalcAddress(index);
            WriteRam(address, address, source);
        }

        private void OnAutoCorrection(AutoCorrectionEventArgs e)
        {
            var handler = AutoCorrection;
            if (handler == null) return;
            handler(this, e);
        }

        private void GBCCorrection(DiagData diagData)
        {
            var cell = this.gbc.Cell(RpmThrRtIndex);
            var real_gbc = diagData.GBC;
            var gbc = this.gbc.GetValue(RpmThrRtIndex);            
            var e = real_gbc - gbc;

            cell.Error = (short) e;
            var e_1 = cell.E_1;
            var e_2 = cell.E_2;

            var Kp = onlineManager.settings.DisableFuelCorrectionProportional
                         ? 0f
                         : onlineManager.settings.FuelCorrectionProportional / 100f;
            var Kd = onlineManager.settings.FuelCorrectionDifferential / 100f;
            var Ki = onlineManager.settings.FuelCorrectionIntegral / 100f;

            var pV = Kp * (e - e_1);
            var iV = Ki * e;
            var dV = Kd * (e - 2 * e_1 + e_2);

            var new_gbc = gbc + pV + iV + dV;
            this.gbc.SetValue(RpmThrRtIndex,  (short) new_gbc);
            WriteGBCValue(RpmThrRtIndex);
            onlineManager.OltProtocol.OperationLog.AppendLine(String.Format("gbc: {0} {1} {2} {3}|{4}|{5} {6} {7}|{8}|{9}",
                                                                        RpmThrRtIndex, real_gbc.ToString("0.##"),
                                                                        gbc.ToString("0.##"), e.ToString("0.##"), e_1.ToString("0.##"), e_2.ToString("0.##"),
                                                                        new_gbc.ToString("0.##"), pV.ToString("0.##"),
                                                                        iV.ToString("0.##"), dV.ToString("0.##")));            
        }

        public void WriteGBCValue(int index)
        {           
            var source = gbc[index];
            var e = new AutoCorrectionEventArgs(gbc.Address, index, source);
            OnAutoCorrection(e);
            if (e.Cancel) return;

            var address = gbc.CalcAddress(index);
            WriteRam(address, address, source);
        }

        public void WriteRam(int ramAddres, int bufferAddress, byte source, bool async = false)
        {
            onlineManager.OltProtocol.WriteRam(ramAddres, new[] { source }, async: async);
            buffer[bufferAddress] = source;
            SaveToFile();
        }

        public void WriteRam(int ramAddres, int bufferAddress, byte[] source, IProgress progress = null, bool async = false)
        {
            if (onlineManager.OltProtocol.IsSupportOnlineCorrection)
            {
                onlineManager.OltProtocol.WriteRam(ramAddres, source, progress, async);
            }

            System.Buffer.BlockCopy(source, 0, buffer, bufferAddress, source.Length);
            SaveToFile();
        }

        public float[] GetAxis(Entry2D entry2D)
        {
            return GetAxis(entry2D.xTable, entry2D.xStart, entry2D.xEnd, entry2D.xPoints);
        }

        public float[] GetAxisX(Entry3D entry3D)
        {
            return GetAxis(entry3D.xTable, entry3D.xStart, entry3D.xEnd, entry3D.xPoints);
        }

        public float[] GetAxisY(Entry3D entry3D)
        {
            return GetAxis(entry3D.zTable, entry3D.zStart, entry3D.zEnd, entry3D.zPoints);
        }

        public float[] GetAxis(string name, double start, double end, int count)
        {
            switch (name)
            {
                case "!001-613C-40":
                    return (from item in rpmRt16 select (float)item).ToArray();

                case "!002-613C-40":
                    return (from item in rpmRt32 select (float)item).ToArray();

                case "!004-6064-6066":
                    return (from item in gbcRt select (float)item).ToArray();

                case "!006-7208":
                    return (from item in thrRt select (float)item).ToArray();

                case "!004-5EF2-5EF4":
                    return (from item in pressRt select (float)item).ToArray();
                    
                case "":
                    var step = (end - start) / (count - 1);
                    return
                        Enumerable.Range(0, count).Select(
                            index =>
                            (float)
                            Math.Round(start + step*index, 2, MidpointRounding.AwayFromZero)).ToArray();

                default:
                    return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

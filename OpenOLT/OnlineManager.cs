using System;
using System.IO;
using System.Windows.Forms;
using EcuCommunication.Protocols;
using Helper.ProgressDialog;
using OpenOLT.Firmware;
using OpenOltTypes;
using WidebandLambdaCommunication;

namespace OpenOLT
{
    public class OnlineManager: IOnlineManager
    {
        internal readonly Settings settings;
        internal readonly DataLogger dataLogger;
        internal readonly DiagDataKeeper dataKeeper;

        public IFirmwareManager FirmwareManager
        {
            get { return firmwareManager; }
        }

        public OltProtocol OltProtocol { get; private set; }
        public LambdaAdapter LambdaAdapter { get; private set; }
        private readonly FirmwareManager firmwareManager;

        public OnlineManager(OltProtocol oltProtocol, LambdaAdapter lambdaAdapter)
        {
            settings = new Settings();            
            settings.LoadFromFile();
            dataLogger = new DataLogger();
            dataKeeper = new DiagDataKeeper();
            dataKeeper.LoadSettings(Settings.settingsKeeper);
            firmwareManager = new FirmwareManager(this);            
            this.OltProtocol = oltProtocol;
            this.LambdaAdapter = lambdaAdapter;

            if (settings.AutoLoadLastFirmware)            
                firmwareManager.Open(settings.LastFirmwarePath);            
            
            oltProtocol.OnDiagUpdate += oltProtocol_OnDiagUpdate;
            oltProtocol.OnConnect += oltProtocol_OnConnect;
            oltProtocol.OnDisconnect += oltProtocol_OnDisconnect;
        }

        void oltProtocol_OnDisconnect(object sender, EventArgs e)
        {
            dataLogger.Flush();
            
            var basePath = Application.StartupPath + @"\trace\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var fileName = String.Format("oplog_{0}_{1}.txt", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss"));
            var filePath = basePath + fileName;
            File.WriteAllText(filePath, OltProtocol.OperationLog.ToString());
        }

        public bool EnabledOnlineCorrection { get; set; }
        public bool EnabledRamOnlineCorrection { get; set; }

        private void oltProtocol_OnConnect(object sender, EventArgs e)
        {
            dataKeeper.diagDataList.Clear();
        }

        private void oltProtocol_OnDiagUpdate(object sender, EventArgs e)
        {
            var diagData = OltProtocol.GetDiagData();
            diagData.LC1_AFR = LambdaAdapter.AFR;
            diagData.LC1_ALF = LambdaAdapter.Lambda;

            dataKeeper.diagDataList.Add(diagData);
            dataLogger.WriteData(diagData);
            firmwareManager.Add(diagData);
            if (OltProtocol.IsEcuErrorFound && settings.AutoClearErrors)
                OltProtocol.ClearErrors();
        }

        public void Close()
        {
            dataLogger.Close();
            firmwareManager.Close();
        }

        public void InitFirmware(IWin32Window owner)
        {
            if (!OltProtocol.Connected || !OltProtocol.IsOnline) return;

            switch (settings.LoadFirmwareToEcuType)
            {
                case LoadFirmwareToEcuType.FullLoad:
                    OltProtocol.WriteFirmware(owner, firmwareManager.Buffer);
                    break;

                case LoadFirmwareToEcuType.OnlyCorrectionTable:
                    WriteCorrectionTable(owner);
                    break;
            }
        }

        private void WriteCorrectionTable(IWin32Window owner)
        {
            using (var progress = ProgressForm.ShowProgress(owner))
            {
                progress.Message = "Загрузка калибровок";                
                OltProtocol.WriteRam(firmwareManager.Kgbc.Address, firmwareManager.Kgbc.GetRawBuffer());
                progress.IterationComplete(this, 50, 100);
                OltProtocol.WriteRam(firmwareManager.Kgbc_press.Address, firmwareManager.Kgbc_press.GetRawBuffer());
                progress.IterationComplete(this, 50, 100);
                OltProtocol.WriteRam(firmwareManager.Gbc.Address, firmwareManager.Gbc.GetRawBuffer());
                progress.IterationComplete(this, 100, 100);
                progress.Close();
            }
        }
    }
}

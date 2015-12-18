using System;
using System.Windows.Forms;
using EcuCommunication.Protocols;
using OpenOltTypes;

namespace IoControlPlugin
{
    internal partial class IoControlPanel : UserControl
    {
        private IoControlManager ioControlManager;
        private IOnlineManager onlineManager;

        public IoControlPanel()
        {
            InitializeComponent();
        }

        public void Prepare(IoControlManager ioControlManager)
        {
            this.ioControlManager = ioControlManager;
            onlineManager = ioControlManager.appHost.GetOnlineManager();
            onlineManager.OltProtocol.OnConnect += OltProtocolOnConnectDisconnect;
            onlineManager.OltProtocol.OnDisconnect += OltProtocolOnConnectDisconnect;
        }

        private void OltProtocolOnConnectDisconnect(object sender, EventArgs eventArgs)
        {
            Enabled = onlineManager.OltProtocol.Connected;
        }

        private void ioControl1_ActiveChanging(object sender, EventArgs e)
        {
            IoControl control;
            IoControlType ioControlType;
            if (!GetIoControlType(sender, out control, out ioControlType)) return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (!control.Active)
                {
                    byte rawValue;
                    if (!GetRawValue(control, ioControlType, out rawValue)) return;
                    var res = onlineManager.OltProtocol.StartIoControl(ioControlType, rawValue);
                    control.Active = res;
                }
                else
                {
                    onlineManager.OltProtocol.StopIoControl(ioControlType);
                    control.Active = false;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool GetRawValue(IoControl control, IoControlType ioControlType, out byte rawValue)
        {
            rawValue = 0;
            var value = control.GetCurrentvalue();
            if (!value.Item1) return false;
            var phisvalue = value.Item3;

            switch (ioControlType)
            {
                case IoControlType.RxxStep:
                    rawValue = (byte) Math.Round(phisvalue, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.XxRpm:
                    rawValue = (byte) Math.Round(phisvalue / 10, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.Alf:
                    rawValue = (byte) Math.Round(phisvalue * 256 / 14.7 - 128, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.Uoz:
                    rawValue = (byte)Math.Round(phisvalue * 2, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.Duoz:
                    rawValue = (byte)Math.Round(phisvalue, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.Faza:
                    rawValue = (byte)Math.Round(phisvalue / 6, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.InjCoeff:
                    rawValue = (byte)Math.Round(phisvalue * 256 - 128, MidpointRounding.AwayFromZero);
                    break;

                case IoControlType.Twat:
                    rawValue = (byte)Math.Round(phisvalue + 60, MidpointRounding.AwayFromZero);
                    break;
            }
            
            return true;
        }

        private static bool GetIoControlType(object sender, out IoControl control, out IoControlType ioControlType)
        {
            control = sender as IoControl;
            ioControlType = IoControlType.Unknown;
            var ioControlTypeStr = control != null && control.Tag != null ? control.Tag.ToString() : null;
            return !String.IsNullOrEmpty(ioControlTypeStr) && Enum.TryParse(ioControlTypeStr, true, out ioControlType);
        }

        private void ioControl1_CurrentValueChange(object sender, EventArgs e)
        {
            IoControl control;
            IoControlType ioControlType;
            if (!GetIoControlType(sender, out control, out ioControlType) || !control.Active) return;

            byte rawValue;
            if (!GetRawValue(control, ioControlType, out rawValue)) return;

            onlineManager.OltProtocol.SetIoControlValue(ioControlType, rawValue);
        }

        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            foreach (var item in Controls)
            {
                IoControl control;
                IoControlType ioControlType;
                if (!GetIoControlType(item, out control, out ioControlType) || !control.Active) continue;
                control.Active = false;
                onlineManager.OltProtocol.StopIoControl(ioControlType);
            }            

            Cursor.Current = Cursors.Default;
        }
    }
}

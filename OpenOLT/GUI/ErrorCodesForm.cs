using System;
using System.Windows.Forms;
using EcuCommunication;
using EcuCommunication.Protocols;

namespace OpenOLT.GUI
{
    internal partial class ErrorCodesForm : Form
    {
        private static bool isShow;
        private OltProtocol oltProtocol;

        private ErrorCodesForm()
        {
            InitializeComponent();
        }

        public static void ShowErrors(IWin32Window owner, OltProtocol oltProtocol)
        {
            if (isShow) return;

            var ef = new ErrorCodesForm();
            ef.Prepare(oltProtocol);
            ef.Show(owner);

            isShow = true;
        }

        private void Prepare(OltProtocol oltProtocol)
        {
            this.oltProtocol = oltProtocol;
            var errors = oltProtocol.ReadErrors().ToArray();
            var errorStatus = ECUErrorFactory.DecodingErrorStatus(oltProtocol.GetDiagData().ErrorStatus);

            savedError.Items.Clear();
            savedError.Items.AddRange(errors);
            activeError.Items.Clear();
            activeError.Items.AddRange(errorStatus);
        }

        private void ErrorCodesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isShow = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oltProtocol.ClearErrors();
            Prepare(oltProtocol);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prepare(oltProtocol);
        }
    }
}

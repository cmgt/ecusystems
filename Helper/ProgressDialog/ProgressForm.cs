using System;
using System.Windows.Forms;

namespace Helper.ProgressDialog
{
    public partial class ProgressForm : Form, IProgress
    {
        private static ProgressForm instance;

        private ProgressForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }
        
        public bool Cancel { get; private set; }
        public string Message
        {
            get { return messageLabel.Text; }
            set { messageLabel.Text = value; }
        }

        public void IterationComplete(object state, int current, int count)
        {
            progress.Value = current;
            progress.Maximum = count;
            messageLabel.Text = String.Format("{0} из {1}", current, count);
            progress.Refresh();        
            Application.DoEvents();
        }

        public static IProgress ShowProgress(IWin32Window owner)
        {
            if (instance == null)
            {
                instance = new ProgressForm();
            }

            instance.Show(owner);

            return instance;
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }        
    }
}

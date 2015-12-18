using System;
using System.Windows.Forms;

namespace KWPTest
{
    public partial class ReverseProtocolForm : Form
    {
        private static bool isShow;

        public ReverseProtocolForm()
        {
            InitializeComponent();
            dataGrid.RowHeadersWidth = 50;
        }

        public static void ShowForm(IWin32Window owner)
        {
            if (isShow) return;

            var rf = new ReverseProtocolForm();
            rf.Show(owner);
            isShow = true;
            rf.button1.PerformClick();
            rf.reverseEnabled.Checked = true;
        }

        private void ReverseProtocolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isShow = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(answerBytesCount.Text, out count)) return;
            var fill = count - dataGrid.RowCount;
            dataGrid.RowCount = count;

            for (int i = 0; i < fill; i++)
            {
                dataGrid.Rows[count - fill + i].Cells[0].Value = "00";
            }

            InitGridHeader();
        }

        private void InitGridHeader()
        {            
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                dataGrid.Rows[i].HeaderCell.Value = i.ToString();                
            }
        }

        private void reverseEnabled_CheckedChanged(object sender, EventArgs e)
        {            
            ReverseData.instance.Enabled = reverseEnabled.Checked;            
            if (ReverseData.instance.Enabled)
                PrepareReverceData();
        }

        private void PrepareReverceData()
        {
            var rd = ReverseData.instance;

            rd.RequestHeader = requestHeader.Text;
            rd.AnswerHeader = answerHeader.Text;
            var answerData = String.Empty;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                answerData += row.Cells[0].Value.ToString();
            }
            rd.AnswerData = answerData;
            rd.Prepare();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrepareReverceData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Cells[0].Value = "00";
            }

            PrepareReverceData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Cells[0].Value = "FF";
            }

            PrepareReverceData();
        }
    }
}

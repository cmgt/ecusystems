using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KWPTest
{
    public partial class CommonDiagForm : Form
    {
        private readonly CommonDiagParams commonDiagParams;

        public CommonDiagForm(CommonDiagParams commonDiagParams)
        {
            this.commonDiagParams = commonDiagParams;
            InitializeComponent();
        }

        private void OltDiagForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private void ParamsApply()
        {
            commonDiagParams.bytes[0] = byte0.Value;
            commonDiagParams.bytes[1] = byte1.Value;
            commonDiagParams.bytes[2] = byte2.Value;
            commonDiagParams.bytes[3] = byte3.Value;
            commonDiagParams.bytes[4] = byte4.Value;
            commonDiagParams.bytes[5] = byte5.Value;
            commonDiagParams.bytes[6] = byte6.Value;
            commonDiagParams.bytes[7] = byte7.Value;

            foreach (Control control in Controls)
            {
                if (control.Tag == null) continue;

                if (control is IByteSetter)
                {
                    var index = Convert.ToInt32(control.Tag);
                    commonDiagParams.bytes[index] = ((IByteSetter)control).Value;
                }
                else if (control is IWordSetter)
                {
                    var index = Convert.ToInt32(control.Tag);
                    commonDiagParams.bytes[index] = ((IWordSetter)control).Byte1;
                    commonDiagParams.bytes[index + 1] = ((IWordSetter)control).Byte2;
                }
            }
        }

        private void byte_OnValueChange(object sender, EventArgs e)
        {
            ParamsApply();
        }
    }
}

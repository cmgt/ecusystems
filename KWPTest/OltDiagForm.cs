using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KWPTest
{
    public partial class OltDiagForm : Form
    {
        private readonly OltDiagParams diagParams;

        public OltDiagForm(OltDiagParams diagParams)
        {
            this.diagParams = diagParams;
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
            diagParams.bytes[0] = byte0.Value;
            diagParams.bytes[1] = byte1.Value;

            foreach (Control control in Controls)
            {
                if (control.Tag == null) continue;

                if (control is IByteSetter)
                {
                    var index = Convert.ToInt32(control.Tag);
                    diagParams.bytes[index] = ((IByteSetter) control).Value;
                }
                else if (control is IWordSetter)
                {
                    var index = Convert.ToInt32(control.Tag);
                    diagParams.bytes[index] = ((IWordSetter)control).Byte1;
                    diagParams.bytes[index + 1] = ((IWordSetter)control).Byte2;
                }
            }
        }

        private void bytes_OnValueChange(object sender, EventArgs e)
        {
            ParamsApply();
        }

        private void word_OnValueChange(object sender, EventArgs e)
        {
            ParamsApply();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KWPTest
{
    public partial class ByteSetter : UserControl, IByteSetter
    {        
        public byte Value
        {
            get
            {
                byte value;
                try
                {
                    value = Convert.ToByte(byteValue.Text, 16);
                }
                catch
                {
                    value = 0;
                }

                return value;
            }
            set 
            {
                byteValue.Text = value.ToString("X2");
            }
        }

        public event EventHandler OnValueChange;

        public string ByteDescription { get { return byteDescription.Text; } set { byteDescription.Text = value; } }

        public ByteSetter()
        {
            InitializeComponent();
        }

        private void DoValueChange(EventArgs e)
        {
            var vc = OnValueChange;
            if (vc != null)
                vc(this, e);
        }

        private void byteValue_TextChanged(object sender, EventArgs e)
        {
            DoValueChange(EventArgs.Empty);
        }

        private void ByteSetter_DoubleClick(object sender, EventArgs e)
        {
            byteValue.Text = "00";
        }
    }
}

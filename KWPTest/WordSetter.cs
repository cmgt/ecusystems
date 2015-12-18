using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KWPTest
{
    public partial class WordSetter : UserControl, IWordSetter
    {
        public WordSetter()
        {
            InitializeComponent();
        }

        public ushort Value
        {
            get
            {
                ushort value;
                try
                {
                    value = Convert.ToUInt16(byteValue.Text, 16);
                }
                catch
                {
                    value = 0;
                }

                return value;
            }
            set 
            {
                byteValue.Text = value.ToString("X4");
            }
        }

        public byte Byte1
        {
            get { return (byte) (Value & 0xFF); }
        }

        public byte Byte2
        {
            get { return (byte) ((Value & 0xFF00) >> 8); }
        }

        public event EventHandler OnValueChange;

        public string ByteDescription { get { return byteDescription.Text; } set { byteDescription.Text = value; } }

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
            byteValue.Text = "0000";
        }
    }
}

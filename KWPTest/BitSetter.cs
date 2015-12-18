using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Helper;

namespace KWPTest
{
    public partial class BitSetter : UserControl, IByteSetter
    {
        private byte value;
        public byte Value
        {
            get
            {
                GetValue();
                return value;
            }
            set
            {
                if (this.value == value) return;
                this.value = value;
                SetValue();
            }
        }

        public event EventHandler OnValueChange;

        public string ByteDescription { get { return byteDescription.Text; } set { byteDescription.Text = value; } }

        private string[] toolTips;
        public string[] ToolTips
        {
            get { return toolTips; }
            set
            {
                toolTips = value;
                SetToolTips();
            }
        }

        private void SetToolTips()
        {
            if (toolTips == null) return;

            for (int i = 0; i < 8; i++)
            {
                if (toolTips.Length <= i) return;
                var control = bitPanel.Controls["label" + (i + 1)];
                control.Text = toolTips[i];
            }
        }



        private void SetValue()
        {
            bit0.Checked = DataHelper.IsBitSet(value, 0);
            bit1.Checked = DataHelper.IsBitSet(value, 1);
            bit2.Checked = DataHelper.IsBitSet(value, 2);
            bit3.Checked = DataHelper.IsBitSet(value, 3);
            bit4.Checked = DataHelper.IsBitSet(value, 4);
            bit5.Checked = DataHelper.IsBitSet(value, 5);
            bit6.Checked = DataHelper.IsBitSet(value, 6);
            bit7.Checked = DataHelper.IsBitSet(value, 7);
        }

        private void GetValue()
        {
            value = 0;
            DataHelper.BitSet(ref value, 0, bit0.Checked);
            DataHelper.BitSet(ref value, 1, bit1.Checked);
            DataHelper.BitSet(ref value, 2, bit2.Checked);
            DataHelper.BitSet(ref value, 3, bit3.Checked);
            DataHelper.BitSet(ref value, 4, bit4.Checked);
            DataHelper.BitSet(ref value, 5, bit5.Checked);
            DataHelper.BitSet(ref value, 6, bit6.Checked);
            DataHelper.BitSet(ref value, 7, bit7.Checked);
        }

        private void DoValueChange(EventArgs e)
        {
            var vc = OnValueChange;
            if (vc != null)
                vc(this, e);
        }

        public BitSetter()
        {
            InitializeComponent();            
        }

        private void bits_CheckedChanged(object sender, EventArgs e)
        {
            DoValueChange(EventArgs.Empty);
        }
    }
}

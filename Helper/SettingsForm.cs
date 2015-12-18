using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Helper
{
    internal partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public void Prepare(object settings)
        {
            propertyGrid.SelectedObject = settings;
        }
    }
}

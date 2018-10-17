using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenOLT.Map;

namespace OpenOLT.GUI
{
    public partial class FirmwareEditPanel : UserControl
    {
        private readonly FirmwareMap map = new FirmwareMap();

        public FirmwareEditPanel()
        {
            InitializeComponent();
        }
        
        public void Open()
        {
            map.Open();

            firmwareMap.Nodes.Clear();            

            foreach (var table in map.Tables)
            {
                var category = firmwareMap.Nodes[table.Category] ?? firmwareMap.Nodes.Add(table.Category, map.Categories[table.Category]);
                var tableNode = category.Nodes.Add(table.Title);
                tableNode.Tag = table;
            }
        }

        private void firmwareMapOpen_Click(object sender, EventArgs e)
        {
            Open();
        }
    }
}

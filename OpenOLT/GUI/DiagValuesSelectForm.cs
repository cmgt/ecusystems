using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenOLT.DataValueInfo;

namespace OpenOLT.GUI
{
    internal partial class DiagValuesSelectForm : Form
    {
        private DiagValuesSelectForm()
        {
            InitializeComponent();
        }

        public static void ShowSelectionDialog(IWin32Window owner, List<ValueInfo> selectedValues, ValueInfo[] supportedValues)
        {
            using (var frm = new DiagValuesSelectForm())
            {
                var values = supportedValues.OrderBy(item => item.Order).ToArray();

                for (int index = 0; index < values.Length; index++)
                {
                    var valueInfo = values[index];
                    frm.diagValuesList.Items.Add(valueInfo);
                    frm.diagValuesList.SetItemChecked(index, selectedValues.Contains(valueInfo));
                }
                frm.ShowDialog(owner);
                selectedValues.Clear();
                selectedValues.AddRange(frm.diagValuesList.CheckedItems.Cast<ValueInfo>());
            }
        }
    }
}

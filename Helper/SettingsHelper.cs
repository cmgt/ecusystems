using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Helper
{
    public static class SettingsHelper
    {
        public static bool ShowSettingsDialog(IWin32Window owner, object settings)
        {
            using (var sf = new SettingsForm())
            {
                sf.Prepare(settings);
                return sf.ShowDialog(owner) == DialogResult.OK;
            }
        }
    }
}

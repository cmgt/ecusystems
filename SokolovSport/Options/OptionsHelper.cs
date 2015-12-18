using System;
using System.Linq;
using System.Windows.Forms;
using Helper;

namespace SokolovSport.Options
{
    static class OptionsHelper
    {
        private static readonly OptionsEntity options;
        public static OptionsEntity Options { get { return options; } }
        public static readonly LocalSettingsKeeper SettingsKeeper;

        static OptionsHelper()
        {         
            options = new OptionsEntity();
            SettingsKeeper = new LocalSettingsKeeper();
            SettingsKeeper.LoadSettings(options);
            var datFiles = LocalSettingsHelper.GetValues<string>(SettingsKeeper, "OPENED_DAT_FILE");
            options.OpenedDatFile.AddRange(datFiles);
        }

        public static bool OpenDialog(IWin32Window owner)
        {            
            return SettingsHelper.ShowSettingsDialog(owner, options);
        }

        public static void SaveSettings()
        {
            LocalSettingsHelper.SetValues(SettingsKeeper, "OPENED_DAT_FILE", options.OpenedDatFile.Take(20).ToArray());
            SettingsKeeper.SaveSettings(options);
        }
    }
}

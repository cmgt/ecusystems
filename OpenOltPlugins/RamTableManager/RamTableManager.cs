using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CtpMaps;
using OpenOltTypes;
using RamTablePlugin.Properties;

namespace RamTablePlugin
{
    public class RamTableManager
    {
        private readonly IApplicationHost appHost;
        private readonly RamTableControl ramTableControl;
        private CtpMap ramTables;
        private readonly CaptureManager captureManager;

        public RamTableManager(IApplicationHost applicationHost)
        {
            appHost = applicationHost;
            var onlineManager = appHost.GetOnlineManager();
            captureManager = new CaptureManager(onlineManager);            
            LoadSupportedRamTables();
            ramTableControl = new RamTableControl();
            ramTableControl.Prepare(captureManager, ramTables);
            appHost.AddContent(ramTableControl, "Online коррекция Ram таблиц", Resources.ram, Keys.F5);
        }

        private void LoadSupportedRamTables()
        {
            ramTables = new CtpMap();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\tables.map";
            ramTables.LoadFromFile(path);
        }
    }
}

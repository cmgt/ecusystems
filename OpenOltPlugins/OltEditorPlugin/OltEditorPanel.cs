using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CtpMaps;
using OpenOltTypes;

namespace OltEditorPlugin
{
    internal partial class OltEditorPanel : UserControl
    {
        private IOnlineManager onlineManager;
        private CtpMap ctpMap;

        public OltEditorPanel()
        {
            InitializeComponent();
        }

        public void Init(IOnlineManager onlineManager)
        {
            this.onlineManager = onlineManager;
            onlineManager.FirmwareManager.OnOpenFirmware += FirmwareManagerOnOnOpenFirmware;
            onlineManager.FirmwareManager.OnCloseFirmware += FirmwareManagerOnOnCloseFirmware;
        }

        private void FirmwareManagerOnOnCloseFirmware(object sender, EventArgs eventArgs)
        {
            ctpMapTree.Clear();
        }

        private void FirmwareManagerOnOnOpenFirmware(object sender, EventArgs eventArgs)
        {
            
        }

        public void OpenMap()
        {
            if (openMapDialog.ShowDialog() != DialogResult.OK) return;
            ctpMap = new CtpMap();
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\tables.map";
            //ctpMap.LoadFromFile(path);
        }
    }
}

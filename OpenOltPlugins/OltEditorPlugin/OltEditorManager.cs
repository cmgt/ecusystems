using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OpenOltTypes;

namespace OltEditorPlugin
{
    public class OltEditorManager
    {
        private IApplicationHost appHost;
        private OltEditorPanel oltEditorPanel;
        private IOnlineManager onlineManager;

        public OltEditorManager(IApplicationHost applicationHost)
        {
            appHost = applicationHost;          
            onlineManager = appHost.GetOnlineManager();
            oltEditorPanel = new OltEditorPanel();
            oltEditorPanel.Init(onlineManager);
            appHost.AddContent(oltEditorPanel, "Изменение калибровок online", null, Keys.None);
        }
    }
}

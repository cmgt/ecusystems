using System;
using System.Windows.Forms;
using IoControlPlugin.Properties;
using OpenOltTypes;

namespace IoControlPlugin
{
    public class IoControlManager
    {
        internal readonly IApplicationHost appHost;
        private readonly IoControlPanel ioControlPanel;

        public IoControlManager(IApplicationHost applicationHost)
        {
            appHost = applicationHost;
            ioControlPanel = new IoControlPanel();
            ioControlPanel.Prepare(this);
            appHost.AddContent(ioControlPanel, "Online управление ИМ", Resources.IoControl, Keys.F6, true);
        }       
    }
}

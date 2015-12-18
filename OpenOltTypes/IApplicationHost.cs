using System.Drawing;
using System.Windows.Forms;

namespace OpenOltTypes
{
    public interface IApplicationHost
    {
        void AddContent(Control control, string text, Image image, Keys shortcut, bool left = false);
        IOnlineManager GetOnlineManager();
    }
}

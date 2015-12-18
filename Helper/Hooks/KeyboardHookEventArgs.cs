using System;
using System.Windows.Forms;

namespace Helper.Hooks
{
    public class KeyboardHookEventArgs: EventArgs
    {
        public Keys Key { get; private set; }
        public int ExtendedParams { get; private set; }
        public int KeyCode { get; private set; }

        public KeyboardHookEventArgs(Keys key, int extendedParams, int keyCode)
        {
            Key = key;
            ExtendedParams = extendedParams;
            KeyCode = keyCode;
        }
    }
}

using System;

namespace Helper.Hooks
{
    public class HookEventArgs : EventArgs
    {
        public int HookCode;
        public IntPtr lParam;
        public IntPtr wParam;
        public bool Handled;
    }
}

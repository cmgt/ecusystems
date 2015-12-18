using System;
using System.Windows.Forms;

namespace Helper
{
    public class ToolStripEx: ToolStrip
    {
        private bool clickThrough = true;

        /// <summary>
        /// Gets or sets whether the ToolStripEx honors item clicks when its containing form does
        /// not have input focus.
        /// </summary>
        /// <remarks>
        /// Default value is false, which is the same behavior provided by the base ToolStrip class.
        /// </remarks>
        public bool ClickThrough
        {
            get { return clickThrough; }
            set { clickThrough = value; }
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (clickThrough &&
                m.Msg == NativeConstants.WM_MOUSEACTIVATE &&
                m.Result == (IntPtr) NativeConstants.MA_ACTIVATEANDEAT)
            {
                m.Result = (IntPtr) NativeConstants.MA_ACTIVATE;
            }
        }
    }


    internal static class NativeConstants
    {
        internal const uint WM_MOUSEACTIVATE = 0x21;
        internal const uint MA_ACTIVATE = 1;
        internal const uint MA_ACTIVATEANDEAT = 2;
        internal const uint MA_NOACTIVATE = 3;
        internal const uint MA_NOACTIVATEANDEAT = 4;
    }
}
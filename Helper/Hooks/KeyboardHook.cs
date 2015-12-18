using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Helper.Hooks
{
    public class KeyboardHook : LocalWindowsHook
    {
        private static KeyboardHook instance;
        public static KeyboardHook Instance
        {
            get { return instance ?? (instance = new KeyboardHook()); }
        }
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        public byte[] keyCodes;        
      
        private EventHandler<HookEventArgs> fireEvent;
        public event EventHandler<HookEventArgs> FireEvent
        {
            add { fireEvent += value; }
            remove { fireEvent -= value; }
        }

        private EventHandler<KeyboardHookEventArgs> keyDown;
        public event EventHandler<KeyboardHookEventArgs> KeyDown
        {
            add { keyDown += value; }
            remove { keyDown -= value; }
        }

        private EventHandler<KeyboardHookEventArgs> keyUp;
        
        public event EventHandler<KeyboardHookEventArgs> KeyUp
        {
            add { keyUp += value; }
            remove { keyUp -= value; }
        }
        
        public static bool Enabled { get; set; }

        public KeyboardHook()
            : base(HookType.WH_KEYBOARD)
        {            
            keyCodes = new byte[256];
            Enabled = true;

            hookInvoked += keyboardHook_HookInvoked;
            Install();
        }

        public void Clean()
        {
            Array.Clear(keyCodes, 0, keyCodes.Length);
        }
        
        void keyboardHook_HookInvoked(object sender, HookEventArgs e)
        {
            if (!Enabled) return;

            DoFireEvent(e);
            
            if (!e.Handled && e.HookCode == HC_ACTION)
                ProcessKeyboardEvent(e.wParam.ToInt32(), e.lParam.ToInt32());
        }

        private void ProcessKeyboardEvent(int keyCode, int extendedParams)
        {
            GetKeyboardState(keyCodes);            
            var keyPressedFlag = !DataHelper.IsBitSet((uint)extendedParams, 31);

            if (keyPressedFlag)
            {
                DoKeyDown(new KeyboardHookEventArgs((Keys)keyCode, extendedParams, keyCode));
            }
            else
            {
                DoKeyUp(new KeyboardHookEventArgs((Keys)keyCode, extendedParams, keyCode));
            }
        }

        private void DoFireEvent(HookEventArgs args)
        {
            var fe = fireEvent;
            if (fe == null) return;

            fe(this, args);
        }

        private void DoKeyDown(KeyboardHookEventArgs args)
        {
            var kd = keyDown;
            if (kd == null) return;

            kd(this, args);
        }

        private void DoKeyUp(KeyboardHookEventArgs args)
        {
            var ku = keyUp;
            if (ku == null) return;

            ku(this, args);
        }       
    }
}

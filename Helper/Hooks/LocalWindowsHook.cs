using System;
using System.Runtime.InteropServices;

namespace Helper.Hooks
{
    public class LocalWindowsHook: SafeHandle
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        protected HookProc filterFunc;
        protected IntPtr hhook;
        protected HookType hookType;

        protected event EventHandler<HookEventArgs> hookInvoked;
        public event EventHandler<HookEventArgs> HookInvoked
        {
            add{ hookInvoked += value;}
            remove { hookInvoked -= value;}
        }

        public LocalWindowsHook(HookType hook)
            : base(IntPtr.Zero, true)
        {
            hhook = IntPtr.Zero;
            hookType = hook;
            filterFunc = CoreHookProc;
        }        

        [DllImport("user32.dll")]
        protected static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam);
        public int CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
        {            
            if (code < 0)
            {
                return CallNextHookEx(hhook, code, wParam, lParam);
            }

            var e = new HookEventArgs {HookCode = code, wParam = wParam, lParam = lParam};
            OnHookInvoked(e);

            return e.Handled ? 1 : CallNextHookEx(hhook, code, wParam, lParam);
        }

        [DllImport("Kernel32.dll")]
        protected static extern int GetCurrentThreadId();        

        public void Install()
        {
            var threadId = GetCurrentThreadId();
            hhook = SetWindowsHookEx(hookType, filterFunc, IntPtr.Zero, threadId);       

            if (hhook == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
        }       

        protected void OnHookInvoked(HookEventArgs e)
        {
            var hi = hookInvoked;
            if (hi != null)
                hi(this, e);            
        }

        [DllImport("user32.dll")]
        protected static extern IntPtr SetWindowsHookEx(HookType code, HookProc func, IntPtr hInstance, int threadID);
        [DllImport("user32.dll")]
        protected static extern int UnhookWindowsHookEx(IntPtr hhook);

        public void Uninstall()
        {
            if (IsInvalid) return;

            UnhookWindowsHookEx(hhook);
            hhook = IntPtr.Zero;
        }

        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        public const int HC_ACTION = 0;
        public const int HC_NOREMOVE = 3;
        public const int PM_NOREMOVE = 0x0000;
        public const int PM_REMOVE = 0x0001;
        public const int HWND_BROADCAST = 0xffff;        

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>
        /// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (IsInvalid) return true;
            Uninstall();
            return true;
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the handle value is invalid.
        /// </summary>
        /// <returns>
        /// true if the handle value is invalid; otherwise, false.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public override bool IsInvalid
        {
            get { return hhook == IntPtr.Zero; }
        }
    }
}

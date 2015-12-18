using System;
using System.Runtime.InteropServices;

namespace Helper.Hooks
{
    public enum HookType
    {
        WH_CALLWNDPROC = 4,
        WH_CALLWNDPROCRET = 12,
        WH_CBT = 5,
        WH_DEBUG = 9,
        WH_FOREGROUNDIDLE = 11,
        WH_GETMESSAGE = 3,
        WH_HARDWARE = 8,
        WH_JOURNALPLAYBACK = 1,
        WH_JOURNALRECORD = 0,
        WH_KEYBOARD = 2,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE = 7,
        WH_MOUSE_LL = 14,
        WH_MSGFILTER = -1,
        WH_SHELL = 10,
        WH_SYSMSGFILTER = 6
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;      
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public uint message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public POINT pt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CWPSTRUCT
    {
        public IntPtr lParam;
        public IntPtr wParam;
        public uint message;
        public IntPtr hwnd;
    }

}

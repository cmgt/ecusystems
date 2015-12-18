using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Helper
{
    public static class ComApi
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetCommTimeouts(IntPtr hFile, [In] ref COMMTIMEOUTS lpCommTimeouts);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetCommTimeouts(IntPtr hFile, [In, Out] ref COMMTIMEOUTS lpCommTimeouts);

        public struct COMMTIMEOUTS
        {
            public UInt32 ReadIntervalTimeout;
            public UInt32 ReadTotalTimeoutMultiplier;
            public UInt32 ReadTotalTimeoutConstant;
            public UInt32 WriteTotalTimeoutMultiplier;
            public UInt32 WriteTotalTimeoutConstant;
        }
    }
}

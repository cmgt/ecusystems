using System;
using Helper;

namespace OpenOltTypes
{
    public class J7esFlags
    {        
        public void Prepare(byte[] buffer)
        {
            var index = DataHelper.IndexOf(buffer, new byte[] {0x6A, 0x37, 0x65, 0x73});
            IsJ7es = index != -1;
            
            if (IsJ7es)
            {
                IsJ7esaFork = buffer[index + 1] == (byte) 'a';
                Version = IsJ7esaFork
                    ? new Version(17, buffer[index + 4] - 0x30, buffer[index + 6] - 0x30, buffer[index + 8] - 0x30)
                    : new Version((buffer[0x36] - 0x30)*10 + (buffer[0x37] - 0x30), (buffer[0x39] - 0x30));                
                IsDadMode = DataHelper.IsBitSet(buffer[j7eFlagsAddr], 0);
                IsCommonKGBCTable = DataHelper.IsBitSet(buffer[j7eFlagsAddr], 6);
                IsRamCaptureSupport = Version.Major > 14 && buffer[j7eRamCapturesAddr] == 1;
            }
            else
            {
                IsDadMode = false;
                IsCommonKGBCTable = false;
                IsRamCaptureSupport = false;
                Version = new Version();
            }

            if (IsJ7esaFork)
            {
                IsKgbc32_16 = DataHelper.IsBitSet(buffer[j7eFlagsAddr], 3);
                IsKgbcPress32_32 = DataHelper.IsBitSet(buffer[j7eFlagsAddr], 4);
            }
        }

        public bool IsKgbcPress32_32 { get; private set; }
        public bool IsKgbc32_16 { get; private set; }

        private const int j7eFlagsAddr = 0x5F02;
        private const int j7eRamCapturesAddr = 0x0007;

        public bool IsDadMode { get; private set; }
        public bool IsCommonKGBCTable { get; private set; }
        public bool IsJ7es { get; private set; }
        public bool IsRamCaptureSupport { get; private set; }
        public bool IsJ7esaFork { get; private set; }
        public Version Version { get; private set; }
    }
}
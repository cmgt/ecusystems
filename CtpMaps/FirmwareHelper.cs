using System;
using Helper;

namespace CtpMaps
{
    public static class FirmwareHelper
    {
        public const int RmpSamplingAddr = 0x613C;
        public const int ThrSamplingAddr = 0x7208;
        public const int MinGbcAddr = 0x6064;
        public const int StepGbcAddr = 0x6066;
        public const int MinPressAddr = 0x5EF2;
        public const int RangePressAddr = 0x5EF4;
        public const int GbcAddr = 0x75EF;
        public const int KGbcAddr = 0x7CF7;
        public const int KGbcPressAddr = 0x9294;
        public const int KGbcJ7esDadAddr = 0x9294;

        public static void FillRpmRT(byte[] buffer, out byte[] rpmSampling, out int[] rpmRt32, out int[] rpmRt16)
        {            
            var isFastRpm = DataHelper.IndexOf(buffer, new byte[] {0x90, 0x61, 0x3C, 0xE5, 0x55}) != -1;
            rpmSampling = new byte[256];
            rpmRt32 = new int[16];
            rpmRt16 = new int[32];

            Buffer.BlockCopy(buffer, RmpSamplingAddr, rpmSampling, 0, rpmSampling.Length);

            byte index = 0;
            var value = index * 16;
            for (var i = 0; i < rpmSampling.Length; i++)
            {
                var delta = rpmSampling[i] - value;

                if (index == 0)
                {
                    if (delta <= 0) continue;
                    rpmRt32[index] = Math.Max(i - 1, 0) * (isFastRpm ? 40 : 30);
                }
                else
                {
                    if (delta < 0) continue;
                    rpmRt32[index] = i * (isFastRpm ? 40 : 30);
                }

                if (index < 15) index++;
                value = index * 16;
            }

            index = 0;
            value = index * 8;
            for (var i = 0; i < rpmSampling.Length; i++)
            {
                var delta = rpmSampling[i] - value;

                if (index == 0)
                {
                    if (delta <= 0) continue;
                    rpmRt16[index] = Math.Max(i - 1, 0) * (isFastRpm ? 40 : 30);
                }
                else
                {
                    if (delta < 0) continue;
                    rpmRt16[index] = i * (isFastRpm ? 40 : 30);
                }

                if (index < 31) index++;
                value = Math.Min(index * 8, 240);
            }
        }
    }
}

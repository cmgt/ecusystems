using System;
using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public unsafe class ExInfo
    {
        public byte CaptureRamId { get; set; }
        public RtType RtType { get; set; }
        public bool SymmetricPalette { get; set; }
        public byte[] unk1 { get; set; }

        public ExInfo(ref byte* ptr)
        {
            CaptureRamId = *ptr++;
            RtType = (RtType) (*ptr++);
            SymmetricPalette = *ptr++ == 1;
            unk1 = MapDataHelper.LoadBytes(ref ptr, 5);  
        }

        public void WriteToBuffer(ref byte* ptr)
        {
            *ptr++ = CaptureRamId;
            *ptr++ = (byte) RtType;
            *ptr++ = (byte) (SymmetricPalette ? 1 : 0);
            MapDataHelper.SaveBytes(ref ptr, unk1);
        }
    }

    public enum RtType: byte
    {
        Unknown = 0,
        RpmThr = 1,
        RpmGbc = 2,
        Rpm32 = 3,
        Twat = 4,
        RpmPress = 5,
        Rpm32Thr = 6
    }
}

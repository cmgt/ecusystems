using System;
using System.Runtime.InteropServices;

namespace CtpMaps.DataTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct MapHeader
    {
        public fixed byte Ctm[3]; //"CTM"
        public byte Version_hi;
        public byte Version_lo;
        public byte unk1;
        public uint unk2;
        public fixed byte unk3 [12];        
    }
}

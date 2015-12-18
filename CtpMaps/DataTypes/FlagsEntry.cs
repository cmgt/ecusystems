using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
   [TypeConverter(typeof(PropertyConverter))]
    public unsafe class FlagsEntry
    {
        public uint Comp_id { get; set; } //CTP Compare id
        public uint[] Addr { get; set; } //Xored address   
        //j5unk<8,0> unk1;
        public byte[] unk1 { get; set; }
        public string[] ItemsName { get; set; }
        public string[,] BitsName { get; set; }
        //j5str<64> flags_bits_name[8][8];
        //j5unk<16,0> unk2;
        public byte[] unk2 { get; set; }
        public ushort Cs { get; set; }

        public FlagsEntry(ref byte* ptr, bool olt = false)
        {
            Comp_id = MapDataHelper.LoadUint(ref ptr);            
            Addr = new uint[8];
            for (var i = 0; i < Addr.Length; i++)
            {
                Addr[i] = MapDataHelper.LoadUint(ref ptr);
            }

            if (!olt)
            {
                Addr[0] ^= MapDataHelper.XorKey;
                unk1 = MapDataHelper.LoadBytes(ref ptr, 8);
            }
            else
            {
                unk1 = MapDataHelper.LoadBytes(ref ptr, 4);
            }

            ItemsName = new string[8];
            for (int i = 0; i < ItemsName.Length; i++)
            {
                ItemsName[i] = MapDataHelper.LoadString(ref ptr);
            }

            BitsName = new string[8, 8];
            for (int i = 0; i < BitsName.GetLength(0); i++)
            {
                for (int j = 0; j < BitsName.GetLength(1); j++)
                {
                    BitsName[i, j] = MapDataHelper.LoadString(ref ptr);
                }
            }

            if (olt) return;
            unk2 = MapDataHelper.LoadBytes(ref ptr, 16);
            Cs = MapDataHelper.LoadUshort(ref ptr);
        }

        public void WriteToBuffer(ref byte* ptr, bool olt)
        {
            MapDataHelper.SaveUint(ref ptr, Comp_id);            

            if (!olt) Addr[0] ^= MapDataHelper.XorKey;

            foreach (var t in Addr)
            {
                MapDataHelper.SaveUint(ref ptr, t);
            }

            MapDataHelper.SaveBytes(ref ptr, unk1, olt ? 4 : 8);            

            foreach (var t in ItemsName)
            {
                MapDataHelper.SaveString(ref ptr, t);
            }

            for (int i = 0; i < BitsName.GetLength(0); i++)
            {
                for (int j = 0; j < BitsName.GetLength(1); j++)
                {
                    MapDataHelper.SaveString(ref ptr, BitsName[i, j]);
                }
            }

            if (olt) return;
            MapDataHelper.SaveBytes(ref ptr, unk2);
            MapDataHelper.SaveUshort(ref ptr, Cs);
        }
    }
}
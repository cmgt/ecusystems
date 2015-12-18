using System;
using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public unsafe class Entry1D : EntryBase
    {
        //j5unk<8,0> unk1;
        public byte[] unk1 { get; set; }
        //j5str<16> units;		//Units string

        //0 - unsigned byte
        //1 - signed byte
        //2 - unsigned word little endian
        //3 - signed word little endian
        //4 - unsigned word big endian
        //5 - signed word big endian
        //6 - unsigned word, separated (Tarrirovka DMRV)

        public byte Precision { get; set; }

        public Entry1D(ref byte* ptr, bool olt = false)
        {
            Comp_id = MapDataHelper.LoadUint(ref ptr);
            Addr = MapDataHelper.LoadUint(ref ptr);
            if (!olt)
            {
                Addr ^= MapDataHelper.XorKey;
                unk1 = MapDataHelper.LoadBytes(ref ptr, 8);
            }
            else
            {
                unk1 = MapDataHelper.LoadBytes(ref ptr, 4);
            }

            Units = MapDataHelper.LoadString(ref ptr, 16);
            Lower_lim = MapDataHelper.LoadDouble(ref ptr);
            Upper_lim = MapDataHelper.LoadDouble(ref ptr);
            Const_type = *(ptr++);
            Precision = *(ptr++);
            Convert = new ConvertInfo(ref ptr);

            if (olt) return;            
            Cs = MapDataHelper.LoadUshort(ref ptr);
        }

        public void WriteToBuffer(ref byte* ptr, bool olt)
        {
            MapDataHelper.SaveUint(ref ptr, Comp_id);
            if (!olt) Addr ^= MapDataHelper.XorKey;
            
            MapDataHelper.SaveUint(ref ptr, Addr);
            MapDataHelper.SaveBytes(ref ptr, unk1, olt ? 4 : 8);
            MapDataHelper.SaveString(ref ptr, Units, 16);
            MapDataHelper.SaveDouble(ref ptr, Lower_lim);
            MapDataHelper.SaveDouble(ref ptr, Upper_lim);

            *(ptr++) = Const_type;
            *(ptr++) = Precision;

            Convert.WriteToBuffer(ref ptr);

            if (olt) return;            
            MapDataHelper.SaveUshort(ref ptr, Cs);
        }
    }
}

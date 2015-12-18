using System;
using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public unsafe class MapEntry
    {        
        public string Name { get; set; } //MapEntry name	
        public byte Level { get; set; } //MapEntry tree level	
        public byte Type { get; set; } //MapEntry type: 
        //0 - folder, 
        //1 - 1d value (y=f(x)), 
        //2 - 2d value (y=f(x,z)), 
        //3 - 0d value,
        //4 - flags (Flagi komplektatsii, Maska Oshibok)
        //5 - id data (Identifikatsionnie dannie)            
        public ushort Length{ get; set; }

        public uint Comp_id { get; set; }

        public IdentEntry IdentEntry { get; set; }
        public FlagsEntry FlagsEntry { get; set; }
        public Entry1D Entry1D { get; set; }
        public Entry2D Entry2D { get; set; }
        public Entry3D Entry3D { get; set; }

        internal MapEntry()
        {}

        public MapEntry(ref byte* ptr, bool olt = false)
        {
            Name = MapDataHelper.LoadString(ref ptr);
            Level = *(ptr++);
            Type = *(ptr++);
            Length = MapDataHelper.LoadUshort(ref ptr);
            Comp_id = MapDataHelper.LoadUint(ref ptr);
            ptr -= 4;

            switch ((MapEntryType)Type)
            {
                case MapEntryType.Ident:
                    IdentEntry = new IdentEntry(ref ptr, olt);
                    break;

                case MapEntryType.Flags:
                    FlagsEntry = new FlagsEntry(ref ptr, olt);
                    break;

                case MapEntryType.Entry1D:
                    Entry1D = new Entry1D(ref ptr, olt);
                    break;

                case MapEntryType.Entry2D:
                    Entry2D = new Entry2D(ref ptr, olt);
                    break;

                case MapEntryType.Entry3D:
                    Entry3D = new Entry3D(ref ptr, olt);
                    break;

                default:
                    Comp_id = 0;
                    ptr += Length;
                    break;
            }                                   
        }        

        public uint WriteToBuffer(ref byte* ptr, bool olt = false)
        {
            var startPtr = (uint) ptr;

            MapDataHelper.SaveString(ref ptr, Name);
            *(ptr++) = Level;
            *(ptr++) = Type;            
            
            switch (Type)
            {
                case 5:
                    MapDataHelper.SaveUshort(ref ptr, (ushort)(Length - (olt ? 22 : 0)));
                    IdentEntry.WriteToBuffer(ref ptr, olt);
                    break;

                case 4:
                    MapDataHelper.SaveUshort(ref ptr, (ushort)(Length - (olt ? 22 : 0)));
                    FlagsEntry.WriteToBuffer(ref ptr, olt);
                    break;

                case 3:
                    MapDataHelper.SaveUshort(ref ptr, (ushort)(Length - (olt ? 6 : 0)));
                    Entry1D.WriteToBuffer(ref ptr, olt);
                    break;

                case 1:
                    MapDataHelper.SaveUshort(ref ptr, (ushort)(Length - (olt ? 6 : 0)));
                    Entry2D.WriteToBuffer(ref ptr, olt);
                    break;

                case 2:
                    MapDataHelper.SaveUshort(ref ptr, (ushort)(Length - (olt ? 6 : 0)));
                    Entry3D.WriteToBuffer(ref ptr, olt);
                    break;

                default:
                    MapDataHelper.SaveUshort(ref ptr, Length);
                    ptr += Length;
                    break;
            }

            return (uint)ptr - startPtr;
        }
    }
}

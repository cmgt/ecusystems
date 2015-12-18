using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public class EntryBase
    {
        [TypeConverter(typeof(UintHexTypeConverter))]
        public uint Comp_id { get; set; } //CTP Compare id
        [TypeConverter(typeof(UintHexTypeConverter))]
        public uint Addr { get; set; }//Xored address
        public string Units { get; set; }
        public double Lower_lim { get; set; }
        public double Upper_lim { get; set; }
        //0 - unsigned byte
        //1 - signed byte
        //2 - unsigned word little endian
        //3 - signed word little endian
        //4 - unsigned word big endian
        //5 - signed word big endian
        //6 - unsigned word, separated (Tarrirovka DMRV)
        public byte Const_type { get; set; }//Type:
        public ConvertInfo Convert { get; set; }        
        public ushort Cs { get; set; } //Check summ
    }
}
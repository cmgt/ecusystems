using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public class EntryTableBase : EntryBase
    {
        public string xUnits { get; set; }
        public string xTable { get; set; }
        public ushort xPoints { get; set; }
        public double xStart { get; set; }
        public double xEnd { get; set; }
    }
}
using System;
using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public unsafe class ConvertInfo
    {
        public double Div_step { get; set; }
        public double Offset2 { get; set; }
        public double Inverted { get; set; }
        public double Step { get; set; }
        public double Offset1 { get; set; }
        public ExInfo ExInfo { get; set; }

        public ConvertInfo(ref byte* ptr)
        {            
            Div_step = MapDataHelper.LoadDouble(ref ptr);
            Offset2 = MapDataHelper.LoadDouble(ref ptr);
            Inverted = MapDataHelper.LoadDouble(ref ptr);
            Step = MapDataHelper.LoadDouble(ref ptr);
            Offset1 = MapDataHelper.LoadDouble(ref ptr);
            ExInfo = new ExInfo(ref ptr);  
        }

        public void WriteToBuffer(ref byte* ptr)
        {
            MapDataHelper.SaveDouble(ref ptr, Div_step);
            MapDataHelper.SaveDouble(ref ptr, Offset2);
            MapDataHelper.SaveDouble(ref ptr, Inverted);
            MapDataHelper.SaveDouble(ref ptr, Step);
            MapDataHelper.SaveDouble(ref ptr, Offset1);
            ExInfo.WriteToBuffer(ref ptr); 
        }      
    }
}

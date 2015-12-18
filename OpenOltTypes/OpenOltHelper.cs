using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalibrTable;
using CtpMaps.DataTypes;

namespace OpenOltTypes
{
    public static class OpenOltHelper
    {
        public static void FillMinMax(TableValues<byte, float> table, EntryBase entry)
        {
            float min = table.converter((byte)table.RawMin);
            float max = table.converter((byte)table.RawMax);
            if (entry.Lower_lim != 0) min = (float)entry.Lower_lim;
            if (entry.Upper_lim != 0) max = (float)entry.Upper_lim;
            table.Min = min;
            table.Max = max;
        }
    }
}

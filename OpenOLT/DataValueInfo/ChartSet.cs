using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenOLT.DataValueInfo
{
    internal class ChartSet
    {
        public string Name { get; set; }
        public List<ValueInfo> Items { get; private set; }

        public ChartSet()
        {
            Items = new List<ValueInfo>();
        }
    }
}

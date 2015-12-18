using System;
using System.ComponentModel;
using System.Reflection;

namespace OpenOLT.DataValueInfo
{
    internal class ValueInfo
    {
        public string Title { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public ValueInfo(string title, float min, float max, string name, int order)
        {
            Title = title;
            Min = min;
            Max = max;
            Name = name;
            Order = order;
        }

        public ValueInfo(PropertyInfo info)
        {
            Name = info.Name;
            Title =
                ((DisplayNameAttribute) Attribute.GetCustomAttribute(info, typeof (DisplayNameAttribute))).DisplayName;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}

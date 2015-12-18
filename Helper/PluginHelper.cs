using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class PluginAttribute : Attribute
    {
        public PluginAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}

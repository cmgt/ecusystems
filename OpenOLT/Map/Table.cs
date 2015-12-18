using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OpenOLT.Map
{
    class Table
    {
        public string Title { get; private set; }
        public string Category { get; private set; }

        public Table(XElement source)
        {
            Title = source.Element("title").Value;
            Category = source.Element("CATEGORYMEM").Attribute("category").Value;
        }
    }
}

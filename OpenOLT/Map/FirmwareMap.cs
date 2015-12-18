using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OpenOLT.Map
{
    class FirmwareMap
    {
        private XDocument map;

        public List<Table> Tables { get; private set; }
        public Dictionary<string, string> Categories { get; private set; }

        public FirmwareMap()
        {
            Tables = new List<Table>();
            Categories = new Dictionary<string, string>();
        }

        public void Open()
        {
            var initPath = Application.StartupPath;
            if (Directory.Exists(initPath + @"\maps\"))
                initPath += @"\maps\";

            var openDialog = new OpenFileDialog
                                 {
                                     InitialDirectory = initPath,
                                     Filter = "map files|*.xdf|all files|*.*"
                                 };

            if (openDialog.ShowDialog() != DialogResult.OK) return;

            var fileName = openDialog.FileName;
            if (!File.Exists(fileName)) return;
            
            using (var reader = new StreamReader(fileName, Encoding.GetEncoding(1251)))
            {
                map = XDocument.Load(reader);                
                reader.Close();
            }

            PrepareMapFile();
        }

        private void PrepareMapFile()
        {
            if (map == null) return;

            var root = map.Element("XDFFORMAT");
            if (root == null) return;

            var header = root.Element("XDFHEADER");
            if (header == null) return;

            Categories.Clear();
            foreach (var category in header.Elements("CATEGORY"))
            {
                Categories.Add(category.Attribute("index").Value, category.Attribute("name").Value);
            }

            Tables.Clear();
            foreach (var table in root.Elements("XDFTABLE"))
            {
                Tables.Add(new Table(table));
            }
        }        
    }
}

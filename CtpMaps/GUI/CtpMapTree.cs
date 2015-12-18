using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CtpMaps.DataTypes;

namespace CtpMaps.GUI
{
    public partial class CtpMapTree : UserControl
    {
        private readonly IList<CtpMap> maps = new List<CtpMap>();
        [Browsable(false)]
        public IList<CtpMap> Maps { get { return maps; } }

        public TreeView Tree { get { return entriesTree; } }
        public event TreeViewEventHandler AfterSelect
        {
            add { entriesTree.AfterSelect += value; }
            remove { entriesTree.AfterSelect -= value; }
        }

        [DefaultValue(false)]
        public bool OnlyRamSupport { get; set; }

        public CtpMapTree()
        {
            InitializeComponent();
        }

        public void LoadMap(CtpMap map, bool clear = false)
        {            
            var levels = new Dictionary<int, TreeNode>();

            if (clear)
            {
                Clear();
            }

            maps.Add(map);

            var node = entriesTree.Nodes.Add(Guid.NewGuid().ToString(), map.Path, (byte)MapEntryType.Folder);            
            var lastFolder = node;
            var level = 1;
            levels.Add(level, node);

            foreach (var entry in map.Entries)
            {
                
                if (entry.Level > level)
                {
                    level++;
                    node = lastFolder;
                    if (!levels.ContainsKey(level))
                        levels.Add(level, node);
                    else
                        levels[level] = node;
                }
                else if (entry.Level < level)
                {
                    level = entry.Level;
                    node = levels[level];
                    lastFolder = node;
                }

                var item = AddTreeNode(entry, node);

                if (entry.Type == (byte)MapEntryType.Folder)
                    lastFolder = item;
            }
        }

        public void Clear()
        {
            entriesTree.Nodes.Clear();
            maps.Clear();
        }

        public TreeNode AddTreeNode(MapEntry entry, TreeNode node)
        {
            if (entry == null) return null;

            var imageIndex = GetImageIndex((MapEntryType) entry.Type);
            var item = node.Nodes.Add(entry.Type == (byte) MapEntryType.Folder ? "id_" : "level_" + MapDataHelper.GetId(entry),
                                      entry.Name, imageIndex, imageIndex);
            item.Tag = entry;
            return item;
        }

        private int GetImageIndex(MapEntryType type)
        {
            switch (type)
            {
                case MapEntryType.Ident:
                    return 6;

                case MapEntryType.Entry1D:
                    return 4;

                case MapEntryType.Entry2D:
                    return 2;

                case MapEntryType.Entry3D:
                    return 3;

                case MapEntryType.Folder:
                    return 0;

                case MapEntryType.Flags:
                    return 5;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}

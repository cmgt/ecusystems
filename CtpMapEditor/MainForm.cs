using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CtpMaps;
using CtpMaps.DataTypes;

namespace CtpMapEditor
{
    public partial class MainForm : Form
    {
        private readonly CtpMap ctpMap = new CtpMap();
        private MapEntry copyEntry;

        public MainForm()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = Application.StartupPath;

#if DEBUG
            LoadMap(Application.StartupPath + "\\j7es.j7");
            //LoadMap(Application.StartupPath + "\\M74_typeG3.m74");
            //LoadMap(Application.StartupPath + "\\J5trs_243i.J5", true);
#endif
        }

        private void LoadMap(string path)
        {
            ctpMap.LoadFromFile(path);
            bindingSource1.DataSource = ctpMap.Entries;
            bindingSource1.ResetBindings(false);

            bindingSource2.DataSource =
                ctpMap.Entries.Where(
                    entry =>
                    (entry.Entry2D != null && entry.Entry2D.Convert.ExInfo.CaptureRamId != 0) ||
                    (entry.Entry3D != null && entry.Entry3D.Convert.ExInfo.CaptureRamId != 0));
            bindingSource2.ResetBindings(false);

            bindingSource3.DataSource =
               ctpMap.Entries.Where(
                   entry =>
                   //(entry.Entry1D != null && entry.Entry1D.Const_type > 1) ||
                   (entry.Entry2D != null && entry.Entry2D.Const_type > 1) ||
                   (entry.Entry3D != null && entry.Entry3D.Const_type > 1));
            bindingSource3.ResetBindings(false);

            ctpMapTree.LoadMap(ctpMap);
        }

        private void SaveMap(bool olt = false)
        {
            saveFileDialog.InitialDirectory = openFileDialog.InitialDirectory;
            saveFileDialog.FileName = openFileDialog.FileName;
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            if (listBox1.SelectedItems.Count > 1)
            {
                var entries = listBox1.SelectedItems.OfType<MapEntry>().ToArray();
                foreach (var mapEntry in entries)
                {
                    mapEntry.Level = 1;
                }
                ctpMap.SaveToFile(saveFileDialog.FileName, entries, olt);
            }
            else
                ctpMap.SaveToFile(saveFileDialog.FileName, olt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;
            var path = openFileDialog.FileName;

            LoadMap(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            SaveMap(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveMap(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var message = ctpMap.CheckCompareId();
            if (String.IsNullOrEmpty(message)) return;
            MessageBox.Show(this, message, "Check compare id", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIda_Click(object sender, EventArgs e)
        {
            if (ctpMap.Entries.Count == 0) return;

            var strBuilder = new StringBuilder();

            foreach (var entry in ctpMap.Entries)
            {
                if (entry.Type == 0) continue;

                strBuilder.AppendLine(MapDataHelper.ToIdaDescr(entry));
            }

            File.WriteAllText(Application.StartupPath + "\\ida_descr.fid", strBuilder.ToString(), Encoding.GetEncoding(866));
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            var entry = (sender as BindingSource).Current as MapEntry;
            object source = entry;
            //if (entry != null)
            //{
            //    source = entry.Entry1D ?? entry.Entry2D ?? entry.Entry3D ?? entry.FlagsEntry ?? entry.IdentEntry ?? 
            //}

            entryEditor.SelectedObject = source;
        }

        private void ctpMapTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            entryEditor.SelectedObject = e.Node.Tag as MapEntry;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var node = ctpMapTree.Tree.SelectedNode;
            if (node == null) return;
            copyEntry = node.Tag as MapEntry;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (copyEntry == null) return;
            var node = ctpMapTree.Tree.SelectedNode;
            if (node == null) return;
            copyEntry.Level = 1;
            ctpMapTree.AddTreeNode(copyEntry, node);            
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = ctpMapTree.Tree.SelectedNode;
            if (node == null) return;
            var entries = node.Nodes.OfType<TreeNode>().Select(item => item.Tag as MapEntry).ToArray();

            saveFileDialog.InitialDirectory = openFileDialog.InitialDirectory;
            saveFileDialog.FileName = openFileDialog.FileName;
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ctpMap.SaveToFile(saveFileDialog.FileName, entries);
        }

        private void syncronizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = ctpMapTree.Tree.SelectedNode;
            if (node == null) return;            

            foreach (var entry in node.Nodes.OfType<TreeNode>().Select(item => item.Tag as MapEntry))
            {
                var destEntry = ctpMap.Entries.FirstOrDefault(item => item.Comp_id != 0 && item.Comp_id == entry.Comp_id);
                if (destEntry == null) continue;
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MazdaVINEditor
{
    public partial class MainForm : Form
    {
        private string path;
        private byte[] buffer;
        private string source;

        public MainForm()
        {
            InitializeComponent();
        }

        private unsafe void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            path = openFileDialog1.FileName;
            if (!File.Exists(path)) return;
            pathStatus.Text = path;

            buffer = File.ReadAllBytes(path);
            fixed (byte* ptr = &buffer[0])
                source = new string((sbyte*)ptr, 0, buffer.Length);

            textBoxId.Text = FindId();
            textBoxVin.Text = source.Substring(0x7080, 17);
            

            saveButton.Enabled = true;
        }

        private string FindId()
        {
            var regex = new Regex(@"L([a-zA-Z_0-9]{10})", RegexOptions.Compiled);
            var res = regex.Match(source);

            return res.Success ? res.Value : "ID не найден";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var vin = textBoxVin.Text;
            if (vin.Length != 17 && MessageBox.Show(this, "VIN должен содержать 17 символов. Заполнить недостающие символы пробелами и сохранить?", "Некорректный VIN", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            vin = vin.PadRight(17, ' ');
            for (int i = 0; i < vin.Length; i++)
            {
                buffer[0x7080 + i] = (byte) vin[i];
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = path;
                if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;
                var savePath = saveFileDialog.FileName;

                File.WriteAllBytes(savePath, buffer);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://ecusystems.ru");
            toolStripStatusLabel1.LinkVisited = true;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            using(var about = new AboutBox())
            {
                about.ShowDialog(this);
            }
        }
    }
}

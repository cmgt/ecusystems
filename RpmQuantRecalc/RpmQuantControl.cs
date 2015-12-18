using System;
using System.IO;
using System.Windows.Forms;
using CtpMaps;
using CtpMaps.DataTypes;

namespace RpmQuantRecalc
{
    public partial class RpmQuantControl : UserControl
    {
        private readonly CtpMap ctpMap = new CtpMap();
        private byte[] buffer;
        private byte[] rpmSampling;
        private int[] rpmRt32;
        private int[] rpmRt16;

        public RpmQuantControl()
        {
            InitializeComponent();

            quantGrid.RowCount = 1;
            quantGrid.ColumnCount = 256;
            quantGrid.Rows[0].HeaderCell.Value = "RPM";


            for (int i = 0; i < 256; i++)
            {
                quantGrid.Columns[i].HeaderText = i.ToString();
            }

            quant16Grid.RowCount = 1;
            quant16Grid.ColumnCount = 32;
            quant16Grid.Rows[0].HeaderCell.Value = "RPM_32";

            for (int i = 0; i < 32; i++)
            {
                quant16Grid.Columns[i].HeaderText = i.ToString();
            }

            quant32Grid.RowCount = 1;
            quant32Grid.ColumnCount = 16;
            quant32Grid.Rows[0].HeaderCell.Value = "RPM_16";

            for (int i = 0; i < 16; i++)
            {
                quant32Grid.Columns[i].HeaderText = i.ToString();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите карту CTP 3.21";
                openFileDialog.Filter = "Map files|*.j5;*.j7|All files|*.*";
                if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;
                ctpMap.LoadFromFile(openFileDialog.FileName);

                openFileDialog.Title = "Выберите файл прошивки";
                openFileDialog.Filter = "buffer files|*.bir;*.bin|all files|*.*";
                openFileDialog.FileName = String.Empty;
                if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;
                var fileInfo = new FileInfo(openFileDialog.FileName);

                if (fileInfo.Length != 0x10000 && !MapDataHelper.UnpackCtpFirmware(fileInfo, true, this))
                {
                    return;
                }

                buffer = File.ReadAllBytes(openFileDialog.FileName);                
            }

            ctpMapTree.LoadMap(ctpMap, true);
            FirmwareHelper.FillRpmRT(buffer, out rpmSampling, out rpmRt32, out rpmRt16);

            for (int i = 0; i < 256; i++)
            {
                quantGrid.Rows[0].Cells[i].Value = rpmSampling[i].ToString();
            }

            for (int i = 0; i < 32; i++)
            {                
                quant16Grid.Rows[0].Cells[i].Value = rpmRt16[i].ToString();
            }

            for (int i = 0; i < 16; i++)
            {
                quant32Grid.Rows[0].Cells[i].Value = rpmRt32[i].ToString();
            }
        }
    }
}

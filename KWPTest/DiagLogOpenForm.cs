using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EcuCommunication.Protocols;

namespace KWPTest
{
    internal partial class DiagLogOpenForm : Form
    {
        byte[] icdIndexes = new byte[] {35, 2, 3, 3, 5, 6, 0};
        byte[] matrixIndexes = new byte[] {};
        byte[] injIndexes = new byte[] {};

        readonly List<DiagData> diagData = new List<DiagData>();

        public DiagLogOpenForm()
        {
            InitializeComponent();
        }

        public static DiagData[] LoadDiagLog(IWin32Window owner)
        {
            using (var form = new DiagLogOpenForm())
            {
                return form.ShowDialog(owner) != DialogResult.OK ? new DiagData[0] : form.diagData.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            if (openLogFileDialog.ShowDialog(this) != DialogResult.OK) return;

            var log = File.ReadAllLines(openLogFileDialog.FileName, Encoding.GetEncoding(1251));

            PrepareLog(log);

            bsDiagData.DataSource = diagData;
        }

        private void PrepareLog(string[] log)
        {
            diagData.Clear();

            loadProgressBar.Maximum = log.Length;
            loadProgressBar.Value = 1;

            for (int i = 1; i < log.Length; i++)
            {
                var item = log[i];

                diagData.Add(rbICD.Checked
                                 ? GetInjDiagData(item)
                                 : rbMatrix.Checked ? GetMatrixDiagData(item) : GetInjDiagData(item));

                loadProgressBar.Value++;
            }
        }

        private DiagData GetInjDiagData(string item)
        {
            var items = item.Split(',');
            var diagData = new DiagData();

            try
            {
                diagData.Time = TimeSpan.FromSeconds(float.Parse(items[36]));
                diagData.TRT = (byte)float.Parse(items[2]);
                diagData.RPM = diagData.RPM40 = ushort.Parse(items[3]);
                diagData.RPM_XX = ushort.Parse(items[4]);
                diagData.UFRXX = byte.Parse(items[5]);
                diagData.SSM = byte.Parse(items[6]);
                diagData.TWAT = (sbyte)float.Parse(items[0]);
                diagData.AFR = float.Parse(items[1]);
                diagData.ALF = diagData.AFR / 14.7f;
                diagData.COEFF = float.Parse(items[7]);
                diagData.UOZ = (sbyte)float.Parse(items[8]);
                diagData.SPD = byte.Parse(items[9]);
                diagData.INJ = float.Parse(items[12]);
                diagData.AIR = float.Parse(items[13]);
                diagData.GBC = float.Parse(items[14]);
                diagData.fSTOP = items[19] == "1";
                diagData.fXX = items[20] == "1";
                diagData.fPOW = items[21] == "1";
                diagData.fFUELOFF = items[22] == "1";
                diagData.fLAMREG = items[23] == "1";
                diagData.fDETZONE = items[24] == "1";
                diagData.fADS = items[25] == "1";
                diagData.fLEARN = items[26] == "1";
                diagData.fLAMRDY = items[27] == "1";
                diagData.fLAMHEAT = items[28] == "1";
                diagData.fDET = items[33] == "1";
                diagData.fLAM = items[35] == "1";
            }
            catch { }

            return diagData;
        }

        private DiagData GetMatrixDiagData(string item)
        {
            throw new NotImplementedException();
        }

        private DiagData GetICDDiagData(string item)
        {
            var items = item.Split('\t');
            var diagData = new DiagData();

            try
            {
                diagData.Time = TimeSpan.FromSeconds(float.Parse(items[36]));
                diagData.TRT = (byte) float.Parse(items[2]);
                diagData.RPM = diagData.RPM40 = ushort.Parse(items[3]);
                diagData.RPM_XX = ushort.Parse(items[4]);
                diagData.UFRXX = byte.Parse(items[5]);
                diagData.SSM = byte.Parse(items[6]);
                diagData.TWAT = (sbyte) float.Parse(items[0]);                
                diagData.AFR = float.Parse(items[1]);
                diagData.ALF = diagData.AFR/14.7f;
                diagData.COEFF = float.Parse(items[7]);
                diagData.UOZ = (sbyte) float.Parse(items[8]);
                diagData.SPD = byte.Parse(items[9]);
                diagData.INJ = float.Parse(items[12]);
                diagData.AIR = float.Parse(items[13]);
                diagData.GBC = float.Parse(items[14]);
                diagData.fSTOP = items[19] == "1";
                diagData.fXX = items[20] == "1";
                diagData.fPOW = items[21] == "1";
                diagData.fFUELOFF = items[22] == "1";
                diagData.fLAMREG = items[23] == "1";
                diagData.fDETZONE = items[24] == "1";
                diagData.fADS = items[25] == "1";
                diagData.fLEARN = items[26] == "1";
                diagData.fLAMRDY = items[27] == "1";
                diagData.fLAMHEAT = items[28] == "1";
                diagData.fDET = items[33] == "1";
                diagData.fLAM = items[35] == "1";
            }
            catch{}

            return diagData;
        }

        private void rbMatrix_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

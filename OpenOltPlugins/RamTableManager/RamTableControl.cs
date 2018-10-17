using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CtpMaps;
using CtpMaps.DataTypes;
using Helper;

namespace RamTablePlugin
{
    internal partial class RamTableControl : UserControl
    {
        private CaptureManager captureManager;

        public RamTableControl()
        {
            
            InitializeComponent();            
        }
      
        public void Prepare(CaptureManager captureManager, CtpMap maps)
        {
            this.captureManager = captureManager;
            
            captureManager.OnCaptureTable += FirmwareManagerOnOnCaptureTable;
            captureManager.OnEnabledChange += CaptureManagerOnOnEnabledChange;
            captureManager.onlineManager.OltProtocol.OnConnect += OltProtocolOnConnect;
            captureManager.onlineManager.OltProtocol.OnDisconnect += OltProtocolOnConnect;
            ramTablesBS.DataSource =
                maps.Entries.Where(
                    item =>
                    (item.Entry2D != null && item.Entry2D.Convert.ExInfo.CaptureRamId != 0) ||
                    (item.Entry3D != null && item.Entry3D.Convert.ExInfo.CaptureRamId != 0));
            Enabled = captureManager.Enabled;
        }

        private void CaptureManagerOnOnEnabledChange(object sender, EventArgs e)
        {
            Enabled = captureManager.Enabled;
        }

        private void FirmwareManagerOnOnCaptureTable(object sender, EventArgs e)
        {
            if (captureManager.CapturedTable == null)
            {
                currentRam.Text = "отсутствует";
                currentRam.BackColor = Color.Gold;
            }
            else
            {
                currentRam.Text = captureManager.CapturedTable.Name;
                rtGrid.XLabel = captureManager.table.xUnits;
                rtGrid.YLabel = captureManager.table.Units;
                rtGrid.Max = captureManager.table.Max;
                rtGrid.Min = captureManager.table.Min;
                currentRam.BackColor = Color.Lime;
            }
        }

        private void OltProtocolOnConnect(object sender, EventArgs e)
        {
            rtGrid.ReadOnly = !captureManager.onlineManager.OltProtocol.Connected;
            btnCapture.Enabled = btnReturn.Enabled = btnRestore.Enabled = captureManager.onlineManager.OltProtocol.Connected;
        }       

        private void btnCapture_Click(object sender, EventArgs e)
        {
            var currentEntry = (MapEntry)ramTablesBS.Current;
            if (currentEntry == null) return;

            
            captureManager.CaptureTable(currentEntry, FindForm());
            rtGrid.Init(captureManager.table);
            rtGrid.FillPalette(captureManager.exInfo.SymmetricPalette
                                   ? PaletteHelper.GetSymmetric(captureManager.table.Min, captureManager.table.Max)
                                   : PaletteHelper.GetLinear(captureManager.table.Min, captureManager.table.Max));
            rtGrid.LoadGrid();  
            captureManager.SetCurrentIndex();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            captureManager.ReturnTable();
            rtGrid.Init(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            captureManager.RestoreTable(this);
            rtGrid.LoadGrid();
        }

        private void rtGrid_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "FollowTableRt" || !rtGrid.FollowTableRt) return;            
            captureManager.SetCurrentIndex();
            rtGrid.CalcAndSetCurrentCell();
        }

        private void ramTablesBS_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

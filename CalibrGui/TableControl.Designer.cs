namespace CalibrGui
{
    partial class TableControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableControl));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 29D);
            this.rtGrid = new System.Windows.Forms.DataGridView();
            this.editPanel = new System.Windows.Forms.Panel();
            this.toolStripEx = new Helper.ToolStripEx();
            this.followTableRtBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllBtn = new System.Windows.Forms.ToolStripButton();
            this.deselectAllBtn = new System.Windows.Forms.ToolStripButton();
            this.invertSelectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDec = new System.Windows.Forms.ToolStripButton();
            this.tsbInc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.offsetValue = new System.Windows.Forms.ToolStripTextBox();
            this.offsetBtn = new System.Windows.Forms.ToolStripButton();
            this.persentOffsetBtn = new System.Windows.Forms.ToolStripButton();
            this.setBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewSwitch = new System.Windows.Forms.ToolStripButton();
            this.RamChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.rtGrid)).BeginInit();
            this.editPanel.SuspendLayout();
            this.toolStripEx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RamChart)).BeginInit();
            this.SuspendLayout();
            // 
            // rtGrid
            // 
            this.rtGrid.AllowUserToAddRows = false;
            this.rtGrid.AllowUserToDeleteRows = false;
            this.rtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtGrid.Location = new System.Drawing.Point(0, 26);
            this.rtGrid.Name = "rtGrid";
            this.rtGrid.ReadOnly = true;
            this.rtGrid.RowHeadersWidth = 60;
            this.rtGrid.Size = new System.Drawing.Size(1280, 469);
            this.rtGrid.TabIndex = 0;
            this.rtGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.rtGrid_CellEndEdit);
            this.rtGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.rtGrid_CellPainting);
            this.rtGrid.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.rtGrid_CellParsing);
            this.rtGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.rtGrid_ColumnAdded);
            this.rtGrid.CurrentCellChanged += new System.EventHandler(this.rtGrid_CurrentCellChanged);
            this.rtGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.rtGrid_EditingControlShowing);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.toolStripEx);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.editPanel.Location = new System.Drawing.Point(0, 0);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(1280, 26);
            this.editPanel.TabIndex = 2;
            // 
            // toolStripEx
            // 
            this.toolStripEx.ClickThrough = true;
            this.toolStripEx.Enabled = false;
            this.toolStripEx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.followTableRtBtn,
            this.toolStripSeparator4,
            this.selectAllBtn,
            this.deselectAllBtn,
            this.invertSelectBtn,
            this.toolStripSeparator3,
            this.tsbDec,
            this.tsbInc,
            this.toolStripSeparator1,
            this.offsetValue,
            this.offsetBtn,
            this.persentOffsetBtn,
            this.setBtn,
            this.toolStripSeparator2,
            this.ViewSwitch});
            this.toolStripEx.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx.Name = "toolStripEx";
            this.toolStripEx.Size = new System.Drawing.Size(1280, 25);
            this.toolStripEx.TabIndex = 1;
            this.toolStripEx.Text = "toolStripEx1";
            // 
            // followTableRtBtn
            // 
            this.followTableRtBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.followTableRtBtn.Image = ((System.Drawing.Image)(resources.GetObject("followTableRtBtn.Image")));
            this.followTableRtBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.followTableRtBtn.Name = "followTableRtBtn";
            this.followTableRtBtn.Size = new System.Drawing.Size(23, 22);
            this.followTableRtBtn.Text = "Следить за рабочей точкой";
            this.followTableRtBtn.Click += new System.EventHandler(this.followTableRtBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectAllBtn.Image")));
            this.selectAllBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.selectAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(23, 22);
            this.selectAllBtn.Text = "Выделить все ячейки";
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // deselectAllBtn
            // 
            this.deselectAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deselectAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("deselectAllBtn.Image")));
            this.deselectAllBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deselectAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deselectAllBtn.Name = "deselectAllBtn";
            this.deselectAllBtn.Size = new System.Drawing.Size(23, 22);
            this.deselectAllBtn.Text = "Снять выделение";
            this.deselectAllBtn.Click += new System.EventHandler(this.deselectAllBtn_Click);
            // 
            // invertSelectBtn
            // 
            this.invertSelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.invertSelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("invertSelectBtn.Image")));
            this.invertSelectBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.invertSelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.invertSelectBtn.Name = "invertSelectBtn";
            this.invertSelectBtn.Size = new System.Drawing.Size(23, 22);
            this.invertSelectBtn.Text = "Обратить выделение";
            this.invertSelectBtn.Click += new System.EventHandler(this.invertSelectBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDec
            // 
            this.tsbDec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDec.Image = ((System.Drawing.Image)(resources.GetObject("tsbDec.Image")));
            this.tsbDec.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbDec.Name = "tsbDec";
            this.tsbDec.Size = new System.Drawing.Size(23, 22);
            this.tsbDec.Text = "Уменьшить выделенные ячейки (Shift - быстрое уменьшение)";
            this.tsbDec.Click += new System.EventHandler(this.tsbDec_Click);
            // 
            // tsbInc
            // 
            this.tsbInc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInc.Image = ((System.Drawing.Image)(resources.GetObject("tsbInc.Image")));
            this.tsbInc.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbInc.Name = "tsbInc";
            this.tsbInc.Size = new System.Drawing.Size(23, 22);
            this.tsbInc.Text = "Увеличить выделенные ячейки (Shift - быстрое увеличение)";
            this.tsbInc.Click += new System.EventHandler(this.tsbInc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // offsetValue
            // 
            this.offsetValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.offsetValue.Name = "offsetValue";
            this.offsetValue.Size = new System.Drawing.Size(40, 25);
            this.offsetValue.Text = "0";
            this.offsetValue.ToolTipText = "Значение для изменения выделенных ячеек";
            // 
            // offsetBtn
            // 
            this.offsetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.offsetBtn.Image = ((System.Drawing.Image)(resources.GetObject("offsetBtn.Image")));
            this.offsetBtn.ImageTransparentColor = System.Drawing.Color.Silver;
            this.offsetBtn.Name = "offsetBtn";
            this.offsetBtn.Size = new System.Drawing.Size(23, 22);
            this.offsetBtn.Text = "Изменить выделенные ячейки на заданное значение";
            this.offsetBtn.Click += new System.EventHandler(this.offsetBtn_Click);
            // 
            // persentOffsetBtn
            // 
            this.persentOffsetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.persentOffsetBtn.Image = ((System.Drawing.Image)(resources.GetObject("persentOffsetBtn.Image")));
            this.persentOffsetBtn.ImageTransparentColor = System.Drawing.Color.Silver;
            this.persentOffsetBtn.Name = "persentOffsetBtn";
            this.persentOffsetBtn.Size = new System.Drawing.Size(23, 22);
            this.persentOffsetBtn.Text = "Изменить выделенные ячейки на заданное значение в процентах";
            this.persentOffsetBtn.Click += new System.EventHandler(this.persentOffsetBtn_Click);
            // 
            // setBtn
            // 
            this.setBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setBtn.Image = ((System.Drawing.Image)(resources.GetObject("setBtn.Image")));
            this.setBtn.ImageTransparentColor = System.Drawing.Color.Silver;
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(23, 22);
            this.setBtn.Text = "Заполнить выделенные ячейки заданным значением";
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ViewSwitch
            // 
            this.ViewSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ViewSwitch.Image = ((System.Drawing.Image)(resources.GetObject("ViewSwitch.Image")));
            this.ViewSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewSwitch.Name = "ViewSwitch";
            this.ViewSwitch.Size = new System.Drawing.Size(23, 22);
            this.ViewSwitch.Text = "toolStripButton1";
            this.ViewSwitch.Click += new System.EventHandler(this.ViewSwitch_Click);
            // 
            // RamChart
            // 
            this.RamChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.RamChart.ChartAreas.Add(chartArea1);
            this.RamChart.Location = new System.Drawing.Point(0, 26);
            this.RamChart.Name = "RamChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.MarkerStep = 10;
            series1.Name = "Series1";
            dataPoint1.AxisLabel = "LABEL";
            dataPoint1.Color = System.Drawing.Color.Lime;
            series1.Points.Add(dataPoint1);
            this.RamChart.Series.Add(series1);
            this.RamChart.Size = new System.Drawing.Size(1280, 466);
            this.RamChart.TabIndex = 3;
            this.RamChart.Text = "chart1";
            this.RamChart.Visible = false;
            this.RamChart.Click += new System.EventHandler(this.RamChart_Click);
            this.RamChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RamChart_MouseDown);
            this.RamChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RamChart_MouseMove);
            this.RamChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RamChart_MouseUp);
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RamChart);
            this.Controls.Add(this.rtGrid);
            this.Controls.Add(this.editPanel);
            this.Name = "TableControl";
            this.Size = new System.Drawing.Size(1280, 495);
            ((System.ComponentModel.ISupportInitialize)(this.rtGrid)).EndInit();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.toolStripEx.ResumeLayout(false);
            this.toolStripEx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RamChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rtGrid;
        private Helper.ToolStripEx toolStripEx;
        private System.Windows.Forms.ToolStripButton tsbInc;
        private System.Windows.Forms.ToolStripButton tsbDec;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox offsetValue;
        private System.Windows.Forms.ToolStripButton offsetBtn;
        private System.Windows.Forms.ToolStripButton persentOffsetBtn;
        private System.Windows.Forms.ToolStripButton setBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton selectAllBtn;
        private System.Windows.Forms.ToolStripButton deselectAllBtn;
        private System.Windows.Forms.ToolStripButton invertSelectBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton followTableRtBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton ViewSwitch;
        private System.Windows.Forms.DataVisualization.Charting.Chart RamChart;
    }
}

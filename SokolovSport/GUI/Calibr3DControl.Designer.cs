namespace SokolovSport.GUI
{
    partial class Calibr3DControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calibr3DControl));
            this.calibrToolStrip = new System.Windows.Forms.ToolStrip();
            this.gridToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.surfaceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.calibr3DChart = new Gigasoft.ProEssentials.Pe3do();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.calibr1DChart = new Gigasoft.ProEssentials.Pesgo();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.calibrGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.calibrLabel = new System.Windows.Forms.Label();
            this.calibrInfo = new SokolovSport.GUI.CalibrInfo();
            this.calibrToolStrip.SuspendLayout();
            this.chartPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibrGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // calibrToolStrip
            // 
            this.calibrToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.calibrToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripButton,
            this.surfaceToolStripButton});
            this.calibrToolStrip.Location = new System.Drawing.Point(0, 0);
            this.calibrToolStrip.Name = "calibrToolStrip";
            this.calibrToolStrip.Size = new System.Drawing.Size(24, 493);
            this.calibrToolStrip.TabIndex = 2;
            // 
            // gridToolStripButton
            // 
            this.gridToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gridToolStripButton.Image = global::SokolovSport.Properties.Resources.grid;
            this.gridToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gridToolStripButton.Name = "gridToolStripButton";
            this.gridToolStripButton.Size = new System.Drawing.Size(21, 20);
            this.gridToolStripButton.Text = "Таблица";
            this.gridToolStripButton.Click += new System.EventHandler(this.gridToolStripButton_Click);
            // 
            // surfaceToolStripButton
            // 
            this.surfaceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.surfaceToolStripButton.Image = global::SokolovSport.Properties.Resources.chart;
            this.surfaceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.surfaceToolStripButton.Name = "surfaceToolStripButton";
            this.surfaceToolStripButton.Size = new System.Drawing.Size(21, 20);
            this.surfaceToolStripButton.Text = "3D поверхность";
            this.surfaceToolStripButton.Click += new System.EventHandler(this.surfaceToolStripButton_Click);
            // 
            // calibr3DChart
            // 
            this.calibr3DChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibr3DChart.Location = new System.Drawing.Point(0, 0);
            this.calibr3DChart.Name = "calibr3DChart";
            this.calibr3DChart.Size = new System.Drawing.Size(689, 359);
            this.calibr3DChart.TabIndex = 3;
            // 
            // chartPanel
            // 
            this.chartPanel.Controls.Add(this.calibr1DChart);
            this.chartPanel.Controls.Add(this.calibr3DChart);
            this.chartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel.Location = new System.Drawing.Point(24, 14);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(689, 359);
            this.chartPanel.TabIndex = 5;
            this.chartPanel.Visible = false;
            // 
            // calibr1DChart
            // 
            this.calibr1DChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibr1DChart.Location = new System.Drawing.Point(0, 0);
            this.calibr1DChart.Name = "calibr1DChart";
            this.calibr1DChart.Size = new System.Drawing.Size(689, 359);
            this.calibr1DChart.TabIndex = 4;
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.calibrGrid);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(24, 14);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(689, 359);
            this.gridPanel.TabIndex = 5;
            // 
            // calibrGrid
            // 
            this.calibrGrid.AllowEditing = false;
            this.calibrGrid.AutoGenerateColumns = false;
            this.calibrGrid.ColumnInfo = "2,1,0,0,0,95,Columns:";
            this.calibrGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrGrid.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.calibrGrid.Location = new System.Drawing.Point(0, 0);
            this.calibrGrid.Name = "calibrGrid";
            this.calibrGrid.Rows.Count = 2;
            this.calibrGrid.Rows.DefaultSize = 19;
            this.calibrGrid.Size = new System.Drawing.Size(689, 359);
            this.calibrGrid.StyleInfo = resources.GetString("calibrGrid.StyleInfo");
            this.calibrGrid.TabIndex = 5;
            this.calibrGrid.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.calibrGrid_AfterEdit);
            this.calibrGrid.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(this.calibrGrid_OwnerDrawCell);
            // 
            // calibrLabel
            // 
            this.calibrLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.calibrLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.calibrLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calibrLabel.ForeColor = System.Drawing.Color.White;
            this.calibrLabel.Location = new System.Drawing.Point(24, 0);
            this.calibrLabel.Name = "calibrLabel";
            this.calibrLabel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.calibrLabel.Size = new System.Drawing.Size(689, 14);
            this.calibrLabel.TabIndex = 6;
            this.calibrLabel.Text = "Калибровка";
            // 
            // calibrInfo
            // 
            this.calibrInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.calibrInfo.Location = new System.Drawing.Point(24, 373);
            this.calibrInfo.Name = "calibrInfo";
            this.calibrInfo.Padding = new System.Windows.Forms.Padding(2);
            this.calibrInfo.Size = new System.Drawing.Size(689, 120);
            this.calibrInfo.TabIndex = 6;
            // 
            // Calibr3DControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.calibrInfo);
            this.Controls.Add(this.calibrLabel);
            this.Controls.Add(this.calibrToolStrip);
            this.Name = "Calibr3DControl";
            this.Size = new System.Drawing.Size(713, 493);
            this.calibrToolStrip.ResumeLayout(false);
            this.calibrToolStrip.PerformLayout();
            this.chartPanel.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calibrGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip calibrToolStrip;
        private System.Windows.Forms.ToolStripButton gridToolStripButton;
        private System.Windows.Forms.ToolStripButton surfaceToolStripButton;
        private Gigasoft.ProEssentials.Pe3do calibr3DChart;
        private System.Windows.Forms.Panel chartPanel;
        private Gigasoft.ProEssentials.Pesgo calibr1DChart;
        private System.Windows.Forms.Label calibrLabel;
        private System.Windows.Forms.Panel gridPanel;
        private C1.Win.C1FlexGrid.C1FlexGrid calibrGrid;
        private CalibrInfo calibrInfo;
    }
}

namespace OpenOLT.GUI
{
    partial class RTGridPanel
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
            this.components = new System.ComponentModel.Container();
            this.rtGrid = new System.Windows.Forms.DataGridView();
            this.rtGridTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.currentRTLabel = new System.Windows.Forms.Label();
            this.cbCorrectionParams = new System.Windows.Forms.CheckBox();
            this.thrRtPersent = new System.Windows.Forms.Label();
            this.rpmThrRtIndex = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.smoothingFactor = new System.Windows.Forms.TextBox();
            this.btnSmoothing = new System.Windows.Forms.Button();
            this.btnGridChart = new System.Windows.Forms.Button();
            this.fuelTuning = new System.Windows.Forms.GroupBox();
            this.cbxFollowRT = new System.Windows.Forms.CheckBox();
            this.disableFuelCutoff = new System.Windows.Forms.CheckBox();
            this.rtValueType = new System.Windows.Forms.GroupBox();
            this.veValue = new System.Windows.Forms.CheckBox();
            this.gbcValue = new System.Windows.Forms.RadioButton();
            this.pcnValue = new System.Windows.Forms.RadioButton();
            this.rtToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rtGridFillProgressBar = new System.Windows.Forms.ProgressBar();
            this.rtChart = new Gigasoft.ProEssentials.Pe3do();
            this.hotSpotValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rtGrid)).BeginInit();
            this.rtGridTypeGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.fuelTuning.SuspendLayout();
            this.rtValueType.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtGrid
            // 
            this.rtGrid.AllowUserToAddRows = false;
            this.rtGrid.AllowUserToDeleteRows = false;
            this.rtGrid.AllowUserToResizeColumns = false;
            this.rtGrid.AllowUserToResizeRows = false;
            this.rtGrid.ColumnHeadersHeight = 20;
            this.rtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rtGrid.Location = new System.Drawing.Point(3, 73);
            this.rtGrid.Name = "rtGrid";
            this.rtGrid.ReadOnly = true;
            this.rtGrid.RowHeadersWidth = 60;
            this.rtGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.rtGrid.ShowCellErrors = false;
            this.rtGrid.ShowEditingIcon = false;
            this.rtGrid.ShowRowErrors = false;
            this.rtGrid.Size = new System.Drawing.Size(900, 394);
            this.rtGrid.TabIndex = 0;
            this.rtGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rtGrid_CellDoubleClick);
            this.rtGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.rtGrid_CellPainting);
            this.rtGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.rtGrid_ColumnAdded);
            // 
            // rtGridTypeGroupBox
            // 
            this.rtGridTypeGroupBox.Controls.Add(this.currentRTLabel);
            this.rtGridTypeGroupBox.Controls.Add(this.cbCorrectionParams);
            this.rtGridTypeGroupBox.Controls.Add(this.thrRtPersent);
            this.rtGridTypeGroupBox.Controls.Add(this.rpmThrRtIndex);
            this.rtGridTypeGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtGridTypeGroupBox.Location = new System.Drawing.Point(122, 3);
            this.rtGridTypeGroupBox.Name = "rtGridTypeGroupBox";
            this.rtGridTypeGroupBox.Size = new System.Drawing.Size(143, 65);
            this.rtGridTypeGroupBox.TabIndex = 1;
            this.rtGridTypeGroupBox.TabStop = false;
            this.rtGridTypeGroupBox.Text = " Сетка РТ: ";
            // 
            // currentRTLabel
            // 
            this.currentRTLabel.AutoSize = true;
            this.currentRTLabel.Location = new System.Drawing.Point(6, 42);
            this.currentRTLabel.Name = "currentRTLabel";
            this.currentRTLabel.Size = new System.Drawing.Size(48, 13);
            this.currentRTLabel.TabIndex = 7;
            this.currentRTLabel.Text = "[rpm][thr]";
            // 
            // cbCorrectionParams
            // 
            this.cbCorrectionParams.AutoSize = true;
            this.cbCorrectionParams.Location = new System.Drawing.Point(6, 19);
            this.cbCorrectionParams.Name = "cbCorrectionParams";
            this.cbCorrectionParams.Size = new System.Drawing.Size(134, 17);
            this.cbCorrectionParams.TabIndex = 6;
            this.cbCorrectionParams.Text = "Параметры обучения";
            this.cbCorrectionParams.UseVisualStyleBackColor = true;
            this.cbCorrectionParams.CheckedChanged += new System.EventHandler(this.pcnValue_CheckedChanged);
            // 
            // thrRtPersent
            // 
            this.thrRtPersent.AutoSize = true;
            this.thrRtPersent.Location = new System.Drawing.Point(91, 42);
            this.thrRtPersent.Name = "thrRtPersent";
            this.thrRtPersent.Size = new System.Drawing.Size(21, 13);
            this.thrRtPersent.TabIndex = 5;
            this.thrRtPersent.Text = "0%";
            this.rtToolTip.SetToolTip(this.thrRtPersent, "Процент заполнения сетки rpm/thr");
            // 
            // rpmThrRtIndex
            // 
            this.rpmThrRtIndex.AutoSize = true;
            this.rpmThrRtIndex.Location = new System.Drawing.Point(60, 42);
            this.rpmThrRtIndex.Name = "rpmThrRtIndex";
            this.rpmThrRtIndex.Size = new System.Drawing.Size(25, 13);
            this.rpmThrRtIndex.TabIndex = 2;
            this.rpmThrRtIndex.Text = "[00]";
            this.rtToolTip.SetToolTip(this.rpmThrRtIndex, "Номер рабочей точки rpm/thr");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.smoothingFactor);
            this.panel1.Controls.Add(this.btnSmoothing);
            this.panel1.Controls.Add(this.btnGridChart);
            this.panel1.Controls.Add(this.fuelTuning);
            this.panel1.Controls.Add(this.rtGridTypeGroupBox);
            this.panel1.Controls.Add(this.rtValueType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(905, 71);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(613, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 43);
            this.label2.TabIndex = 8;
            this.label2.Text = "A, W, S, D - перемещение по ячейкам\r\nL, K - увеличение/уменьшение значений\r\nShift" +
    " + L, K - быстрое увеличение/уменьшение\r\n";
            // 
            // smoothingFactor
            // 
            this.smoothingFactor.Location = new System.Drawing.Point(477, 14);
            this.smoothingFactor.Name = "smoothingFactor";
            this.smoothingFactor.Size = new System.Drawing.Size(35, 20);
            this.smoothingFactor.TabIndex = 7;
            this.smoothingFactor.Text = "4";
            this.rtToolTip.SetToolTip(this.smoothingFactor, "Коэффициент сглаживания");
            // 
            // btnSmoothing
            // 
            this.btnSmoothing.Location = new System.Drawing.Point(518, 14);
            this.btnSmoothing.Name = "btnSmoothing";
            this.btnSmoothing.Size = new System.Drawing.Size(64, 23);
            this.btnSmoothing.TabIndex = 6;
            this.btnSmoothing.Text = "Сгладить";
            this.btnSmoothing.UseVisualStyleBackColor = true;
            this.btnSmoothing.Click += new System.EventHandler(this.btnSmoothing_Click);
            // 
            // btnGridChart
            // 
            this.btnGridChart.Location = new System.Drawing.Point(477, 42);
            this.btnGridChart.Name = "btnGridChart";
            this.btnGridChart.Size = new System.Drawing.Size(122, 23);
            this.btnGridChart.TabIndex = 5;
            this.btnGridChart.Text = "Сетка / поверхность";
            this.btnGridChart.UseVisualStyleBackColor = true;
            this.btnGridChart.Click += new System.EventHandler(this.btnGridChart_Click);
            // 
            // fuelTuning
            // 
            this.fuelTuning.Controls.Add(this.cbxFollowRT);
            this.fuelTuning.Controls.Add(this.disableFuelCutoff);
            this.fuelTuning.Dock = System.Windows.Forms.DockStyle.Left;
            this.fuelTuning.Location = new System.Drawing.Point(265, 3);
            this.fuelTuning.Name = "fuelTuning";
            this.fuelTuning.Size = new System.Drawing.Size(200, 65);
            this.fuelTuning.TabIndex = 4;
            this.fuelTuning.TabStop = false;
            this.fuelTuning.Text = " Обучение топливоподачи: ";
            // 
            // cbxFollowRT
            // 
            this.cbxFollowRT.AutoSize = true;
            this.cbxFollowRT.Location = new System.Drawing.Point(6, 40);
            this.cbxFollowRT.Name = "cbxFollowRT";
            this.cbxFollowRT.Size = new System.Drawing.Size(100, 17);
            this.cbxFollowRT.TabIndex = 1;
            this.cbxFollowRT.Text = "Следить за РТ";
            this.cbxFollowRT.UseVisualStyleBackColor = true;
            this.cbxFollowRT.CheckedChanged += new System.EventHandler(this.cbxFollowRT_CheckedChanged);
            // 
            // disableFuelCutoff
            // 
            this.disableFuelCutoff.AutoSize = true;
            this.disableFuelCutoff.Location = new System.Drawing.Point(6, 17);
            this.disableFuelCutoff.Name = "disableFuelCutoff";
            this.disableFuelCutoff.Size = new System.Drawing.Size(184, 17);
            this.disableFuelCutoff.TabIndex = 0;
            this.disableFuelCutoff.Text = "Запрет отсечки топливоподачи";
            this.disableFuelCutoff.UseVisualStyleBackColor = true;
            this.disableFuelCutoff.Click += new System.EventHandler(this.disableFuelCutoff_Click);
            // 
            // rtValueType
            // 
            this.rtValueType.Controls.Add(this.veValue);
            this.rtValueType.Controls.Add(this.gbcValue);
            this.rtValueType.Controls.Add(this.pcnValue);
            this.rtValueType.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtValueType.Location = new System.Drawing.Point(3, 3);
            this.rtValueType.Name = "rtValueType";
            this.rtValueType.Size = new System.Drawing.Size(119, 65);
            this.rtValueType.TabIndex = 2;
            this.rtValueType.TabStop = false;
            this.rtValueType.Text = " Значения в сетке: ";
            // 
            // veValue
            // 
            this.veValue.AutoSize = true;
            this.veValue.Checked = true;
            this.veValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.veValue.Location = new System.Drawing.Point(73, 18);
            this.veValue.Name = "veValue";
            this.veValue.Size = new System.Drawing.Size(40, 17);
            this.veValue.TabIndex = 5;
            this.veValue.Text = "VE";
            this.veValue.UseVisualStyleBackColor = true;
            this.veValue.CheckStateChanged += new System.EventHandler(this.veValue_CheckStateChanged);
            // 
            // gbcValue
            // 
            this.gbcValue.AutoSize = true;
            this.gbcValue.Location = new System.Drawing.Point(6, 40);
            this.gbcValue.Name = "gbcValue";
            this.gbcValue.Size = new System.Drawing.Size(48, 17);
            this.gbcValue.TabIndex = 4;
            this.gbcValue.Text = "БЦН";
            this.gbcValue.UseVisualStyleBackColor = true;
            this.gbcValue.CheckedChanged += new System.EventHandler(this.pcnValue_CheckedChanged);
            // 
            // pcnValue
            // 
            this.pcnValue.AutoSize = true;
            this.pcnValue.Checked = true;
            this.pcnValue.Location = new System.Drawing.Point(6, 17);
            this.pcnValue.Name = "pcnValue";
            this.pcnValue.Size = new System.Drawing.Size(49, 17);
            this.pcnValue.TabIndex = 3;
            this.pcnValue.TabStop = true;
            this.pcnValue.Text = "ПЦН";
            this.pcnValue.UseVisualStyleBackColor = true;
            this.pcnValue.CheckedChanged += new System.EventHandler(this.pcnValue_CheckedChanged);
            // 
            // rtGridFillProgressBar
            // 
            this.rtGridFillProgressBar.Location = new System.Drawing.Point(3, 473);
            this.rtGridFillProgressBar.Name = "rtGridFillProgressBar";
            this.rtGridFillProgressBar.Size = new System.Drawing.Size(902, 23);
            this.rtGridFillProgressBar.TabIndex = 3;
            // 
            // rtChart
            // 
            this.rtChart.Location = new System.Drawing.Point(3, 73);
            this.rtChart.Name = "rtChart";
            this.rtChart.Size = new System.Drawing.Size(894, 394);
            this.rtChart.TabIndex = 4;
            this.rtChart.Visible = false;
            this.rtChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rtChart_MouseMove);
            // 
            // hotSpotValue
            // 
            this.hotSpotValue.AutoSize = true;
            this.hotSpotValue.Location = new System.Drawing.Point(6, 428);
            this.hotSpotValue.Name = "hotSpotValue";
            this.hotSpotValue.Size = new System.Drawing.Size(0, 13);
            this.hotSpotValue.TabIndex = 5;
            // 
            // RTGridPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.hotSpotValue);
            this.Controls.Add(this.rtGridFillProgressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtGrid);
            this.Controls.Add(this.rtChart);
            this.Name = "RTGridPanel";
            this.Size = new System.Drawing.Size(905, 510);
            ((System.ComponentModel.ISupportInitialize)(this.rtGrid)).EndInit();
            this.rtGridTypeGroupBox.ResumeLayout(false);
            this.rtGridTypeGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.fuelTuning.ResumeLayout(false);
            this.fuelTuning.PerformLayout();
            this.rtValueType.ResumeLayout(false);
            this.rtValueType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rtGrid;
        private System.Windows.Forms.GroupBox rtGridTypeGroupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label rpmThrRtIndex;
        private System.Windows.Forms.ToolTip rtToolTip;
        private System.Windows.Forms.ProgressBar rtGridFillProgressBar;
        private System.Windows.Forms.Label thrRtPersent;
        private System.Windows.Forms.GroupBox rtValueType;
        private System.Windows.Forms.RadioButton gbcValue;
        private System.Windows.Forms.RadioButton pcnValue;
        private System.Windows.Forms.GroupBox fuelTuning;
        private System.Windows.Forms.CheckBox disableFuelCutoff;
        private Gigasoft.ProEssentials.Pe3do rtChart;
        private System.Windows.Forms.Button btnGridChart;
        private System.Windows.Forms.Button btnSmoothing;
        private System.Windows.Forms.TextBox smoothingFactor;
        private System.Windows.Forms.CheckBox cbCorrectionParams;
        private System.Windows.Forms.Label currentRTLabel;
        private System.Windows.Forms.CheckBox cbxFollowRT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label hotSpotValue;
        private System.Windows.Forms.CheckBox veValue;
    }
}

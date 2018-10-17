namespace OpenOLT.GUI
{
    partial class DiagChartPanel
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
            this.diagChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartToolStrip = new System.Windows.Forms.ToolStrip();
            this.openLogStripButton = new System.Windows.Forms.ToolStripButton();
            this.chartsSetPanelStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.incScaleStripButton = new System.Windows.Forms.ToolStripButton();
            this.decScaleStripButton = new System.Windows.Forms.ToolStripButton();
            this.priorFrameStripButton = new System.Windows.Forms.ToolStripButton();
            this.nextFrameStripButton = new System.Windows.Forms.ToolStripButton();
            this.openLogToolButton = new System.Windows.Forms.ToolStripButton();
            this.actionList = new Crad.Windows.Forms.Actions.ActionList();
            this.openLogAction = new Crad.Windows.Forms.Actions.Action();
            this.chartsSetPanelAction = new Crad.Windows.Forms.Actions.Action();
            this.openChartsAction = new Crad.Windows.Forms.Actions.Action();
            this.incScaleAction = new Crad.Windows.Forms.Actions.Action();
            this.decScaleAction = new Crad.Windows.Forms.Actions.Action();
            this.priorFrameAction = new Crad.Windows.Forms.Actions.Action();
            this.nextFrameAction = new Crad.Windows.Forms.Actions.Action();
            this.firstFrameAction = new Crad.Windows.Forms.Actions.Action();
            this.lastFrameAction = new Crad.Windows.Forms.Actions.Action();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.chartsSet = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.diagChart)).BeginInit();
            this.chartToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).BeginInit();
            this.chartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagChart
            // 
            this.diagChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagChart.Location = new System.Drawing.Point(0, 0);
            this.diagChart.Name = "diagChart";
            this.diagChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.diagChart.Size = new System.Drawing.Size(827, 673);
            this.diagChart.TabIndex = 0;
            this.diagChart.CursorPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.diagChart_CursorPositionChanging);
            this.diagChart.Resize += new System.EventHandler(this.diagChart_Resize);
            // 
            // chartToolStrip
            // 
            this.chartToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogStripButton,
            this.chartsSetPanelStripButton,
            this.toolStripButton1,
            this.incScaleStripButton,
            this.decScaleStripButton,
            this.priorFrameStripButton,
            this.nextFrameStripButton});
            this.chartToolStrip.Location = new System.Drawing.Point(0, 0);
            this.chartToolStrip.Name = "chartToolStrip";
            this.chartToolStrip.Size = new System.Drawing.Size(32, 673);
            this.chartToolStrip.TabIndex = 1;
            this.chartToolStrip.Text = "toolStrip1";
            // 
            // openLogStripButton
            // 
            this.actionList.SetAction(this.openLogStripButton, this.openLogAction);
            this.openLogStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openLogStripButton.Image = global::OpenOLT.Properties.Resources.open_log;
            this.openLogStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openLogStripButton.Name = "openLogStripButton";
            this.openLogStripButton.Size = new System.Drawing.Size(29, 20);
            this.openLogStripButton.Text = "Открыть лог файл";
            // 
            // chartsSetPanelStripButton
            // 
            this.actionList.SetAction(this.chartsSetPanelStripButton, this.chartsSetPanelAction);
            this.chartsSetPanelStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chartsSetPanelStripButton.Image = global::OpenOLT.Properties.Resources.chart_curve_go;
            this.chartsSetPanelStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chartsSetPanelStripButton.Name = "chartsSetPanelStripButton";
            this.chartsSetPanelStripButton.Size = new System.Drawing.Size(29, 20);
            this.chartsSetPanelStripButton.Text = "Показать/скрыть список параметров";
            // 
            // toolStripButton1
            // 
            this.actionList.SetAction(this.toolStripButton1, this.openChartsAction);
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::OpenOLT.Properties.Resources.chart_line_edit;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripButton1.Text = "Открыть набор графиков";
            // 
            // incScaleStripButton
            // 
            this.actionList.SetAction(this.incScaleStripButton, this.incScaleAction);
            this.incScaleStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.incScaleStripButton.Image = global::OpenOLT.Properties.Resources.incScale;
            this.incScaleStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.incScaleStripButton.Name = "incScaleStripButton";
            this.incScaleStripButton.Size = new System.Drawing.Size(29, 20);
            this.incScaleStripButton.Text = "Уже";
            // 
            // decScaleStripButton
            // 
            this.actionList.SetAction(this.decScaleStripButton, this.decScaleAction);
            this.decScaleStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.decScaleStripButton.Image = global::OpenOLT.Properties.Resources.decScale;
            this.decScaleStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decScaleStripButton.Name = "decScaleStripButton";
            this.decScaleStripButton.Size = new System.Drawing.Size(29, 20);
            this.decScaleStripButton.Text = "Шире";
            // 
            // priorFrameStripButton
            // 
            this.actionList.SetAction(this.priorFrameStripButton, this.priorFrameAction);
            this.priorFrameStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.priorFrameStripButton.Image = global::OpenOLT.Properties.Resources.page_left;
            this.priorFrameStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.priorFrameStripButton.Name = "priorFrameStripButton";
            this.priorFrameStripButton.Size = new System.Drawing.Size(29, 20);
            this.priorFrameStripButton.Text = "Предыдущий кадр";
            // 
            // nextFrameStripButton
            // 
            this.actionList.SetAction(this.nextFrameStripButton, this.nextFrameAction);
            this.nextFrameStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextFrameStripButton.Image = global::OpenOLT.Properties.Resources.page_right;
            this.nextFrameStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextFrameStripButton.Name = "nextFrameStripButton";
            this.nextFrameStripButton.Size = new System.Drawing.Size(29, 20);
            this.nextFrameStripButton.Text = "Следующий кадр";
            // 
            // openLogToolButton
            // 
            this.actionList.SetAction(this.openLogToolButton, this.openLogAction);
            this.openLogToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openLogToolButton.Image = global::OpenOLT.Properties.Resources.open_log;
            this.openLogToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openLogToolButton.Name = "openLogToolButton";
            this.openLogToolButton.Size = new System.Drawing.Size(21, 20);
            this.openLogToolButton.Text = "Открыть лог файл";
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.openLogAction);
            this.actionList.Actions.Add(this.openChartsAction);
            this.actionList.Actions.Add(this.incScaleAction);
            this.actionList.Actions.Add(this.decScaleAction);
            this.actionList.Actions.Add(this.nextFrameAction);
            this.actionList.Actions.Add(this.priorFrameAction);
            this.actionList.Actions.Add(this.firstFrameAction);
            this.actionList.Actions.Add(this.lastFrameAction);
            this.actionList.Actions.Add(this.chartsSetPanelAction);
            this.actionList.ContainerControl = this;
            // 
            // openLogAction
            // 
            this.openLogAction.Image = global::OpenOLT.Properties.Resources.open_log;
            this.openLogAction.Tag = null;
            this.openLogAction.Text = "Открыть лог файл";
            this.openLogAction.ToolTipText = "Открыть лог файл";
            this.openLogAction.Execute += new System.EventHandler(this.openLogAction_Execute);
            this.openLogAction.Update += new System.EventHandler(this.OfflineAction_Update);
            // 
            // chartsSetPanelAction
            // 
            this.chartsSetPanelAction.Image = global::OpenOLT.Properties.Resources.chart_curve_go;
            this.chartsSetPanelAction.Tag = null;
            this.chartsSetPanelAction.Text = "Показать/скрыть список параметров";
            this.chartsSetPanelAction.ToolTipText = "Показать/скрыть список параметров";
            this.chartsSetPanelAction.Execute += new System.EventHandler(this.chartsSetPanelAction_Execute);
            this.chartsSetPanelAction.Update += new System.EventHandler(this.chartsSetPanelAction_Update);
            // 
            // openChartsAction
            // 
            this.openChartsAction.Image = global::OpenOLT.Properties.Resources.chart_line_edit;
            this.openChartsAction.Tag = null;
            this.openChartsAction.Text = "Открыть набор графиков";
            this.openChartsAction.ToolTipText = "Открыть набор графиков";
            this.openChartsAction.Execute += new System.EventHandler(this.openChartsAction_Execute);
            // 
            // incScaleAction
            // 
            this.incScaleAction.Image = global::OpenOLT.Properties.Resources.incScale;
            this.incScaleAction.Tag = null;
            this.incScaleAction.Text = "Уже";
            this.incScaleAction.ToolTipText = "Уже";
            this.incScaleAction.Execute += new System.EventHandler(this.incScaleAction_Execute);
            // 
            // decScaleAction
            // 
            this.decScaleAction.Image = global::OpenOLT.Properties.Resources.decScale;
            this.decScaleAction.Tag = null;
            this.decScaleAction.Text = "Шире";
            this.decScaleAction.ToolTipText = "Шире";
            this.decScaleAction.Execute += new System.EventHandler(this.decScaleAction_Execute);
            // 
            // priorFrameAction
            // 
            this.priorFrameAction.Image = global::OpenOLT.Properties.Resources.page_left;
            this.priorFrameAction.Tag = null;
            this.priorFrameAction.Text = "Предыдущий кадр";
            this.priorFrameAction.ToolTipText = "Предыдущий кадр";
            this.priorFrameAction.Execute += new System.EventHandler(this.priorFrameAction_Execute);
            this.priorFrameAction.Update += new System.EventHandler(this.OfflineAction_Update);
            // 
            // nextFrameAction
            // 
            this.nextFrameAction.Image = global::OpenOLT.Properties.Resources.page_right;
            this.nextFrameAction.Tag = null;
            this.nextFrameAction.Text = "Следующий кадр";
            this.nextFrameAction.ToolTipText = "Следующий кадр";
            this.nextFrameAction.Execute += new System.EventHandler(this.nextFrameAction_Execute);
            this.nextFrameAction.Update += new System.EventHandler(this.OfflineAction_Update);
            // 
            // firstFrameAction
            // 
            this.firstFrameAction.Tag = null;
            this.firstFrameAction.Text = "Первый кадр";
            this.firstFrameAction.ToolTipText = "Первый кадр";
            // 
            // lastFrameAction
            // 
            this.lastFrameAction.Tag = null;
            this.lastFrameAction.Text = "Последний кадр";
            this.lastFrameAction.ToolTipText = "Последний кадр";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Лог файлы|*.txt|Все файлы|*.*";
            // 
            // chartPanel
            // 
            this.chartPanel.AutoScroll = true;
            this.chartPanel.Controls.Add(this.diagChart);
            this.chartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel.Location = new System.Drawing.Point(184, 0);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(827, 673);
            this.chartPanel.TabIndex = 2;
            // 
            // chartsSet
            // 
            this.chartsSet.CheckOnClick = true;
            this.chartsSet.ColumnWidth = 150;
            this.chartsSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartsSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartsSet.FormattingEnabled = true;
            this.chartsSet.Location = new System.Drawing.Point(32, 0);
            this.chartsSet.MultiColumn = true;
            this.chartsSet.Name = "chartsSet";
            this.chartsSet.Size = new System.Drawing.Size(152, 673);
            this.chartsSet.TabIndex = 3;
            this.chartsSet.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chartsSet_ItemCheck);
            // 
            // DiagChartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.chartsSet);
            this.Controls.Add(this.chartToolStrip);
            this.Name = "DiagChartPanel";
            this.Size = new System.Drawing.Size(1011, 673);
            ((System.ComponentModel.ISupportInitialize)(this.diagChart)).EndInit();
            this.chartToolStrip.ResumeLayout(false);
            this.chartToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).EndInit();
            this.chartPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart diagChart;
        private System.Windows.Forms.ToolStrip chartToolStrip;
        private System.Windows.Forms.ToolStripButton openLogToolButton;
        private Crad.Windows.Forms.Actions.ActionList actionList;
        private Crad.Windows.Forms.Actions.Action openLogAction;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton openLogStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Crad.Windows.Forms.Actions.Action openChartsAction;
        private Crad.Windows.Forms.Actions.Action incScaleAction;
        private Crad.Windows.Forms.Actions.Action decScaleAction;
        private Crad.Windows.Forms.Actions.Action nextFrameAction;
        private Crad.Windows.Forms.Actions.Action priorFrameAction;
        private Crad.Windows.Forms.Actions.Action firstFrameAction;
        private Crad.Windows.Forms.Actions.Action lastFrameAction;
        private System.Windows.Forms.ToolStripButton incScaleStripButton;
        private System.Windows.Forms.ToolStripButton decScaleStripButton;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.ToolStripButton priorFrameStripButton;
        private System.Windows.Forms.ToolStripButton nextFrameStripButton;
        private System.Windows.Forms.CheckedListBox chartsSet;
        private System.Windows.Forms.ToolStripButton chartsSetPanelStripButton;
        private Crad.Windows.Forms.Actions.Action chartsSetPanelAction;
    }
}

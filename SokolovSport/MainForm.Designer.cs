namespace SokolovSport
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.commands = new C1.Win.C1Command.C1CommandHolder();
            this.fileMenu = new C1.Win.C1Command.C1CommandMenu();
            this.openDatFileLink = new C1.Win.C1Command.C1CommandLink();
            this.openDatFileCommand = new C1.Win.C1Command.C1Command();
            this.openOptionsDialogLink = new C1.Win.C1Command.C1CommandLink();
            this.openOptionsDialogCommand = new C1.Win.C1Command.C1Command();
            this.startCommunicationCommand = new C1.Win.C1Command.C1Command();
            this.stopCommunicationCommand = new C1.Win.C1Command.C1Command();
            this.communicationMenu = new C1.Win.C1Command.C1CommandMenu();
            this.startCommunicationLink = new C1.Win.C1Command.C1CommandLink();
            this.stopCommunicationLink = new C1.Win.C1Command.C1CommandLink();
            this.openedDatFilesCommandControl = new C1.Win.C1Command.C1CommandControl();
            this.openedDatFilesComboBox = new System.Windows.Forms.ComboBox();
            this.readCurrentCalibrCommand = new C1.Win.C1Command.C1Command();
            this.writeCurrentCalibrCommand = new C1.Win.C1Command.C1Command();
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.leftTabs = new C1.Win.C1Command.C1DockingTab();
            this.calibrListTabPage = new C1.Win.C1Command.C1DockingTabPage();
            this.calibrGridView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.calibrationsBS = new System.Windows.Forms.BindingSource(this.components);
            this.leftCommandDock = new C1.Win.C1Command.C1CommandDock();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.valuesPanel = new System.Windows.Forms.Panel();
            this.graphsPanel = new System.Windows.Forms.Panel();
            this.calibrControl = new SokolovSport.GUI.Calibr3DControl();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.versionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stateStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolBar = new C1.Win.C1Command.C1ToolBar();
            this.openDatFileButton = new C1.Win.C1Command.C1CommandLink();
            this.openOptionsDialogButton = new C1.Win.C1Command.C1CommandLink();
            this.startCommunicationButton = new C1.Win.C1Command.C1CommandLink();
            this.stopCommunicationButton = new C1.Win.C1Command.C1CommandLink();
            this.readCurrentCalibrButton = new C1.Win.C1Command.C1CommandLink();
            this.writeCurrentCalibrButton = new C1.Win.C1Command.C1CommandLink();
            this.openedDatFilesLink = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            ((System.ComponentModel.ISupportInitialize)(this.commands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTabs)).BeginInit();
            this.leftTabs.SuspendLayout();
            this.calibrListTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibrGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calibrationsBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftCommandDock)).BeginInit();
            this.leftCommandDock.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.mainToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "dat файлы|*.dat|Все файлы|*.*";
            // 
            // commands
            // 
            this.commands.Commands.Add(this.fileMenu);
            this.commands.Commands.Add(this.openDatFileCommand);
            this.commands.Commands.Add(this.openOptionsDialogCommand);
            this.commands.Commands.Add(this.startCommunicationCommand);
            this.commands.Commands.Add(this.stopCommunicationCommand);
            this.commands.Commands.Add(this.communicationMenu);
            this.commands.Commands.Add(this.openedDatFilesCommandControl);
            this.commands.Commands.Add(this.readCurrentCalibrCommand);
            this.commands.Commands.Add(this.writeCurrentCalibrCommand);
            this.commands.ImageList = this.mainImageList;
            this.commands.Owner = this;
            this.commands.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // fileMenu
            // 
            this.fileMenu.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.openDatFileLink,
            this.openOptionsDialogLink});
            this.fileMenu.HideNonRecentLinks = false;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.ShowToolTips = true;
            this.fileMenu.Text = "Файл";
            this.fileMenu.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // openDatFileLink
            // 
            this.openDatFileLink.Command = this.openDatFileCommand;
            // 
            // openDatFileCommand
            // 
            this.openDatFileCommand.ImageIndex = 0;
            this.openDatFileCommand.Name = "openDatFileCommand";
            this.openDatFileCommand.Text = "Открыть dat";
            this.openDatFileCommand.Click += new C1.Win.C1Command.ClickEventHandler(this.openDatFileCommand_Click);
            this.openDatFileCommand.CommandStateQuery += new C1.Win.C1Command.CommandStateQueryEventHandler(this.openDatFileCommand_CommandStateQuery);
            // 
            // openOptionsDialogLink
            // 
            this.openOptionsDialogLink.Command = this.openOptionsDialogCommand;
            this.openOptionsDialogLink.SortOrder = 1;
            // 
            // openOptionsDialogCommand
            // 
            this.openOptionsDialogCommand.ImageIndex = 1;
            this.openOptionsDialogCommand.Name = "openOptionsDialogCommand";
            this.openOptionsDialogCommand.Text = "Настройки";
            this.openOptionsDialogCommand.ToolTipText = "Ооткрыть диалог настроек";
            this.openOptionsDialogCommand.Click += new C1.Win.C1Command.ClickEventHandler(this.openOptionsDialogCommand_Click);
            // 
            // startCommunicationCommand
            // 
            this.startCommunicationCommand.Name = "startCommunicationCommand";
            this.startCommunicationCommand.Text = "Соединение";
            this.startCommunicationCommand.ToolTipText = "Подключиться к ЭБУ";
            this.startCommunicationCommand.Click += new C1.Win.C1Command.ClickEventHandler(this.startCommunicationCommand_Click);
            this.startCommunicationCommand.CommandStateQuery += new C1.Win.C1Command.CommandStateQueryEventHandler(this.startCommunicationCommand_CommandStateQuery);
            // 
            // stopCommunicationCommand
            // 
            this.stopCommunicationCommand.Name = "stopCommunicationCommand";
            this.stopCommunicationCommand.Text = "Отключение";
            this.stopCommunicationCommand.ToolTipText = "Отключиться от ЭБУ";
            this.stopCommunicationCommand.Click += new C1.Win.C1Command.ClickEventHandler(this.stopCommunicationCommand_Click);
            this.stopCommunicationCommand.CommandStateQuery += new C1.Win.C1Command.CommandStateQueryEventHandler(this.stopCommunicationCommand_CommandStateQuery);
            // 
            // communicationMenu
            // 
            this.communicationMenu.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.startCommunicationLink,
            this.stopCommunicationLink});
            this.communicationMenu.HideNonRecentLinks = false;
            this.communicationMenu.Name = "communicationMenu";
            this.communicationMenu.ShowToolTips = true;
            this.communicationMenu.Text = "Связь";
            this.communicationMenu.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // startCommunicationLink
            // 
            this.startCommunicationLink.Command = this.startCommunicationCommand;
            // 
            // stopCommunicationLink
            // 
            this.stopCommunicationLink.Command = this.stopCommunicationCommand;
            this.stopCommunicationLink.SortOrder = 1;
            // 
            // openedDatFilesCommandControl
            // 
            this.openedDatFilesCommandControl.Control = this.openedDatFilesComboBox;
            this.openedDatFilesCommandControl.Name = "openedDatFilesCommandControl";
            this.openedDatFilesCommandControl.Text = "Последние dat файлы";
            this.openedDatFilesCommandControl.ToolTipText = "Список последних открываемых dat файлов";
            this.openedDatFilesCommandControl.CommandStateQuery += new C1.Win.C1Command.CommandStateQueryEventHandler(this.openedDatFilesCommandControl_CommandStateQuery);
            // 
            // openedDatFilesComboBox
            // 
            this.openedDatFilesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.openedDatFilesComboBox.FormattingEnabled = true;
            this.openedDatFilesComboBox.Location = new System.Drawing.Point(261, 4);
            this.openedDatFilesComboBox.MaxDropDownItems = 20;
            this.openedDatFilesComboBox.Name = "openedDatFilesComboBox";
            this.openedDatFilesComboBox.Size = new System.Drawing.Size(448, 21);
            this.openedDatFilesComboBox.TabIndex = 1;
            this.openedDatFilesComboBox.SelectionChangeCommitted += new System.EventHandler(this.openedDatFilesComboBox_SelectionChangeCommitted);
            // 
            // readCurrentCalibrCommand
            // 
            this.readCurrentCalibrCommand.ImageIndex = 2;
            this.readCurrentCalibrCommand.Name = "readCurrentCalibrCommand";
            this.readCurrentCalibrCommand.Text = "Прочитать калибровку";
            this.readCurrentCalibrCommand.ToolTipText = "Прочитать текущую калибровку из ЭБУ";
            this.readCurrentCalibrCommand.Click += new C1.Win.C1Command.ClickEventHandler(this.readCurrentCalibrCommand_Click);
            this.readCurrentCalibrCommand.CommandStateQuery += new C1.Win.C1Command.CommandStateQueryEventHandler(this.readWriteCurrentCalibrCommand_CommandStateQuery);
            // 
            // writeCurrentCalibrCommand
            // 
            this.writeCurrentCalibrCommand.ImageIndex = 3;
            this.writeCurrentCalibrCommand.Name = "writeCurrentCalibrCommand";
            this.writeCurrentCalibrCommand.Text = "Записать калибровку";
            this.writeCurrentCalibrCommand.ToolTipText = "Записать текущую калибровку в ЭБУ";
            this.writeCurrentCalibrCommand.Click += new C1.Win.C1Command.ClickEventHandler(this.writeCurrentCalibrCommand_Click);
            this.writeCurrentCalibrCommand.CommandStateQuery += new C1.Win.C1Command.CommandStateQueryEventHandler(this.readWriteCurrentCalibrCommand_CommandStateQuery);
            // 
            // mainImageList
            // 
            this.mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList.ImageStream")));
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList.Images.SetKeyName(0, "Open.ico");
            this.mainImageList.Images.SetKeyName(1, "tools.ico");
            this.mainImageList.Images.SetKeyName(2, "read1.png");
            this.mainImageList.Images.SetKeyName(3, "write1.png");
            // 
            // leftTabs
            // 
            this.leftTabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.leftTabs.AutoHiding = true;
            this.leftTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftTabs.CanAutoHide = true;
            this.leftTabs.Controls.Add(this.calibrListTabPage);
            this.leftTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftTabs.Location = new System.Drawing.Point(0, 0);
            this.leftTabs.Name = "leftTabs";
            this.leftTabs.ShowCaption = true;
            this.leftTabs.ShowToolTips = true;
            this.leftTabs.Size = new System.Drawing.Size(508, 659);
            this.leftTabs.TabIndex = 2;
            this.leftTabs.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.leftTabs.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2010;
            this.leftTabs.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // calibrListTabPage
            // 
            this.calibrListTabPage.CaptionVisible = true;
            this.calibrListTabPage.Controls.Add(this.calibrGridView);
            this.calibrListTabPage.Location = new System.Drawing.Point(1, 1);
            this.calibrListTabPage.Name = "calibrListTabPage";
            this.calibrListTabPage.Size = new System.Drawing.Size(503, 634);
            this.calibrListTabPage.TabIndex = 3;
            this.calibrListTabPage.TabStop = false;
            this.calibrListTabPage.Text = "Калибровки";
            // 
            // calibrGridView
            // 
            this.calibrGridView.AutoGenerateColumns = false;
            this.calibrGridView.ColumnInfo = resources.GetString("calibrGridView.ColumnInfo");
            this.calibrGridView.DataSource = this.calibrationsBS;
            this.calibrGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrGridView.Location = new System.Drawing.Point(0, 20);
            this.calibrGridView.Name = "calibrGridView";
            this.calibrGridView.Rows.Count = 1;
            this.calibrGridView.Rows.DefaultSize = 19;
            this.calibrGridView.Size = new System.Drawing.Size(503, 614);
            this.calibrGridView.TabIndex = 0;
            // 
            // calibrationsBS
            // 
            this.calibrationsBS.DataSource = typeof(SokolovSport.Dat.CalibrItem);
            this.calibrationsBS.CurrentChanged += new System.EventHandler(this.calibrationsBS_CurrentChanged);
            // 
            // leftCommandDock
            // 
            this.leftCommandDock.Controls.Add(this.leftTabs);
            this.leftCommandDock.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftCommandDock.Id = 1;
            this.leftCommandDock.Location = new System.Drawing.Point(0, 29);
            this.leftCommandDock.Name = "leftCommandDock";
            this.leftCommandDock.Size = new System.Drawing.Size(508, 659);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.valuesPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.graphsPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.calibrControl, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(508, 29);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(742, 659);
            this.mainTableLayoutPanel.TabIndex = 3;
            // 
            // valuesPanel
            // 
            this.valuesPanel.AutoScroll = true;
            this.valuesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuesPanel.Location = new System.Drawing.Point(3, 3);
            this.valuesPanel.Name = "valuesPanel";
            this.valuesPanel.Size = new System.Drawing.Size(1, 653);
            this.valuesPanel.TabIndex = 0;
            this.valuesPanel.TabStop = true;
            // 
            // graphsPanel
            // 
            this.graphsPanel.AutoScroll = true;
            this.mainTableLayoutPanel.SetColumnSpan(this.graphsPanel, 2);
            this.graphsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphsPanel.Location = new System.Drawing.Point(3, 662);
            this.graphsPanel.Name = "graphsPanel";
            this.graphsPanel.Size = new System.Drawing.Size(736, 1);
            this.graphsPanel.TabIndex = 1;
            this.graphsPanel.TabStop = true;
            // 
            // calibrControl
            // 
            this.calibrControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrControl.Location = new System.Drawing.Point(3, 3);
            this.calibrControl.Name = "calibrControl";
            this.calibrControl.Size = new System.Drawing.Size(736, 653);
            this.calibrControl.TabIndex = 1;
            this.calibrControl.OnCalibrEdit += new System.EventHandler<SokolovSport.GUI.CalibrEditArgs>(this.calibrControl_OnCalibrEdit);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionStatusLabel,
            this.linkStatusLabel,
            this.stateStatusLabel,
            this.connectedStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 688);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1250, 24);
            this.mainStatusStrip.TabIndex = 7;
            // 
            // versionStatusLabel
            // 
            this.versionStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.versionStatusLabel.Name = "versionStatusLabel";
            this.versionStatusLabel.Size = new System.Drawing.Size(41, 19);
            this.versionStatusLabel.Text = "vNext";
            // 
            // linkStatusLabel
            // 
            this.linkStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.linkStatusLabel.IsLink = true;
            this.linkStatusLabel.Name = "linkStatusLabel";
            this.linkStatusLabel.Size = new System.Drawing.Size(121, 19);
            this.linkStatusLabel.Text = "http://ecusystems.ru";
            this.linkStatusLabel.Click += new System.EventHandler(this.linkStatusLabel_Click);
            // 
            // stateStatusLabel
            // 
            this.stateStatusLabel.BackColor = System.Drawing.Color.Gold;
            this.stateStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stateStatusLabel.Name = "stateStatusLabel";
            this.stateStatusLabel.Size = new System.Drawing.Size(136, 19);
            this.stateStatusLabel.Text = "опрос ЭБУ остановлен";
            // 
            // connectedStatusLabel
            // 
            this.connectedStatusLabel.BackColor = System.Drawing.Color.Gold;
            this.connectedStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.connectedStatusLabel.Name = "connectedStatusLabel";
            this.connectedStatusLabel.Size = new System.Drawing.Size(139, 19);
            this.connectedStatusLabel.Text = "связь с ЭБУ отсутствует";
            // 
            // mainToolBar
            // 
            this.mainToolBar.AccessibleName = "Tool Bar";
            this.mainToolBar.AutoSize = false;
            this.mainToolBar.CommandHolder = this.commands;
            this.mainToolBar.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.openDatFileButton,
            this.openOptionsDialogButton,
            this.startCommunicationButton,
            this.stopCommunicationButton,
            this.readCurrentCalibrButton,
            this.writeCurrentCalibrButton,
            this.openedDatFilesLink});
            this.mainToolBar.Controls.Add(this.openedDatFilesComboBox);
            this.mainToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainToolBar.Location = new System.Drawing.Point(0, 0);
            this.mainToolBar.Movable = false;
            this.mainToolBar.Name = "mainToolBar";
            this.mainToolBar.Size = new System.Drawing.Size(1250, 29);
            this.mainToolBar.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // openDatFileButton
            // 
            this.openDatFileButton.Command = this.openDatFileCommand;
            this.openDatFileButton.DefaultItem = true;
            // 
            // openOptionsDialogButton
            // 
            this.openOptionsDialogButton.Command = this.openOptionsDialogCommand;
            this.openOptionsDialogButton.SortOrder = 1;
            // 
            // startCommunicationButton
            // 
            this.startCommunicationButton.ButtonLook = C1.Win.C1Command.ButtonLookFlags.Text;
            this.startCommunicationButton.Command = this.startCommunicationCommand;
            this.startCommunicationButton.Delimiter = true;
            this.startCommunicationButton.SortOrder = 2;
            // 
            // stopCommunicationButton
            // 
            this.stopCommunicationButton.ButtonLook = C1.Win.C1Command.ButtonLookFlags.Text;
            this.stopCommunicationButton.Command = this.stopCommunicationCommand;
            this.stopCommunicationButton.SortOrder = 3;
            // 
            // readCurrentCalibrButton
            // 
            this.readCurrentCalibrButton.Command = this.readCurrentCalibrCommand;
            this.readCurrentCalibrButton.SortOrder = 4;
            // 
            // writeCurrentCalibrButton
            // 
            this.writeCurrentCalibrButton.Command = this.writeCurrentCalibrCommand;
            this.writeCurrentCalibrButton.SortOrder = 5;
            // 
            // openedDatFilesLink
            // 
            this.openedDatFilesLink.Command = this.openedDatFilesCommandControl;
            this.openedDatFilesLink.Delimiter = true;
            this.openedDatFilesLink.SortOrder = 6;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 712);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.leftCommandDock);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainToolBar);
            this.Name = "MainForm";
            this.Text = "Sokolov sport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.commands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTabs)).EndInit();
            this.leftTabs.ResumeLayout(false);
            this.calibrListTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calibrGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calibrationsBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftCommandDock)).EndInit();
            this.leftCommandDock.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainToolBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private C1.Win.C1Command.C1CommandHolder commands;
        private C1.Win.C1Command.C1DockingTab leftTabs;
        private C1.Win.C1Command.C1DockingTabPage calibrListTabPage;
        private C1.Win.C1Command.C1CommandMenu fileMenu;
        private C1.Win.C1Command.C1CommandLink openDatFileLink;
        private C1.Win.C1Command.C1Command openDatFileCommand;
        private C1.Win.C1Command.C1CommandDock leftCommandDock;
        private System.Windows.Forms.BindingSource calibrationsBS;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel valuesPanel;
        private System.Windows.Forms.Panel graphsPanel;
        private GUI.Calibr3DControl calibrControl;
        private C1.Win.C1Command.C1CommandLink openOptionsDialogLink;
        private C1.Win.C1Command.C1Command openOptionsDialogCommand;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel versionStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel linkStatusLabel;
        private C1.Win.C1Command.C1Command startCommunicationCommand;
        private C1.Win.C1Command.C1Command stopCommunicationCommand;
        private C1.Win.C1Command.C1CommandMenu communicationMenu;
        private C1.Win.C1Command.C1CommandLink startCommunicationLink;
        private C1.Win.C1Command.C1CommandLink stopCommunicationLink;
        private System.Windows.Forms.ToolStripStatusLabel stateStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel connectedStatusLabel;
        private System.Windows.Forms.ImageList mainImageList;
        private C1.Win.C1Command.C1ToolBar mainToolBar;
        private C1.Win.C1Command.C1CommandLink openDatFileButton;
        private C1.Win.C1Command.C1CommandLink openOptionsDialogButton;
        private C1.Win.C1Command.C1CommandLink startCommunicationButton;
        private C1.Win.C1Command.C1CommandLink stopCommunicationButton;
        private C1.Win.C1FlexGrid.C1FlexGrid calibrGridView;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Command.C1CommandControl openedDatFilesCommandControl;
        private System.Windows.Forms.ComboBox openedDatFilesComboBox;
        private C1.Win.C1Command.C1CommandLink openedDatFilesLink;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1Command readCurrentCalibrCommand;
        private C1.Win.C1Command.C1Command writeCurrentCalibrCommand;
        private C1.Win.C1Command.C1CommandLink readCurrentCalibrButton;
        private C1.Win.C1Command.C1CommandLink writeCurrentCalibrButton;
    }
}


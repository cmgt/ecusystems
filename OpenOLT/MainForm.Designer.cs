using Helper;
using OpenOLT.GUI;
using WidebandLambdaCommunication;

namespace OpenOLT
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
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.versionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkStatuslable = new System.Windows.Forms.ToolStripStatusLabel();
            this.warnTwatStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.warnTairStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.warnFuseStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.warnUbatStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.warnPressStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ecuConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.onlineStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lambdaStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lambdaValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.firmwareStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dadModeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolStrip = new Helper.ToolStripEx();
            this.connectToolButton = new System.Windows.Forms.ToolStripButton();
            this.disconnectToolButton = new System.Windows.Forms.ToolStripButton();
            this.settingDialogToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.enabledOnlineCorrectionButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gaugeShowStripButton = new System.Windows.Forms.ToolStripButton();
            this.showIndicPanelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showRtGridStripButton = new System.Windows.Forms.ToolStripButton();
            this.showChartStripButton = new System.Windows.Forms.ToolStripButton();
            this.showFEStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFirmwareMapButton = new System.Windows.Forms.ToolStripButton();
            this.openFirmwareStripButton = new System.Windows.Forms.ToolStripButton();
            this.pluginSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.connectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingDialogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionList = new Crad.Windows.Forms.Actions.ActionList();
            this.connectAction = new Crad.Windows.Forms.Actions.Action();
            this.disconnectAction = new Crad.Windows.Forms.Actions.Action();
            this.settingsDialogAction = new Crad.Windows.Forms.Actions.Action();
            this.showErrorsFormAction = new Crad.Windows.Forms.Actions.Action();
            this.enabledOnlineCorrectionAction = new Crad.Windows.Forms.Actions.Action();
            this.showGaugePanelAction = new Crad.Windows.Forms.Actions.Action();
            this.showDiagValuesPanel = new Crad.Windows.Forms.Actions.Action();
            this.showRtGridAction = new Crad.Windows.Forms.Actions.Action();
            this.showChartPanelAction = new Crad.Windows.Forms.Actions.Action();
            this.showFirmwareEditPanelAction = new Crad.Windows.Forms.Actions.Action();
            this.openFirmwareMap = new Crad.Windows.Forms.Actions.Action();
            this.openFirmwareAction = new Crad.Windows.Forms.Actions.Action();
            this.exitAction = new Crad.Windows.Forms.Actions.Action();
            this.fullScreenAction = new Crad.Windows.Forms.Actions.Action();
            this.updateThread = new System.ComponentModel.BackgroundWorker();
            this.lambdaAdapter = new WidebandLambdaCommunication.LambdaAdapter(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.rtGridPanel = new OpenOLT.GUI.RTGridPanel();
            this.diagChartPanel = new OpenOLT.GUI.DiagChartPanel();
            this.firmwareEditorPanel = new OpenOLT.GUI.FirmwareEditPanel();
            this.diagGaugePanel = new OpenOLT.GUI.DiagGaugePanel();
            this.mainStatusStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 0.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch, ((byte)(204)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionStatusLabel,
            this.linkStatuslable,
            this.warnTwatStatus,
            this.warnTairStatus,
            this.warnFuseStatus,
            this.warnUbatStatus,
            this.warnPressStatus,
            this.ecuConnectionStatus,
            this.onlineStatusLabel,
            this.lambdaStatus,
            this.lambdaValue,
            this.errorStatus,
            this.firmwareStatusLabel,
            this.dadModeStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 642);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.ShowItemToolTips = true;
            this.mainStatusStrip.Size = new System.Drawing.Size(1093, 29);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // versionStatusLabel
            // 
            this.versionStatusLabel.Name = "versionStatusLabel";
            this.versionStatusLabel.Size = new System.Drawing.Size(88, 24);
            this.versionStatusLabel.Text = "version next";
            // 
            // linkStatuslable
            // 
            this.linkStatuslable.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.linkStatuslable.IsLink = true;
            this.linkStatuslable.Name = "linkStatuslable";
            this.linkStatuslable.Size = new System.Drawing.Size(103, 24);
            this.linkStatuslable.Text = "ecusystems.ru";
            this.linkStatuslable.Click += new System.EventHandler(this.linkStatuslable_Click);
            // 
            // warnTwatStatus
            // 
            this.warnTwatStatus.BackColor = System.Drawing.Color.Tomato;
            this.warnTwatStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.warnTwatStatus.Name = "warnTwatStatus";
            this.warnTwatStatus.Size = new System.Drawing.Size(45, 24);
            this.warnTwatStatus.Text = "ТОЖ";
            this.warnTwatStatus.ToolTipText = "Аварийная температура ОЖ";
            this.warnTwatStatus.Visible = false;
            // 
            // warnTairStatus
            // 
            this.warnTairStatus.BackColor = System.Drawing.Color.Tomato;
            this.warnTairStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.warnTairStatus.Name = "warnTairStatus";
            this.warnTairStatus.Size = new System.Drawing.Size(53, 24);
            this.warnTairStatus.Text = "Твозд";
            this.warnTairStatus.ToolTipText = "Аварийная температура воздуха на впуске";
            this.warnTairStatus.Visible = false;
            // 
            // warnFuseStatus
            // 
            this.warnFuseStatus.BackColor = System.Drawing.Color.Tomato;
            this.warnFuseStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.warnFuseStatus.Name = "warnFuseStatus";
            this.warnFuseStatus.Size = new System.Drawing.Size(49, 24);
            this.warnFuseStatus.Text = "Форс";
            this.warnFuseStatus.ToolTipText = "Аварийно высокая загрузка форсунок";
            this.warnFuseStatus.Visible = false;
            // 
            // warnUbatStatus
            // 
            this.warnUbatStatus.BackColor = System.Drawing.Color.Tomato;
            this.warnUbatStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.warnUbatStatus.Name = "warnUbatStatus";
            this.warnUbatStatus.Size = new System.Drawing.Size(45, 24);
            this.warnUbatStatus.Text = "Ubat";
            this.warnUbatStatus.ToolTipText = "Аварийное напряжение бортсети";
            this.warnUbatStatus.Visible = false;
            // 
            // warnPressStatus
            // 
            this.warnPressStatus.BackColor = System.Drawing.Color.Tomato;
            this.warnPressStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.warnPressStatus.Name = "warnPressStatus";
            this.warnPressStatus.Size = new System.Drawing.Size(46, 24);
            this.warnPressStatus.Text = "Press";
            this.warnPressStatus.ToolTipText = "Аварийное давление";
            this.warnPressStatus.Visible = false;
            // 
            // ecuConnectionStatus
            // 
            this.ecuConnectionStatus.BackColor = System.Drawing.Color.Gold;
            this.ecuConnectionStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ecuConnectionStatus.Name = "ecuConnectionStatus";
            this.ecuConnectionStatus.Size = new System.Drawing.Size(132, 24);
            this.ecuConnectionStatus.Text = "ECU disconnected";
            this.ecuConnectionStatus.ToolTipText = "Статус соединения с ЭБУ";
            // 
            // onlineStatusLabel
            // 
            this.onlineStatusLabel.BackColor = System.Drawing.Color.Gold;
            this.onlineStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.onlineStatusLabel.Name = "onlineStatusLabel";
            this.onlineStatusLabel.Size = new System.Drawing.Size(147, 24);
            this.onlineStatusLabel.Text = "online no supported";
            this.onlineStatusLabel.ToolTipText = "Поддержка ЭБУ online протокола";
            // 
            // lambdaStatus
            // 
            this.lambdaStatus.BackColor = System.Drawing.Color.Gold;
            this.lambdaStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lambdaStatus.Name = "lambdaStatus";
            this.lambdaStatus.Size = new System.Drawing.Size(159, 24);
            this.lambdaStatus.Text = "Lambda disconnected";
            this.lambdaStatus.ToolTipText = "Статус соединения с ШДК";
            // 
            // lambdaValue
            // 
            this.lambdaValue.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lambdaValue.Name = "lambdaValue";
            this.lambdaValue.Size = new System.Drawing.Size(120, 24);
            this.lambdaValue.Text = "[Lambda], [AFR]";
            this.lambdaValue.ToolTipText = "[Lambda], [AF], [AFR]";
            // 
            // errorStatus
            // 
            this.errorStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.errorStatus.Name = "errorStatus";
            this.errorStatus.Size = new System.Drawing.Size(114, 24);
            this.errorStatus.Text = "Error not found";
            this.errorStatus.ToolTipText = "Статус ошибок ЭБУ";
            // 
            // firmwareStatusLabel
            // 
            this.firmwareStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.firmwareStatusLabel.Name = "firmwareStatusLabel";
            this.firmwareStatusLabel.Size = new System.Drawing.Size(132, 24);
            this.firmwareStatusLabel.Text = "firmware not load";
            this.firmwareStatusLabel.ToolTipText = "Открытая прошивка";
            // 
            // dadModeStatusLabel
            // 
            this.dadModeStatusLabel.BackColor = System.Drawing.Color.Gold;
            this.dadModeStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.dadModeStatusLabel.Name = "dadModeStatusLabel";
            this.dadModeStatusLabel.Size = new System.Drawing.Size(43, 24);
            this.dadModeStatusLabel.Text = "ДАД";
            this.dadModeStatusLabel.ToolTipText = "Расчет наполнения по ДАД";
            this.dadModeStatusLabel.Visible = false;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.ClickThrough = true;
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 0.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolButton,
            this.disconnectToolButton,
            this.settingDialogToolButton,
            this.toolStripButton1,
            this.enabledOnlineCorrectionButton,
            this.toolStripSeparator1,
            this.gaugeShowStripButton,
            this.showIndicPanelButton,
            this.toolStripSeparator2,
            this.showRtGridStripButton,
            this.showChartStripButton,
            this.showFEStripButton,
            this.openFirmwareMapButton,
            this.openFirmwareStripButton,
            this.pluginSeparator,
            this.exitSeparator,
            this.exitButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 36);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainToolStrip.Size = new System.Drawing.Size(1093, 39);
            this.mainToolStrip.TabIndex = 0;
            // 
            // connectToolButton
            // 
            this.actionList.SetAction(this.connectToolButton, this.connectAction);
            this.connectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectToolButton.Image = global::OpenOLT.Properties.Resources.connect;
            this.connectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectToolButton.Name = "connectToolButton";
            this.connectToolButton.Size = new System.Drawing.Size(36, 36);
            this.connectToolButton.Text = "Соединиться";
            // 
            // disconnectToolButton
            // 
            this.actionList.SetAction(this.disconnectToolButton, this.disconnectAction);
            this.disconnectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.disconnectToolButton.Image = global::OpenOLT.Properties.Resources.disconnect;
            this.disconnectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disconnectToolButton.Name = "disconnectToolButton";
            this.disconnectToolButton.Size = new System.Drawing.Size(36, 36);
            this.disconnectToolButton.Text = "Разъединиться";
            // 
            // settingDialogToolButton
            // 
            this.actionList.SetAction(this.settingDialogToolButton, this.settingsDialogAction);
            this.settingDialogToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingDialogToolButton.Image = global::OpenOLT.Properties.Resources.tools;
            this.settingDialogToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingDialogToolButton.Name = "settingDialogToolButton";
            this.settingDialogToolButton.Size = new System.Drawing.Size(36, 36);
            this.settingDialogToolButton.Text = "Диалог настройки";
            // 
            // toolStripButton1
            // 
            this.actionList.SetAction(this.toolStripButton1, this.showErrorsFormAction);
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::OpenOLT.Properties.Resources.check_engine_ru;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Список ошибок";
            // 
            // enabledOnlineCorrectionButton
            // 
            this.actionList.SetAction(this.enabledOnlineCorrectionButton, this.enabledOnlineCorrectionAction);
            this.enabledOnlineCorrectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enabledOnlineCorrectionButton.Image = global::OpenOLT.Properties.Resources.action_go;
            this.enabledOnlineCorrectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enabledOnlineCorrectionButton.Name = "enabledOnlineCorrectionButton";
            this.enabledOnlineCorrectionButton.Size = new System.Drawing.Size(36, 36);
            this.enabledOnlineCorrectionButton.ToolTipText = "Начать обучение";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // gaugeShowStripButton
            // 
            this.actionList.SetAction(this.gaugeShowStripButton, this.showGaugePanelAction);
            this.gaugeShowStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gaugeShowStripButton.Image = global::OpenOLT.Properties.Resources.gauge2;
            this.gaugeShowStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gaugeShowStripButton.Name = "gaugeShowStripButton";
            this.gaugeShowStripButton.Size = new System.Drawing.Size(36, 36);
            this.gaugeShowStripButton.Text = "Показать/скрыть панель приборов";
            this.gaugeShowStripButton.ToolTipText = "Показать/скрыть панель приборов";
            // 
            // showIndicPanelButton
            // 
            this.actionList.SetAction(this.showIndicPanelButton, this.showDiagValuesPanel);
            this.showIndicPanelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showIndicPanelButton.Image = global::OpenOLT.Properties.Resources.layout;
            this.showIndicPanelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showIndicPanelButton.Name = "showIndicPanelButton";
            this.showIndicPanelButton.Size = new System.Drawing.Size(36, 36);
            this.showIndicPanelButton.Text = "Показать/скрыть панель индикаторов";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // showRtGridStripButton
            // 
            this.actionList.SetAction(this.showRtGridStripButton, this.showRtGridAction);
            this.showRtGridStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showRtGridStripButton.Image = global::OpenOLT.Properties.Resources.table;
            this.showRtGridStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showRtGridStripButton.Name = "showRtGridStripButton";
            this.showRtGridStripButton.Size = new System.Drawing.Size(36, 36);
            this.showRtGridStripButton.Text = "Сетка РТ";
            // 
            // showChartStripButton
            // 
            this.actionList.SetAction(this.showChartStripButton, this.showChartPanelAction);
            this.showChartStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showChartStripButton.Image = global::OpenOLT.Properties.Resources.chart_line;
            this.showChartStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showChartStripButton.Name = "showChartStripButton";
            this.showChartStripButton.Size = new System.Drawing.Size(36, 36);
            this.showChartStripButton.Text = "Панель диагностики";
            // 
            // showFEStripButton
            // 
            this.actionList.SetAction(this.showFEStripButton, this.showFirmwareEditPanelAction);
            this.showFEStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showFEStripButton.Image = global::OpenOLT.Properties.Resources.icon_extension;
            this.showFEStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showFEStripButton.Name = "showFEStripButton";
            this.showFEStripButton.Size = new System.Drawing.Size(36, 36);
            this.showFEStripButton.Text = "Редактор прошивки";
            // 
            // openFirmwareMapButton
            // 
            this.actionList.SetAction(this.openFirmwareMapButton, this.openFirmwareMap);
            this.openFirmwareMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFirmwareMapButton.Image = global::OpenOLT.Properties.Resources.open_map;
            this.openFirmwareMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFirmwareMapButton.Name = "openFirmwareMapButton";
            this.openFirmwareMapButton.Size = new System.Drawing.Size(36, 36);
            this.openFirmwareMapButton.Text = "Открыть карту прошивки";
            // 
            // openFirmwareStripButton
            // 
            this.actionList.SetAction(this.openFirmwareStripButton, this.openFirmwareAction);
            this.openFirmwareStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFirmwareStripButton.Image = global::OpenOLT.Properties.Resources.open_bin;
            this.openFirmwareStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFirmwareStripButton.Name = "openFirmwareStripButton";
            this.openFirmwareStripButton.Size = new System.Drawing.Size(36, 36);
            this.openFirmwareStripButton.Text = "Открыть прошивку";
            // 
            // pluginSeparator
            // 
            this.pluginSeparator.Name = "pluginSeparator";
            this.pluginSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // exitSeparator
            // 
            this.exitSeparator.Name = "exitSeparator";
            this.exitSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // exitButton
            // 
            this.actionList.SetAction(this.exitButton, this.exitAction);
            this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitButton.Image = global::OpenOLT.Properties.Resources.exit;
            this.exitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(36, 36);
            this.exitButton.Text = "Выход";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 0.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Inch, ((byte)(204)));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.connectionMenu,
            this.pagesMenu,
            this.settingsMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1093, 36);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.exitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(77, 32);
            this.fileMenu.Text = "Файл";
            // 
            // toolStripMenuItem6
            // 
            this.actionList.SetAction(this.toolStripMenuItem6, this.openFirmwareAction);
            this.toolStripMenuItem6.Image = global::OpenOLT.Properties.Resources.open_bin;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeyDisplayString = "Ctrl+O";
            this.toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem6.Size = new System.Drawing.Size(348, 32);
            this.toolStripMenuItem6.Text = "Открыть прошивку";
            // 
            // exitMenuItem
            // 
            this.actionList.SetAction(this.exitMenuItem, this.exitAction);
            this.exitMenuItem.Image = global::OpenOLT.Properties.Resources.exit;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(348, 32);
            this.exitMenuItem.Text = "Выход";
            // 
            // connectionMenu
            // 
            this.connectionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMenuItem,
            this.disconnectMenuItem});
            this.connectionMenu.Name = "connectionMenu";
            this.connectionMenu.Size = new System.Drawing.Size(143, 32);
            this.connectionMenu.Text = "Соединение";
            // 
            // connectMenuItem
            // 
            this.actionList.SetAction(this.connectMenuItem, this.connectAction);
            this.connectMenuItem.Image = global::OpenOLT.Properties.Resources.connect;
            this.connectMenuItem.Name = "connectMenuItem";
            this.connectMenuItem.ShortcutKeyDisplayString = "F9";
            this.connectMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.connectMenuItem.Size = new System.Drawing.Size(277, 32);
            this.connectMenuItem.Text = "Соединиться";
            // 
            // disconnectMenuItem
            // 
            this.actionList.SetAction(this.disconnectMenuItem, this.disconnectAction);
            this.disconnectMenuItem.Image = global::OpenOLT.Properties.Resources.disconnect;
            this.disconnectMenuItem.Name = "disconnectMenuItem";
            this.disconnectMenuItem.ShortcutKeyDisplayString = "F10";
            this.disconnectMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.disconnectMenuItem.Size = new System.Drawing.Size(277, 32);
            this.disconnectMenuItem.Text = "Разъединиться";
            // 
            // pagesMenu
            // 
            this.pagesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.toolStripMenuItem5,
            this.toolStripSeparator3});
            this.pagesMenu.Name = "pagesMenu";
            this.pagesMenu.Size = new System.Drawing.Size(116, 32);
            this.pagesMenu.Text = "Закладки";
            // 
            // toolStripMenuItem2
            // 
            this.actionList.SetAction(this.toolStripMenuItem2, this.showDiagValuesPanel);
            this.toolStripMenuItem2.Image = global::OpenOLT.Properties.Resources.layout;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(528, 32);
            this.toolStripMenuItem2.Text = "Показать/скрыть панель индикаторов";
            // 
            // toolStripMenuItem3
            // 
            this.actionList.SetAction(this.toolStripMenuItem3, this.showErrorsFormAction);
            this.toolStripMenuItem3.Image = global::OpenOLT.Properties.Resources.check_engine_ru;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeyDisplayString = "F11";
            this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.toolStripMenuItem3.Size = new System.Drawing.Size(528, 32);
            this.toolStripMenuItem3.Text = "Список ошибок";
            // 
            // toolStripMenuItem4
            // 
            this.actionList.SetAction(this.toolStripMenuItem4, this.showGaugePanelAction);
            this.toolStripMenuItem4.Image = global::OpenOLT.Properties.Resources.gauge2;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(528, 32);
            this.toolStripMenuItem4.Text = "Показать/скрыть панель приборов";
            // 
            // toolStripMenuItem1
            // 
            this.actionList.SetAction(this.toolStripMenuItem1, this.showChartPanelAction);
            this.toolStripMenuItem1.Image = global::OpenOLT.Properties.Resources.chart_line;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = "F3";
            this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(528, 32);
            this.toolStripMenuItem1.Text = "Панель диагностики";
            // 
            // toolStripMenuItem5
            // 
            this.actionList.SetAction(this.toolStripMenuItem5, this.showRtGridAction);
            this.toolStripMenuItem5.Image = global::OpenOLT.Properties.Resources.table;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeyDisplayString = "F4";
            this.toolStripMenuItem5.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.toolStripMenuItem5.Size = new System.Drawing.Size(528, 32);
            this.toolStripMenuItem5.Text = "Сетка РТ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(525, 6);
            // 
            // settingsMenu
            // 
            this.settingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingDialogMenuItem,
            this.fullScreenMenuItem});
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(130, 32);
            this.settingsMenu.Text = "Настройки";
            // 
            // settingDialogMenuItem
            // 
            this.actionList.SetAction(this.settingDialogMenuItem, this.settingsDialogAction);
            this.settingDialogMenuItem.Image = global::OpenOLT.Properties.Resources.tools;
            this.settingDialogMenuItem.Name = "settingDialogMenuItem";
            this.settingDialogMenuItem.ShortcutKeyDisplayString = "F2";
            this.settingDialogMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.settingDialogMenuItem.Size = new System.Drawing.Size(299, 32);
            this.settingDialogMenuItem.Text = "Диалог настройки";
            // 
            // fullScreenMenuItem
            // 
            this.actionList.SetAction(this.fullScreenMenuItem, this.fullScreenAction);
            this.fullScreenMenuItem.Name = "fullScreenMenuItem";
            this.fullScreenMenuItem.ShortcutKeyDisplayString = "F12";
            this.fullScreenMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.fullScreenMenuItem.Size = new System.Drawing.Size(299, 32);
            this.fullScreenMenuItem.Text = "Во весь экран";
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.settingsDialogAction);
            this.actionList.Actions.Add(this.connectAction);
            this.actionList.Actions.Add(this.disconnectAction);
            this.actionList.Actions.Add(this.exitAction);
            this.actionList.Actions.Add(this.fullScreenAction);
            this.actionList.Actions.Add(this.showGaugePanelAction);
            this.actionList.Actions.Add(this.showChartPanelAction);
            this.actionList.Actions.Add(this.showRtGridAction);
            this.actionList.Actions.Add(this.showFirmwareEditPanelAction);
            this.actionList.Actions.Add(this.openFirmwareMap);
            this.actionList.Actions.Add(this.openFirmwareAction);
            this.actionList.Actions.Add(this.enabledOnlineCorrectionAction);
            this.actionList.Actions.Add(this.showErrorsFormAction);
            this.actionList.Actions.Add(this.showDiagValuesPanel);
            this.actionList.ContainerControl = this;
            // 
            // connectAction
            // 
            this.connectAction.Image = global::OpenOLT.Properties.Resources.connect;
            this.connectAction.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.connectAction.Tag = null;
            this.connectAction.Text = "Соединиться";
            this.connectAction.Execute += new System.EventHandler(this.connectAction_Execute);
            // 
            // disconnectAction
            // 
            this.disconnectAction.Image = global::OpenOLT.Properties.Resources.disconnect;
            this.disconnectAction.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.disconnectAction.Tag = null;
            this.disconnectAction.Text = "Разъединиться";
            this.disconnectAction.Execute += new System.EventHandler(this.disconnectAction_Execute);
            // 
            // settingsDialogAction
            // 
            this.settingsDialogAction.Image = global::OpenOLT.Properties.Resources.tools;
            this.settingsDialogAction.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.settingsDialogAction.Tag = null;
            this.settingsDialogAction.Text = "Диалог настройки";
            this.settingsDialogAction.ToolTipText = "Открыть диалог настройки";
            this.settingsDialogAction.Execute += new System.EventHandler(this.settingsDialogAction_Execute);
            // 
            // showErrorsFormAction
            // 
            this.showErrorsFormAction.Image = global::OpenOLT.Properties.Resources.check_engine_ru;
            this.showErrorsFormAction.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.showErrorsFormAction.Tag = null;
            this.showErrorsFormAction.Text = "Список ошибок";
            this.showErrorsFormAction.ToolTipText = "Показать список текущих ошибок ЭБУ";
            this.showErrorsFormAction.Execute += new System.EventHandler(this.showErrorsFormAction_Execute);
            this.showErrorsFormAction.Update += new System.EventHandler(this.showErrorsFormAction_Update);
            // 
            // enabledOnlineCorrectionAction
            // 
            this.enabledOnlineCorrectionAction.Image = global::OpenOLT.Properties.Resources.action_go;
            this.enabledOnlineCorrectionAction.Tag = null;
            this.enabledOnlineCorrectionAction.ToolTipText = "Начать обучение";
            this.enabledOnlineCorrectionAction.Execute += new System.EventHandler(this.enabledOnlineCorrectionAction_Execute);
            this.enabledOnlineCorrectionAction.Update += new System.EventHandler(this.enabledOnlineCorrectionAction_Update);
            // 
            // showGaugePanelAction
            // 
            this.showGaugePanelAction.Image = global::OpenOLT.Properties.Resources.gauge2;
            this.showGaugePanelAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.showGaugePanelAction.Tag = null;
            this.showGaugePanelAction.Text = "Показать/скрыть панель приборов";
            this.showGaugePanelAction.ToolTipText = "Показать/скрыть панель приборов";
            this.showGaugePanelAction.Execute += new System.EventHandler(this.showGaugePanel_Execute);
            this.showGaugePanelAction.Update += new System.EventHandler(this.showGaugePanel_Update);
            // 
            // showDiagValuesPanel
            // 
            this.showDiagValuesPanel.Image = global::OpenOLT.Properties.Resources.layout;
            this.showDiagValuesPanel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.showDiagValuesPanel.Tag = null;
            this.showDiagValuesPanel.Text = "Показать/скрыть панель индикаторов";
            this.showDiagValuesPanel.ToolTipText = "Показать/скрыть панель индикаторов";
            this.showDiagValuesPanel.Execute += new System.EventHandler(this.showDiagValuesPanel_Execute);
            this.showDiagValuesPanel.Update += new System.EventHandler(this.showDiagValuesPanel_Update);
            // 
            // showRtGridAction
            // 
            this.showRtGridAction.Image = global::OpenOLT.Properties.Resources.table;
            this.showRtGridAction.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.showRtGridAction.Tag = null;
            this.showRtGridAction.Text = "Сетка РТ";
            this.showRtGridAction.ToolTipText = "Сетка РТ";
            this.showRtGridAction.Execute += new System.EventHandler(this.showRtGridAction_Execute);
            this.showRtGridAction.Update += new System.EventHandler(this.showRtGridAction_Update);
            // 
            // showChartPanelAction
            // 
            this.showChartPanelAction.Image = global::OpenOLT.Properties.Resources.chart_line;
            this.showChartPanelAction.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.showChartPanelAction.Tag = null;
            this.showChartPanelAction.Text = "Панель диагностики";
            this.showChartPanelAction.ToolTipText = "Панель диагностики";
            this.showChartPanelAction.Execute += new System.EventHandler(this.showChartPanelAction_Execute);
            this.showChartPanelAction.Update += new System.EventHandler(this.showChartPanelAction_Update);
            // 
            // showFirmwareEditPanelAction
            // 
            this.showFirmwareEditPanelAction.Image = global::OpenOLT.Properties.Resources.icon_extension;
            this.showFirmwareEditPanelAction.Tag = null;
            this.showFirmwareEditPanelAction.Text = "Редактор прошивки";
            this.showFirmwareEditPanelAction.ToolTipText = "Редактор прошивки";
            this.showFirmwareEditPanelAction.Visible = false;
            this.showFirmwareEditPanelAction.Execute += new System.EventHandler(this.showFirmwareEditPanelAction_Execute);
            // 
            // openFirmwareMap
            // 
            this.openFirmwareMap.Image = global::OpenOLT.Properties.Resources.open_map;
            this.openFirmwareMap.Tag = null;
            this.openFirmwareMap.Text = "Открыть карту прошивки";
            this.openFirmwareMap.ToolTipText = "Открыть карту прошивки";
            this.openFirmwareMap.Visible = false;
            this.openFirmwareMap.Execute += new System.EventHandler(this.openFirmwareMap_Execute);
            // 
            // openFirmwareAction
            // 
            this.openFirmwareAction.Image = global::OpenOLT.Properties.Resources.open_bin;
            this.openFirmwareAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFirmwareAction.Tag = null;
            this.openFirmwareAction.Text = "Открыть прошивку";
            this.openFirmwareAction.ToolTipText = "Открыть прошивку";
            this.openFirmwareAction.Execute += new System.EventHandler(this.openFirmwareAction_Execute);
            // 
            // exitAction
            // 
            this.exitAction.Image = global::OpenOLT.Properties.Resources.exit;
            this.exitAction.Tag = null;
            this.exitAction.Text = "Выход";
            this.exitAction.ToolTipText = "Выход из программы";
            this.exitAction.Execute += new System.EventHandler(this.exitAction_Execute);
            // 
            // fullScreenAction
            // 
            this.fullScreenAction.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.fullScreenAction.Tag = null;
            this.fullScreenAction.Text = "Во весь экран";
            this.fullScreenAction.Execute += new System.EventHandler(this.fullScreenAction_Execute);
            // 
            // updateThread
            // 
            this.updateThread.WorkerSupportsCancellation = true;
            this.updateThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateThread_DoWork);
            // 
            // lambdaAdapter
            // 
            this.lambdaAdapter.ReadTimeout = 100;
            this.lambdaAdapter.SmoothingFactor = ((byte)(7));
            this.lambdaAdapter.SmoothingWindow = ((byte)(5));
            this.lambdaAdapter.TraceEnabled = false;
            this.lambdaAdapter.OnConnect += new System.EventHandler(this.lambdaAdapter_OnConnect);
            this.lambdaAdapter.OnDisconnect += new System.EventHandler(this.lambdaAdapter_OnConnect);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.rtGridPanel);
            this.mainPanel.Controls.Add(this.diagChartPanel);
            this.mainPanel.Controls.Add(this.firmwareEditorPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(193, 75);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(900, 567);
            this.mainPanel.TabIndex = 6;
            // 
            // rtGridPanel
            // 
            this.rtGridPanel.AutoScroll = true;
            this.rtGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtGridPanel.Location = new System.Drawing.Point(0, 0);
            this.rtGridPanel.Name = "rtGridPanel";
            this.rtGridPanel.Size = new System.Drawing.Size(900, 567);
            this.rtGridPanel.TabIndex = 5;
            // 
            // diagChartPanel
            // 
            this.diagChartPanel.AutoScroll = true;
            this.diagChartPanel.ChartScale = 200;
            this.diagChartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagChartPanel.FirstPoint = 0;
            this.diagChartPanel.Location = new System.Drawing.Point(0, 0);
            this.diagChartPanel.MinChartHeight = 150;
            this.diagChartPanel.Name = "diagChartPanel";
            this.diagChartPanel.Size = new System.Drawing.Size(900, 567);
            this.diagChartPanel.TabIndex = 3;
            this.diagChartPanel.Visible = false;
            // 
            // firmwareEditorPanel
            // 
            this.firmwareEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firmwareEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.firmwareEditorPanel.Name = "firmwareEditorPanel";
            this.firmwareEditorPanel.Size = new System.Drawing.Size(900, 567);
            this.firmwareEditorPanel.TabIndex = 4;
            this.firmwareEditorPanel.Visible = false;
            // 
            // diagGaugePanel
            // 
            this.diagGaugePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagGaugePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.diagGaugePanel.Location = new System.Drawing.Point(0, 75);
            this.diagGaugePanel.Name = "diagGaugePanel";
            this.diagGaugePanel.Size = new System.Drawing.Size(193, 567);
            this.diagGaugePanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 671);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.diagGaugePanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "OpenOLT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion        

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private ToolStripEx mainToolStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem settingDialogMenuItem;
        private System.Windows.Forms.ToolStripButton settingDialogToolButton;
        private System.Windows.Forms.ToolStripMenuItem connectionMenu;
        private System.Windows.Forms.ToolStripMenuItem connectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectMenuItem;
        private Crad.Windows.Forms.Actions.ActionList actionList;
        private Crad.Windows.Forms.Actions.Action settingsDialogAction;
        private System.Windows.Forms.ToolStripButton connectToolButton;
        private Crad.Windows.Forms.Actions.Action connectAction;
        private Crad.Windows.Forms.Actions.Action disconnectAction;
        private System.Windows.Forms.ToolStripButton disconnectToolButton;
        private Crad.Windows.Forms.Actions.Action exitAction;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ecuConnectionStatus;
        private Crad.Windows.Forms.Actions.Action fullScreenAction;
        private System.Windows.Forms.ToolStripMenuItem fullScreenMenuItem;
        private LambdaAdapter lambdaAdapter;
        private System.Windows.Forms.ToolStripStatusLabel lambdaStatus;
        private System.Windows.Forms.ToolStripStatusLabel lambdaValue;
        private System.ComponentModel.BackgroundWorker updateThread;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DiagGaugePanel diagGaugePanel;
        private System.Windows.Forms.ToolStripStatusLabel linkStatuslable;
        private System.Windows.Forms.ToolStripStatusLabel versionStatusLabel;
        private System.Windows.Forms.ToolStripButton gaugeShowStripButton;
        private Crad.Windows.Forms.Actions.Action showGaugePanelAction;
        private DiagChartPanel diagChartPanel;
        private Crad.Windows.Forms.Actions.Action showChartPanelAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton showChartStripButton;
        private System.Windows.Forms.ToolStripButton showFEStripButton;
        private Crad.Windows.Forms.Actions.Action showFirmwareEditPanelAction;
        private FirmwareEditPanel firmwareEditorPanel;
        private Crad.Windows.Forms.Actions.Action openFirmwareMap;
        private System.Windows.Forms.ToolStripButton openFirmwareMapButton;
        private System.Windows.Forms.ToolStripStatusLabel onlineStatusLabel;
        private Crad.Windows.Forms.Actions.Action openFirmwareAction;
        private System.Windows.Forms.ToolStripButton openFirmwareStripButton;
        private System.Windows.Forms.ToolStripStatusLabel firmwareStatusLabel;
        private RTGridPanel rtGridPanel;
        private Crad.Windows.Forms.Actions.Action showRtGridAction;
        private System.Windows.Forms.ToolStripButton showRtGridStripButton;
        private Crad.Windows.Forms.Actions.Action enabledOnlineCorrectionAction;
        private System.Windows.Forms.ToolStripButton enabledOnlineCorrectionButton;
        private System.Windows.Forms.ToolStripStatusLabel errorStatus;
        private System.Windows.Forms.ToolStripSeparator pluginSeparator;
        private System.Windows.Forms.ToolStripButton exitButton;
        private Crad.Windows.Forms.Actions.Action showErrorsFormAction;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Crad.Windows.Forms.Actions.Action showDiagValuesPanel;
        private System.Windows.Forms.ToolStripButton showIndicPanelButton;
        private System.Windows.Forms.ToolStripStatusLabel dadModeStatusLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripSeparator exitSeparator;
        private System.Windows.Forms.ToolStripMenuItem pagesMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel warnTwatStatus;
        private System.Windows.Forms.ToolStripStatusLabel warnTairStatus;
        private System.Windows.Forms.ToolStripStatusLabel warnFuseStatus;
        private System.Windows.Forms.ToolStripStatusLabel warnUbatStatus;
        private System.Windows.Forms.ToolStripStatusLabel warnPressStatus;
    }
}


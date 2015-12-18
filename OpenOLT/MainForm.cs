using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using EcuCommunication.Protocols;
using Helper;
using Helper.Hooks;
using OpenOLT.GUI;
using OpenOltTypes;
using WidebandLambdaCommunication;

using Action = Crad.Windows.Forms.Actions.Action;

namespace OpenOLT
{
    public partial class MainForm : Form, IApplicationHost
    {
        private readonly SynchronizationContext uiContext;        
        private readonly OltProtocol oltProtocol;
        private bool fullScreen;
        private FormWindowState windowState;
        private readonly OnlineManager onlineManager;
        private DiagValuesPanel diagValuePanel;

        public MainForm()
        {
            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();
            
            oltProtocol = new OltProtocol();
            oltProtocol.PropertyChanged += oltProtocol_PropertyChanged;            

            onlineManager = new OnlineManager(oltProtocol, lambdaAdapter);
            onlineManager.FirmwareManager.OnOpenFirmware += FirmwareManagerOnOpenFirmware;            
            uiContext = SynchronizationContext.Current;
            diagGaugePanel.Prepare(oltProtocol, lambdaAdapter);
            diagChartPanel.Prepare(onlineManager);
            rtGridPanel.Prepare(onlineManager);

            PrepareOpenedFirmware();

            versionStatusLabel.Text = String.Format("version {0}", Assembly.GetExecutingAssembly().GetName().Version);          
            Cursor.Current = Cursors.Default;

            oltProtocol.OnDiagUpdate += OltProtocolOnOnDiagUpdate;
        }

        private void FirmwareManagerOnOpenFirmware(object sender, EventArgs eventArgs)
        {
            PrepareOpenedFirmware();
        }

        private void OltProtocolOnOnDiagUpdate(object sender, EventArgs eventArgs)
        {
            var diagData = oltProtocol.GetDiagData();

            uiContext.Send(
                delegate
                    {
                        rtGridPanel.DiagDataUpdate(diagData);                        
                    }, null);
        }

        private void UpdateErrorStatus()
        {
            if (oltProtocol.IsEcuErrorFound)
            {
                errorStatus.BackColor = Color.Gold;
                errorStatus.Text = "Found ecu error";
            }
            else
            {
                errorStatus.BackColor = SystemColors.Control;
                errorStatus.Text = "Error not found";
            }
        }

        void oltProtocol_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Connected":
                    oltProtocolConnectChange();
                    break;

                case "IsOnline":
                    uiContext.Post(
                        delegate
                            {
                                UpdateOnlineStatus();
                            }, null);
                    break;

                case "IsEcuErrorFound":
                    uiContext.Post(
                        delegate
                        {
                            UpdateErrorStatus();
                        }, null);
                    break;
            }
        }

        void oltProtocolConnectChange()
        {
            if (oltProtocol.Connected)
            {
                lambdaAdapter.StartCommunication();
                updateThread.RunWorkerAsync();
            }
            else
            {
                if (onlineManager.settings.NewLogOnConnectECU)
                    onlineManager.dataLogger.Close();

                lambdaAdapter.StopCommunication();
                updateThread.CancelAsync();
                BackgroundWorkerHelper.Wait(updateThread);
            }

            uiContext.Post(
                delegate
                    {
                        UpdateConnectStatus();
                        UpdateEcuDiagValues();
                    }, null);
        }             

        private void EcuConnect()
        {
            if (oltProtocol.Connected || oltProtocol.IsBusy) return;

            ApplySettings();

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    if (oltProtocol.Start()) break;
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            UpdateConnectStatus();
            UpdateEcuDiagValues();
            UpdateLambdaStatus();
            UpdateLambdaValue();

            if (!oltProtocol.Connected)
                MessageBox.Show(this, "Соединение с ЭБУ выполнить не удалось", "StartCommunication",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void EcuDisconnect()
        {
            if (!oltProtocol.Connected || oltProtocol.IsBusy) return;
            Cursor.Current = Cursors.WaitCursor;
            oltProtocol.Stop();

            UpdateConnectStatus();
            UpdateOnlineStatus();
            UpdateEcuDiagValues();
            UpdateLambdaStatus();
            UpdateLambdaValue();
            Cursor.Current = Cursors.Default;
        }

        private void ApplySettings()
        {
            ApplySettingsReboot();
            ApplySettingsImmediately();
        }

        private void ApplySettingsReboot()
        {
            oltProtocol.PortName = onlineManager.settings.PortName;
            oltProtocol.BaundRate = onlineManager.settings.BaundRate;
            oltProtocol.Version = onlineManager.settings.OltProtocolVersion;
            oltProtocol.CalcEcuSn = onlineManager.settings.CalcEcuSn;
            oltProtocol.EcuSn = onlineManager.settings.EcuSn;

            lambdaAdapter.PortName = onlineManager.settings.LambdaPortName;
            lambdaAdapter.BaundRate = onlineManager.settings.LambdaBaundRate;
            lambdaAdapter.Protocol = onlineManager.settings.LambdaProtocol;

            DiagData.FullTimeMode = onlineManager.settings.LogFullTimeMode;
        }

        private void ApplySettingsImmediately()
        {
            oltProtocol.ReadTimeout = onlineManager.settings.ReadTimeout;
            oltProtocol.ReadFreq = onlineManager.settings.ReadFreqNew;
            oltProtocol.WriteTimeout = onlineManager.settings.WriteTimeout;
            oltProtocol.TraceEnabled = onlineManager.settings.TraceECU;            
            lambdaAdapter.TraceEnabled = onlineManager.settings.TraceLambda;
            lambdaAdapter.ReadTimeout = onlineManager.settings.ReadLambdaTimeout;
            onlineManager.dataLogger.Enabled = onlineManager.settings.LogECU;            
        }

        #region Action handlers
        private void settingsDialogAction_Execute(object sender, EventArgs e)
        {
            var old = KeyboardHook.Enabled;
            KeyboardHook.Enabled = false;

            try
            {
                if (!SettingsHelper.ShowSettingsDialog(this, onlineManager.settings)) return;
                ApplySettingsImmediately();
                onlineManager.settings.SaveToFile();
            }
            finally
            {
                KeyboardHook.Enabled = old;
            }
        }

        private void exitAction_Execute(object sender, EventArgs e)
        {
            Close();
        }

        private void connectAction_Execute(object sender, EventArgs e)
        {
            EcuConnect();
        }        

        private void disconnectAction_Execute(object sender, EventArgs e)
        {
            EcuDisconnect();
        }

        private void showGaugePanel_Execute(object sender, EventArgs e)
        {
            diagGaugePanel.Visible = !diagGaugePanel.Visible;
            UpdateEcuDiagValues();
        }

        private void showGaugePanel_Update(object sender, EventArgs e)
        {
            showGaugePanelAction.Checked = diagGaugePanel.Visible;
        }

        private void showChartPanelAction_Execute(object sender, EventArgs e)
        {
            HideAllDataContent();
            diagChartPanel.Visible = true;
        }

        private void showFirmwareEditPanelAction_Execute(object sender, EventArgs e)
        {
            HideAllDataContent();
            firmwareEditorPanel.Visible = true;
        }

        private void openFirmwareMap_Execute(object sender, EventArgs e)
        {
            firmwareEditorPanel.Open();
        }

        private void openFirmwareAction_Execute(object sender, EventArgs e)
        {
            var old = KeyboardHook.Enabled;
            KeyboardHook.Enabled = false;

            try
            {
                onlineManager.FirmwareManager.OpenDialog(this);
            }
            finally
            {
                KeyboardHook.Enabled = old;
            }
        }

        private void showRtGridAction_Execute(object sender, EventArgs e)
        {
            HideAllDataContent();
            rtGridPanel.Visible = true;
        }

        private void enabledOnlineCorrectionAction_Execute(object sender, EventArgs e)
        {
            if (!onlineManager.EnabledOnlineCorrection && onlineManager.FirmwareManager.SWDigest != oltProtocol.SWDigest)
            {
                if (MessageBox.Show(this, "Прошивка не соответствует загруженной в ЭБУ. Игнорировать предупреждение и начать обучение?",
                                "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                    return;
            }

            onlineManager.EnabledOnlineCorrection = !onlineManager.EnabledOnlineCorrection;
        }

        private void enabledOnlineCorrectionAction_Update(object sender, EventArgs e)
        {
            enabledOnlineCorrectionAction.Enabled = (oltProtocol.IsSupportOnlineCorrection &&
                                                     onlineManager.FirmwareManager.IsOpened && !oltProtocol.InitProgress) ||
                                                    onlineManager.EnabledRamOnlineCorrection;
            enabledOnlineCorrectionAction.Checked = onlineManager.EnabledOnlineCorrection;
        }

        private void showErrorsFormAction_Execute(object sender, EventArgs e)
        {
            ErrorCodesForm.ShowErrors(this, oltProtocol);
        }

        private void showErrorsFormAction_Update(object sender, EventArgs e)
        {
            showErrorsFormAction.Enabled = oltProtocol.IsEcuErrorFound;
        }
        #endregion        

        private void UpdateEcuDiagValues()
        {
            var diagData = oltProtocol.GetDiagData();
            diagGaugePanel.UpdateValue();
            if (diagValuePanel != null)
                diagValuePanel.UpdateValues(diagData);
            UpdateWarnStatus(diagData);
        }

        private void UpdateWarnStatus(DiagData diagData)
        {
            var j7esdd = diagData as J7esDiagData;
            warnTwatStatus.Visible = diagData.TWAT > onlineManager.settings.WarnTwat;
            warnTairStatus.Visible = diagData.TAIR > onlineManager.settings.WarnTair;
            warnFuseStatus.Visible = diagData.FUSE > onlineManager.settings.WarnFuse;
            warnUbatStatus.Visible = diagData.ADCUBAT > onlineManager.settings.WarnUBatMax || diagData.ADCUBAT < onlineManager.settings.WarnUBatMin;
            warnPressStatus.Visible = (j7esdd != null) &&
                                      (j7esdd.Press > onlineManager.settings.WarnPressMax ||
                                       j7esdd.Press < onlineManager.settings.WarnPressMin);
        }

        private void UpdateConnectStatus()
        {
            ecuConnectionStatus.Text = oltProtocol.Connected ? "ECU connected" : "ECU disconnected";
            ecuConnectionStatus.BackColor = oltProtocol.Connected ? Color.LawnGreen : Color.Gold;                       
        }

        private void UpdateOnlineStatus()
        {
            onlineStatusLabel.Text = oltProtocol.IsOnline ? "online supported" : "online no supported";
            onlineStatusLabel.BackColor = oltProtocol.IsOnline ? Color.LawnGreen : Color.Gold;
        }

        private void fullScreenAction_Execute(object sender, EventArgs e)
        {
            if (!fullScreen)
            {
                windowState = WindowState;
            }

            fullScreen = !fullScreen;

            mainMenuStrip.Visible = mainToolStrip.Visible = !fullScreen;            
            FormBorderStyle = fullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
            WindowState = fullScreen ? FormWindowState.Maximized : windowState;
        }

        private void lambdaAdapter_OnConnect(object sender, EventArgs e)
        {
            uiContext.Post(
                delegate
                    {
                        UpdateLambdaStatus();
                        UpdateLambdaValue();
                    }, null);
        }

        private void UpdateLambdaStatus()
        {
            lambdaStatus.Text = lambdaAdapter.Connected ? "Lambda connected" : "Lambda disconnected";
            lambdaStatus.BackColor = lambdaAdapter.Connected ? Color.LawnGreen : Color.Gold;
        }

        private void UpdateLambdaValue()
        {
            lambdaValue.BackColor = SystemColors.Control;

            if (!lambdaAdapter.Available)
            {
                lambdaValue.Text = "LC1 - нет данных";
                lambdaValue.BackColor = Color.Gold;
            }
            else
                switch (lambdaAdapter.State)
                {
                    case LambdaState.LambdaValue:
                        lambdaValue.Text = String.Format("LC1 - [{0}], [{1}]",
                                                         lambdaAdapter.Lambda.ToString("0.###", CultureInfo.InvariantCulture),
                                                         lambdaAdapter.AFR.ToString("0.###", CultureInfo.InvariantCulture));
                        break;

                    case LambdaState.O2Level:
                        lambdaValue.Text = String.Format("[LC1 - O2 Level [{0}%]", lambdaAdapter.O2Level);
                        lambdaValue.BackColor = Color.Gold;
                        break;

                    case LambdaState.ErrorCode:
                        lambdaValue.Text = String.Format("LC1 - Error Code [{0}]", lambdaAdapter.O2Level);
                        lambdaValue.BackColor = Color.Red;
                        break;
                }            
        }

        private void updateThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                if (updateThread.CancellationPending) break;

                uiContext.Send(
                    delegate
                        {
                            UpdateEcuDiagValues();
                            UpdateLambdaValue();
                        }, null);

                if (updateThread.CancellationPending) break;
                Thread.Sleep(onlineManager.settings.UpdateDiagValuesFreq);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            diagGaugePanel.Prepare(null, null);
            EcuDisconnect();
            onlineManager.Close();
            onlineManager.settings.SaveToFile();
        }

        private void linkStatuslable_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://ecusystems.ru");
            linkStatuslable.LinkVisited = true;
        }

        private void PrepareOpenedFirmware()
        {
            if (!onlineManager.FirmwareManager.IsOpened) return;
            firmwareStatusLabel.Text = onlineManager.FirmwareManager.Name;
            firmwareStatusLabel.ToolTipText = onlineManager.FirmwareManager.SWDigest.ToString("X8");
            dadModeStatusLabel.Visible = onlineManager.FirmwareManager.J7esFlags.IsDadMode;            
            rtGridPanel.InitData();
            rtGridPanel.LoadData();
            onlineManager.InitFirmware(this);            
        }

        private void showDiagValuesPanel_Execute(object sender, EventArgs e)
        {
            SuspendLayout();

            if (diagValuePanel == null)
            {
                diagValuePanel = new DiagValuesPanel {Dock = DockStyle.Left};
                Controls.Add(diagValuePanel);
                Controls.SetChildIndex(diagValuePanel, 1);
            }
            else
            {
                Controls.Remove(diagValuePanel);
                diagValuePanel.Dispose();
                diagValuePanel = null;
            }
            ResumeLayout(true);
        }

        private void HideAllDataContent()
        {
            foreach (Control control in mainPanel.Controls)
            {
                control.Visible = false;
            }
        }

        private void showDiagValuesPanel_Update(object sender, EventArgs e)
        {
            showDiagValuesPanel.Checked = diagValuePanel != null;
        }

        public void AddContent(Control control, string text, Image image, Keys shortcut, bool left = false)
        {
            control.Dock = left ? DockStyle.Left : DockStyle.Fill;
            control.Visible = false;

            if (left)
            {
                Controls.Add(control);
                Controls.SetChildIndex(control, 1);
            }
            else
                mainPanel.Controls.Add(control);

            var button = new ToolStripButton {DisplayStyle = ToolStripItemDisplayStyle.Image};
            var menuItem = new ToolStripMenuItem();
            var action = new Action {Text = text, ToolTipText = text, Image = image, ShortcutKeys = shortcut};
            action.Execute += (sender, args) =>
                {
                    if (left)
                    {
                        control.Visible = !control.Visible;                        
                    }
                    else
                    {
                        HideAllDataContent();
                        control.Visible = true;
                    }
                };
            action.Update += (sender, args) =>
                {
                    var act = (Action) sender;
                    act.Checked = control.Visible;
                    act.Enabled = control.Enabled;
                };            
            actionList.Actions.Add(action);
            actionList.SetAction(button, action);
            actionList.SetAction(menuItem, action);
            mainToolStrip.Items.Insert(mainToolStrip.Items.IndexOf(pluginSeparator) + 1, button);
            pagesMenu.DropDownItems.Add(menuItem);
        }

        public IOnlineManager GetOnlineManager()
        {
            return onlineManager;
        }

        private void showRtGridAction_Update(object sender, EventArgs e)
        {
            showRtGridAction.Checked = rtGridPanel.Visible;
        }

        private void showChartPanelAction_Update(object sender, EventArgs e)
        {
            showChartPanelAction.Checked = diagChartPanel.Visible;
        }
    }
}

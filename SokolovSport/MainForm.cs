using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CalibrGui;
using SokolovSport.Dat;
using SokolovSport.EcuComm;
using SokolovSport.GUI;
using SokolovSport.Options;

namespace SokolovSport
{
    public partial class MainForm : Form
    {
        
        private readonly Dictionary<string, ValueControl> valueControls = new Dictionary<string, ValueControl>();  
        private readonly Dictionary<string, GraphControl> graphControls = new Dictionary<string, GraphControl>();
        private readonly Dispatcher dispatcher;
        private readonly List<string> openedDatFile;
        private CalibrItem currentCalibr;

        public MainForm()
        {
            dispatcher = new Dispatcher();
            dispatcher.Ecu.PropertyChanged += EcuOnPropertyChanged;

            InitializeComponent();
            leftTabs.AutoHiding = true;
            leftTabs.SlideHidePage();            

            versionStatusLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            openedDatFile = OptionsHelper.Options.OpenedDatFile;            
            LoadOpenedDatFilesComboBox();
        }

        private void LoadOpenedDatFilesComboBox()
        {
            openedDatFilesComboBox.BeginUpdate();
            openedDatFilesComboBox.Items.Clear();
            openedDatFilesComboBox.Items.AddRange(openedDatFile.ToArray());
            if (openedDatFilesComboBox.Items.Count > 0)
                openedDatFilesComboBox.SelectedIndex = 0;
            openedDatFilesComboBox.EndUpdate();
        }

        private void EcuOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsStarted":
                    stateStatusLabel.Text = dispatcher.Ecu.IsStarted ? "опрос ЭБУ запущен" : "опрос ЭБУ остановлен";
                    stateStatusLabel.BackColor = dispatcher.Ecu.IsStarted ? Color.LawnGreen : Color.Gold;
                    break;

                case "IsConnected":
                    connectedStatusLabel.Text = dispatcher.Ecu.IsConnected ? "связь с ЭБУ установлена" : "связь с ЭБУ отсутствует";
                    connectedStatusLabel.BackColor = dispatcher.Ecu.IsConnected ? Color.LawnGreen : Color.Gold;
                    break;
            }
        }

        void datFile_CalibrChange(object sender, CalibrChangeEventArgs e)
        {
            switch (e.PropertyChange)
            {
                case "ShowValue":
                    if (e.Calibr.ShowValue)
                        AddValueControl(e.Calibr);
                    else
                        DeleteValueControl(e.Calibr);
                    break;

                case "ShowGraph":
                    if (e.Calibr.ShowGraph)
                        AddGraphControl(e.Calibr);
                    else
                        DeleteGraphControl(e.Calibr);
                    break;
            }
        }

        private void AddGraphControl(CalibrItem calibr)
        {
            var graph = new GraphControl();
            graph.SetValue(calibr);
            graphControls.Add(calibr.Name, graph);
            graph.Dock= DockStyle.Left;
            graphsPanel.Controls.Add(graph);
            graph.BringToFront();
            PlaceGraphs();
        }

        private void PlaceGraphs()
        {
            if (graphControls.Count == 0)
            {
                mainTableLayoutPanel.RowStyles[1].Height = 0;
                return;
            }

            graphsPanel.SuspendLayout();
            mainTableLayoutPanel.RowStyles[1].Height = 145;
            var width = graphsPanel.ClientSize.Width/graphControls.Count;
            foreach (var graphControl in graphControls)
            {
                graphControl.Value.Width = width;
            }
            graphsPanel.ResumeLayout(true);
        }

        private void DeleteGraphControl(CalibrItem calibr)
        {            
            graphControls.Remove(calibr.Name);
            graphsPanel.Controls.RemoveByKey(calibr.Name);
            PlaceGraphs();
        }

        private void AddValueControl(CalibrItem calibr)
        {
            var value = new ValueControl();
            value.SetValue(calibr);
            valueControls.Add(calibr.Name, value);
            value.Dock = DockStyle.Top;
            valuesPanel.Controls.Add(value);
            value.BringToFront();
            PlaceValueControl();
        }        

        private void DeleteValueControl(CalibrItem calibr)
        {
            valueControls.Remove(calibr.Name);
            valuesPanel.Controls.RemoveByKey(calibr.Name);
            PlaceValueControl();
        }

        private void PlaceValueControl()
        {
            mainTableLayoutPanel.ColumnStyles[0].Width = valueControls.Count == 0 ? 0 : 176;
        }

        private void LoadCalibrList()
        {
            calibrationsBS.DataSource = dispatcher.DatFile.Calibrations.Values;

            leftTabs.AutoHiding = false;
            leftTabs.SlideShowPage(calibrListTabPage);
        }

        private void openDatFileCommand_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            var oldDatFile = dispatcher.DatFile;
            dispatcher.OpenDatFileDialog(this);
            var newDatFile = dispatcher.DatFile;

            PrepareOpenedDatFile(oldDatFile, newDatFile);
        }

        private void calibrationsBS_CurrentChanged(object sender, EventArgs e)
        {
            currentCalibr = GetCurrentCalibr();
            if (currentCalibr == null) return;
            calibrControl.Prepare(dispatcher.DatFile, currentCalibr);
        }

        private CalibrItem GetCurrentCalibr()
        {
            return calibrationsBS.Current as CalibrItem;
        }

        private void openOptionsDialogCommand_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            OptionsHelper.OpenDialog(this);
        }

        private void linkStatusLabel_Click(object sender, EventArgs e)
        {
            Process.Start(linkStatusLabel.Text);
            linkStatusLabel.LinkVisited = true;
        }

        private void startCommunicationCommand_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (dispatcher.DatFile == null) return;            
            dispatcher.Ecu.Start(dispatcher.DatFile);
        }

        private void startCommunicationCommand_CommandStateQuery(object sender, C1.Win.C1Command.CommandStateQueryEventArgs e)
        {
            e.Checked = dispatcher.Ecu.IsStarted;
            e.Enabled = dispatcher.DatFile != null && !dispatcher.Ecu.IsStarted;
        }

        private void stopCommunicationCommand_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            dispatcher.Ecu.Stop();
        }

        private void stopCommunicationCommand_CommandStateQuery(object sender, C1.Win.C1Command.CommandStateQueryEventArgs e)
        {
            e.Enabled = dispatcher.Ecu.IsStarted;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dispatcher.Ecu.Stop();
                OptionsHelper.SaveSettings();
                dispatcher.DatFile.Dispose();
            }
            catch
            { }
        }

        private void openDatFileCommand_CommandStateQuery(object sender, C1.Win.C1Command.CommandStateQueryEventArgs e)
        {
            e.Enabled = !dispatcher.Ecu.IsStarted;
        }

        private void calibrControl_OnCalibrEdit(object sender, CalibrEditArgs e)
        {
            dispatcher.DatFile.SaveToFile();

            if (!dispatcher.Ecu.IsConnected) return;

            var writeRequests = e.CalibrItem.CreateWriteRequest();
            foreach (var request in writeRequests)
            {
                dispatcher.Ecu.WriteRequests.Add(request);
            }            
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = !dispatcher.Ecu.IsStarted && e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var s = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            if (s.Length == 0) return;

            OpenDatFile(s[0]);
        }

        public void OpenDatFile(string path)
        {
            if (!DatHelper.TestFile(path) || dispatcher.Ecu.IsStarted) return;
            
            var oldDatFile = dispatcher.DatFile;
            if (!dispatcher.OpenDatFile(path)) return;
            var newDatFile = dispatcher.DatFile;

            PrepareOpenedDatFile(oldDatFile, newDatFile);
        }

        private void PrepareOpenedDatFile(DatFile oldDatFile, DatFile newDatFile)
        {            
            if (newDatFile == null) return;

            if (oldDatFile != null)
            {
                oldDatFile.CalibrChange -= datFile_CalibrChange;
                oldDatFile.Dispose();
            }

            newDatFile.CalibrChange += datFile_CalibrChange;
            LoadCalibrList();

            var path = newDatFile.Path;
            if (openedDatFile.Contains(path))
                openedDatFile.Remove(path);

            openedDatFile.Insert(0, path);
            LoadOpenedDatFilesComboBox();
        }

        private void openedDatFilesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OpenDatFile(openedDatFilesComboBox.Text);
        }

        private void openedDatFilesCommandControl_CommandStateQuery(object sender, C1.Win.C1Command.CommandStateQueryEventArgs e)
        {
            e.Enabled = !dispatcher.Ecu.IsStarted;
        }

        private void readCurrentCalibrCommand_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (!dispatcher.Ecu.IsConnected || currentCalibr == null) return;

            dispatcher.Ecu.ReadCalibrItems.Enqueue(currentCalibr);
        }

        private void writeCurrentCalibrCommand_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (!dispatcher.Ecu.IsConnected || currentCalibr == null) return;

            dispatcher.Ecu.WriteCalibr(currentCalibr);
        }

        private void readWriteCurrentCalibrCommand_CommandStateQuery(object sender, C1.Win.C1Command.CommandStateQueryEventArgs e)
        {
            e.Enabled = dispatcher.Ecu.IsConnected && currentCalibr != null;
        }
    }
}

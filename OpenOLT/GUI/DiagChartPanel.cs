using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EcuCommunication.Protocols;
using OpenOLT.DataValueInfo;

namespace OpenOLT.GUI
{
    internal partial class DiagChartPanel : UserControl
    {
        private OnlineManager onlineManager;
        private readonly IDictionary<string, Series> charts = new Dictionary<string, Series>();
        private readonly IDictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
        private readonly SynchronizationContext uiContext;
        private DiagDataKeeper dataKeeper;
        private readonly Color[] palette;

        public DiagChartPanel()
        {
            InitializeComponent();

            uiContext = SynchronizationContext.Current;
            ChartScale = 200;
            MinChartHeight = 150;

            palette = new Color[]
                          {
                              Color.Green,
                              Color.Blue,
                              Color.Purple,
                              Color.Lime,
                              Color.Fuchsia,
                              Color.Teal,
                              Color.Yellow,
                              Color.Gray,
                              Color.Aqua,
                              Color.Navy,
                              Color.Maroon,
                              Color.Red,
                              Color.Olive,
                              Color.Silver,
                              Color.Tomato,
                              Color.Moccasin
                          };

            foreach (var propertyInfo in typeof(DiagData).GetProperties())
            {
                properties.Add(propertyInfo.Name, propertyInfo);
            }
        }

        public void Prepare(OnlineManager onlineManager)
        {
            this.onlineManager = onlineManager;
            dataKeeper = onlineManager.dataKeeper;
            dataKeeper.diagDataList.ListChanged += diagDataList_ListChanged;

            foreach (var valueInfo in dataKeeper.valueInfos)
            {
                chartsSet.Items.Add(valueInfo.Title);
            }
        }

        void diagDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    uiContext.Send(
                        delegate
                            {
                                UpdateCharts();
                            }, null);
                    break;

                case ListChangedType.Reset:
                    uiContext.Send(
                        delegate
                            {
                                ClearCharts();
                                LoadCharts();
                            }, null);
                    break;
            }
        }

        private void LoadCharts()
        {
            foreach (var item in charts)
            {
                LoadChart(item.Key);
            }
        }

        private void LoadChart(string name)
        {
            var data = dataKeeper.diagDataList.Skip(FirstPoint).Take(ChartScale).ToArray();
            var chart = charts[name];
            chart.Points.DataBindXY(data, "_Time", data, name);
        }

        private void ClearCharts()
        {
            foreach (var item in charts)
            {
                item.Value.Points.Clear();
            }  
        }

        private void UpdateCharts()
        {
            var value = dataKeeper.diagDataList.Last();

            foreach (var item in charts)
            {
                if (item.Value.Points.Count > ChartScale)
                    for (int i = 0; i < item.Value.Points.Count - ChartScale; i++)
                    {
                        item.Value.Points.RemoveAt(0);
                    }                    
                item.Value.Points.AddXY(properties["_Time"].GetValue(value, null),
                                        properties[item.Key].GetValue(value, null));
                diagChart.ChartAreas[item.Key].RecalculateAxesScale();
            }            
        }
        
        public int ChartScale { get; set; }
        public int FirstPoint { get; set; }
        public int MinChartHeight { get; set; }

        private void AddChart(ValueInfo info)
        {
            if (diagChart.ChartAreas.IndexOf(info.Name) != -1) return;
            var chartArea = diagChart.ChartAreas.Add(info.Name);            
            chartArea.BackColor = SystemColors.Control;
            chartArea.AxisX.LabelStyle.Format = "H:mm:ss";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Number;          
            chartArea.AxisX.LabelStyle.Font = new Font(FontFamily.GenericSansSerif, 8f);            
            chartArea.AxisY.LabelStyle.Font = new Font(FontFamily.GenericSansSerif, 8f);
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.StaggeredLabels |
                                                LabelAutoFitStyles.LabelsAngleStep30 | LabelAutoFitStyles.WordWrap;
            //chartArea.AxisY.LabelStyle.IsEndLabelVisible = false;

            chartArea.CursorX.LineColor = Color.Red;
            chartArea.CursorX.LineWidth = 2;
            chartArea.CursorX.Interval = 1;
            chartArea.CursorX.IntervalType = DateTimeIntervalType.Number;
            chartArea.CursorX.IsUserEnabled = true;            

            var title = new Title
                            {
                                DockedToChartArea = info.Name,
                                Text = info.Title,
                                Font = new Font(FontFamily.GenericSansSerif, 9.75f, FontStyle.Bold),
                                Name = info.Name
                            };
            diagChart.Titles.Add(title);

            title = new Title
            {
                Name = info.Name + "Value",
                DockedToChartArea = info.Name,
                Text = info.Name + "Value",
                Font = new Font(FontFamily.GenericSansSerif, 24f, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, palette[charts.Count % palette.Length])
            };
            diagChart.Titles.Add(title); 

            var series = new Series(info.Name)
                             {
                                 ChartType = SeriesChartType.FastLine,
                                 ChartArea = info.Name,
                                 BorderWidth = 2,
                                 XValueMember = "_Time",
                                 XValueType = ChartValueType.DateTime,
                                 YValueMembers = info.Name,
                                 IsXValueIndexed = true
                             };            
            
            charts.Add(info.Name, series);           

            LoadChart(info.Name);
            diagChart.Series.Add(series);
        }

        private void AligningCharts()
        {
            var count = charts.Count;
            var frameChartCount = ClientSize.Height / MinChartHeight;
            diagChart.Height = frameChartCount < count ? count*MinChartHeight : ClientSize.Height;

            if (count == 0) return;

            var chartHeightPercent = 98/count;
            var firstChartArea = diagChart.ChartAreas[0];

            for (int i = 0; i < count; i++)
            {
                var chartArea = diagChart.ChartAreas[i];

                if (i < count - 1)
                    chartArea.AxisX.LabelStyle.Enabled = false;

                if (i > 0)
                {
                    chartArea.AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                    chartArea.AlignWithChartArea = firstChartArea.Name;
                    chartArea.AlignmentStyle = AreaAlignmentStyles.Position |
                                                AreaAlignmentStyles.PlotPosition |
                                                AreaAlignmentStyles.Cursor |
                                                AreaAlignmentStyles.AxesView;    
                }

                chartArea.Position.X = 1;
                chartArea.Position.Y = 1 + chartHeightPercent * i;
                chartArea.Position.Width = 98;
                chartArea.Position.Height = chartHeightPercent;                
            }
        }

        private void openLogAction_Execute(object sender, EventArgs e)
        {
            var path = Application.StartupPath;
            if (Directory.Exists(path + @"\logs\"))
                path += @"\logs\";

            openFileDialog.InitialDirectory = path;
            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

            dataKeeper.LoadFromFile(openFileDialog.FileName);
        }

        private void openChartsAction_Execute(object sender, EventArgs e)
        {
            var newCharts = dataKeeper.OpenCharts();
            if (newCharts.Length == 0) return;

            charts.Clear();
            diagChart.Series.Clear();
            diagChart.Titles.Clear();
            diagChart.ChartAreas.Clear();

            foreach (var info in newCharts)
            {
                AddChart(info);
            }

            AligningCharts();
        }

        private void incScaleAction_Execute(object sender, EventArgs e)
        {
            if (ChartScale > dataKeeper.diagDataList.Count) return;
            var factor = (ModifierKeys & Keys.Control) == Keys.Control ? 1.5 : 1.1;
            ChartScale = (int)Math.Ceiling(ChartScale * factor);
            if (onlineManager != null && onlineManager.OltProtocol.Connected) return;
            LoadCharts();
        }

        private void decScaleAction_Execute(object sender, EventArgs e)
        {
            if (ChartScale < 10) return;
            var factor = (ModifierKeys & Keys.Control) == Keys.Control ? 0.5 : 0.9;
            ChartScale = (int) Math.Floor(ChartScale*factor);
            if (onlineManager != null && onlineManager.OltProtocol.Connected) return;
            LoadCharts();
        }

        private void nextFrameAction_Execute(object sender, EventArgs e)
        {
            if (FirstPoint >= dataKeeper.diagDataList.Count - ChartScale) return;
            FirstPoint += ChartScale;            
            LoadCharts();
        }

        private void priorFrameAction_Execute(object sender, EventArgs e)
        {
            if (FirstPoint == 0) return;
            FirstPoint = Math.Max(0, FirstPoint - ChartScale);
            LoadCharts();
        }

        private void diagChart_Resize(object sender, EventArgs e)
        {
            AligningCharts();
        }

        private void OfflineAction_Update(object sender, EventArgs e)
        {
            var action = (Crad.Windows.Forms.Actions.Action) sender;
            action.Enabled = onlineManager != null && !onlineManager.OltProtocol.Connected;
        }

        private void chartsSetPanelAction_Execute(object sender, EventArgs e)
        {
            chartsSet.Visible = !chartsSet.Visible;
        }

        private void chartsSetPanelAction_Update(object sender, EventArgs e)
        {
            chartsSetPanelAction.Checked = chartsSet.Visible;
        }

        private void chartsSet_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var valueInfo = dataKeeper.valueInfos[e.Index];
            if (e.NewValue == CheckState.Checked)
                AddChart(valueInfo);
            else
                RemoveChart(valueInfo);

            AligningCharts();
        }

        private void RemoveChart(ValueInfo valueInfo)
        {            
            charts.Remove(valueInfo.Name);
            var index = diagChart.ChartAreas.IndexOf(valueInfo.Name);
            diagChart.ChartAreas.RemoveAt(index);
            diagChart.Titles.Remove(diagChart.Titles[valueInfo.Name]);
            diagChart.Titles.Remove(diagChart.Titles[valueInfo.Name+"Value"]);
            diagChart.Series.RemoveAt(index);
        }

        private void diagChart_CursorPositionChanging(object sender, CursorEventArgs e)
        {
            if (double.IsNaN(e.NewPosition)) return;
            
            var index = (int)e.NewPosition;
            UpdateCursorValue(index - 1);
        }

        private void UpdateCursorValue(int index)
        {            
            foreach (var item in charts)
            {
                var name = item.Key;
                var title = diagChart.Titles[name + "Value"];
                var serier = item.Value;
                var count = serier.Points.Count;
                if (count == 0) break;

                if (index >= count)
                    index = count - 1;
                else if (index < 0)
                    index = 0;
                title.Text = serier.Points[index].YValues[0].ToString("0.###");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CalibrTable;
using Helper;
using Helper.Hooks;

namespace CalibrGui
{
    public partial class TableControl : UserControl, INotifyPropertyChanged
    {
        private ITableValues table;
        private int currentRow;
        private int currentCol;
        private readonly PaletteFast fastPalette;
        private TextBox editingBox;
        private readonly int defaultColor = Color.White.ToArgb();
        private bool followTableRt;
        private readonly SynchronizationContext uiContext;
        private string xLabel;
        private string yLabel;
        private float min;
        private float max;
        


        /// <summary>
        /// Отслеживать изменения значений в ассоциированной table
        /// </summary>
        [DefaultValue(false)]
        public bool HandleValueChanged { get; set; }
        /// <summary>
        /// Следить за рабочей точкой в таблице
        /// </summary>
        [DefaultValue(false)]
        public bool FollowTableRt
        {
            get { return followTableRt; }
            set
            {
                if (followTableRt == value) return;
                followTableRt = value;
                followTableRtBtn.Checked = followTableRt;
                OnPropertyChanged("FollowTableRt");
            }
        }

        [DefaultValue(false)]
        public int CurrentRow
        {
            get { return currentRow; }
            set
            {
                if (currentRow == value) return;
                currentRow = value;
                SetCurrentCell();
                OnPropertyChanged("CurrentRow");
            }
        }

        [DefaultValue(false)]
        public int CurrentCol
        {
            get { return currentCol; }
            set
            {
                if (currentCol == value) return;
                currentCol = value;
                SetCurrentCell();
                OnPropertyChanged("CurrentCol");
            }
        }

        public bool ReadOnly
        {
            get { return rtGrid.ReadOnly; }
            set
            {
                rtGrid.ReadOnly = value;
                toolStripEx.Enabled = !value;
            }
        }

        public bool EnableHeadersVisualStyles
        {
            get { return rtGrid.EnableHeadersVisualStyles = false; }
            set { rtGrid.EnableHeadersVisualStyles = value; }
        }

        public int HeaderWidth
        {
            get { return rtGrid.RowHeadersWidth; }
            set { rtGrid.RowHeadersWidth = value; }
        }

        public TableControl()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;

            fastPalette = new PaletteFast(new Palette(), 100);
            KeyboardHook.Instance.KeyDown += KeyboardHookOnKeyDown;
        }

        public void FillPalette(IEnumerable<KeyValuePair<float, Color>> items)
        {
            fastPalette.Palette.Clear();
            fastPalette.Palette.AddElementsRange(items);
            fastPalette.FillColors();
        }

        private void KeyboardHookOnKeyDown(object sender, KeyboardHookEventArgs e)
        {
            if (!Visible) return;

            if (!FollowTableRt)
            {
                switch (e.Key)
                {
                    case Keys.D:
                        SetCurrentCell(1);
                        break;

                    case Keys.A:
                        SetCurrentCell(-1);
                        break;

                    case Keys.W:
                        SetCurrentCell(-table.ColCount);
                        break;

                    case Keys.S:
                        SetCurrentCell(table.ColCount);
                        break;
                }
            }

            if (ReadOnly) return;
            switch (e.Key)
            {
                case Keys.K:
                    ChangeTableValue((ModifierKeys & Keys.Shift) == Keys.Shift ? -10 : -1);
                    break;

                case Keys.L:
                    ChangeTableValue((ModifierKeys & Keys.Shift) == Keys.Shift ? 10 : 1);
                    break;
            }
        }

        private void ChangeTableValue(float offset, bool fill = false)
        {
            if (table == null) return;

            Cursor.Current = Cursors.WaitCursor;
            //var length = Math.Abs(table.Max - table.Min);
            //var rawLength = Math.Abs(table.RawMax - table.RawMin);

            var step = Math.Max(Math.Abs(table.ConvertRawToValue(1) - table.ConvertRawToValue(0)), 0.01f); //Math.Max(length/rawLength, 0.01f);

            var fullTableUpdate = rtGrid.SelectedCells.Count > table.Count * 0.3;
            var values = table.GetFloatValues();

            foreach (DataGridViewCell cell in rtGrid.SelectedCells)
            {
                var col = cell.ColumnIndex;
                var row = cell.RowIndex;
                var index = row * table.ColCount + col;
                var value = values[index];
                if (fill)
                    value = offset;
                else
                    value += step * offset;

                value = (float)Math.Round(Math.Min(Math.Max(table.Min, value), table.Max), 3, MidpointRounding.AwayFromZero);
                if (fullTableUpdate)
                    values[index] = value;
                else
                    table.SetFloatValue(col, row, value);
            }

            if (fullTableUpdate)
                table.SetFloatValues(values);

            Cursor.Current = Cursors.Default;
            UpdateChart();
        }

        public void Init(ITableValues table)
        {
            if (this.table != null)
            {
                this.table.ValueChanged -= TableOnValueChanged;
                this.table.PropertyChanged -= TableOnPropertyChanged;
            }
            this.table = table;

            InitGrid();
            InitChart();
            if (table == null) return;
            this.table.ValueChanged += TableOnValueChanged;
            this.table.PropertyChanged += TableOnPropertyChanged;
        }

        private void TableOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Table":
                    if (HandleValueChanged)
                        LoadGrid();
                    break;

                case "CurrentIndex":
                    if (FollowTableRt)
                    {
                        uiContext.Send(
                            delegate
                                {
                                    CalcAndSetCurrentCell();
                                    OnPropertyChanged("CurrentCol");
                                }, null);
                    }
                    break;
            }
        }

        public void CalcAndSetCurrentCell()
        {
            InvalidateCurrentCell();
            currentRow = Math.DivRem(table.CurrentIndex, table.ColCount, out currentCol);

            SetCurrentCell();
            if (ViewSwitch.Visible && table != null)
            {
                HighlightCurrentDot();
                RamChart.Update();
            }
        }

        private void HighlightCurrentDot() {
            currentRow = Math.DivRem(table.CurrentIndex, table.ColCount, out currentCol);
            for (var i = 0; i < rtGrid.RowCount; i++)
            {
                for (var j = 0; j < rtGrid.ColumnCount; j++)
                {
                    var currentElement = RamChart.Series[i].Points[j];
                    currentElement.MarkerSize = 8;
                    currentElement.MarkerColor = Color.FromArgb(180, Color.DarkBlue);
                }
            }

            var element = RamChart.Series[currentRow].Points[currentCol];
            element.MarkerSize = 10;
            element.MarkerColor = Color.FromArgb(180, Color.Red);
            element.MarkerBorderWidth = 1;
        }

        private void InitGrid()
        {
            if (table == null)
            {
                rtGrid.ColumnCount = 0;
                rtGrid.RowCount = 0;
                return;
            }

            rtGrid.ColumnCount = table.ColCount;
            rtGrid.RowCount = table.RowCount;

            for (var i = 0; i < rtGrid.RowCount; i++)
            {
                rtGrid.Rows[i].HeaderCell.Value = table.AxisY == null ? String.Empty : table.AxisY[i].ToString();
            }

            for (var i = 0; i < rtGrid.ColumnCount; i++)
            {
                rtGrid.Columns[i].Width = 50;
                rtGrid.Columns[i].HeaderCell.Value = table.AxisX == null ? String.Empty : table.AxisX[i].ToString();
                rtGrid.Columns[i].ValueType = typeof(float);
            }
        }

        public void LoadGrid()
        {
            ((ISupportInitialize)rtGrid).BeginInit();
            try
            {
                for (var i = 0; i < rtGrid.RowCount; i++)
                {
                    var row = rtGrid.Rows[i];

                    for (var j = 0; j < rtGrid.ColumnCount; j++)
                    {
                        row.Cells[j].Value = table.GetFloatValue(j, i);
                    }
                }
            }
            finally
            {
                ((ISupportInitialize)rtGrid).EndInit();
            }

            rtGrid.Refresh();
        }

        private void TableOnValueChanged(object sender, ValueChangeArgs e)
        {
            if (HandleValueChanged) UpdateValues(e.Index);
        }

        private void UpdateValues(int index)
        {
            var valueRow = index / table.ColCount;
            var valueCol = index - valueRow * table.ColCount;
            float value = table.GetFloatValue(index);

            rtGrid.Rows[valueRow].Cells[valueCol].Value = value;
            if (ViewSwitch.Checked)
                UpdateChart();
            //rtGrid.InvalidateCell(valueCol, valueRow);

            //rtChart.PeData.Y[valueRow, valueCol] = value;
            //Gigasoft.ProEssentials.Api.PEreconstruct3dpolygons(rtChart.PeSpecial.HObject);
            //rtChart.PeFunction.ResetImage(0, 0);
            //rtChart.Refresh();
        }

        private void SetCurrentCell()
        {
            if (rtGrid.RowCount == 0 || rtGrid.ColumnCount == 0) return;
            rtGrid.Select();
            rtGrid.CurrentCell = rtGrid.Rows[currentRow].Cells[currentCol];
        }

        private void SetCurrentCell(int offset)
        {
            InvalidateCurrentCell();
            var tableIndex = table.ColCount * currentRow + currentCol;
            var count = table.Count;
            tableIndex = (tableIndex + offset + count) % count;
            currentRow = tableIndex / table.ColCount;
            currentCol = tableIndex - currentRow * table.ColCount;
            SetCurrentCell();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void rtGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            var cell = rtGrid.CurrentCellAddress;
            rtGrid.InvalidateCell(-1, cell.Y);
            rtGrid.InvalidateCell(cell.X, -1);

            if (FollowTableRt) return;

            InvalidateCurrentCell();
            currentCol = cell.X;
            currentRow = cell.Y;

            OnPropertyChanged("CurrentCol");
        }

        private void InvalidateCurrentCell()
        {
            rtGrid.InvalidateCell(-1, Math.Min(currentRow, rtGrid.RowCount - 1));
            rtGrid.InvalidateCell(Math.Min(currentCol, rtGrid.ColumnCount - 1), -1);
        }

        private void rtGrid_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                var source = e.Value.ToString().Trim();
                source =
                    source.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator).Replace(".",
                                                                                                                  CultureInfo
                                                                                                                      .
                                                                                                                      InvariantCulture
                                                                                                                      .
                                                                                                                      NumberFormat
                                                                                                                      .
                                                                                                                      NumberDecimalSeparator);
                float value;
                if (float.TryParse(source, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                {
                    value = Math.Max(Math.Min(table.Max, value), table.Min);
                    table.SetFloatValue(e.ColumnIndex, e.RowIndex, value);
                }
                else
                    value = table.GetFloatValue(e.ColumnIndex, e.RowIndex);

                e.Value = value;
                e.ParsingApplied = true;
            }
            catch
            { }
        }

        private void rtGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (rtGrid.CurrentCell.ColumnIndex < 0) return;

            var tb = (rtGrid.EditingControl as TextBox);
            if (tb == null) return;
            editingBox = tb;
            tb.KeyPress += tb_KeyPress;
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                rtGrid.EndEdit();
            }
        }

        private void rtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editingBox == null) return;
            editingBox.KeyPress -= tb_KeyPress;
            editingBox = null;
        }

        private void tsbInc_Click(object sender, EventArgs e)
        {
            ChangeTableValue((ModifierKeys & Keys.Shift) == Keys.Shift ? 10 : 1);
        }

        private void tsbDec_Click(object sender, EventArgs e)
        {
            ChangeTableValue((ModifierKeys & Keys.Shift) == Keys.Shift ? -10 : -1);
        }

        private void offsetBtn_Click(object sender, EventArgs e)
        {
            var source = offsetValue.Text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            float value;
            if (float.TryParse(source, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value))
            {
                ChangeTableValue(value, false);
            }
        }

        private void persentOffsetBtn_Click(object sender, EventArgs e)
        {
            var source = offsetValue.Text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            float value;
            if (float.TryParse(source, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value))
            {
                ChangeTableValue(value);
            }
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            var source = offsetValue.Text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            float value;
            if (float.TryParse(source, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value))
            {
                ChangeTableValue(value, fill: true);
            }
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rtGrid.Rows.Count; i++)
            {
                for (int j = 0; j < rtGrid.Columns.Count; j++)
                {
                    rtGrid.Rows[i].Cells[j].Selected = true;
                }
            }
        }

        private void deselectAllBtn_Click(object sender, EventArgs e)
        {
            rtGrid.ClearSelection();
        }

        private void invertSelectBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rtGrid.Rows.Count; i++)
            {
                for (int j = 0; j < rtGrid.Columns.Count; j++)
                {
                    rtGrid.Rows[i].Cells[j].Selected = !rtGrid.Rows[i].Cells[j].Selected;
                }
            }
        }

        private void followTableRtBtn_Click(object sender, EventArgs e)
        {
            FollowTableRt = !FollowTableRt;
        }

        private void rtGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void rtGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null) return;

            var currentCellColor = Color.NavajoWhite;

            if (e.RowIndex == -1)
            {
                if (e.ColumnIndex == currentCol)
                    e.CellStyle.BackColor = currentCellColor;
            }
            else if (e.ColumnIndex == -1)
            {
                if (e.RowIndex == currentRow)
                    e.CellStyle.BackColor = currentCellColor;
            }
            else
            {
                var currentIndex = currentRow * table.ColCount + currentCol;
                var cellIndex = e.RowIndex * table.ColCount + e.ColumnIndex;

                if (cellIndex == currentIndex)
                {
                    e.CellStyle.BackColor = currentCellColor;
                }
                else
                {
                    var palette = fastPalette;
                    if (palette.Palette.Count == 0) return;

                    float value;
                    if (float.TryParse(e.Value.ToString(), out value))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(palette.GetColorOnValue(value, defaultColor));
                    }
                }
            }
        }

        private void ViewSwitch_Click(object sender, EventArgs e)
        {
            RamChart.Visible = !RamChart.Visible;
            ViewSwitch.Checked = RamChart.Visible;
            //InitChart();
        }

        [DefaultValue("X")]
        public string XLabel
        {
            get { return xLabel; }
            set
            {
                if (xLabel == value) return;
                xLabel = value;
                RamChart.ChartAreas[0].AxisX.Title = value;
                OnPropertyChanged("XLabel");
            }
        }

        [DefaultValue("Y")]
        public string YLabel
        {
            get { return yLabel; }
            set
            {
                if (yLabel == value) return;
                xLabel = value;
                RamChart.ChartAreas[0].AxisY.Title = value;
                OnPropertyChanged("YLabel");
            }
        }

        [DefaultValue("max")]
        public float Max
        {
            get => max;
            set
            {
                if (max == value) return;
                max = value;
                RamChart.ChartAreas[0].AxisY.Maximum = value;
                OnPropertyChanged("Max");
            }
        }

        [DefaultValue("min")]
        public float Min
        {
            get => min;
            set
            {
                if (min == value) return;
                min = value;
                RamChart.ChartAreas[0].AxisY.Minimum = value;
                RamChart.ChartAreas[0].AxisY.MajorGrid.Interval = (max - min) / 32;
                RamChart.ChartAreas[0].AxisY.LabelStyle.Format = "#.#";
                
                OnPropertyChanged("Min");
            }
        }

        private void InitChart()
        {
            RamChart.Series.Clear();
                      
            RamChart.ChartAreas[0].AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            RamChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            RamChart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            //RamChart.ChartAreas[0].AxisY.Crossing = 0;
            RamChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            if (table == null)
            {
                return;
            }

            for (var x = 0; x < rtGrid.RowCount; x++)
            {
                RamChart.Series.Add(table.AxisY == null ? x.ToString() : table.AxisY[x].ToString());
                //RamChart.Titles.Add(table.AxisY == null ? String.Empty : table.AxisY[x].ToString());
                RamChart.Series[x].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                RamChart.Series[x].Color = Color.FromArgb(160, Color.DarkBlue);
                RamChart.Series[x].BorderWidth = 2;
                RamChart.Series[x].MarkerSize = 8;
            }
            for (var i = 0; i < rtGrid.RowCount; i++)
            {
                for (var j = 0; j < rtGrid.ColumnCount; j++)
                {
                    RamChart.Series[i].Points.AddXY(j, table.GetFloatValue(j, i));
                    RamChart.Series[i].Points[j].AxisLabel = table.AxisX[j].ToString();
                }
            }
            UpdateChart();
        }

        public void UpdateChart() {
            if (table != null) {
                //TODO: Update max min
                //RamChart.ChartAreas[0].AxisY.Maximum += 10;
                //RamChart.ChartAreas[0].AxisY.Minimum -= 10;

                for (var i = 0; i < rtGrid.RowCount; i++)
                {
                    for (var j = 0; j < rtGrid.ColumnCount; j++)
                    {
                        var element = RamChart.Series[i].Points[j];
                        element.SetValueY(table.GetFloatValue(j, i));
                        element.AxisLabel = table.AxisX == null ? j.ToString() : table.AxisX[j].ToString();
                        element.Label = table.GetFloatValue(j, i).ToString();
                        element.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
                        element.MarkerSize = 8;
                        element.MarkerBorderColor = element.MarkerColor = Color.FromArgb(160, Color.DarkBlue);
                        element.MarkerBorderWidth = 1;
                    }
                }
                RamChart.Update();
            }
        }
        /// <summary>
        /// Currently selected data point
        /// </summary>
        private System.Windows.Forms.DataVisualization.Charting.DataPoint selectedDataPoint = null;
        private void RamChart_MouseDown(object sender, MouseEventArgs e)
        {
            // Call Hit Test Method
            System.Windows.Forms.DataVisualization.Charting.HitTestResult hitResult = RamChart.HitTest(e.X, e.Y);

            // Initialize currently selected data point
            selectedDataPoint = null;
            if (hitResult.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint)
            {
                selectedDataPoint = (System.Windows.Forms.DataVisualization.Charting.DataPoint)hitResult.Object;

                // Show point value as label
                selectedDataPoint.IsValueShownAsLabel = true;

                // Set cursor shape
                RamChart.Cursor = Cursors.SizeNS;
            }
        }
        /// <summary>
        /// Mouse Move Event
        /// </summary>
        private void RamChart_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if data point selected
            if (selectedDataPoint != null)
            {
                // Mouse coordinates should not be outside of the chart 
                int coordinate = e.Y;
                if (coordinate < 0)
                    coordinate = 0;
                if (coordinate > RamChart.Size.Height - 1)
                    coordinate = RamChart.Size.Height - 1;

                // Calculate new Y value from current cursor position
                double yValue = RamChart.ChartAreas[0].AxisY.PixelPositionToValue(coordinate);
                yValue = Math.Min(yValue, RamChart.ChartAreas[0].AxisY.Maximum);
                yValue = Math.Max(yValue, RamChart.ChartAreas[0].AxisY.Minimum);

                //TODO: set round interval based on max and min
                // Update selected point Y value
                //selectedDataPoint.YValues[0] = (Math.Round(yValue * 2, MidpointRounding.AwayFromZero) / 2);
                var newValue = Math.Round(yValue, 1, MidpointRounding.AwayFromZero);
                selectedDataPoint.YValues[0] = newValue;
                int x = (int) selectedDataPoint.XValue;
                
                table.SetFloatValue(x, 0, (float)newValue);
                // Invalidate chart
                RamChart.Invalidate();
            }
            else
            {
                // Set different shape of cursor over the data points
                System.Windows.Forms.DataVisualization.Charting.HitTestResult hitResult = RamChart.HitTest(e.X, e.Y);
                if (hitResult.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint)
                {
                    RamChart.Cursor = Cursors.Hand;
                }
                else
                {
                    RamChart.Cursor = Cursors.Default;
                }
            }
        }

        public void UpdateTableValuesFromChart()
        {
            
            for (var i = 0; i < rtGrid.RowCount; i++)
            {
                for (var j = 0; j < rtGrid.ColumnCount; j++)
                {
                    var element = RamChart.Series[i].Points[j];
                    var value =(float)element.YValues[0];
                    //rtGrid.Rows[i].Cells[j].Value = value;
                    table.SetFloatValue(j, i, value);
                }
            }

        }
    /// <summary>
    /// Mouse Up Event
    /// </summary>
    private void RamChart_MouseUp(object sender, MouseEventArgs e)
        {
            // Initialize currently selected data point
            if (selectedDataPoint != null)
            {
                // Hide point label
                selectedDataPoint.IsValueShownAsLabel = false;

                // reset selected object
                selectedDataPoint = null;

                // Invalidate chart
                RamChart.Invalidate();

                // Reset cursor style
                RamChart.Cursor = Cursors.Default;
                ///TODO: recalculate update table value;
                
            }
        }

        private void RamChart_Click(object sender, EventArgs e)
        {

        }
    }
}

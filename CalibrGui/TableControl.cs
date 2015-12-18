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

            var fullTableUpdate = rtGrid.SelectedCells.Count > table.Count*0.3;
            var values = table.GetFloatValues();
            
            foreach (DataGridViewCell cell in rtGrid.SelectedCells)
            {
                var col = cell.ColumnIndex;
                var row = cell.RowIndex;
                var index = row*table.ColCount + col;
                var value = values[index];
                if (fill)
                    value = offset;
                else
                    value += step * offset;
                
                value = (float) Math.Round(Math.Min(Math.Max(table.Min, value), table.Max), 3, MidpointRounding.AwayFromZero);
                if (fullTableUpdate)
                    values[index] = value;
                else
                    table.SetFloatValue(col, row, value);
            }

            if (fullTableUpdate)
                table.SetFloatValues(values);

            Cursor.Current = Cursors.Default;
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
                rtGrid.Columns[i].ValueType = typeof (float);                
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
            var tableIndex = table.ColCount*currentRow + currentCol;
            var count = table.Count;
            tableIndex = (tableIndex + offset + count)%count;
            currentRow = tableIndex/table.ColCount;
            currentCol = tableIndex - currentRow*table.ColCount;
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
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gigasoft.ProEssentials.Enums;
using Gigasoft.ProEssentials.EventArg;
using Helper;
using SokolovSport.Dat;

namespace SokolovSport.GUI
{
    internal partial class Calibr3DControl : UserControl
    {
        private CalibrItem calibrItem;
        private DatFile datFile;        
        private readonly PaletteFast paletteFast;
        private int paletteScale;
        private bool bDragging;
        private int nDragIndexS;
        private int nDragIndexP;
        private Point lastMousePoint;

        public event EventHandler<CalibrEditArgs> OnCalibrEdit;

        public Calibr3DControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            
            paletteFast = new PaletteFast(new Palette());

            FirstChartInit();
        }

        private void FirstChartInit()
        {
            calibr1DChart.PeDataHotSpot += Calibr1DChartOnPeDataHotSpot;
            calibr1DChart.MouseMove += Calibr1DChartOnMouseMove;
            calibr1DChart.MouseUp += Calibr1DChartOnMouseUp;

            calibr3DChart.PeDataHotSpot += Calibr1DChartOnPeDataHotSpot;
            calibr3DChart.MouseUp += Calibr1DChartOnMouseUp;
            calibr3DChart.MouseMove += Calibr3DChartOnMouseMove;
        }

        private void Calibr3DChartOnMouseMove(object sender, MouseEventArgs e)
        {
            if (!bDragging) return;
            // get last mouse location within control //'
            var pt = calibr3DChart.PeUserInterface.Cursor.LastMouseMove;
            var fY = calibr3DChart.PeData.Y[nDragIndexS, nDragIndexP];

            var deltaY = lastMousePoint.Y - pt.Y;
            var factor = (float)(calibr3DChart.PeGrid.Configure.ManualMaxY - calibr3DChart.PeGrid.Configure.ManualMinY)/
                         calibr3DChart.ClientSize.Height;

            fY += deltaY*factor;

            // Change XData and YData to new location //'
            calibr3DChart.PeData.Y[nDragIndexS, nDragIndexP] = fY;
            calibrItem.Table.SetValue(nDragIndexP, nDragIndexS, fY);

            // Performs a PartialReinitialize, ResetImage, and Invalidate //'
            calibr3DChart.PeFunction.PartialReinitialize();
            calibr3DChart.PeFunction.ResetImage(0, 0);
            calibr3DChart.Invalidate();

            lastMousePoint = pt;
        }

        private void Calibr1DChartOnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            bDragging = false;
            datFile.SaveToFile();
        }

        private void Calibr1DChartOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (!bDragging) return;
            double fX = 0, fY = 0;

            // get last mouse location within control //'
            Point pt = calibr1DChart.PeUserInterface.Cursor.LastMouseMove;
            int pX = pt.X;
            int pY = pt.Y;

            int nA = 0;
            // return the axis if MultiAxesSubsets is used without OverlapMultiAxes
            int nX = pX;
            int nY = pY;
            // This returns mouse coordinates in data units //
            calibr1DChart.PeFunction.ConvPixelToGraph(ref nA, ref nX, ref nY, ref fX, ref fY, false, false, false);

            // Check move-to location and restrain to the chart's extents.
            // Note that you can only expect to read valid ManualMinX type
            // properties after an initial PEactions = 0 or PEactions = 1
            // has been executed.

            if (fY <= calibr1DChart.PeGrid.Configure.ManualMinY)
                fY = calibr1DChart.PeGrid.Configure.ManualMinY;
            else if (fY >= calibr1DChart.PeGrid.Configure.ManualMaxY)
                fY = calibr1DChart.PeGrid.Configure.ManualMaxY;

            // Change XData and YData to new location //'
            calibr1DChart.PeData.Y[nDragIndexS, nDragIndexP] = (float)fY;
            calibrItem.Table.SetValue(nDragIndexP, nDragIndexS, (float)fY);            

            // Performs a PartialReinitialize, ResetImage, and Invalidate //'
            calibr1DChart.PeFunction.PartialReinitialize();
            calibr1DChart.PeFunction.ResetImage(0, 0);
            calibr1DChart.Invalidate();
        }

        private void Calibr1DChartOnPeDataHotSpot(object sender, DataHotSpotEventArgs e)
        {
            bDragging = true;
            nDragIndexS = e.SubsetIndex;
            nDragIndexP = e.PointIndex;
        }

        public void Prepare(DatFile datFile, CalibrItem calibrItem)
        {
            if (this.calibrItem != null)
            {
                this.calibrItem.PropertyChanged -= CalibrItemOnPropertyChanged;
                if (this.calibrItem.Table != null)
                    this.calibrItem.Table.PropertyChanged -= CalibrItemOnPropertyChanged;
            }            

            this.datFile = datFile;
            this.calibrItem = calibrItem;            

            calibrLabel.Text = String.Format("{0} ({1}), {2}", calibrItem.Description, calibrItem.Name, calibrItem.Unit);            

            calibrItem.PropertyChanged += CalibrItemOnPropertyChanged;
            if (calibrItem.Table != null)
                calibrItem.Table.PropertyChanged += CalibrItemOnPropertyChanged;

            FillPalette();
            LoadData();
        }

        private void FillPalette()
        {
            paletteScale = 1;
            paletteFast.Clear();
            if (calibrItem.Table != null)
            {
                float min, max;
                CalcMinMax(out min, out max);
                var length = max - min;
                paletteScale = length < 10 ? 100 : length < 100 ? 10 : 1;
                paletteFast.Palette.AddElement(min*paletteScale, Color.Lime.ToArgb());
                if (min != max)
                {
                    paletteFast.Palette.AddElement(length*paletteScale/2f, Color.Yellow.ToArgb());
                    paletteFast.Palette.AddElement(max*paletteScale, Color.OrangeRed.ToArgb());
                }
                paletteFast.FillColors();
            }
        }

        private void CalibrItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Table":
                    if (calibrItem.ItemInfo.ItemType == ItemTypes.Teach || calibrItem.ItemInfo.ItemType == ItemTypes.Table)
                    {
                        FillPalette();
                        LoadData();
                    }
                    break;

                case "Value":
                    if (calibrItem.ItemInfo.ItemType == ItemTypes.Var || calibrItem.ItemInfo.ItemType == ItemTypes.Const)
                    {
                        LoadData();
                    }
                    calibrInfo.Prepare(calibrItem);
                    break;
            }           
        }

        public void CalcMinMax(out float min, out float max)
        {
            var values = calibrItem.Table.GetFloatValues();
            min = float.MaxValue;
            max = float.MinValue;

            foreach (var value in values.Select(Math.Abs))
            {
                min = Math.Min(min, value);
                max = Math.Max(max, value);
            }
        }

        private void Prepare3DChart()
        {
            //calibr3DChart.PeUserInterface.HotSpot.Data = true;
            calibr3DChart.PeUserInterface.HotSpot.Size = HotSpotSize.Medium;

            calibr3DChart.PeData.NullDataValue = calibr3DChart.PeData.NullDataValueX = calibr3DChart.PeData.NullDataValueZ = -9999;

            calibr3DChart.PeColor.XZBackColor = Color.Empty;
            calibr3DChart.PeColor.YBackColor = Color.Empty;

            // Mechanism to control polygon border color //
            calibr3DChart.PeColor.BarBorderColor = Color.FromArgb(255, 0, 0, 0);
            calibr3DChart.PeColor.SubsetColors[(int)(SurfaceColors.WireFrame)] = Color.FromArgb(96, 198, 0, 0);
            calibr3DChart.PeColor.SubsetColors[(int)(SurfaceColors.SolidSurface)] = Color.FromArgb(96, 0, 148, 0);
            
            // Set various other properties //
            calibr3DChart.PeColor.BitmapGradientMode = true;
            calibr3DChart.PeColor.QuickStyle = QuickStyle.DarkLine;

            calibr3DChart.PeLegend.SimplePoint = true;
            calibr3DChart.PeLegend.SimpleLine = true;
            calibr3DChart.PeLegend.Style = SimpleLegendStyle.OneLine;

            calibr3DChart.PeString.SubTitle = String.Empty;
            calibr3DChart.PeString.MainTitle = calibrItem.Description;
            calibr3DChart.PeString.YAxisLabel = String.Format("{0}, {1}", calibrItem.Name, calibrItem.Unit);
            calibr3DChart.PeString.ZAxisLabel = calibrItem.AxisYCalibrItem == null
                                                    ? String.Empty
                                                    : String.Format("{0}, {1}", calibrItem.AxisYCalibrItem.Name,
                                                                    calibrItem.AxisYCalibrItem.Unit);
            calibr3DChart.PeString.XAxisLabel = calibrItem.AxisXCalibrItem == null
                                                    ? String.Empty
                                                    : String.Format("{0}, {1}", calibrItem.AxisXCalibrItem.Name,
                                                                    calibrItem.AxisXCalibrItem.Unit);


            calibr3DChart.PeUserInterface.Scrollbar.ViewingHeight = 20;
            calibr3DChart.PeUserInterface.Scrollbar.DegreeOfRotation = 275;
            calibr3DChart.PeUserInterface.Scrollbar.MouseDraggingX = true;
            calibr3DChart.PeUserInterface.Scrollbar.MouseDraggingY = true;
            calibr3DChart.PeFont.Fixed = true;
            calibr3DChart.PeFont.FontSize = FontSize.Large;
            calibr3DChart.PeConfigure.PrepareImages = false;
            calibr3DChart.PeConfigure.CacheBmp = false;
            calibr3DChart.PeUserInterface.Allow.FocalRect = false;

            calibr3DChart.PePlot.Method = ThreeDGraphPlottingMethod.One;
            calibr3DChart.PePlot.MarkDataPoints = true;
            calibr3DChart.PePlot.Option.ShadingStyle = ShadingStyle.White;
            calibr3DChart.PePlot.Option.ShowBoundingBox = ShowBoundingBox.Never;

            calibr3DChart.PeConfigure.TextShadows = TextShadows.BoldText;
            calibr3DChart.PeFont.MainTitle.Bold = true;
            calibr3DChart.PeFont.SubTitle.Bold = true;
            calibr3DChart.PeFont.Label.Bold = true;

            // Improves Metafile Export //
            calibr3DChart.PeSpecial.DpiX = 600;
            calibr3DChart.PeSpecial.DpiY = 600;

            calibr3DChart.PeConfigure.RenderEngine = RenderEngine.Hybrid;
            calibr3DChart.PeConfigure.AntiAliasGraphics = true;
            calibr3DChart.PeConfigure.AntiAliasText = true;
        }

        private void LoadData()
        {
            if (gridPanel.Visible)
                LoadGrid();
            else            
                LoadChart();            
        }

        private void LoadChart()
        {
            //switch (calibrItem.ItemInfo.ItemType)
            //{
            //    case ItemTypes.Table:
            //    case ItemTypes.Teach:
            //        {
            //            InitChart();
            //        }
            //        break;

            //    default:
            //        ClearCharts();
            //        break;
            //}

            InitChart();
        }

        private void ClearCharts()
        {           
        }

        public void InitChart()
        {
            var colCount = calibrItem.Table == null ? 1 : calibrItem.Table.ColCount;
            var rowCount = calibrItem.Table == null ? 1 : calibrItem.Table.RowCount;

            if (colCount > 1 && rowCount > 1)            
                Init3DChart(colCount, rowCount);            
            else
                Init1DChart(colCount, rowCount);
        }

        private void Init1DChart(int colCount, int rowCount)
        {
            calibr1DChart.Visible = true;
            calibr3DChart.Visible = false;

            calibr1DChart.PeFunction.Reset();

            var pointCount = Math.Max(colCount, rowCount);
            var axisCalibr = calibrItem.AxisYCalibrItem ?? calibrItem.AxisXCalibrItem;

            calibr1DChart.PeData.NullDataValue = calibr1DChart.PeData.NullDataValueX = calibr1DChart.PeData.NullDataValueZ = -9999;
            calibr1DChart.PeData.Subsets = 1;
            calibr1DChart.PeData.Points = pointCount;

            calibr1DChart.PeData.X.Clear();
            calibr1DChart.PeData.Y.Clear();

            calibr1DChart.PeFont.Fixed = true;
            //calibr1DChart.PeFont.FontSize = FontSize.Small;
            //calibr1DChart.PeFont.SizeGlobalCntl = 0.85f;

            calibr1DChart.PePlot.Method = SGraphPlottingMethod.PointsPlusLine;
            calibr1DChart.PePlot.MarkDataPoints = true;
            calibr1DChart.PePlot.PointSize = PointSize.Large;
            calibr1DChart.PePlot.SubsetLineTypes[0] = LineType.MediumSolid;
            calibr1DChart.PePlot.SubsetPointTypes[0] = PointType.DotSolid;

            calibr1DChart.PeLegend.SimplePoint = true;
            calibr1DChart.PeLegend.SimpleLine = true;

            calibr1DChart.PeConfigure.RenderEngine = RenderEngine.GdiPlus;
            calibr1DChart.PeConfigure.AntiAliasGraphics = true;
            calibr1DChart.PeConfigure.AntiAliasText = true;
            calibr1DChart.PeConfigure.PrepareImages = true;
            calibr1DChart.PeConfigure.CacheBmp = true;

            calibr1DChart.PeString.SubTitle = String.Empty;
            calibr1DChart.PeString.MainTitle = calibrItem.Description;
            calibr1DChart.PeString.YAxisLabel = String.Format("{0}, {1}", calibrItem.Name, calibrItem.Unit);
            calibr1DChart.PeString.XAxisLabel = axisCalibr == null ? String.Empty : String.Format("{0}, {1}", axisCalibr.Name, axisCalibr.Unit);

            calibr1DChart.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.MinMax;
            calibr1DChart.PeGrid.Configure.ManualMinY = calibrItem.MinValue;
            calibr1DChart.PeGrid.Configure.ManualMaxY = calibrItem.MaxValue;
            calibr1DChart.PeGrid.Configure.XAxisWholeNumbers = true;
            calibr1DChart.PeGrid.LineControl = GridLineControl.Both;

            calibr1DChart.PeUserInterface.HotSpot.Data = true;
            calibr1DChart.PeUserInterface.HotSpot.Size = HotSpotSize.Large;

            if (axisCalibr != null)
            {
                calibr1DChart.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.MinMax;
                calibr1DChart.PeGrid.Configure.ManualMinX = axisCalibr.MinValue;
                calibr1DChart.PeGrid.Configure.ManualMaxX = axisCalibr.MaxValue;
            }
            else
            {
                calibr1DChart.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.None;
            }
            
            for (int i = 0; i < pointCount; i++)
            {
                calibr1DChart.PeData.X[0, i] = axisCalibr == null ? i : axisCalibr.CalcValueByIndex(i, pointCount);
                calibr1DChart.PeData.Y[0, i] = calibrItem.Table == null ? calibrItem.Value : calibrItem.Table.GetValue(i);
            }

            calibr1DChart.PeFunction.ReinitializeResetImage();
            calibr1DChart.Refresh();
        }

        private void Init3DChart(int colCount, int rowCount)
        {
            calibr1DChart.Visible = false;
            calibr3DChart.Visible = true;

            var rowCalibr = calibrItem.AxisYCalibrItem;
            var colCalibr = calibrItem.AxisXCalibrItem;

            //if (rowCalibr != null)
            //    for (var i = 0; i < calibrGrid.RowCount; i++)
            //    {
            //        var value = CalcAxisLabel(calibrItem.ItemInfo.ReverseY ? calibrGrid.RowCount - i - 1 : i, rowCalibr, calibrGrid.RowCount);
            //        calibrGrid.Rows[i].HeaderCell.Value = value.ToString();
            //    }
            //else
            //    for (var i = 0; i < calibrGrid.RowCount; i++)
            //    {
            //        calibrGrid.Rows[i].HeaderCell.Value = String.Empty;
            //    }

            //if (colCalibr != null)
            //    for (var i = 0; i < calibrGrid.ColumnCount; i++)
            //    {
            //        var value = CalcAxisLabel(calibrItem.ItemInfo.ReverseX ? calibrGrid.ColumnCount - i - 1 : i, colCalibr, calibrGrid.ColumnCount);
            //        calibrGrid.Columns[i].Width = 50;
            //        calibrGrid.Columns[i].HeaderCell.Value = value.ToString();
            //    }
            //else
            //    for (var i = 0; i < calibrGrid.ColumnCount; i++)
            //    {
            //        calibrGrid.Columns[i].Width = 50;
            //        calibrGrid.Columns[i].HeaderCell.Value = String.Empty;
            //    }

            var count = colCount*rowCount;
            var X = new float[count];
            var Y = new float[count];
            var Z = new float[count];
            var index = 0;


            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    X[index] = i;
                    Z[index] = j;
                    Y[index++] = calibrItem.Table.GetValue(j, i);
                }
            }

            calibr3DChart.PeFunction.Reset();
            Prepare3DChart();
            calibr3DChart.PeData.Subsets = rowCount;
            calibr3DChart.PeData.Points = colCount;           

            Gigasoft.ProEssentials.Api.PEvsetW(calibr3DChart.PeSpecial.HObject,
                                               Gigasoft.ProEssentials.DllProperties.XData,
                                               X, count);
            Gigasoft.ProEssentials.Api.PEvsetW(calibr3DChart.PeSpecial.HObject,
                                               Gigasoft.ProEssentials.DllProperties.YData,
                                               Y, count);
            Gigasoft.ProEssentials.Api.PEvsetW(calibr3DChart.PeSpecial.HObject,
                                               Gigasoft.ProEssentials.DllProperties.ZData,
                                               Z, count);
            calibr3DChart.PeFunction.ReinitializeResetImage();
            calibr3DChart.Refresh();
        }

        private void LoadGrid()
        {            
            switch (calibrItem.ItemInfo.ItemType)
            {
                case ItemTypes.Table:
                case ItemTypes.Teach:
                    {
                        InitTable();
                        calibrGrid.AllowEditing = true;
                    }
                    break;

                case ItemTypes.Var:
                case ItemTypes.Const:
                    calibrGrid.Cols.Count = 2;
                    calibrGrid.Rows.Count = 2;
                    calibrGrid.Cols[1].Width = 50;
                    calibrGrid.Cols[1].DataType = typeof(float);
                    calibrGrid.Cols[1].Caption = String.Empty;
                    calibrGrid.Cols[1].Format = "f" + calibrItem.ItemInfo.Precision.ToString();
                    calibrGrid.Rows[1].Caption = String.Empty;
                    calibrGrid[1, 1] = calibrItem.Value;
                    calibrGrid.AllowEditing = calibrItem.ItemInfo.ItemType == ItemTypes.Const;
                    calibrGrid.Refresh();
                    break;

                default:
                    calibrGrid.AllowEditing = false;
                    break;
            }   
         
            calibrInfo.Prepare(calibrItem);
        }

        private void InitTable()
        {
            calibrGrid.Cols.Count = calibrItem.Table.ColCount + 1;           
            calibrGrid.Rows.Count = calibrItem.Table.RowCount + 1;

            var rowCalibr = calibrItem.AxisYCalibrItem;
            var colCalibr = calibrItem.AxisXCalibrItem;

            if (rowCalibr != null)
                for (var i = 1; i <= calibrItem.Table.RowCount; i++)
                {
                    var value = CalcAxisLabel((calibrItem.ItemInfo.ReverseY ? calibrItem.Table.RowCount - i + 1 : i) - 1, rowCalibr, calibrItem.Table.RowCount);
                    calibrGrid.Rows[i].Caption = value.ToString();
                }
            else
                for (var i = 1; i <= calibrItem.Table.RowCount; i++)
                {
                    calibrGrid.Rows[i].Caption = String.Empty;
                }

            if (colCalibr != null)
                for (var i = 1; i <= calibrItem.Table.ColCount; i++)
                {
                    var value = CalcAxisLabel((calibrItem.ItemInfo.ReverseX ? calibrItem.Table.ColCount - i + 1 : i) - 1, colCalibr, calibrItem.Table.ColCount);
                    calibrGrid.Cols[i].Width = 45;
                    calibrGrid.Cols[i].DataType = typeof(float);
                    calibrGrid.Cols[i].Format = "f" + calibrItem.ItemInfo.Precision.ToString();
                    calibrGrid.Cols[i].Caption = value.ToString();                    
                }
            else
                for (var i = 1; i <= calibrItem.Table.ColCount; i++)
                {                 
                    calibrGrid.Cols[i].Width = 45;
                    calibrGrid.Cols[i].DataType = typeof(float);
                    calibrGrid.Cols[i].Format = "f" + calibrItem.ItemInfo.Precision.ToString();
                    calibrGrid.Cols[i].Caption = String.Empty;
                }


            for (int i = 1; i <= calibrItem.Table.RowCount; i++)
            {
                for (int j = 1; j <= calibrItem.Table.ColCount; j++)
                {                    
                    calibrGrid[i, j] = calibrItem.Table.GetValue(j - 1, i - 1);
                }
            }
        }

        private int CalcAxisLabel(int i, CalibrItem axisCalibr, int count)
        {
            int value = 0;
            switch (axisCalibr.ItemInfo.ItemType)
            {
                case ItemTypes.Table:
                    value = (int)  Math.Round(axisCalibr.Table.GetValue(i));
                    break;

                case ItemTypes.Var:
                    value = (int)Math.Round(axisCalibr.CalcValueByIndex(i, count), MidpointRounding.AwayFromZero);
                    break;
            }

            return value;
        }

        private void gridToolStripButton_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = true;
            chartPanel.Visible = false;

            LoadData();
        }

        private void surfaceToolStripButton_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            chartPanel.Visible = true;

            LoadData();
        }

        private void calibrGrid_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Cancel || calibrItem == null) return;
            float value;
            if (float.TryParse(calibrGrid[e.Row, e.Col].ToString(), out value))
            {                
                if (calibrItem.Table != null)
                    calibrItem.Table.SetValue(e.Col - 1, e.Row - 1, value);
                else
                    calibrItem.RawValue = calibrItem.Convert2Source(value);

                DoCalibrEdit(new CalibrEditArgs
                                 {CalibrItem = calibrItem, Value = value, Col = e.Col - 1, Row = e.Row - 1});
            }
        }

        private void DoCalibrEdit(CalibrEditArgs e)
        {
            if (OnCalibrEdit != null)
                OnCalibrEdit(this, e);
        }

        private void calibrGrid_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {            
            if (e.Col == 0 || e.Row == 0) return;
            try
            {
                float value;
                if (float.TryParse(e.Text, out value))
                {
                    value = Math.Abs(value*paletteScale);
                    e.Style.BackColor = Color.FromArgb(paletteFast.GetColorOnValue(value, SystemColors.Window.ToArgb()));
                    e.Style.ForeColor = Color.Black;
                }
            }
            catch
            {}
        }
    }

    internal class CalibrEditArgs : EventArgs
    {
        public CalibrItem CalibrItem;
        public float Value;
        public int Col;
        public int Row;
    }
}

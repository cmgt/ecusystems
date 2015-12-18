using System;
using System.ComponentModel;
using System.Windows.Forms;
using Gigasoft.ProEssentials.Enums;

namespace CalibrGui
{
    public partial class GraphControl : UserControl, IShowValue
    {
        private ICalibrItem baseItem;
        private float xIndex;

        public GraphControl()
        {
            InitializeComponent();   
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void VisualPrepare()
        {
            valueGraph.PeFunction.Reset();
            
            valueGraph.PeData.NullDataValue = valueGraph.PeData.NullDataValueX = valueGraph.PeData.NullDataValueZ = -9999;
            valueGraph.PeData.Subsets = 1;
            valueGraph.PeData.Points = 20;

            // Clear out default data //
            valueGraph.PeData.X[0, 0] = 0;
            valueGraph.PeData.X[0, 1] = 0;
            valueGraph.PeData.X[0, 2] = 0;
            valueGraph.PeData.X[0, 3] = 0;
            valueGraph.PeData.Y[0, 0] = 0;
            valueGraph.PeData.Y[0, 1] = 0;
            valueGraph.PeData.Y[0, 2] = 0;
            valueGraph.PeData.Y[0, 3] = 0;
            
            valueGraph.PeFont.Fixed = true;
            valueGraph.PeFont.FontSize = FontSize.Small;
            valueGraph.PeFont.SizeGlobalCntl = 0.85f;         

            valueGraph.PeConfigure.RenderEngine = RenderEngine.Hybrid;
            valueGraph.PeConfigure.AntiAliasGraphics = false;
            valueGraph.PeConfigure.AntiAliasText = false;
            valueGraph.PeConfigure.PrepareImages = true;
            valueGraph.PeConfigure.CacheBmp = true;

            valueGraph.PeString.SubTitle = String.Empty;
            valueGraph.PeString.MainTitle = baseItem.Description;
            valueGraph.PeString.YAxisLabel = String.Format("{0}, {1}", baseItem.Name, baseItem.Unit);
            valueGraph.PeString.XAxisLabel = String.Empty;

            valueGraph.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.MinMax;
            valueGraph.PeGrid.Configure.ManualMinY = baseItem.MinValue;
            valueGraph.PeGrid.Configure.ManualMaxY = baseItem.MaxValue;
            valueGraph.PeGrid.Configure.XAxisWholeNumbers = true;
            valueGraph.PeGrid.LineControl = GridLineControl.YAxis;
           
            valueGraph.PeFunction.ReinitializeResetImage();
        }

        public void SetValue(ICalibrItem baseItem)
        {
            Clear();

            this.baseItem = baseItem;
            Name = baseItem.Name;            
            baseItem.PropertyChanged += baseItem_PropertyChanged;
            VisualPrepare();
        }

        public void Clear()
        {
            if (baseItem == null) return;
            baseItem.PropertyChanged -= baseItem_PropertyChanged;
            baseItem = null;
        }

        void baseItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Value") return;
            var newy = baseItem.Value;
            float newx = xIndex++;            
            Gigasoft.ProEssentials.Api.PEvsetW(valueGraph.PeSpecial.HObject, Gigasoft.ProEssentials.DllProperties.AppendYData, newy, 1);
            Gigasoft.ProEssentials.Api.PEvsetW(valueGraph.PeSpecial.HObject, Gigasoft.ProEssentials.DllProperties.AppendXData, newx, 1);
            valueGraph.PeFunction.ReinitializeResetImage();
            valueGraph.Refresh();
        }
    }
}

using System;
using System.Windows.Forms;
using SokolovSport.Dat;

namespace SokolovSport.GUI
{
    public partial class CalibrInfo : UserControl
    {
        public CalibrInfo()
        {
            InitializeComponent();
        }

        internal void Prepare(CalibrItem calibrItem)
        {
            FillLables(calibrName, calibrValue, calibrItem);
            FillLables(xAxisName, xAxisValue, calibrItem.AxisXCalibrItem);            
            FillLables(yAxisName, yAxisValue, calibrItem.AxisYCalibrItem);                        
            FillLables(value1Name, value1Value, calibrItem.VisualCalibr1);                        
            FillLables(value2Name, value2Value, calibrItem.VisualCalibr2);           
        }

        private static void FillLables(Label nameLable, Label valueLable, CalibrItem calibrItem)
        {
            nameLable.Visible = valueLable.Visible = calibrItem != null;
            if (calibrItem == null) return;

            nameLable.Text = String.Format("{0} ({1}), {2}", calibrItem.Description, calibrItem.Name, calibrItem.Unit);
            valueLable.Text = calibrItem.ValueStr;            
        }
    }
}

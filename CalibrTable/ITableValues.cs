using System;
using System.ComponentModel;

namespace CalibrTable
{
    public interface ITableValues: INotifyPropertyChanged
    {        
        int ColCount { get; }
        int RowCount { get; }
        int Count { get; }
        int Address { get; set; }
        int FillThreshold { get; set; }
        int CurrentIndex { get; set; }
        int LastEditCellIndex { get; }
        int CalcAddress(int index);
        int CalcFillPersent();
        void FillValues();
        void FirstInit();
        float[] GetFloatValues();
        void DoTableChanged();
        void DoValueChange(int index);
        float GetFloatValue(int index);
        float GetFloatValue(int col, int row);
        void SetFloatValue(int index, float value);
        void SetFloatValue(int col, int row, float value);
        void SetFloatValues(float[] source);
        int GetRawValue(int col, int row);
        void SetRawValue(int col, int row, int value);

        float ConvertRawToValue(int raw);

        float[] AxisX { get; set; }
        float[] AxisY { get; set; }

        float Min { get; set; }
        float Max { get; set; }
        int RawMin { get; set; }
        int RawMax { get; set; }

        event EventHandler<ValueChangeArgs> ValueChanged;
    }
}
using System;
using System.ComponentModel;
using System.Linq;

namespace CalibrTable
{
    public class TableValues<TSource, TValue> : ITableValues where  TSource: struct, IComparable<TSource> where TValue: struct, IComparable<TValue>
    {
        public object Tag { get; set; }

        private int colCount;
        public int ColCount { get { return colCount; } }
        private int rowCount;
        public int RowCount { get { return rowCount; } }
        private int count;
        public int Count { get { return count; } }
        private TableCell<TSource, TValue>[] sources;
        private TValue[] values;
        public Func<TSource, TValue> converter;
        public Func<TValue, TSource> reverseConverter;
        public int Address { get; set; }
        public int FillThreshold { get; set; }

        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex == value) return;
                currentIndex = value;
                DoPropertyChanged(new PropertyChangedEventArgs("CurrentIndex"));
            }
        }

        public float[] AxisY { get; set; }
        
        public float ConvertRawToValue(int raw)
        {
            return Convert.ToSingle(converter((TSource) Convert.ChangeType(raw, typeof (TSource))));
        }

        public float[] AxisX { get; set; }        
        public event EventHandler<ValueChangeArgs> ValueChanged; 

        public TValue CurrentValue { get { return values != null ? values[CurrentIndex] : default(TValue); } }
        public TSource CurrentRawValue { get { return sources != null ? sources[CurrentIndex].Source : default(TSource); } }

        public TSource this[int index] 
        { 
            get { return sources[index].Source; }
            set
            {
                var cell = sources[index];
                cell.OldSource = cell.Source;
                cell.Source = value;                
                cell.Count++;
            }
        }

        public TSource this[int col, int row]
        {
            get { return sources[col + row*colCount].Source; }
            set
            {
                var cell = sources[col + row * colCount];
                cell.OldSource = cell.Source;
                cell.Source = value;
                cell.Count++;
            }
        }

        public TableCell<TSource, TValue> Cell(int index)
        {
            return sources[index];
        }

        public TableCell<TSource, TValue> Cell(int col, int row)
        {
            return sources[col + row * colCount];
        }

        public TValue GetValue(int index)
        {
            return values == null ? default(TValue) : values[index];
        }        

        public TValue GetValue(int col, int row)
        {
            return values == null ? default(TValue) : values[col + row*colCount];
        }

        public float GetFloatValue(int index)
        {
            return values == null ? Convert.ToSingle(sources[index]) : Convert.ToSingle(values[index]);
        }

        public float GetFloatValue(int col, int row)
        {
            return values == null ? Convert.ToSingle(sources[col + row * colCount]) : Convert.ToSingle(values[col + row * colCount]);
        }

        public int GetRawValue(int col, int row)
        {
            return Convert.ToInt32(sources[col + row * colCount].Source);
        }

        public void SetRawValue(int col, int row, int value)
        {
            SetSource(col + row*colCount, (TSource) Convert.ChangeType(value, typeof (TSource)));
        }

        public void SetValue(int index, TValue value)
        {
            var rawValue = reverseConverter(value);
            this[index] = rawValue;

            if (values != null)
                values[index] = converter(rawValue);

            LastEditCellIndex = index;

            DoValueChange(index);
        }

        public void SetValue(int col, int row, TValue value)
        {
            SetValue(col + row * colCount, value);
        }

        public void SetFloatValue(int index, float value)
        {
            SetValue(index, (TValue)Convert.ChangeType(value, typeof(TValue)));
        }

        public void SetFloatValue(int col, int row, float value)
        {
            SetValue(col, row, (TValue)Convert.ChangeType(value, typeof(TValue)));
        }

        public int LastEditCellIndex { get; private set; }

        public float Min { get; set; }
        public float Max { get; set; }

        public int RawMin { get; set; }
        public int RawMax { get; set; }

        public string Name { get; set; }

        public void DoValueChange(int index)
        {
            if (ValueChanged != null)
                ValueChanged(this, new ValueChangeArgs {Index = index});
        }        

        public void SetSource(int index, TSource source)
        {
            sources[index].Source = source;
            values[index] = converter(source);
            DoValueChange(index);
        }

        public TableValues()
        {}

        public TableValues(int address, int col, int row): this(address, col, row, null, null)
        {}

        public TableValues(int address, int col, int row, Func<TSource, TValue> converter, Func<TValue, TSource> reverseConverter)
        {
            Address = address;
            Init(col, row, converter, reverseConverter, null);
        }

        public void Init(int col, int row, Func<TSource, TValue> converter, Func<TValue, TSource> reverseConverter, TSource[] source)
        {
            colCount = col;
            rowCount = row;
            count = colCount * rowCount;
            sources = new TableCell<TSource, TValue>[count];
            values = new TValue[count];

            for (var i = 0; i < count; i++)
            {
                sources[i] = new TableCell<TSource, TValue>();
                if (source != null)
                    sources[i].Source = source[Address + i];
            }
            this.converter = converter;
            this.reverseConverter = reverseConverter;
        }

        public int CalcAddress(int index)
        {
            return Address + index;
        }

        public int CalcFillPersent()
        {
            if (count == 0) return 0;

            var persent = 0.0;
            for (var i = 0; i < count; i++)
            {
                var cell = sources[i];
                if (!cell.StopStudy) continue;

                persent += 1;
            }

            return (int) Math.Round(persent/count*100, MidpointRounding.AwayFromZero);
        }

        public void FillValues()
        {
            if (converter == null) return;
            
            for (int i = 0; i < sources.Length; i++)
            {
                var cell = sources[i];
                var value = converter(cell.Source);
                cell.StudyValue = value;
                cell.Value = value;
                values[i] = value;
            }
        }

        public void FirstInit()
        {
            for (var i = 0; i < count; i++)
            {
                var cell = sources[i];
                cell.OldSource = cell.Source;
                cell.FirstSource = cell.Source;
                cell.Count = 0;
                cell.Error = cell.E_1 = cell.E_2 = default(TValue);
                cell.StopStudy = false;
                cell.Tag = 0;
            }
        }

        public float[] GetFloatValues()
        {
            var count = colCount * rowCount;
            var data = new float[count];

            if (values != null)
                for (int i = 0; i < count; i++)
                    data[i] = Convert.ToSingle(values[i]);
            else
                for (int i = 0; i < count; i++)
                    data[i] = Convert.ToSingle(sources[i].Source);

            return data;
        }

        public void SetFloatValues(float[] source)
        {
            if (values.Length != count) throw new IndexOutOfRangeException();

            for (int i = 0; i < count; i++)
            {
                var value = (TValue)Convert.ChangeType(source[i], typeof(TValue));

                if (values != null)
                    values[i] = value;

                var rawValue = reverseConverter(value);
                this[i] = rawValue;
            }

            DoTableChanged();
        }
        
        public TSource[] GetRawBuffer()
        {
            return (from item in sources select item.Source).ToArray();
        }

        public void SetRawBuffer(TSource[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                sources[i].Source = buffer[i];
            }
        }

        public void DoTableChanged()
        {
            DoPropertyChanged(new PropertyChangedEventArgs("Table"));            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DoPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public string xUnits { get; set; }
        public string Units { get; set; }
        public double xStart { get; set; }
        public double xEnd { get; set; }
        public ushort xPoints { get; set; }
    }
}

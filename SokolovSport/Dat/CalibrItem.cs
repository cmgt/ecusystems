using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using CalibrGui;
using CalibrTable;
using SokolovSport.EcuComm;

namespace SokolovSport.Dat
{
    class CalibrItem: ICalibrItem
    {
        private int partIndex;
        [Browsable(false)]
        public string Name { get; private set; }
        [DisplayName("Разм.")]
        public string Unit { get; private set; }
        [DisplayName("Название")]
        public string Description { get; private set; }
        [Browsable(false)]
        public string AxisX { get; private set; }
        [Browsable(false)]
        public string AxisY { get; private set; }
        [Browsable(false)]
        public string VisualCalibr1Name { get; private set; }
        [Browsable(false)]
        public string VisualCalibr2Name { get; private set; }
        [Browsable(false)]
        public ItemInfo ItemInfo { get; private set; }
        [DisplayName("Тип")]
        public string ItemType { get { return ItemInfo == null ? String.Empty : ItemInfo.ItemType.ToString(); } }

        public Request[] readRequests = new Request[0];

        private CalibrItem _axisXCalibrItem;
        public CalibrItem AxisXCalibrItem
        {
            get { return _axisXCalibrItem; }
            set
            {
                _axisXCalibrItem = value;
                _axisXCalibrItem.PropertyChanged += (sender, args) =>
                                                     {
                                                         if (args.PropertyName == "Value") CalcTableRT();
                                                     };
            }
        }

        private CalibrItem _axisYCalibrItem;
        public CalibrItem AxisYCalibrItem
        {
            get { return _axisYCalibrItem; }
            set
            {
                _axisYCalibrItem = value;
                _axisYCalibrItem.PropertyChanged += (sender, args) =>
                                                     {
                                                         if (args.PropertyName == "Value") CalcTableRT();
                                                     };
            }
        }

        private int rawValue;
        [Browsable(false)]
        public int RawValue
        {
            get { return rawValue; }
            set
            {
                if (rawValue == value) return;
                rawValue = value;
                Value = this.Convert2Value(rawValue);                
                ValueStr = Value.ToString("f" + ItemInfo.Precision, CultureInfo.InvariantCulture);
                DoPropertyChanged(new PropertyChangedEventArgs("Value"));
            }
        }        
        
        [Browsable(false), DisplayName("Значение")]
        public float Value { get; private set; }

        [DisplayName("Значение")]
        public string ValueStr { get; private set; }

        [Browsable(false)]
        public TableValues<int, float> Table { get; private set; }

        private bool showValue;
        [DisplayName("Индик.")]
        public bool ShowValue
        {
            get { return showValue; }
            set
            {
                if (showValue == value) return;
                showValue = value;
                DoPropertyChanged(new PropertyChangedEventArgs("ShowValue"));
            }
        }

        private bool showGraph;
        private readonly DatFile datFile;

        [DisplayName("График")]
        public bool ShowGraph
        {
            get { return showGraph; }
            set
            {
                if (showGraph == value) return;
                showGraph = value;
                DoPropertyChanged(new PropertyChangedEventArgs("ShowGraph"));
            }
        }

        [Browsable(false)]
        public float MinValue { get; private set; }
        [Browsable(false)]
        public float MaxValue { get; private set; }

        public CalibrItem VisualCalibr1 { get; set; }
        public CalibrItem VisualCalibr2 { get; set; }

        public CalibrItem(DatFile datFile)
        {
            this.datFile = datFile;
            ValueStr = "0";
        }

        private void CalcTableRT()
        {
            var colIndex = _axisXCalibrItem == null
                               ? 0
                               : _axisXCalibrItem.CalcIndexByValue(_axisXCalibrItem.Value, Table.ColCount);
            var rowIndex = _axisYCalibrItem == null
                               ? 0
                               : _axisYCalibrItem.CalcIndexByValue(_axisYCalibrItem.Value, Table.RowCount);

            var index = rowIndex*Table.ColCount + colIndex;
            Table.CurrentIndex = index;
        }

        public bool LoadFromPartString(string part)
        {
            var res = true;

            switch (partIndex)
            {
                case 0:
                    Description = part;
                    break;

                case 1:
                    Unit = part;
                    break;

                case 2:
                    Name = part;
                    break;

                case 3:
                    AxisX = part;
                    break;

                case 4:
                    AxisY = part;
                    break;

                case 5:
                    VisualCalibr1Name = part;
                    break;

                case 6:
                    VisualCalibr2Name = part;
                    break;

                case 7:
                    ItemInfo = new ItemInfo(part);
                    FillReadRequests();
                    FillMinMax();
                    break;

                default:
                    switch (ItemInfo.ItemType)
                    {
                        case ItemTypes.Const:
                            int value;
                            res = int.TryParse(part, out value);
                            if (res)
                                RawValue = value;
                            break;

                        case ItemTypes.Table:
                        case ItemTypes.Teach:
                            var rowIndex = partIndex - 8;
                            LoadTable(rowIndex, part);
                            if (rowIndex == ItemInfo.RowCount - 1 && Table != null)
                            {
                                Table.FillValues();
                                RawValue = Table.CurrentRawValue;
                            }
                            break;
                    }                    
                    break;
            }

            partIndex++;

            return res;
        }        

        private void FillMinMax()
        {
            MinValue = this.Convert2Value(ItemInfo.Min);
            MaxValue = this.Convert2Value(ItemInfo.Max);
        }

        private void FillReadRequests()
        {
            switch (ItemInfo.ItemType)
            {
                case ItemTypes.Var:
                case ItemTypes.Const:                
                    readRequests = this.CreateRequest(RequestType.Read, ItemInfo.Address, 0);
                    break;

                case ItemTypes.Table:
                case ItemTypes.Teach:
                    var count = ItemInfo.ColCount * ItemInfo.RowCount;
                    var reqs = new List<Request>();                     
                    for (var i = 0; i < count; i++)
                    {
                        reqs.AddRange(this.CreateRequest(RequestType.Read, this.GetTableCellAddress(i), 0));
                    }
                    readRequests = reqs.ToArray();
                    break;
            }
        }

        private void LoadTable(int rowIndex, string part)
        {
            if (ItemInfo == null) return;
            if (Table == null)
            {
                Table = new TableValues<int, float>(ItemInfo.Address, ItemInfo.ColCount, ItemInfo.RowCount,
                                                    this.Convert2Value, this.Convert2Source);

                Table.PropertyChanged += Table_PropertyChanged;
            }

            var cols = part.Split(' ');
            if (cols.Length != ItemInfo.ColCount) return;

            for (int i = 0; i < cols.Length; i++)
            {
                int cell;
                if (!int.TryParse(cols[i], out cell)) continue;

                Table[i, rowIndex] = cell;
            }
        }

        void Table_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentIndex")
            {
                RawValue = Table.CurrentRawValue;
            }
        }

        public string SaveToString()
        {
            return string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DoPropertyChanged(PropertyChangedEventArgs e)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, e);
        }
    }
}

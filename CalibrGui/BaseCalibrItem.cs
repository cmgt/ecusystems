using System;
using System.ComponentModel;

namespace CalibrGui
{
        public class BaseCalibrItem : ICalibrItem
        {
            [Browsable(false)]
            public string Name { get; private set; }
            [DisplayName("Разм.")]
            public string Unit { get; private set; }
            [DisplayName("Название")]
            public string Description { get; private set; }

            private float _value;
            [Browsable(false)]
            public float Value
            {
                get { return _value; }
                private set
                {
                    if (_value == value) return;
                    _value = value;
                    ValueStr = _value.ToString("0.###");
                    DoPropertyChanged(new PropertyChangedEventArgs("Value"));
                }
            }

            [DisplayName("Значение")]
            public string ValueStr { get; private set; }            

            [Browsable(false)]
            public float MinValue { get; private set; }
            [Browsable(false)]
            public float MaxValue { get; private set; }

            public BaseCalibrItem()
            {
                ValueStr = "0";
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

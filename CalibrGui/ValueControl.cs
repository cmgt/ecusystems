using System.ComponentModel;
using System.Windows.Forms;

namespace CalibrGui
{
    public partial class ValueControl : UserControl, IShowValue
    {
        private ICalibrItem baseItem;

        public ValueControl()
        {
            InitializeComponent();
        }

        public void SetValue(ICalibrItem baseItem)
        {
            Clear();

            this.baseItem = baseItem;
            Name = baseItem.Name;
            valueLabel.Text = baseItem.ValueStr;
            baseItem.PropertyChanged += baseItem_PropertyChanged;
            nameLabel.Text = baseItem.Description;
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

            valueLabel.Text = baseItem.ValueStr;
        }
    }
}

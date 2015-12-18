using System;
using System.ComponentModel;
using System.Globalization;
using System.IO.Ports;

namespace SerialPortEx
{
    public class SerialPortNameConverter : TypeConverter
    {
        // Fields
        private static StandardValuesCollection values;

        // Methods
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {            
            return values ?? (values = new StandardValuesCollection(SerialPort.GetPortNames()));
        }        

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string str = ((string)value).Trim();
                return str;
            }

            return base.ConvertFrom(context, culture, value);
        }       

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}

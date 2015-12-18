using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Helper
{
    /// <summary>
    /// TypeConverter для Boolean, преобразовывающий Enum к строке с учетом атрибута Description
    /// </summary>
    public class BaseBooleanTypeConverter : BooleanConverter
    {
        private readonly string m_true;
        private readonly string m_false;

        protected BaseBooleanTypeConverter(string strTrue, string strFalse)
        {

            m_true = strTrue;
            m_false = strFalse;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
          CultureInfo culture,
          object value,
          Type destType)
        {
            return (bool)value ?
              m_true : m_false;
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
          CultureInfo culture,
          object value)
        {
            return (string)value == m_true;
        }
    }

    /// <summary>
    /// TypeConverter для Enum, преобразовывающий Enum к строке с учетом атрибута Description
    /// </summary>
    public class EnumTypeConverter : EnumConverter
    {
        private readonly Type _enumType;

        /// <summary>Инициализирует экземпляр</summary>
        /// <param name="type">тип Enum</param>
        public EnumTypeConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
          Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
          CultureInfo culture,
          object value, Type destType)
        {
            var fi = _enumType.GetField(Enum.GetName(_enumType, value));
            var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            return dna == null ? value.ToString() : dna.Description;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
          Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
          CultureInfo culture,
          object value)
        {
            foreach (var fi in _enumType.GetFields())
            {
                var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                    fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }

            return Enum.Parse(_enumType, (string)value);
        }
    }

    public class BooleanTypeConverter : BaseBooleanTypeConverter
    {
        private BooleanTypeConverter() : base("Да", "Нет") { }
    }

    public class BoolEventArgs : EventArgs
    {
        public bool BoolAnswer { get; private set; }

        public BoolEventArgs(bool answer)
        {
            BoolAnswer = answer;
        }
    }

    public class UintHexTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return destinationType == typeof (string) && value is uint
                ? string.Format("0x{0:X8}", value)
                : base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var s = value as string;
            if (s != null)
            {
                var input = s;

                if (input.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    input = input.Substring(2);
                }

                return UInt32.Parse(input, NumberStyles.HexNumber, culture);
            }

            return base.ConvertFrom(context, culture, value);
        }
    } 
}

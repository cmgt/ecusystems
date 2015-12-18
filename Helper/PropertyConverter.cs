using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Helper
{
    /// <summary>
    /// Преобразователь свойств: 
    /// использовать вместе с PropertyRightAttribute и PropertyOrderAttribute
    /// </summary>
    public class PropertyConverter : ExpandableObjectConverter
    {
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Возвращает упорядоченный список свойств c учетом прав на редактирование
        /// </summary>
        public override PropertyDescriptorCollection GetProperties(
          ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var properties = TypeDescriptor.GetProperties(value, attributes);            
            return properties;
        }
    }

    #region PropertyOrder Attribute

    /// <summary>
    /// Атрибут для задания сортировки, 
    /// использовать вместе с PropertyConverter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        private readonly int _order;
        public PropertyOrderAttribute(int order)
        {
            _order = order;
        }

        public int Order
        {
            get { return _order; }
        }
    }

    #endregion

    #region PropertyOrderPair

    /// <summary>
    /// Пара имя/номер п/п с сортировкой по номеру
    /// </summary>
    internal class PropertyOrderPair : IComparable
    {
        private int _order;
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public PropertyOrderPair(string name, int order)
        {
            _order = order;
            _name = name;
        }

        /// <summary>
        /// Собственно метод сравнения
        /// </summary>
        public int CompareTo(object obj)
        {
            var otherOrder = ((PropertyOrderPair)obj)._order;

            if (otherOrder == _order)
            {
                // если Order одинаковый - сортируем по именам
                var otherName = ((PropertyOrderPair)obj)._name;
                return string.Compare(_name, otherName);
            }
            if (otherOrder > _order) return -1;

            return 1;
        }
    }

    #endregion
}

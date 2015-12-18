using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Helper
{    
    public class Palette
    {
        /// <summary>
        /// Отсортированный список пар: значение-цвет
        /// </summary>
        protected readonly SortedList<float, int> pairs = new SortedList<float, int>();

        public bool LimitAbove { get; set; }
        public bool LimitBelow { get; set; }
        public bool IsDiscrete { get; set; }
       
        //--------------------------------------
        /// <summary>
        /// Очистить список палитры
        /// </summary>
        public void Clear()
        {
            pairs.Clear();
        }

        /// <summary>
        /// Удалить элемент палитры из списка
        /// </summary>
        /// <param name="value">значение элемента палитры</param>
        public void RemoveElement(float value)
        {
            pairs.Remove(value);
        }
        /// <summary>
        /// Удалить элемент палитры по индексу
        /// </summary>
        /// <param name="index">значение элемента палитры</param>
        public void RemoveElement(int index)
        {
            if ((index < 0) && (index >= pairs.Count)) return;

            pairs.RemoveAt(index);
        }

        /// <summary>
        /// Добавить  элемент палитры в список
        /// </summary>
        /// <param name="value">значение элемента палитры</param>
        /// <param name="color">цвет элемента палитры</param>
        public void AddElement(float value, int color)
        {
            pairs.Add(value, color);       
        }

        //--------------------------------------
        /// <summary>
        /// Получить цвет по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        internal int GetColor(int index)
        {
            return pairs.Values[index];
        }

        /// <summary>
        /// Установить цвет по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        /// <param name="color">цвет</param>
        internal void SetColor(int index, int color)
        {
            var value = pairs.Keys[index];
            pairs[value] = color;            
        }

        //--------------------------------------
        /// <summary>
        /// Получить значение по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        public float GetValue(int index)
        {
            return pairs.Keys[index];           
        }

        /// <summary>
        /// Установить значение по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        /// <param name="value">значение</param>
        public void SetValue(int index, float value)
        {
            var color = pairs.Values[index];
            pairs.RemoveAt(index);            
            pairs.Add(value, color);            
        }

        //--------------------------------------
        public int Count
        {
            get { return pairs.Count; }
        }


        /// <summary>
        /// Получить цвет по значению
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="defaultColor">цвет по умолчанию</param>
        public int GetColorOnValue(float value, int defaultColor)
        {
            return InnerGetColorOnValue(value, defaultColor);
        }

        internal int InnerGetColorOnValue(float value, int defaultColor)
        {
            var count = pairs.Count;
            // палитра пустая
            if (count == 0) return defaultColor;

            // --------------------------------------------------------------
            // ищем индекс значения палитры, меньший значения параметра value
            // --------------------------------------------------------------            

            var keys = pairs.Keys;
            var values = pairs.Values;
            var bottomIndex = FindRange(value);

            // проверяем нижнюю границу
            if (bottomIndex < 0)
                return LimitBelow ? defaultColor 
                    : values[0];

            // проверяем верхнюю границу
            var topIndex = count - 1;
            if (bottomIndex >= topIndex)
                return LimitAbove ? defaultColor
                    : values[topIndex];

            if (IsDiscrete)           
                return values[bottomIndex];

            // --------------------------------
            // палитра градиентная (MFL)
            // --------------------------------
            topIndex = bottomIndex + 1;
            // коэффициент градиента
            var scale = (value - keys[bottomIndex]) / (keys[topIndex] - keys[bottomIndex]);

            // вычисляем отдельно по цветам            
            var bottomValue = values[bottomIndex];
            var topValue = values[topIndex];

            return DataHelper.CalcGradientColor(bottomValue, topValue, scale);
        }

        private int FindRange(float key)
        {
            var keys = pairs.Keys;
            var count = pairs.Count;

            for (var i = -1; i < count - 1; i++)
            {
                if (key >= keys[i + 1]) continue;
                return i;
            }

            return count;
        }

        public void AddElementsRange(IEnumerable<KeyValuePair<float, Color>> items)
        {
            foreach (var item in items)
            {
                pairs.Add(item.Key, item.Value.ToArgb());
            }
        }
    }    
}

using System;

namespace CalibrTable
{
    public static class TableHelper
    {
        public static void GetMinMax<TSource, TValue>(this TableValues<TSource, TValue> table, out TValue min, out TValue max)
            where TSource : struct, IComparable<TSource> where TValue : struct, IComparable<TValue>
        {
            min = max = default(TValue);

            var count = table.Count;
            if (count == 0) return;
            min = max = table.GetValue(0);
            for (int i = 1; i < count; i++)
            {
                var value = table.GetValue(i);
                if (value.CompareTo(max) > 0)
                    max = value;
                if (value.CompareTo(min) < 0)
                    min = value;
            }
        }

        public static TSource[,] Get2DArray<TSource, TValue>(this TableValues<TSource, TValue> table)
            where TSource : struct, IComparable<TSource> where TValue : struct, IComparable<TValue>
        {
            var res = new TSource[table.RowCount, table.ColCount];

            for (int i = 0; i < table.RowCount; i++)
            {
                for (int j = 0; j < table.ColCount; j++)
                {
                    res[i, j] = table[j, i];
                }
            }

            return res;
        }

        public static void Set2DArray<TSource, TValue>(this TableValues<TSource, TValue> table, TSource[,] source)
            where TSource : struct, IComparable<TSource> where TValue : struct, IComparable<TValue>
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                for (int j = 0; j < table.ColCount; j++)
                {
                    table[j, i] = source[i, j];
                }
            }

            table.FillValues();
        }
    }
}

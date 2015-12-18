using System;
using System.Collections.Generic;

namespace Helper
{
    public static class LocalSettingsHelper
    {
        private const string countPattern = "{0}_COUNT";        

        public static void SetValues<T>(LocalSettingsKeeper valueSaver, string name, T[] values)
        {
            var i = 0;
            var baseName = name + "_{0}";
            var countName = String.Format(countPattern, name);
            valueSaver.SetValue(countName, values.Length);

            foreach (var value in values)
            {
                valueSaver.SetValue(String.Format(baseName, i++), value);
            }
        }

        public static IEnumerable<T> GetValues<T>(LocalSettingsKeeper valueLoader, string name)
        {            
            var baseName = name + "_{0}";
            var countName = String.Format(countPattern, name);
            var count = valueLoader.GetValue(countName, 0);
            var values = new T[count];

            for (var i = 0; i < count; i++)
            {
                var value = valueLoader.GetValue(String.Format(baseName, i), default(T));
                values[i] = value;
            }

            return values;
        }
    }
}

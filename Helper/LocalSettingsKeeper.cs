using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Helper
{
    public class LocalSettingsKeeper
    {
        private IDictionary<string, string> settings;

        public void LoadSettings()
        {
            try
            {
                var path = BuildPath();
                if (!File.Exists(path))
                {
                    settings = new Dictionary<string, string>();
                    return;
                }

                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    settings = (IDictionary<string, string>) formatter.Deserialize(fs);
                }
            }
            catch
            {
                settings = new Dictionary<string, string>();
            }
        }

        public void LoadSettings(object target)
        {
            LoadSettings();

            foreach (var property in target.GetType().GetProperties())
            {
                try
                {
                    var value = GetValue(property.Name, property.GetValue(target, null));
                    property.SetValue(target,
                                      property.PropertyType.IsEnum
                                          ? Enum.Parse(property.PropertyType, value.ToString())
                                          : Convert.ChangeType(value, property.PropertyType), null);
                }
                catch { }
            }
        }

        private static string BuildPath()
        {
            return Application.StartupPath + String.Format(@"\settings.dat");
        }

        public void SaveSettings()
        {
            var path = BuildPath();
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));                
            }

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, settings);
            }
        }

        public void SaveSettings(object target)
        {
            foreach (var property in target.GetType().GetProperties())
            {
                try
                {
                    var value = property.GetValue(target, null);
                    SetValue(property.Name, value);
                }
                catch { }
            }

            SaveSettings();
        }

        public T GetValue<T>(string name, T defValue)
        {
            return settings.ContainsKey(name) ? (T) Convert.ChangeType(settings[name], typeof (T)) : defValue;
        }

        public void SetValue<T>(string name, T value)
        {
            settings[name] = value.ToString();
        }
    }
}
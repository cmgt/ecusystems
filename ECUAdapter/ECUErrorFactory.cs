using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Helper;

namespace EcuCommunication
{
    public static class ECUErrorFactory
    {
        public static readonly Dictionary<ushort, string> ErrorDescriptions = new Dictionary<ushort, string>();
        public static string[] StatusDescriptions = new string[0];

        public static void Init(string pathError, string pathStatuserror)
        {
            if (File.Exists(pathError))
            {
                ErrorDescriptions.Clear();

                var errors = File.ReadAllLines(pathError, Encoding.GetEncoding(1251));
                foreach (var item in errors)
                {
                    if (String.IsNullOrEmpty(item)) continue;
                    var error = item.Trim();
                    var index = error.IndexOf(' ');
                    var code = error.Substring(1, index - 1);
                    ushort key;
                    if (!ushort.TryParse(code, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out key)) continue;
                    ErrorDescriptions.Add(key, error.Substring(index + 1, error.Length - index - 1).TrimStart());
                }
            }

            if(!File.Exists(pathStatuserror)) return;

            StatusDescriptions = File.ReadAllLines(pathStatuserror, Encoding.GetEncoding(1251));
        }

        public static ECUError CreateECUError(ushort code, byte status)
        {
            var descr = ErrorDescriptions.ContainsKey(code) ? ErrorDescriptions[code] : "Неизвестная ошибка";
            return new ECUError(descr, code, status);
        }

        public static string[] DecodingErrorStatus(uint status)
        {
            if (status == 0) return new string[0];

            var count = Math.Min(StatusDescriptions.Length, 32);
            var errors = new List<string>(32);

            for (byte i = 0; i < count; i++)
            {
                if (DataHelper.IsBitSet(status, i))
                    errors.Add(StatusDescriptions[i]);
            }

            return errors.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Helper
{
    public static class PaletteHelper
    {
        public static KeyValuePair<float, Color>[] GetSymmetric(float min, float max)
        {
            var items = new []
                {
                    new KeyValuePair<float, Color>(min, Color.OrangeRed),
                    new KeyValuePair<float, Color>((max - min)/4f + min, Color.Yellow),
                    new KeyValuePair<float, Color>((max - min)/2f + min, Color.Lime),
                    new KeyValuePair<float, Color>((max - min)*3f/4f + min, Color.Yellow),
                    new KeyValuePair<float, Color>(max, Color.OrangeRed)
                };

            return items;
        }

        public static KeyValuePair<float, Color>[] GetLinear(float min, float max)
        {
            var items = new []
                {
                    new KeyValuePair<float, Color>(min, Color.Lime),
                    new KeyValuePair<float, Color>((max - min) / 2f + min, Color.Yellow),
                    new KeyValuePair<float, Color>(max, Color.OrangeRed)
                };

            return items;
        }
    }
}

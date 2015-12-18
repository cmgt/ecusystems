using System;
using System.Drawing;

namespace Helper
{
    public class PaletteFast
    {
        private int[] colors;
        public Palette Palette { get; private set; }

        private int min;
        private int max;
        private int minColor;
        private int maxColor;

        public int Scale { get; private set; }

        public PaletteFast(Palette palette, int scale = 1)
        {            
            Palette = palette;
            Scale = scale;
        }

        public void FillColors()
        {
            min = (int)Math.Floor(Palette.GetValue(0) * Scale);
            max = (int)Math.Ceiling(Palette.GetValue(Palette.Count - 1) * Scale);
            minColor = Palette.GetColor(0);
            maxColor = Palette.GetColor(Palette.Count - 1);
            var count = max - min + 1;
            colors = new int[count];
            var defaultColor = Color.Transparent.ToArgb();
            for (var i = 0; i < colors.Length; ++i)
                colors[i] = Palette.GetColorOnValue((min + i) / (float)Scale, defaultColor);
        }        

        public int GetColorOnValue(float value, int defaultColor)
        {
            var scaleValue = (int) Math.Round(value * Scale, MidpointRounding.AwayFromZero);

            if (scaleValue > max)
                return Palette.LimitAbove ? defaultColor : maxColor;
            if (scaleValue < min)
                return Palette.LimitBelow ? defaultColor : minColor;

            return colors[scaleValue - min];
        }

        public void Clear()
        {
            Palette.Clear();
            colors = new int[0];
        }
    }
}

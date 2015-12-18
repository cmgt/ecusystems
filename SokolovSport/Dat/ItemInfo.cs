using System;
using System.Globalization;

namespace SokolovSport.Dat
{
    internal class ItemInfo
    {
        public ushort Address { get; private set; }
        public SizeTypes SizeType { get; private set; }
        public int Mul { get; private set; }
        public int Div { get; private set; }
        public int Offset { get; private set; }
        public int Precision { get; private set; }
        public ItemTypes ItemType { get; private set; }
        public int ColCount { get; private set; }
        public int RowCount { get; private set; }
        public int BitAddress { get; private set; }
        public int Reserve1 { get; private set; }
        public int Reserve2 { get; private set; }
        public bool ReverseX { get; private set; }        
        public bool ReverseY { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Length { get { return Max - Min; } }

        public ItemInfo(string source)
        {
            LoadFromString(source);
        }

        public void LoadFromString(string source)
        {
            var parts = source.Split(' ');
            if (parts.Length < 16) return;

            Address = (ushort) (ParseInt(parts[0]) & 0xffff);
            SizeType = (SizeTypes) ParseInt(parts[1]);
            Mul = ParseInt(parts[2]);
            Div = ParseInt(parts[3]);
            Offset = ParseInt(parts[4]);
            Precision = ParseInt(parts[5]);
            ItemType = (ItemTypes) ParseInt(parts[6]);
            ColCount = ParseInt(parts[7]);
            RowCount = ParseInt(parts[8]);
            BitAddress = ParseInt(parts[9]);
            Reserve1 = ParseInt(parts[10]);
            Reserve2 = ParseInt(parts[11]);
            ReverseX = parts[12].Trim() == "1";
            ReverseY = parts[13].Trim() == "1";
            Min = ParseInt(parts[14]);
            Max = ParseInt(parts[15]);
        }

        private static int ParseInt(string source)
        {
            int res;
            if (!int.TryParse(source, out res))
                res = 0;
            
            return res;
        }

        public string SaveToString()
        {
            var buffer = new string[16];

            buffer[0] = ((short)Address).ToString(CultureInfo.InvariantCulture);
            buffer[1] = ((int) SizeType).ToString(CultureInfo.InvariantCulture);
            buffer[2] = Mul.ToString(CultureInfo.InvariantCulture);
            buffer[3] = Div.ToString(CultureInfo.InvariantCulture);
            buffer[4] = Offset.ToString(CultureInfo.InvariantCulture);
            buffer[5] = Precision.ToString(CultureInfo.InvariantCulture);
            buffer[6] = ((int) ItemType).ToString(CultureInfo.InvariantCulture);
            buffer[7] = ColCount.ToString(CultureInfo.InvariantCulture);
            buffer[8] = RowCount.ToString(CultureInfo.InvariantCulture);
            buffer[9] = BitAddress.ToString(CultureInfo.InvariantCulture);
            buffer[10] = Reserve1.ToString(CultureInfo.InvariantCulture);
            buffer[11] = Reserve2.ToString(CultureInfo.InvariantCulture);
            buffer[12] = ReverseX ? "1" : "0";
            buffer[13] = ReverseY ? "1" : "0";
            buffer[14] = Min.ToString(CultureInfo.InvariantCulture);
            buffer[15] = Max.ToString(CultureInfo.InvariantCulture);

            return String.Join(" ", buffer);
        }
    }
}
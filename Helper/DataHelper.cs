using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Helper
{
    public static class DataHelper
    {

        public static bool Compare(byte[] b1, byte[] b2)
        {
            IntPtr retval = memcmp(b1, b2, new IntPtr(b1.Length));
            return retval == IntPtr.Zero;
        }

        [DllImport("msvcrt.dll")]
        static extern IntPtr memcmp(byte[] b1, byte[] b2, IntPtr count);

        public static bool IsBitSet(byte value, byte index)
        {
            var mask = (byte) (1 << index);
            return (value & mask) == mask;
        }
        public static bool IsBitSet(uint value, byte index)
        {
            var mask = (1u << index);
            return (value & mask) == mask;
        }

        public static byte BitSet(ref byte value, byte index, bool set)
        {
            return set ? OnBit(ref value, index) : OffBit(ref value, index);
        }

        public static byte OnBit(ref byte value, byte index)
        {
            value = (byte)(value | (1 << index));

            return value;
        }

        public static byte OffBit(ref byte value, byte index)
        {
            value = (byte)(~value);
            value = (byte)(~OnBit(ref value, index));

            return value;
        }

        public static byte Swap(byte value)
        {
            return (byte) (((value & 0xF) << 4) + ((value & 0xF0) >> 4));
        }

        public static string ByteArrayToStr(byte[] buffer, int index, int count)
        {
            if (buffer == null || count < 1 || count > (buffer.Length - index)) return String.Empty;
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.AppendFormat(buffer[i + index].ToString("X2"));
            }

            return sb.ToString();
        }

        public static char[] ByteArrayToCharArray(byte[] buffer, int index, int count)
        {
            if (buffer == null || count < 1 || count > (buffer.Length - index)) return new char[0];

            var chars = new char[count];

            for (int i = 0; i < count; i++)
            {
                chars[i] = (char) buffer[index + i];
            }

            return chars;
        }

        public static byte[]CharArrayToByteArray(char[] buffer, int index, int count)
        {            
            if (buffer == null || count < 1 || count > (buffer.Length - index)) return new byte[0];

            var bytes = new byte[count];

            for (int i = 0; i < count; i++)
            {
                bytes[i] = (byte)buffer[index + i];
            }

            return bytes;
        }

        public static string ByteArrayToStr(byte[] buffer, int count)
        {
            return ByteArrayToStr(buffer, 0, count);
        }

        public static string ByteArrayToStr(byte[] buffer)
        {
            return ByteArrayToStr(buffer, buffer != null ? buffer.Length : 0);
        }

        public static byte rl(byte source)
        {
            return (byte)((byte)(source << 1) | (byte)(source >> 7));
        }

        public static byte rr(byte source)
        {
            return (byte)((byte)(source >> 1) | (byte)(source << 7));
        }

        public static byte[] Xor(byte[] source, byte[] key)
        {
            if (source == null || key == null) return source;
            var count = Math.Min(source.Length, key.Length);
            var xorArr = new byte[count];
            for (int i = 0; i < count; i++)
            {
                xorArr[i] = (byte) (source[i] ^ key[i]);
            }

            return xorArr;
        }

        public static byte[] StrToByteArray(string str)
        {
            var count = str.Length / 2;
            var sn = new byte[count];

            for (int i = 0; i < sn.Length; i++)
            {
                var valStr = str.Substring(i * 2, 2);
                var valByte = Convert.ToByte(valStr, 16);
                sn[i] = valByte;
            }

            return sn;
        }

        public static byte[] StrToByteArray(string str, int count)
        {
            var length = Math.Min(str.Length / 2, count);
            var sn = new byte[count];            

            for (int i = 0; i < length; i++)
            {
                var valStr = str.Substring(i * 2, 2);
                var valByte = Convert.ToByte(valStr, 16);
                sn[i] = valByte;
            }

            return sn;
        } 
        
        public static int IndexOf(byte[] buffer, byte[] source)
        {
            var index = 0;
            var stopIndex = source.Length - 1;
            for (var i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != source[index])
                {
                    index = 0;
                }
                else
                {
                    if (index == stopIndex) return i;
                    index++;
                }
            }

            return -1;
        }

        public static int NearCell(int[] source, int value)
        {
            var index = 0;
            if (source == null) return index;
            var delta = int.MaxValue;

            for (var i = 0; i < source.Length; i++)
            {
                var currentDelta = value - source[i];
                if (currentDelta < 0 ||  currentDelta > delta) continue;
                delta = currentDelta;
                index = i;
            }

            return index;
        }

        private static uint[] tableCrc32;

        /// <summary>
        /// Вычисление CRC32
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static uint CalculateCRC(byte[] buffer, int offset, int count)
        {
            uint result = 0xFFFFFFFF;
            if (buffer == null || buffer.Length < (offset + count)) 
                return result;

            if (tableCrc32 == null)
                InitCrc32Table();

            unchecked
            {
                //
                // Вычисление CRC
                //
                for (int i = 0; i < count; i++)
                {
                    result = ((result) >> 8) ^ tableCrc32[(buffer[i + offset]) ^ ((result) & 0x000000FF)];
                }
            }

            return ~result;
        }

        private static void InitCrc32Table()
        {
            //
            // Инициалиазация таблицы
            //
            const uint POLYNOMIAL = 0xEDB88320;
            tableCrc32 = new uint[256];

            for (uint i = 0; i < 256; i++)
            {
                var crc32 = i;

                for (int j = 8; j > 0; j--)
                {
                    if ((crc32 & 1) == 1)
                        crc32 = (crc32 >> 1) ^ POLYNOMIAL;
                    else
                        crc32 >>= 1;
                }

                tableCrc32[i] = crc32;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public static void CalcCRC(byte[] buffer)
        {
            byte crc = 0;
            for (int i = 0; i < buffer.Length - 1; i++)
            {
                crc = (byte)((crc + buffer[i]) & 0xFF);
            }

            buffer[buffer.Length - 1] = crc;
        }

        public static byte CalcXorCRC(byte[] buffer, int index, int count)
        {
            byte crc = buffer[index];
            for (int i = index + 1; i < index + count; i++)
            {
                crc = (byte)((crc ^ buffer[i]) & 0xFF);
            }

            return crc;
        }

        public static byte Hi(ushort value)
        {
            return (byte) ((value >> 8) & 0xFF);
        }

        public static byte Lo(ushort value)
        {
            return (byte) (value & 0xFF);
        }

        public static int CalcGradientColor(int startColor, int stopColor, float scale)
        {
            var rStart = (byte)(startColor >> 16);
            var gStart = (byte)(startColor >> 8);
            var bStart = (byte)startColor;

            var rStop = (byte)(stopColor >> 16);
            var gStop = (byte)(stopColor >> 8);
            var bStop = (byte)stopColor;

            rStop = (byte)(rStart + (rStop - rStart) * scale);
            gStop = (byte)(gStart + (gStop - gStart) * scale);
            bStop = (byte)(bStart + (bStop - bStart) * scale);

            return (int)(0xff000000 | (uint)(rStop << 16) | (ushort)(gStop << 8) | bStop);
        }

        public static byte[,] Smoothing(byte[,] source, byte k)
        {
            var row = source.GetLength(0);
            var col = source.GetLength(1);

            var res = new byte[row, col];

            for (int i = 0; i < row; i++)
            {                
                for (int j = 0; j < col; j++)
                {
                    if (i == 0 && j == 0) // вверх левый угол
                    {
                        res[i, j] = (byte) ((source[i, j + 1] + source[i + 1, j] + source[i + 1, j + 1]) / 3);
                    }
                    else if (i == 0 && j == col - 1) // вверх правый угол
                    {
                        res[i, j] = (byte) ((source[i, j - 1] + source[i + 1, j] + source[i + 1, j - 1]) / 3);
                    }
                    else if (i == row - 1 && j == 0) // низ левый угол
                    {
                        res[i, j] = (byte) ((source[i, j + 1] + source[i - 1, j] + source[i - 1, j + 1]) / 3);
                    }
                    else if (i == row - 1 && j == col - 1) // низ правый  угол
                    {
                        res[i, j] = (byte) ((source[i, j - 1] + source[i - 1, j] + source[i - 1, j - 1]) / 3);
                    }
                    else if (i == 0 && j != 0 && j != col - 1) // вверх
                    {
                        res[i, j] = (byte) ((source[i, j - 1] + source[i, j + 1] + source[i + 1, j - 1] + source[i + 1, j] + source[i + 1, j + 1]) / 5);
                    }
                    else if (i == row - 1 && j != 0 && j != col - 1) // низ
                    {
                        res[i, j] = (byte) ((source[i, j - 1] + source[i, j + 1] + source[i - 1, j - 1] + source[i - 1, j] + source[i - 1, j + 1]) / 5);
                    }
                    else if (i != 0 && i != row - 1 && j == 0) // левый край
                    {
                        res[i, j] = (byte) ((source[i - 1, j] + source[i - 1, j + 1] + source[i, j + 1] + source[i + 1, j] + source[i + 1, j + 1]) / 5);
                    }
                    else if (i != 0 && i != row - 1 && j == col - 1) // правый край
                    {
                        res[i, j] = (byte) ((source[i - 1, j] + source[i - 1, j - 1] + source[i, j - 1] + source[i + 1, j] + source[i + 1, j - 1]) / 5);
                    }
                    else if (i != 0 && i != row - 1 && j != 0 && j != col - 1) // общий случай
                    {
                        res[i, j] =
                            (byte)
                            ((source[i - 1, j - 1] + source[i - 1, j] + source[i - 1, j + 1] + source[i, j - 1] +
                              k*source[i, j] + source[i, j + 1] + source[i + 1, j - 1] + source[i + 1, j] +
                              source[i + 1, j + 1])/(k + 9 - 1));
                    }                
                }
            }

            return res;
        }
    }
}

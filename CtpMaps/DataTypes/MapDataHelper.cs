using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CtpMaps.DataTypes
{
    public unsafe static class MapDataHelper
    {
        private static readonly Encoding stringEncoder = Encoding.GetEncoding(1251);
        public static uint XorKey = 0x28A6FBB8;

        public static string LoadString(ref byte* source, byte fullSize = 64)
        {
            var size = Math.Min(*source, fullSize);
            source++;
            var name = new byte[size];
            Marshal.Copy((IntPtr) source, name, 0, size);

            source += fullSize;

            return stringEncoder.GetString(name);
        }

        public static void SaveString(ref byte* dest, string source, byte fullSize = 64)
        {
            *(dest++) = (byte)source.Length;

            var bytes = stringEncoder.GetBytes(source);
            Marshal.Copy(bytes, 0, (IntPtr) dest, bytes.Length);

            dest += bytes.Length;

            for (int i = source.Length; i < fullSize; i++)
            {
                *(dest++) = 0;
            }
        }

        public static ushort LoadUshort(ref byte* source)
        {
            return (ushort)(*(source++) + (*(source++) << 8));
        }

        public static void SaveUshort(ref byte* dest, ushort source)
        {
            *(dest++) = (byte) (source & 0xff);
            *(dest++) = (byte) ((source & 0xff00) >> 8);
        }

        public static uint LoadUint(ref byte* source)
        {
            return (uint) (LoadUshort(ref source) + (LoadUshort(ref source) << 16));
        }

        public static void SaveUint(ref byte* dest, uint source)
        {
            SaveUshort(ref dest, (ushort) (source & 0xffff));
            SaveUshort(ref dest, (ushort) ((source & 0xffff0000) >> 16));
        }

        public static double LoadDouble(ref byte* source)
        {
            var bytes = LoadBytes(ref source, 8);
            
            return BitConverter.ToDouble(bytes, 0);
        }

        public static void SaveDouble(ref byte* dest, double source)
        {
            var bytes = BitConverter.GetBytes(source);
            SaveBytes(ref dest, bytes);           
        }

        public static byte[] LoadBytes(ref byte* source, byte size)
        {
            var bytes = new byte[size];
            Marshal.Copy((IntPtr)source, bytes, 0, size);
            source += size;

            return bytes;
        }

        public static void SaveBytes(ref byte* dest, byte[] source, int length = -1)
        {
            var size = length == -1 ? source.Length : length;
            Marshal.Copy(source, 0, (IntPtr)dest, size);            
            dest += size;
        }

        public static string ToIdaDescr(MapEntry mapEntry)
        {
            var str = String.Join(":", new [] {mapEntry.Type.ToString(), mapEntry.Name});

            switch (mapEntry.Type)
            {
                case 3:
                    var entry1D = mapEntry.Entry1D;
                    str = String.Join(":", new[] { str, entry1D.Addr.ToString("X4"), entry1D.Units.Replace("\r", String.Empty).Replace("\n", String.Empty), entry1D.Const_type > 1 ? "1" : "0" });
                    break;

                case 1:
                    var entry2D = mapEntry.Entry2D;
                    str = String.Join(":", new[] { str, entry2D.Addr.ToString("X4"), (entry2D.Units + " - " + entry2D.xUnits).Replace("\r", String.Empty).Replace("\n", String.Empty), entry2D.xPoints.ToString() });
                    break;

                case 2:
                    var entry3D = mapEntry.Entry3D;
                    str = String.Join(":", new[] { str, entry3D.Addr.ToString("X4"), (entry3D.Units + " - " + entry3D.xUnits + " - " + entry3D.zUnits)
                        .Replace("\r", String.Empty).Replace("\n", String.Empty), 
                        entry3D.xPoints.ToString(), entry3D.zPoints.ToString() });
                    break;

                case 4:
                    var flags = mapEntry.FlagsEntry;
                    var strItems = String.Empty;
                    for (int i = 0; i < flags.Addr.Length; i++)
                    {
                        if (flags.Addr[i] == 0xFFFFFFFF) continue;

                        var bitsName = String.Empty;
                        for (int j = 0; j < 8; j++)
                        {                            
                            bitsName = String.Join("|", new[] {bitsName, flags.BitsName[i, j]});
                        }
                        strItems +=
                            String.Join(":", new[] { str, (flags.Addr[i] & 0xFFFF).ToString("X4"), flags.ItemsName[i], bitsName }) +
                            Environment.NewLine;
                    }

                    str = strItems;
                    break;

                case 5:
                    var ident = mapEntry.IdentEntry;
                    var identItems = String.Empty;
                    for (int i = 0; i < ident.Addr.Length; i++)
                    {
                        if (ident.Length[i] == 0) continue;
                        identItems +=
                            String.Join(":", new[]
                                                 {
                                                     str, (ident.Addr[i] & 0xFFFF).ToString("X4"), ident.ItemsName[i],
                                                     ident.Length[i].ToString()
                                                 }) +
                            Environment.NewLine;
                    }
                    str = identItems;
                    break;

                default:
                    return String.Empty;
            }

            return str;
        }

        public static uint GetId(MapEntry entry)
        {
            switch ((MapEntryType)entry.Type)
            {
                case MapEntryType.Ident:
                    return entry.IdentEntry.Comp_id;

                case MapEntryType.Entry1D:
                    return entry.Entry1D.Comp_id;

                case MapEntryType.Entry2D:
                    return entry.Entry2D.Comp_id;

                case MapEntryType.Entry3D:
                    return entry.Entry3D.Comp_id;

                case MapEntryType.Folder:
                    return entry.Level;

                case MapEntryType.Flags:
                    return entry.FlagsEntry.Comp_id;

                default:
                    throw new NotSupportedException();
            }
        }

        public static bool UnpackCtpFirmware(FileInfo fileInfo, bool showMessage, IWin32Window owner)
        {
            string unpacker = Application.StartupPath + @"\unpacker.exe";
            string arguments = String.Format("{0} {0}", fileInfo.FullName);

            using (var process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = unpacker;
                process.StartInfo.Arguments = arguments;

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                fileInfo.Refresh();
                if (process.ExitCode != 0 || fileInfo.Length != 0x10000)
                {
                    if (showMessage)
                        MessageBox.Show(owner,
                                        String.Format(
                                            "Файл прошивки {0} имеет неверный размер или поврежден. {1}",
                                            fileInfo.FullName, output));
                    return false;
                }
            }

            return true;
        }
    }
}

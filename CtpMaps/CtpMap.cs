using System;
using System.Collections.Generic;
using System.IO;
using CtpMaps.DataTypes;

namespace CtpMaps
{
    public unsafe class CtpMap
    {
        public readonly List<MapEntry> Entries = new List<MapEntry>();
        private byte[] rawBuffer;
        private MapHeader mapHeader;
        public string Path { get; private set; }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;

            Path = path;
            Entries.Clear();

            rawBuffer = File.ReadAllBytes(path);

            //43544D  - CTM
            if (rawBuffer[0] != 0x43 || rawBuffer[1] != 0x54 || rawBuffer[2] != 0x4D)
                throw new Exception("Wrong file");

            fixed (byte* ptr = rawBuffer)
            {
                var stopPtr = (int)ptr + rawBuffer.Length;

                mapHeader = *((MapHeader*) ptr);
                var entryHeaderPtr = ptr + sizeof (MapHeader);

                if (mapHeader.Version_hi == 7)
                {
                    entryHeaderPtr += 35;
                }

                var olt = mapHeader.Version_hi == 1;

                while ((int)entryHeaderPtr < stopPtr)
                {
                    var entryHeader = new MapEntry(ref entryHeaderPtr, olt);
                    Entries.Add(entryHeader);                                       
                }
            }
        }

        public void SaveToFile(string path, bool olt = false)
        {
            if (olt)
            {
                var oltMapHeader = new MapHeader();
                *(oltMapHeader.Ctm) = 0x43;
                *(oltMapHeader.Ctm + 1) = 0x54;
                *(oltMapHeader.Ctm + 2) = 0x4D;
                oltMapHeader.Version_hi = 1;
                oltMapHeader.Version_lo = 0;

                MapFactory.SaveToFile(path, oltMapHeader, Entries, true);
            }
            else
            {
                MapFactory.SaveToFile(path, mapHeader, Entries);
            }
        }

        public void SaveToFile(string path, IEnumerable<MapEntry> entries, bool olt = false)
        {
            MapFactory.SaveToFile(path, mapHeader, entries, olt);
        }
        
        public string CheckCompareId()
        {
            var rnd = new Random((int) DateTime.Now.Ticks);
            var message = String.Empty;

            foreach (var entry in Entries)
            {
                switch (entry.Type)
                {
                    case 5:
                        if (entry.IdentEntry.Comp_id == 0 || entry.IdentEntry.Comp_id == 0xFFFFFFFF)
                        {
                            entry.IdentEntry.Comp_id = (uint) rnd.Next(int.MinValue, int.MaxValue);
                            message += String.Format("CompareID: {0}; Address: {1}\r\n ", entry.IdentEntry.Comp_id,
                                                     entry.IdentEntry.Addr[0].ToString("X4"));
                        }
                        break;

                    case 4:
                        if (entry.FlagsEntry.Comp_id == 0 || entry.FlagsEntry.Comp_id == 0xFFFFFFFF)
                        {
                            entry.FlagsEntry.Comp_id = (uint) rnd.Next(int.MinValue, int.MaxValue);
                            message += String.Format("CompareID: {0}; Address: {1}\r\n", entry.FlagsEntry.Comp_id,
                                                     entry.FlagsEntry.Addr[0].ToString("X4"));
                        }
                        break;

                    case 3:
                        if (entry.Entry1D.Comp_id == 0 || entry.Entry1D.Comp_id == 0xFFFFFFFF)
                        {
                            entry.Entry1D.Comp_id = (uint) rnd.Next(int.MinValue, int.MaxValue);
                            message += String.Format("CompareID: {0}; Address: {1}\r\n", entry.Entry1D.Comp_id,
                                                     entry.Entry1D.Addr.ToString("X4"));
                        }
                        break;

                    case 1:
                        if (entry.Entry2D.Comp_id == 0 || entry.Entry2D.Comp_id == 0xFFFFFFFF)
                        {
                            entry.Entry2D.Comp_id = (uint) rnd.Next(int.MinValue, int.MaxValue);
                            message += String.Format("CompareID: {0}; Address: {1}\r\n", entry.Entry2D.Comp_id,
                                                     entry.Entry2D.Addr.ToString("X4"));
                        }
                        break;

                    case 2:
                        if (entry.Entry3D.Comp_id == 0 || entry.Entry3D.Comp_id == 0xFFFFFFFF)
                        {
                            entry.Entry3D.Comp_id = (uint) rnd.Next(int.MinValue, int.MaxValue);
                            message += String.Format("CompareID: {0}; Address: {1}\r\n", entry.Entry3D.Comp_id,
                                                     entry.Entry3D.Addr.ToString("X4"));
                        }
                        break;

                }
            }

            return message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace CtpMaps.DataTypes
{
    public static class MapFactory
    {
        public static unsafe void SaveToFile(string path, MapHeader mapHeader, IEnumerable<MapEntry> entries, bool olt = false)
        {
            var buffer = new byte[1 * 1024 * 1024];

            uint length;
            fixed (byte* ptr = buffer)
            {
                var currentPtr = ptr;

                *((MapHeader*)currentPtr) = mapHeader;
                currentPtr += sizeof(MapHeader);


                foreach (var entry in entries)
                {
                    entry.WriteToBuffer(ref currentPtr, olt);
                }

                length = (uint)(currentPtr - ptr);
            }

            Array.Resize(ref buffer, (int)length);
            File.WriteAllBytes(path, buffer);
        }
    }
}

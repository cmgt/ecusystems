using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;
using SokolovSport.Dat;

namespace SokolovSport.EcuComm
{
    struct Request
    {
        public readonly RequestType Type;
        public readonly byte AddrLo;
        public readonly byte AddrHi;
        public readonly ushort Address;
        
        private byte rawValue;
        public byte RawValue
        {
            get { return rawValue; }
            set
            {                
                if (rawValue == value) return;
                rawValue = value;
                IsChanged = true;
            }
        }

        public bool IsChanged { get; set; }

        public Request(RequestType type, ushort address, byte rawValue)
            : this()
        {
            Type = type;
            Address = address;
            AddrLo = DataHelper.Lo(address);
            AddrHi = DataHelper.Hi(address);
            RawValue = rawValue;
        }
    }

    enum RequestType: byte
    {
        Read = (byte) 'r',
        Write = (byte) 'w'
    }
}

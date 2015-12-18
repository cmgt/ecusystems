using System;

namespace EcuCommunication.Protocols.Requests
{
    class WriteRamRequest : JRequest
    {
        public void Prepare(int address, byte[] source)
        {           
            Prepare(address, source, 0, source.Length);
        }

        public void Prepare(int address, byte[] source, int index, int length)
        {
            if (source == null) return;
            
            requestBuffer = new byte[length + 10];
            requestBuffer[0] = 0x80;
            requestBuffer[1] = 0x10;
            requestBuffer[2] = 0xF1;
            requestBuffer[3] = (byte)((length + 5) & 0xFF);
            requestBuffer[4] = 0x3D;
            requestBuffer[5] = 0x00;
            requestBuffer[6] = (byte)(((address & 0xFFFF) >> 8) & 0xFF);
            requestBuffer[7] = (byte)(address & 0xFF);
            requestBuffer[8] = (byte)(length & 0xFF);

            Array.Copy(source, index, requestBuffer, 9, length);
            CalcCRC();
        }

        protected override bool TestRequestEcho()
        {
            return true;
        }
    }
}

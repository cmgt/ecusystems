using System;
using System.Collections.Generic;
using System.Text;
using Helper;

namespace EcuCommunication
{
    public class JRequest: Request
    {
        protected bool longRequestHeader;
        protected int replyOffset;
        protected int replyLength;
        protected byte header;
        protected int packetLength;
        protected int replyValueOffset;

        public bool IsOnline { get { return isOnline; } }
        protected bool isOnline;

        public JRequest()
        {}

        public JRequest(string request)
        {
            requestBuffer = DataHelper.StrToByteArray(request);
        }

        protected void Init()
        {
            var count = requestBuffer.Length;
            longRequestHeader = (count - 3) > 63;
            requestBuffer[0] = (byte) (longRequestHeader ? 0x80 : 0x80 | count);
            requestBuffer[1] = 10;
            requestBuffer[2] = 0xF1;
            if (longRequestHeader)
                requestBuffer[3] = (byte) count;
        }

        protected void CalcCRC()
        {
            byte crc = 0;
            for (var i = 0; i < requestBuffer.Length - 1; i++)
            {
                crc = (byte)((crc + requestBuffer[i]) & 0xFF);
            }

            requestBuffer[requestBuffer.Length - 1] = crc;
        }

        protected virtual bool TestRequestEcho()
        {
            var strReply = DataHelper.ByteArrayToStr(replyBuffer);
            var strRequest = DataHelper.ByteArrayToStr(requestBuffer);

            return !String.IsNullOrEmpty(strReply) && strReply.Contains(strRequest);
        }

        protected virtual bool TestReply()
        {
            if (replyBuffer == null || requestBuffer == null) return false;

            replyOffset = requestBuffer.Length;
            replyLength = replyBuffer.Length - replyOffset;
            if (replyLength <= 0) return false;

            header = replyBuffer[replyOffset];
            if ((header & 0x80) != 0x80) return false;
            var headerSize = (header & 0xBF) == 0x80 ? 4 : 3;
            if (replyLength < headerSize) return false;

            packetLength = headerSize == 4 ? replyBuffer[replyOffset + 3] : header & 0x3F;

            if (packetLength != (replyLength - headerSize - 1)) return false;

            replyValueOffset = replyOffset + headerSize + 1;

            //Test request result (0x7F)
            if (replyBuffer[replyValueOffset - 1] == 0x7F) return false;

            if (TestCRC)
            {
                byte crc = 0;

                for (int i = replyOffset; i < replyBuffer.Length - 1; i++)
                {
                    crc += replyBuffer[i];
                }

                return crc == replyBuffer[replyBuffer.Length - 1];
            }

            return true;
        }

        public bool TestCRC = true;        

        public override bool Test()
        {
            Valid = TestRequestEcho() && TestReply();
            return Valid;
        }        
    }
}

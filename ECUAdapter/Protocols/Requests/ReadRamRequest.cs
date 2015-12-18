using System;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    class ReadRamRequest: JRequest
    {
        public byte[] value;
        private int length;

        public void Prepare(int address, int count)
        {
            value = null;
            length = count;            
            requestBuffer =
                DataHelper.StrToByteArray(String.Format("8510F12300{0}{1}00", (address & 0xFFFF).ToString("X4"),
                                                        (count & 0xFF).ToString("X2")));
            CalcCRC();
        }

        protected override bool TestRequestEcho()
        {
            return true;
        }

        protected override void DoExecute(EventArgs e)
        {
            base.DoExecute(e);

            if (Test())
            {
                ParseValues();
            }
        }

        private void ParseValues()
        {
            var valueOffset = replyValueOffset;
            if (valueOffset + length >= replyBuffer.Length) return;
            value = new byte[length];
            Array.Copy(replyBuffer, valueOffset, value, 0, length);
        }
    }
}

using System;

namespace EcuCommunication.Protocols.Requests
{
    internal sealed class SimpleADCDataRequest : JRequest
    {
        public float ADCKNOCK;
        public float ADCMAF;
        public float ADCTWAT;
        public float ADCTAIR;
        public float ADCUBAT;
        public float ADCLAM;
        public float ADCTPS;

        public SimpleADCDataRequest()
            : base("8210F12103A7")
        {
            TestCRC = false;
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
            if ((valueOffset + 51) > replyBuffer.Length) return;

            ADCKNOCK = replyBuffer[valueOffset + 7] * 5f / 256f;
            ADCMAF = replyBuffer[valueOffset + 28] * 5f / 256f;
            ADCTWAT = replyBuffer[valueOffset + 32] * 5f / 256f;
            ADCTAIR = replyBuffer[valueOffset + 33] * 5f / 256f;
            ADCUBAT = replyBuffer[valueOffset + 29] * 0.287f * 5f / 256f;
            ADCLAM = replyBuffer[valueOffset + 40] * 5f / 256f;
            ADCTPS = replyBuffer[valueOffset + 31] * 5f / 256f;
        }
    }
}

using System;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    internal sealed class OltDiagV3DataRequest : JRequest, IDiagDataRequest
    {
        private readonly DiagData diagData;
        public DiagData DiagData { get { return diagData; } }

        public OltDiagV3DataRequest()
            : base("8210F1210FB3")
        {
            TestCRC = false;
            isOnline = true;
            diagData = new DiagData();
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
            var valueOffset = replyValueOffset + 1;
            if ((valueOffset + 49) > replyBuffer.Length) return;

            diagData.TRT = replyBuffer[valueOffset + 7];
            diagData.RPM = (ushort)(5000000f / ((replyBuffer[valueOffset + 10] << 8) + replyBuffer[valueOffset + 9]));
            diagData.RPM40 = (ushort)(replyBuffer[valueOffset + 8] * 40);
            diagData.UOZ = (sbyte)(((sbyte)replyBuffer[valueOffset + 14]) >> 1);
            diagData.KUOZ1 = (sbyte)(((sbyte)replyBuffer[valueOffset + 15]) >> 1);
            diagData.KUOZ2 = (sbyte)(((sbyte)replyBuffer[valueOffset + 16]) >> 1);
            diagData.KUOZ3 = (sbyte)(((sbyte)replyBuffer[valueOffset + 17]) >> 1);
            diagData.KUOZ4 = (sbyte)(((sbyte)replyBuffer[valueOffset + 18]) >> 1);
            diagData.TWAT = (sbyte)(replyBuffer[valueOffset + 4] - 40);
            diagData.TAIR = (sbyte)(replyBuffer[valueOffset + 33] - 40);
            diagData.ALF = (replyBuffer[valueOffset + 5] + 128) / 256f;
            diagData.AFR = 14.7f * diagData.ALF;
            diagData.UFRXX = replyBuffer[valueOffset + 11];
            //diagData.SSM = replyBuffer[valueOffset + 17];
            diagData.COEFF = (replyBuffer[valueOffset + 12] + 128) / 256f;
            diagData.DGTC_LEAN = ((replyBuffer[valueOffset + 41] << 8) + replyBuffer[valueOffset + 40]) / 256f;
            diagData.DGTC_RICH = ((replyBuffer[valueOffset + 39] << 8) + replyBuffer[valueOffset + 38]) / 256f;
            diagData.Faza = (short)(((sbyte)replyBuffer[valueOffset + 13]) * 3);
            diagData.INJ = ((replyBuffer[valueOffset + 43] << 8) + replyBuffer[valueOffset + 42]) / 125f;
            diagData.AIR = ((replyBuffer[valueOffset + 45] << 8) + replyBuffer[valueOffset + 44]) / 10f;
            diagData.GBC = ((replyBuffer[valueOffset + 47] << 8) + replyBuffer[valueOffset + 46]) / 6f;
            diagData.SPD = replyBuffer[valueOffset + 31];

            diagData.ADCKNOCK = replyBuffer[valueOffset + 19] * 0.01953125f; //5f / 256f;
            diagData.ADCMAF = replyBuffer[valueOffset + 20] * 0.01953125f; //5f / 256f;
            diagData.ADCTWAT = replyBuffer[valueOffset + 24] * 0.01953125f; //5f / 256f;
            diagData.ADCTAIR = replyBuffer[valueOffset + 25] * 0.01953125f; //5f / 256f;
            diagData.ADCUBAT = replyBuffer[valueOffset + 21] * 0.00560546875f; //0.287f * 5f / 256f;
            diagData.ADCLAM = ((replyBuffer[valueOffset + 35] << 8) + replyBuffer[valueOffset + 34]) * 5f / 0xFFFFf;
            diagData.ADCTPS = replyBuffer[valueOffset + 23] * 0.01953125f; //5f / 256f;

            var status1 = replyBuffer[valueOffset];
            var status2 = replyBuffer[valueOffset + 1];
            var dkStatus = replyBuffer[valueOffset + 29];

            diagData.fSTOP = DataHelper.IsBitSet(status1, 0);
            diagData.fXX = DataHelper.IsBitSet(status1, 1);
            diagData.fPOW = DataHelper.IsBitSet(status1, 2);
            diagData.fFUELOFF = DataHelper.IsBitSet(status1, 3);
            diagData.fDETZONE = DataHelper.IsBitSet(status1, 5);
            diagData.fDET = DataHelper.IsBitSet(status2, 5);
            diagData.fADS = DataHelper.IsBitSet(status1, 6);
            diagData.fLAMREG = DataHelper.IsBitSet(status1, 4);
            diagData.fLAM = DataHelper.IsBitSet(status2, 7);
            diagData.fLEARN = DataHelper.IsBitSet(status1, 7);
            diagData.fLAMRDY = DataHelper.IsBitSet(dkStatus, 0);
            diagData.fLAMHEAT = DataHelper.IsBitSet(dkStatus, 1);
        }
    }
}

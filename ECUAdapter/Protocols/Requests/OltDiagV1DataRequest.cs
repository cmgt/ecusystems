using System;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    internal class OltDiagV1DataRequest : JRequest, IDiagDataRequest
    {
        protected DiagData diagData;
        public DiagData DiagData { get { return diagData; } }

        public OltDiagV1DataRequest()
            : this("8210F1210FB3")
        {
        }

        protected OltDiagV1DataRequest(string request)
            : base(request)
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

        protected virtual void ParseValues()
        {            
            var valueOffset = replyValueOffset + 1;
 
            diagData.TRT = replyBuffer[valueOffset + 11];
            var cycleTime = (replyBuffer[valueOffset + 15] << 8) + replyBuffer[valueOffset + 14];
            diagData.RPM = (ushort)(5000000f / cycleTime);
            diagData.RPM40 = (ushort)(replyBuffer[valueOffset + 12] * 40);
            diagData.RPM_GBC_RT = replyBuffer[valueOffset + 7];
            diagData.UOZ = ((sbyte)replyBuffer[valueOffset + 20]) / 2f;
            diagData.KUOZ1 = (((sbyte)replyBuffer[valueOffset + 21]) / 2f);
            diagData.KUOZ2 = (((sbyte)replyBuffer[valueOffset + 22]) / 2f);
            diagData.KUOZ3 = (((sbyte)replyBuffer[valueOffset + 23]) / 2f);
            diagData.KUOZ4 = (((sbyte)replyBuffer[valueOffset + 24]) / 2f);
            diagData.TWAT = (sbyte)(replyBuffer[valueOffset + 8] - 40);
            diagData.TAIR = (sbyte)(replyBuffer[valueOffset + 37] - 40);            
            diagData.ALF = (replyBuffer[valueOffset + 9] + 128) / 256f;
            diagData.AFR = 14.7f * diagData.ALF;
            diagData.UFRXX = replyBuffer[valueOffset + 16];
            diagData.SSM = replyBuffer[valueOffset + 17];
            diagData.COEFF = (replyBuffer[valueOffset + 18] + 128) / 256f;
            diagData.DGTC_LEAN = ((replyBuffer[valueOffset + 42] << 8) + replyBuffer[valueOffset + 41]) / 256f;
            diagData.DGTC_RICH = ((replyBuffer[valueOffset + 40] << 8) + replyBuffer[valueOffset + 39]) / 256f;
            diagData.Faza = (short)(((sbyte)replyBuffer[valueOffset + 19]) * 3);
            var injTime = (replyBuffer[valueOffset + 44] << 8) + replyBuffer[valueOffset + 43];
            diagData.INJ = injTime / 125f;
            diagData.FUSE = injTime * 33.3f / cycleTime;
            diagData.AIR = ((replyBuffer[valueOffset + 46] << 8) + replyBuffer[valueOffset + 45]) / 10f;
            diagData.GBC = ((replyBuffer[valueOffset + 48] << 8) + replyBuffer[valueOffset + 47]) / 6f;
            diagData.SPD = replyBuffer[valueOffset + 35];

            diagData.ADCKNOCK = replyBuffer[valueOffset + 25] * 0.01953125f; //5f / 256f;
            diagData.ADCMAF = replyBuffer[valueOffset + 26] * 0.01953125f; //5f / 256f;
            diagData.ADCTWAT = replyBuffer[valueOffset + 30] * 0.01953125f; //5f / 256f;
            diagData.ADCTAIR = replyBuffer[valueOffset + 31] * 0.01953125f; //5f / 256f;
            diagData.ADCUBAT = replyBuffer[valueOffset + 27] * 0.093f; //0.287f * 5f / 256f;            
            
            var adcLam = (sbyte)((((replyBuffer[valueOffset + 38] << 7) + 0x80) & 0xFF00) >> 8);
            diagData.ADCLAM = adcLam * 0.01953125f; //5f / 256f;
            
            diagData.ADCTPS = replyBuffer[valueOffset + 29] * 0.01953125f; //5f / 256f;

            var status1 = replyBuffer[valueOffset];
            var status2 = replyBuffer[valueOffset + 1];
            var dkStatus = replyBuffer[valueOffset + 33];

            diagData.fSTOP = DataHelper.IsBitSet(status1, 0);
            diagData.fXX = DataHelper.IsBitSet(status1, 1);
            diagData.fXXPrev = DataHelper.IsBitSet(status2, 1);
            diagData.fXXFix = DataHelper.IsBitSet(status2, 2);
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

            diagData.ErrorStatus =
                (uint)
                ((replyBuffer[valueOffset + 6] << 24) + (replyBuffer[valueOffset + 5] << 16) +
                 (replyBuffer[valueOffset + 4] << 8) + replyBuffer[valueOffset + 3]);
            diagData.ErrorCount = replyBuffer[valueOffset + 2];
        }
    }
}

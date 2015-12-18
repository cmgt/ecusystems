using System;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    internal sealed class Rus83DiagDataRequest : JRequest, IDiagDataRequest
    {
        private readonly DiagData diagData;
        public DiagData DiagData { get { return diagData; } }

        public Rus83DiagDataRequest()
            : base("8210F12101A5")
        {
            TestCRC = false;
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
            if ((valueOffset + 26) > replyBuffer.Length) return;

            diagData.TRT = replyBuffer[valueOffset + 10];
            diagData.RPM = diagData.RPM40 = (ushort)(replyBuffer[valueOffset + 11] * 40);
            diagData.RPM_XX = (ushort)(replyBuffer[valueOffset + 12] * 10);
            diagData.UOZ = (sbyte)(((sbyte)replyBuffer[valueOffset + 16]) >> 1);
            diagData.TWAT = (sbyte)(replyBuffer[valueOffset + 8] - 40);
            //diagData.ALF = (replyBuffer[valueOffset + 11] + 128) / 256f;
            //diagData.AFR = 14.7f * diagData.ALF;
            diagData.UFRXX = replyBuffer[valueOffset + 13];
            diagData.SSM = replyBuffer[valueOffset + 14];
            diagData.COEFF = (replyBuffer[valueOffset + 15] + 128) / 256f;
            diagData.INJ = ((replyBuffer[valueOffset + 21] << 8) + replyBuffer[valueOffset + 20]) / 125f;
            diagData.AIR = ((replyBuffer[valueOffset + 23] << 8) + replyBuffer[valueOffset + 22]) / 10f;
            diagData.GBC = ((replyBuffer[valueOffset + 25] << 8) + replyBuffer[valueOffset + 24]) / 6f;
            diagData.SPD = replyBuffer[valueOffset + 17];

            var status1 = replyBuffer[valueOffset + 2];
            var status2 = replyBuffer[valueOffset + 3];
            //var dkStatus = replyBuffer[valueOffset + 23];

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
            //diagData.fLAMRDY = DataHelper.IsBitSet(dkStatus, 0);
            //diagData.fLAMHEAT = DataHelper.IsBitSet(dkStatus, 1);

            diagData.ErrorStatus = (uint)(replyBuffer[valueOffset + 4] << 32 + replyBuffer[valueOffset + 5] <<
                                           16 + replyBuffer[valueOffset + 6] << 8 + replyBuffer[valueOffset + 7]);
        }
    }
}

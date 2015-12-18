using System;
using System.Collections.Generic;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    public sealed class Euro2DiagDataRequest : JRequest, IDiagDataRequest
    {
        private readonly DiagData diagData;
        public DiagData DiagData { get { return diagData; } }

        public Euro2DiagDataRequest()
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
            if ((valueOffset + 28) > replyBuffer.Length) return;

            diagData.TRT = replyBuffer[valueOffset + 10];
            diagData.RPM = diagData.RPM40 = (ushort)(replyBuffer[valueOffset + 11] * 40);
            diagData.RPM_XX = (ushort)(replyBuffer[valueOffset + 12] * 10);
            diagData.UOZ = (sbyte)(((sbyte)replyBuffer[valueOffset + 16]) >> 1);            
            diagData.TWAT = (sbyte)(replyBuffer[valueOffset + 8] - 40);            
            diagData.ALF = (replyBuffer[valueOffset + 9] + 128) / 256f;
            diagData.AFR = 14.7f * diagData.ALF;
            diagData.UFRXX = replyBuffer[valueOffset + 13];
            diagData.SSM = replyBuffer[valueOffset + 14];
            diagData.COEFF = (replyBuffer[valueOffset + 15] + 128) / 256f;
            diagData.INJ = ((replyBuffer[valueOffset + 23] << 8) + replyBuffer[valueOffset + 22]) / 125f;
            diagData.AIR = ((replyBuffer[valueOffset + 25] << 8) + replyBuffer[valueOffset + 24]) / 10f;
            diagData.GBC = ((replyBuffer[valueOffset + 27] << 8) + replyBuffer[valueOffset + 26]) / 6f;
            diagData.SPD = replyBuffer[valueOffset + 17];            

            var status1 = replyBuffer[valueOffset + 2];
            var status2 = replyBuffer[valueOffset + 3];
            var dkStatus = replyBuffer[valueOffset + 21];            

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

            diagData.ErrorStatus = (uint)((replyBuffer[valueOffset + 7] << 24) + (replyBuffer[valueOffset + 6] << 16) + (replyBuffer[valueOffset + 5] << 8) + replyBuffer[valueOffset + 4]);            
        }

        public static byte[] ToAnswerBuffer(DiagData diagData)
        {
            var byteList = new List<byte>();
            byteList.AddRange(new byte[] { 0x80, 0xF1, 0x10, 0x26, 0x61, 0x01 });

            byteList.Add(0x00); // 0
            byteList.Add(0x00); // 1

            byte status1 = 0;
            DataHelper.BitSet(ref status1, 0, diagData.fSTOP);
            DataHelper.BitSet(ref status1, 1, diagData.fXX);
            DataHelper.BitSet(ref status1, 2, diagData.fPOW);
            DataHelper.BitSet(ref status1, 3, diagData.fFUELOFF);
            DataHelper.BitSet(ref status1, 4, diagData.fLAMREG);
            DataHelper.BitSet(ref status1, 5, diagData.fDETZONE);
            DataHelper.BitSet(ref status1, 6, diagData.fADS);
            DataHelper.BitSet(ref status1, 7, diagData.fLEARN);
            byteList.Add(status1); //2

            byte status2 = 0;
            DataHelper.BitSet(ref status2, 5, diagData.fDET);
            DataHelper.BitSet(ref status2, 7, diagData.fLAM);
            byteList.Add(status2); //3

            byteList.Add(0x00);  //4
            byteList.Add(0x00);  //5
            byteList.Add(0x00);  //6
            byteList.Add(0x00);  //7

            byteList.Add((byte) (diagData.TWAT + 40));
            byteList.Add((byte) (diagData.ALF * 256 - 128));
            byteList.Add(diagData.TRT);
            byteList.Add((byte) (diagData.RPM40 / 40)); // 11
            byteList.Add((byte) (diagData.RPM_XX / 10));  //12 
            byteList.Add(diagData.UFRXX);
            byteList.Add(diagData.SSM);
            byteList.Add((byte) (diagData.COEFF * 256 - 128));
            byteList.Add((byte) (diagData.UOZ * 2));  // 16
            byteList.Add(diagData.SPD);

            byteList.Add(0x00);  //18
            byteList.Add(0x00);  //19
            byteList.Add(0x00);  //20

            byte dkStatus = 0;
            DataHelper.BitSet(ref dkStatus, 0, diagData.fLAMRDY);
            DataHelper.BitSet(ref dkStatus, 1, diagData.fLAMHEAT);
            byteList.Add(status2);

            var inj = (int)(diagData.INJ*125);
            byteList.Add((byte)(inj & 0xFF));
            byteList.Add((byte)((inj & 0xFF00) >> 8));

            var air = (int)(diagData.AIR * 10);
            byteList.Add((byte)(air & 0xFF));
            byteList.Add((byte)((air & 0xFF00) >> 8));

            var gbc = (int)(diagData.GBC * 6);
            byteList.Add((byte)(gbc & 0xFF));
            byteList.Add((byte)((gbc & 0xFF00) >> 8));
            
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);
            byteList.Add(0x00);            
            var answer = byteList.ToArray();
            DataHelper.CalcCRC(answer);

            return answer;
        }
    }
}

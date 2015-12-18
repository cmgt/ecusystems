using System;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    internal class J7esOltDiagDataRequest : OltDiagV1DataRequest
    {
        private readonly J7esDiagData j7esDiagData;
        public J7esOltDiagDataRequest():
            base("8210F1210DB1")
        {
            j7esDiagData = new J7esDiagData();
            diagData = j7esDiagData;
        }

        protected override void ParseValues()
        {
            base.ParseValues();

            var index = replyValueOffset + 52;
            
            j7esDiagData.PRESS_RT = replyBuffer[index++];
            var tcharge = replyBuffer[index++];
            j7esDiagData.TchargeCoeff = replyBuffer[index++] / 256f;
            j7esDiagData.Tcharge = (sbyte) (tcharge - 40*j7esDiagData.TchargeCoeff);
            j7esDiagData.DUOZ = ((sbyte)replyBuffer[index++]) / 2f;
            j7esDiagData.LaunchFuelCutOff = (short)(replyBuffer[index++] * 40);
            j7esDiagData.KGTC = replyBuffer[index++] / 128f;
            j7esDiagData.KnockFlags = replyBuffer[index++];
            j7esDiagData.MisFireFlags = replyBuffer[index++];
            j7esDiagData.KGBC_DAD = replyBuffer[index++] / 128f;
            j7esDiagData.UOZ_TCORR = ((sbyte)replyBuffer[index++]) / 2f;
            j7esDiagData.KBARR_GTC = replyBuffer[index++] / 128f;
            j7esDiagData.JUFRXX = replyBuffer[index++] * 10;
            j7esDiagData.JFRXX1 = replyBuffer[index++] * 10;
            j7esDiagData.JFRXX2 = replyBuffer[index++] * 10;
            j7esDiagData.KINJ_AIRFREE = replyBuffer[index++] / 256f;
            j7esDiagData.DUOZ_REGXX = ((sbyte)replyBuffer[index++]) / 2f;
            j7esDiagData.DERR_RPM = (short) (((sbyte)replyBuffer[index++]) * 10);
            j7esDiagData.DIUOZ = ((sbyte)replyBuffer[index++]) / 2f;
            j7esDiagData.DELAY_FUEL_CUTOFF = replyBuffer[index++];
            j7esDiagData.TLE_PIN_0_7 = replyBuffer[index++];
            j7esDiagData.TLE_PIN_8_15 = replyBuffer[index++];
            j7esDiagData.TURBO_DYNAMICS = (byte) (((sbyte)replyBuffer[index++]) * 100f / 255f);
            j7esDiagData.WGDC = (byte) (replyBuffer[index++] * 100f / 255f);

            j7esDiagData.TWAT_RT = replyBuffer[index++];
            j7esDiagData.RPM_RT = replyBuffer[index++];            
            j7esDiagData.RPM_THR_RT = replyBuffer[index++];

            int rpm_rt_16;
            j7esDiagData.THR_RT_16 = (byte) Math.DivRem(j7esDiagData.RPM_THR_RT, 16, out rpm_rt_16);
            j7esDiagData.RPM_RT_16 = (byte) rpm_rt_16;
            //j7esDiagData.RPM_RT_16 = (byte)(DataHelper.Swap((byte)(j7esDiagData.RPM_RT + 8)) & 0xF);

            j7esDiagData.StartFlags = replyBuffer[index++];
            //if (DataHelper.IsBitSet(j7esDiagData.StartFlags, 0))
            //    j7esDiagData.FUSE *= 2f;
            j7esDiagData.DELTA_RPM_XX = ((sbyte)replyBuffer[index++]) * 10;
            j7esDiagData.PXX_ZONE = replyBuffer[index++];
            j7esDiagData.UGB_RXX = replyBuffer[index++] / 5f;
            j7esDiagData.DUOZ_LAUNCH = replyBuffer[index++]*6;
            j7esDiagData.GBC_RT = replyBuffer[index++];
            j7esDiagData.GBC_RT_16 = (byte)(DataHelper.Swap((byte)(j7esDiagData.RPM_RT + 8)) & 0xF);
            j7esDiagData.Knock = (ushort)((replyBuffer[index + 1] << 8) + replyBuffer[index]);
            index += 2;

            j7esDiagData.FchargeGBC = (ushort)((replyBuffer[index + 1] << 8) + replyBuffer[index]);
            index += 2;
            j7esDiagData.FchargeGBCFin = (ushort) ((replyBuffer[index + 1] << 8) + replyBuffer[index]);
            index += 2;
            j7esDiagData.Press = ((replyBuffer[index + 1] << 8) + replyBuffer[index]) / 100f;
            index += 2;            
            j7esDiagData.DGTC_DadRich = ((replyBuffer[index + 1] << 8) + replyBuffer[index]) / 256f;
            index += 2;
            j7esDiagData.TARGET_BOOST = ((replyBuffer[index + 1] << 8) + replyBuffer[index]) / 100f;            
        }
    }
}

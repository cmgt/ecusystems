namespace EcuCommunication.Protocols
{
    public static class DiagProtocolHelper
    {
        public static byte[] CalcEcuSn(byte[] snHash)
        {            
            byte b = 0;
            var key = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                byte a = 3;
                a *= b;
                a += 0xA5;
                b = a;

                a = snHash[i];
                key[i] = (byte)(a - b);
                b = a;
            }

            return key;
        }

        public static byte[] InitEcuSnHashBuffer(byte[] ecuSn, int length)
        {
            byte b = 0;
            var keyLength = ecuSn.Length;
            var ecuSnHashBuffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                byte a = 3;
                a *= b;
                a += 0xA5;
                b = a;
                a = ecuSn[i % keyLength];
                a += b;
                b = a;
                ecuSnHashBuffer[i] = a;
            }

            return ecuSnHashBuffer;
        }

        public static string GetLogHeader()
        {
            return
                "H:MM:SS.ms;TRT;RPM;RPM40;UFRXX;SSM;TWAT;TAIR;ALF;AFR;ALF_LC1;AFR_LC1;COEFF;DGTC_RICH;DGTC_LEAN;UOZ;KUOZ1;KUOZ2;KUOZ3;KUOZ4;FAZ;INJ;AIR;GBC;SPD;ADCKNOCK;ADCMAF;ADCTWAT;ADCTAIR;ADCTPS;ADCUBAT;ADCLAM;fSTOP;fXX;fPOW;fFUELOFF;fDETZONE;fDET;fADS;fLAMREG;fLAM;fLEARN;fLAMRDY;fLAMHEAT;";                
        }
    }
}

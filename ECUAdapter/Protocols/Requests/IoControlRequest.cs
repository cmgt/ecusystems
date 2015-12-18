using System;
using Helper;

namespace EcuCommunication.Protocols.Requests
{
    internal class IoControlRequest: JRequest
    {
        public void StopCapture(byte id)
        {
            requestBuffer = DataHelper.StrToByteArray(String.Format("8310F130{0}0000", id.ToString("X2")));
            CalcCRC();
        }

        public void StartCaptureAndSetValue(byte id, byte value)
        {
            requestBuffer =
                DataHelper.StrToByteArray(String.Format("8410F130{0}07{1}00", id.ToString("X2"), value.ToString("X2")));
            CalcCRC();
        }       
    }
}

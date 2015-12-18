using System;
using System.Collections.Generic;
using System.Text;

namespace EcuCommunication.Protocols.Requests
{
    class StartCaptureRequest : JRequest
    {
        public StartCaptureRequest()
            : base("8310F130710025")
        {
        }

        public void Prepare(byte id)
        {
            requestBuffer[5] = id;
            CalcCRC();
        }
    }
}

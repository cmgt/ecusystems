using System;
using System.Collections.Generic;
using System.Text;

namespace EcuCommunication.Protocols
{
    internal interface IDiagDataRequest
    {
        DiagData DiagData { get; }
        bool IsOnline { get; }
    }
}

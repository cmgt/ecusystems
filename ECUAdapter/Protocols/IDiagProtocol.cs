using System;
using System.Collections.Generic;
using System.Text;

namespace EcuCommunication.Protocols
{
    public interface IDiagProtocol
    {
        bool Connected { get; }     

        TimeSpan Time { get; }

        event EventHandler OnConnect;
        event EventHandler OnDisconnect;
        event EventHandler OnDiagUpdate;
        
        DiagData GetDiagData();
    }
}

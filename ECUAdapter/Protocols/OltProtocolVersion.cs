using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EcuCommunication.Protocols
{
    public enum OltProtocolVersion
    {
        [Description("Sms Olt v1")]
        OltDiagV1,
        [Description("Sms Olt v3")]
        OltDiagV3,
        [Description("Euro2")]
        Euro2,
        [Description("Rus83")]
        Rus83
    }
}

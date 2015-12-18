using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Helper
{    
    public enum enBaundRate
    {
        [Description("10400")]
        Low,
        [Description("38400 (Январь 7/5)")]
        Medium,
        [Description("57600 (Только Январь 5)")]
        Hi
    }
}

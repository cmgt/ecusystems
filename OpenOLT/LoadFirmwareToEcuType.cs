using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OpenOLT
{
    public enum LoadFirmwareToEcuType
    {
        [Description("Только корректируемые таблицы")]
        OnlyCorrectionTable,
        [Description("Всю область калибровок")]
        FullLoad,
        [Description("Ничего")]
        None
    }
}

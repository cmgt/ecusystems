using System;
using System.Collections.Generic;
using System.Text;

namespace WidebandLambdaCommunication
{
    public enum LambdaState: byte
    {
        LambdaValue = 0,
        O2Level = 1,
        FreeAirCalibProgress = 2,
        NeedFreeAirCalibRequest = 3,
        WarmingUp = 4,
        HeaterCalib = 5,        
        ErrorCode = 6,
        Reserver = 7
    }
}

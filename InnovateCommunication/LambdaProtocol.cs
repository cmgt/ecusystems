using System.ComponentModel;

namespace WidebandLambdaCommunication
{
    public enum LambdaProtocol
    {
        [Description("Innovate LC-1")]
        InnovateLC1,
        [Description("Innovate LM-1")]
        InnovateLM1,
        [Description("Techedge")]
        Techedge,
        [Description("Motor-Master ALC-1")]
        MotorMasterALC1
    }
}
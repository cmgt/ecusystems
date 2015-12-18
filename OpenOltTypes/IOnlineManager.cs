using EcuCommunication.Protocols;
using WidebandLambdaCommunication;

namespace OpenOltTypes
{
    public interface IOnlineManager
    {
        IFirmwareManager FirmwareManager { get; }
        bool EnabledOnlineCorrection { get; set; }
        bool EnabledRamOnlineCorrection { get; set; }
        OltProtocol OltProtocol { get; }
        LambdaAdapter LambdaAdapter { get; }
    }
}
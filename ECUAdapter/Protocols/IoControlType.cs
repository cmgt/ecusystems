namespace EcuCommunication.Protocols
{
    public enum IoControlType: byte
    {        
        RxxStep = 0x41,
        XxRpm = 0x42,
        Alf = 0x49,
        Uoz = 0x4A,
        Duoz = 0x4B,
        Faza = 0x4C,
        InjCoeff = 0x4D,
        Twat = 0x4E,
        Unknown = 0
    }
}

using System;
using System.ComponentModel;
using System.Windows.Forms;
using CalibrTable;
using CtpMaps.DataTypes;
using EcuCommunication.Protocols;
using Helper.ProgressDialog;

namespace OpenOltTypes
{
    public interface IFirmwareManager : INotifyPropertyChanged
    {
        bool Open(string path, bool showMessage = false, IWin32Window owner = null);
        void Add(DiagData diagData);
        void Close();
        event EventHandler<EventArgs> OnOpenFirmware;
        event EventHandler<EventArgs> OnCloseFirmware;
        event EventHandler<AutoCorrectionEventArgs> AutoCorrection;
        void WriteRam(int ramAddres, int bufferAddress, byte source, bool async = false);
        void WriteRam(int ramAddres, int bufferAddress, byte[] source, IProgress progress = null, bool async = false);
        int TwatRtIndex { get; }
        int RpmRtIndex { get; }
        int RpmRt32Index { get; }
        int ThrRtIndex { get; }
        int RpmThrRtIndex { get; }
        int Rpm32ThrRtIndex { get; }
        int GbcRtIndex { get; }
        int RpmGbcRtIndex { get; }
        int RpmPressRtIndex { get; }
        J7esFlags J7esFlags { get; }
        bool IsOpened { get; }
        byte[] Buffer { get; }
        string Name { get; }
        uint SWDigest { get; }
        TableValues<byte, short> Gbc { get; }
        TableValues<byte, float> Kgbc { get; }
        TableValues<byte, float> Kgbc_press { get; }
        int[] RpmRt32 { get; }
        int[] RpmRt16 { get; }
        int[] TwatRt { get; }
        int[] GbcRt { get; }
        int[] ThrRt { get; }
        int[] PressRt { get; }
        int[] PressRt32 { get; }
        float[] Rpm16_16RtPoints { get; }
        float[] Rpm32_16RtPoints { get; }
        float[] Rpm32_32RtPoints { get; }
        float[] GbcRtPoints { get; }
        float[] ThrRtPoints { get; }
        float[] PressRtPoints { get; }
        float[] PressRt32Points { get; }
        float[] GetAxis(Entry2D entry2D);
        float[] GetAxisX(Entry3D entry3D);
        float[] GetAxisY(Entry3D entry3D);
        float[] GetAxis(string name, double start, double end, int count);
        bool OpenDialog(IWin32Window owner);
        bool IsVolumetricEfficiency { get; set; }
        void WriteKGBCValue(int index);
        void WriteGBCValue(int index);
    }
}
using System.ComponentModel;

namespace OpenOltTypes
{
    public class AutoCorrectionEventArgs: CancelEventArgs
    {
        public int Address { get; set; }        
        public int Index { get; private set; }
        public byte Source { get; private set; }        

        public AutoCorrectionEventArgs(int address, int index, byte source)
        {
            Address = address;            
            Index = index;
            Source = source;
        }
    }
}

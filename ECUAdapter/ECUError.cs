using System;
using System.Collections.Generic;
using System.Text;

namespace EcuCommunication
{
    public class ECUError
    {
        public string Description { get; private set; }
        public ushort Code { get; private set; }
        public byte Status { get; private set; }

        internal ECUError(string description, ushort code, byte status)
        {
            Description = description;
            Code = code;
            Status = status;
        }

        #region Overrides of Object
        
        public override string ToString()
        {
            return String.Format("P{0} - {1} [{2}]", Code.ToString("X4"), Description, Status.ToString("X2"));
        }

        #endregion
    }
}

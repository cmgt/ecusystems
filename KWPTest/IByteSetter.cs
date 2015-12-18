using System;

namespace KWPTest
{
    public interface IByteSetter
    {
        byte Value { get; set; }
        event EventHandler OnValueChange;
    }
}
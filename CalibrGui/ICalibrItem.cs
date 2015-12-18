using System;
using System.ComponentModel;

namespace CalibrGui
{
    public interface ICalibrItem : INotifyPropertyChanged
    {
        string Name { get; }
        string ValueStr { get; }
        string Description { get; }
        float Value { get; }
        string Unit { get; }
        float MinValue { get; }
        float MaxValue { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class WMASmoothing
    {
        private byte windows;
        private ulong count;
        private float[] values;
        public float Value { get; private set; }

        public WMASmoothing(byte window)
        {
            values = new float[window];
        }

        public void Add(float value)
        {}
    }
}

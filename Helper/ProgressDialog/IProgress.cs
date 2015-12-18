using System;

namespace Helper.ProgressDialog
{
    public interface IProgress: IDisposable
    {
        void IterationComplete(object state, int current, int count);
        void Close();
        bool Cancel { get; }
        string Message { get; set; }
    }
}
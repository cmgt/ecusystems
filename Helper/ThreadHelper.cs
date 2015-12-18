using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Helper
{
    public static class BackgroundWorkerHelper
    {
        public static void Wait(BackgroundWorker backgroundWorker)
        {
            while (true)
            {                
                if (!backgroundWorker.IsBusy) break;
                Application.DoEvents();
                Thread.Sleep(50);                
            }
        }
    }
}

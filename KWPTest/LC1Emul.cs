using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;
using Helper;

namespace KWPTest
{
    class LC1Emul: IDisposable
    {
        private readonly SerialPort serialPort;       
        private readonly byte[] data;
        private readonly BackgroundWorker sendThread;
        internal readonly List<string> TraceLines = new List<string>();

        public LC1Emul()
        {
            serialPort = new SerialPort("COM6", 19200, Parity.None, 8, StopBits.One) {ReadTimeout = 50, WriteTimeout = 90};            
            data = new byte[6];
            InitDataBuffer();

            sendThread = new BackgroundWorker {WorkerSupportsCancellation = true};
            sendThread.DoWork += sendThread_DoWork;            
        }

        private bool o2Level;
        private int traceIndex;

        public bool O2Level
        {
            get { return o2Level; }
            set
            {
                o2Level = value;
                InitDataBuffer();
            }
        }

        void sendThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (sendThread.CancellationPending) return;
                SendData();
            }
        }

        private void InitDataBuffer()
        {
            data[0] = 0xB2; //10110010   header hi byte
            data[1] = 0x82; //10000010   header lo byte

            if (o2Level)
            {
                data[2] = 0x46; //01000010  //O2 level
                data[3] = 0x31; //AFR
            }
            else
            {
                data[2] = 0x43; //01000010 
                data[3] = 0x13; //AFR
            }            
            
            SetAFR(14.7f);
        }

        public void Start(string serialPortName)
        {
            if (serialPort.PortName != serialPortName)
            {            
                serialPort.Close();
                serialPort.PortName = serialPortName;
            }

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
            }

            if (!sendThread.IsBusy && serialPort.IsOpen)
                sendThread.RunWorkerAsync();            
        }

        public void Stop()
        {
            sendThread.CancelAsync();
            BackgroundWorkerHelper.Wait(sendThread);
            serialPort.Close();
        }

        public void SetAFR(float afr)
        {
            var lambda = (ushort)(O2Level ? afr * 10 : (afr / 14.7f - 0.5f) * 1000f);
            data[4] = (byte)((lambda >> 7) & 0x7F);
            data[5] = (byte)(lambda & 0x7F);
        }

        private void SendData()
        {
            if (!serialPort.IsOpen) return;

            if (TestReadBuffer()) return;

            if (TraceLines.Count > 0)
            {
                var traceLine = DataHelper.StrToByteArray(TraceLines[traceIndex]);
                for (var i = 0; i < traceLine.Length; i++)
                {
                    try
                    {
                        serialPort.Write(traceLine, i, 1);
                    }
                    catch (TimeoutException)
                    { }
                }

                traceIndex = (traceIndex + 1)%TraceLines.Count;
                Thread.Sleep(100);
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    try
                    {
                        serialPort.Write(data, i, 1);
                    }
                    catch (TimeoutException)
                    { }
                }

                Thread.Sleep(100);
            }
        }

        private bool TestReadBuffer()
        {
            var count = serialPort.BytesToRead;
            if (count > 0)
            {
                byte[] buffer;
                var requestBuffer = new List<byte>();
                do
                {
                    buffer = new byte[count];
                    serialPort.Read(buffer, 0, count);
                    requestBuffer.AddRange(buffer);
                    count = serialPort.BytesToRead;
                } while (count > 0);

                buffer = requestBuffer.ToArray();
                var answer = new byte[0];
                switch (buffer[0])
                {
                    case 0xF3:
                        {
                            answer = new byte[]
                                             {                                         
                                                 0xA2, 0x85, 0x01, 0x73, 
                                                 0x11, 0x0A, 0x4C, 0x43, 0x31, 0x20, 0x05, 0x32
                                             };                            
                        }
                        break;

                    case 0xCE:
                        {
                            answer = new byte[]
                                             {                                         
                                                 0xA2, 0x85, 0x01, 0x4E, 
                                                 0x4C, 0x43, 0x2D, 0x31, 0x00, 0x00, 0x00, 0x00
                                             };                            
                        }
                        break;

                    //Command ‘S’ - Get Setup Mode Header 
                    case 0x53:
                        {
                            answer = new byte[]
                                             {                                         
                                                 /*0xA2, 0x85, 0x01, 0x53,*/

                                                 0x11, 0x0A, 
                                                 0x4C, 0x43, 0x31, 0x20,
                                                 
                                                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
                                             };
                        }
                        break;                        
                }

                if (answer.Length > 0)
                {
                    try
                    {
                        serialPort.Write(answer, 0, answer.Length);
                    }                    
                    catch (TimeoutException)
                    { }
                    return true;
                }
            }

            return false;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            Stop();
        }

        #endregion
    }
}

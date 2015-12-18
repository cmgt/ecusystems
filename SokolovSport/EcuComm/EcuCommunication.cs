//#define USE_MOCK

using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using Helper;
using SokolovSport.Dat;
using SokolovSport.Options;

namespace SokolovSport.EcuComm
{
    class EcuCommunication: INotifyPropertyChanged
    {
        #region fields        
        private readonly OptionsEntity optionsEntity;
        private DatFile datFile;
        private readonly SerialPort serialPort;
        private readonly BackgroundWorker readThread;        
        private bool isStarted;
        private bool isConnected;
        private readonly SynchronizationContext syncContext;
        private readonly Random random;
        private bool syncContextIsBusy;
        private long lastSync;
        private readonly byte[] rawBuffer = new byte[4];
        private uint requestNotSuccess;
        private long visualSyncFreqTicks;
        private int readTimeoutTicks;
        private const uint RequestNotSuccessThreshold = 5;

        #endregion

        #region Properties        
        public ConcurrentQueue<CalibrItem> ReadCalibrItems { get; private set; }
        public ConcurrentBag<Request> WriteRequests { get; private set; }  
      
        public bool IsStarted
        {
            get { return isStarted; }
            set
            {
                if (isStarted == value) return;
                isStarted = value;
                if (!isStarted)
                    IsConnected = false;

                syncContext.Post(DoPropertyChanged, new PropertyChangedEventArgs("IsStarted"));
            }
        }
       
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                if (isConnected == value) return;
                isConnected = value;
                syncContext.Post(DoPropertyChanged, new PropertyChangedEventArgs("IsConnected"));                
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler OnCalibrSync;
        #endregion

        public EcuCommunication(OptionsEntity optionsEntity)
        {
            this.optionsEntity = optionsEntity;
            syncContext = SynchronizationContext.Current;
            random = new Random((int) DateTime.Now.Ticks);

            readThread = new BackgroundWorker { WorkerSupportsCancellation = true };
            readThread.DoWork += readThread_DoWork;

            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)
            {
                WriteTimeout = 100,
                ReadTimeout = 100
            };

            ReadCalibrItems = new ConcurrentQueue<CalibrItem>();
            WriteRequests = new ConcurrentBag<Request>();
        }        

        private void readThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (readThread.CancellationPending) break;

                while (!WriteRequests.IsEmpty)
                {
                    Request writeRequest;
                    if (WriteRequests.TryTake(out writeRequest))
                        ExecuteRequest(ref writeRequest);                    
                }

                if (ReadCalibrItems.Count > 0)
                {
                    CalibrItem calibrItem;
                    if (ReadCalibrItems.TryDequeue(out calibrItem))
                        if (ReadCalibrItem(calibrItem))
                            SyncCalibrValue(calibrItem, false);
                }
                else
                {
                    var readCalibrs = datFile.OnlineCalibrItems;

                    foreach (var calibrItem in readCalibrs.TakeWhile(calibrItem => !readThread.CancellationPending).Where(ReadCalibrItem))
                    {
                        SyncCalibrValue(calibrItem, false);
                    }

                    //SyncCalibrValue(readCalibrs);
                }
            }
        }

        private void SyncCalibrValue(object calibr, bool useTimeouts = true)
        {
            if (useTimeouts)
            {
                if (syncContextIsBusy) return;
                var deltaTime = DateTime.Now.Ticks - lastSync;
                if (deltaTime < visualSyncFreqTicks) return;
                syncContextIsBusy = true;
                lastSync = DateTime.Now.Ticks;
            }

            syncContext.Send(SyncCalibrValueInvoke, calibr);
        }

        private void SyncCalibrValueInvoke(object state)
        {
            var calibrItems = state as CalibrItem[];
            if (calibrItems != null)
            {
                foreach (var item in calibrItems)
                    item.SyncCalibr();
            }
            else
            {
                var item = (CalibrItem)state;
                item.SyncCalibr();
            }

            DoCalibrSync(EventArgs.Empty);

            syncContextIsBusy = false;
        }

        private void DoCalibrSync(EventArgs e)
        {
            if (OnCalibrSync != null)
                OnCalibrSync(this, e);
        }

        public void Start(DatFile datFile)
        {
            if (IsStarted) return;
            ComOpen();
            IsStarted = true;
            visualSyncFreqTicks = optionsEntity.VisualSyncFreq*10000;
            this.datFile = datFile;             
          
            readThread.RunWorkerAsync();
        }

        public void Stop()
        {
            if (!IsStarted) return;

            readThread.CancelAsync();
            BackgroundWorkerHelper.Wait(readThread);
            ComClose();

            IsStarted = false;
        }

        #region Serial port functions
        private bool ReadCalibrItem(CalibrItem calibrItem)
        {
            ExecuteRequests(calibrItem.readRequests);
            
            var changed = false;
            for (var i = 0; i < calibrItem.readRequests.Length; i++)
            {
                var request = calibrItem.readRequests[i];
                changed |= request.IsChanged;
                request.IsChanged = false;
                calibrItem.readRequests[i] = request;
            }

            return changed;
        }

        private void ExecuteRequests(Request[] requests)
        {
            for (var i = 0; i < requests.Length; i++)
            {
                var request = requests[i];
                ExecuteRequest(ref request);
                requests[i] = request;
            }
        }

        private void ExecuteRequest(ref Request request)
        {
#if USE_MOCK
            IsConnected = true;
            if (request.Type == RequestType.Read)
                request.RawValue = (byte)random.Next(byte.MaxValue);
            Thread.Sleep(10);
            return;
#endif
            var requestSuccess = false;            

            try
            {
                request.FillRawBuffer(rawBuffer);
                var length = request.Type == RequestType.Read ? 3 : 4;

                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();

                try
                {                    
                    serialPort.Write(rawBuffer, 0, length);
                }
                catch (TimeoutException)
                {                    
                    return;
                }

                var index = 0;
                length = request.Type == RequestType.Read ? 4 : 3;
                var count = length;
                
                while (index < length)
                {
                    try
                    {
                        count = serialPort.Read(rawBuffer, index, length - index);
                        index += count;                        
                    }
                    catch (TimeoutException)
                    {
                        return;
                    }
                }

                if (index != length) return;

                if (request.Type == RequestType.Read) request.RawValue = rawBuffer[3];

                requestSuccess = true;
                requestNotSuccess = 0;
                IsConnected = true;
            }             
            catch
            {}
            finally
            {
                if (!requestSuccess)
                {
                    requestNotSuccess++;
                    if (requestNotSuccess > RequestNotSuccessThreshold)
                    {
                        IsConnected = false;
                    }
                }                
            }
        }

        private void ComOpen()
        {
#if USE_MOCK
            return;
#endif
            readTimeoutTicks = optionsEntity.ReadTimeout*10000;
            serialPort.PortName = optionsEntity.PortName;
            serialPort.WriteTimeout = optionsEntity.WriteTimeout;
            serialPort.ReadTimeout = optionsEntity.ReadTimeout;
            serialPort.Open();            
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }

        private void ComClose()
        {
#if USE_MOCK
            return;
#endif
            serialPort.Close();
        }
        #endregion

        private void DoPropertyChanged(object e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, (PropertyChangedEventArgs)e);
        }
    }
}

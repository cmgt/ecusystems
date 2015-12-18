using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EcuCommunication.Protocols.Requests;
using Helper;
using Helper.ProgressDialog;

namespace EcuCommunication.Protocols
{
    public sealed class OltProtocol: IDiagProtocol, INotifyPropertyChanged
    {
        #region Communication settings
        [Category("Communication settings"), Browsable(false)]
        [DefaultValue("COM1")]
        public String PortName
        {
            get { return serialPort.PortName; }
            set
            {
                if (serialPort.PortName == value) return;
                serialPort.PortName = value;
                DoPropertyChanged(new PropertyChangedEventArgs("PortName"));
            }
        }
        private enBaundRate baundRate;
        [Category("Communication settings"), Browsable(false)]
        [DefaultValue(10400)]
        public enBaundRate BaundRate
        {
            get { return baundRate; }
            set
            {
                if (baundRate == value) return;
                baundRate = value;
                DoPropertyChanged(new PropertyChangedEventArgs("BaundRate"));
            }
        }

        [Category("Communication settings"), Browsable(false)]
        [DefaultValue(0)]
        public int ReadFreq { get; set; }

        [Category("Communication settings"), Browsable(false)]
        [DefaultValue(100)]
        public int ReadTimeout
        {
            get { return serialPort.ReadTimeout; }
            set
            {
                if (serialPort.ReadTimeout == value) return;
                serialPort.ReadTimeout = value;
                DoPropertyChanged(new PropertyChangedEventArgs("ReadTimeout"));
            }
        }

        [Category("Communication settings"), Browsable(false)]
        [DefaultValue(100)]
        public int WriteTimeout
        {
            get { return serialPort.WriteTimeout; }
            set
            {
                if (serialPort.WriteTimeout == value) return;
                serialPort.WriteTimeout = value;
                DoPropertyChanged(new PropertyChangedEventArgs("WriteTimeout"));
            }
        }

        [Category("Communication settings"), Browsable(false)]
        [DefaultValue(false)]
        public bool TraceEnabled { get; set; }

        [Browsable(false)]
        public Queue<Request> Requests { get; private set; }
        [Browsable(false)]
        public Request IdleRequest { get; set; }
        [Browsable(false)]
        public bool IsBusy { get; private set; }

        public readonly StringBuilder OperationLog = new StringBuilder();

        private readonly byte[] tempBuffer = new byte[1024];

        public bool InitProgress { get; private set; }

        #endregion

        private static readonly Request StartCommunication = new JRequest("8110F18103");
        private static readonly Request StopCommunication = new JRequest("8110F18204");

        private static readonly Request StartDiagnosticSessionLow = new JRequest("8310F110810A1F");
        private static readonly Request StartDiagnosticSessionMedium = new JRequest("8310F11081263B");
        private static readonly Request StartDiagnosticSessionHi = new JRequest("8310F11081394E");
        private static readonly Request StopDiagnosticSession = new JRequest("8110F120A2");

        private static readonly Request TesterPresent = new JRequest("8210F13E01C2");
        private static readonly Request SwitchToRam = new JRequest("8410F1300F0601CB");        
        private static readonly Request LongDiagRequest = new JRequest("8210F1210FB3");
        private static readonly Request ShortDiagRequest = new JRequest("8210F1210EB2");
        private static readonly ReadRamRequest ReadRamRequest = new ReadRamRequest();
        private static readonly WriteRamRequest WriteRamRequest = new WriteRamRequest();

        private static readonly ReadErrorDataRequest ReadErrorDataRequest = new ReadErrorDataRequest();
        private static readonly Request ClearErrorRequest = new JRequest("8310F114FF0097");
      
        private static readonly OltDiagV1DataRequest OltDiagV1DataRequest = new OltDiagV1DataRequest();
        private static readonly OltDiagV3DataRequest OltDiagV3DataRequest = new OltDiagV3DataRequest();
        private static readonly J7esOltDiagDataRequest J7esOltDiagDataRequest = new J7esOltDiagDataRequest();
        private static readonly Euro2DiagDataRequest Euro2DiagDataRequest = new Euro2DiagDataRequest();
        private static readonly Rus83DiagDataRequest Rus83DiagDataRequest = new Rus83DiagDataRequest();

        private static readonly Request StopCaptureRequest = new JRequest("8310F130710025");
        private static readonly StartCaptureRequest StartCaptureRequest = new StartCaptureRequest();

        private readonly IoControlRequest ioControlRequest = new IoControlRequest();

        private readonly SerialPort serialPort;
        private readonly BackgroundWorker readThread;

        private bool connected;
        /// <summary>
        /// Состояние соединения
        /// </summary>
        [Browsable(false)]        
        public bool Connected
        {
            get { return connected; }
            private set
            {
                if (connected == value) return;
                connected = value;

                if (connected)
                    DoConnect(EventArgs.Empty);
                else                
                    DoDisconnect(EventArgs.Empty); 
               
                DoPropertyChanged(new PropertyChangedEventArgs("Connected"));
            }
        }

        private IDiagDataRequest diagRequest;

        private DateTime connectTime = DateTime.Now;
        private FileStream file;
        private StreamWriter writer;
        private readonly object lockObject = new object();

        [Browsable(false)]
        public OltProtocolVersion Version { get; set; }

        private bool isOnline;
        private byte[] ecuSn;
        private byte[] ecuSnHashBuffer = new byte[240];

        public uint SWDigest { get; private set; }        

        public bool IsOnline
        {
            get { return isOnline; }
            private set
            {
                if (isOnline == value) return;
                isOnline = value;
                DoPropertyChanged(new PropertyChangedEventArgs("IsOnline"));
            }
        }                    

        /// <summary>
        /// Получить текущие значения диагностических параметров
        /// </summary>
        /// <returns></returns>
        public DiagData GetDiagData()
        {
            return diagRequest == null ? DiagData.Empty : diagRequest.DiagData;
        }

        public TimeSpan Time { get { return diagRequest == null ? TimeSpan.Zero : diagRequest.DiagData.Time; } }

        public bool CalcEcuSn { get; set; }
        public string EcuSn { get; set; }        

        public bool IsSupportOnlineCorrection { get { return connected && isOnline && diagRequest != null && diagRequest.IsOnline; } }

        private bool isEcuErrorFound;
        public bool IsEcuErrorFound
        {
            get { return isEcuErrorFound; }
            private set
            {
                if (isEcuErrorFound == value) return;
                isEcuErrorFound = value;
                DoPropertyChanged(new PropertyChangedEventArgs("IsEcuErrorFound"));
            }
        }
        /// <summary>
        /// Событие соединение установлено
        /// </summary>
        public event EventHandler OnConnect;
        /// <summary>
        /// Событие соединение разорвано
        /// </summary>
        public event EventHandler OnDisconnect;

        #region Init
        
        public OltProtocol()
        {
            Version = OltProtocolVersion.OltDiagV1;
            diagRequest = OltDiagV1DataRequest;
            ReadFreq = 0;
            Requests = new Queue<Request>();
            readThread = new BackgroundWorker {WorkerSupportsCancellation = true};
            readThread.DoWork += readThread_DoWork;
            serialPort = new SerialPort("COM1", 10400, Parity.None, 8, StopBits.One)
            {
                WriteTimeout = 100,
                ReadTimeout = 100
            };

            ecuSn = new byte[8];
            ecuSnHashBuffer = DiagProtocolHelper.InitEcuSnHashBuffer(ecuSn, 240);
        }
        #endregion

        private void SetBaundRate()
        {
            switch (baundRate)
            {
                case enBaundRate.Medium:
                    serialPort.BaudRate = 38400;                    
                    break;

                case enBaundRate.Hi:
                    serialPort.BaudRate = 57600;
                    break;

                case enBaundRate.Low:
                    serialPort.BaudRate = 10400;
                    break;

                default:
                    throw new NotSupportedException();                    
            }

            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();

            AddOperationLog(String.Format("Change ECU serial port baud rate: {0}", serialPort.BaudRate));
        }

        /// <summary>
        /// Запуск опроса ЭБУ
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            IsBusy = true;

            try
            {
                serialPort.PortName = PortName;
                serialPort.BaudRate = 10400;
                serialPort.Open();
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                AddOperationLog(String.Format("Open ECU serial port: {0}", PortName));

                AddOperationLog("Send start communication...");
                ExecuteRequest(StartCommunication);
                if (!StartCommunication.Test())
                {
                    AddOperationLog("Error start communication");
                    serialPort.Close();                    
                    return false;
                }

                Request startDiag;

                switch (baundRate)
                {
                    case enBaundRate.Medium:
                        startDiag = StartDiagnosticSessionMedium;
                        break;

                    case enBaundRate.Hi:
                        startDiag = StartDiagnosticSessionHi;
                        break;

                    default:
                        startDiag = StartDiagnosticSessionLow;
                        break;
                }

                AddOperationLog("Send start diagnostic session ...");
                ExecuteRequest(startDiag);
                if (!startDiag.Test())
                {
                    AddOperationLog("Error diagnostic session");
                    serialPort.Close();                    
                    return false;
                }

                if (baundRate != enBaundRate.Low)
                    SetBaundRate();

                AddOperationLog("Send tester present ...");
                ExecuteRequest(TesterPresent);

                switch (Version)
                {
                    case OltProtocolVersion.OltDiagV1:
                        AddOperationLog("Test new diag protocol support ...");
                        ExecuteRequest(J7esOltDiagDataRequest);
                        diagRequest = J7esOltDiagDataRequest.Valid ? J7esOltDiagDataRequest : OltDiagV1DataRequest;
                        break;

                    case OltProtocolVersion.OltDiagV3:
                        diagRequest = OltDiagV3DataRequest;
                        break;

                    case OltProtocolVersion.Euro2:
                        diagRequest = Euro2DiagDataRequest;
                        break;

                    case OltProtocolVersion.Rus83:
                        diagRequest = Rus83DiagDataRequest;
                        break;
                }

                IdleRequest = (Request)diagRequest;
                Connected = true;

                readThread.RunWorkerAsync();

                return true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddOperationLog(string line)
        {
            OperationLog.AppendLine(line);
        }

        /// <summary>
        /// Окончание опроса ЭБУ
        /// </summary>
        public void Stop()
        {
            IsBusy = true;

            try
            {
                IdleRequest = TesterPresent;
                readThread.CancelAsync();                
                BackgroundWorkerHelper.Wait(readThread);
                IdleRequest = null;
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                AddOperationLog("Send stop diagnostic session ...");
                ExecuteRequest(StopDiagnosticSession);
                if (baundRate != enBaundRate.Low)
                    serialPort.BaudRate = 10400;
                AddOperationLog("Send stop communication...");
                ExecuteRequest(StopCommunication);                  
            }
            finally 
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Close();
                Connected = false;
                IsOnline = false;
                IsBusy = false;
            }                       
        }       

        public void WriteRam(int address, byte[] source, IProgress progress = null, bool async = false)
        {
            var idleReguest = IdleRequest;
            IdleRequest = null;

            try
            {
                const int size = 0x60;
                if (source.Length <= size)
                {
                    InnerWriteRam(address, source, async);
                    return;
                }

                var buffer = new byte[size];
                var count = (int) Math.Ceiling((float) source.Length/size);
                var index = 0;

                for (var i = 0; i < count; i++)
                {
                    if (progress != null && progress.Cancel) return;

                    var writeSize = Math.Min(size, source.Length - index);
                    if (writeSize != size)
                        Array.Resize(ref buffer, writeSize);

                    Buffer.BlockCopy(source, index, buffer, 0, writeSize);
                    InnerWriteRam(address, buffer, async);
                    address += writeSize;
                    index += writeSize;

                    if (progress != null) progress.IterationComplete(this, i, count);
                }
            }
            finally
            {
                IdleRequest = idleReguest;
            }
        }

        private void InnerWriteRam(int address, byte[] source, bool async = false)
        {
            if (async)
            {
                var writeRam = new WriteRamRequest();
                writeRam.Prepare(address, address < 0xF400 ? DataHelper.Xor(source, ecuSnHashBuffer) : source);
                Requests.Enqueue(writeRam);
            }
            else
            {
                WriteRamRequest.Prepare(address, address < 0xF400 ? DataHelper.Xor(source, ecuSnHashBuffer) : source);
                ExecuteRequest(WriteRamRequest);
            }
        }

        public void WriteFirmware(IWin32Window owner, byte[] source)
        {
            const int address = 0x5EF0;
            const int count = 0xB030 - address;
            var buffer = new byte[count];

            Buffer.BlockCopy(source, address, buffer, 0, count);
            using (var progress = ProgressForm.ShowProgress(owner))
            {
                WriteRam(address, buffer, progress);
                progress.Close();
            }
        }       

        private void readThread_DoWork(object sender, DoWorkEventArgs e)
        {
            InitProgress = true;            
            var online = TestOnline();

            if (online)
            {
                PrepareOnline();
            }

            IsOnline = online;
            InitProgress = false;

            while (true)
            {
                if (readThread.CancellationPending) break;

                if (Requests.Count > 0)
                {
                    var request = Requests.Dequeue();
                    ExecuteRequest(request);
                }
                else
                {
                    ExecuteRequest(IdleRequest);
                    if (IdleRequest != null && IdleRequest.Valid)
                    {
                        diagRequest.DiagData.Time = DateTime.Now - connectTime;
                        IsEcuErrorFound = diagRequest.DiagData.IsErrorFound;
                        DoDiagUpdate(EventArgs.Empty);
                    }
                }

                if (readThread.CancellationPending) break;
                if (ReadFreq > 0) Thread.Sleep(ReadFreq);
            }
        }        

        private bool TestOnline()
        {
            AddOperationLog("Switch to RAM ...");
            ExecuteRequest(SwitchToRam);
            if (!SwitchToRam.Test())
            {
                AddOperationLog("Error switch to RAM");
                return false;
            }                                   

            AddOperationLog("Test long diagnostic request ...");
            ExecuteRequest(LongDiagRequest);
            if (!LongDiagRequest.Test())
            {
                AddOperationLog("Not supported long diagnostic request");
                return false;
            }

            AddOperationLog("Test short diagnostic request ...");
            ExecuteRequest(ShortDiagRequest);
            if (!ShortDiagRequest.Test())
            {
                AddOperationLog("Not supported short diagnostic request");
                return false;
            }

            ReadRamRequest.Prepare(0xF300, 8);
            ExecuteRequest(ReadRamRequest);
            if (!ReadRamRequest.Valid)
            {
                AddOperationLog("Error read 0xF300(8)");
                return false;
            }
            AddOperationLog("Read 0xF300(8): " + DataHelper.ByteArrayToStr(ReadRamRequest.value));
            //TODO: Определение типа ЭБУ (онлайн или нет)
            var online = !DataHelper.Compare(ReadRamRequest.value, new byte[] {0, 1, 2, 3, 4, 5, 6, 7});

            AddOperationLog(online ? "is online ECU" : "is no online ECU");

            return online;
        }

        private void PrepareOnline()
        {
            SWDigest = 0;                    

            ReadRamRequest.Prepare(0xF3F8, 8);
            ExecuteRequest(ReadRamRequest);
            AddOperationLog("Read 0xF3F8(8): " + DataHelper.ByteArrayToStr(ReadRamRequest.value));

            ReadRamRequest.Prepare(0xF6F8, 8);
            ExecuteRequest(ReadRamRequest);
            AddOperationLog("Read 0xF6F8(8): " + DataHelper.ByteArrayToStr(ReadRamRequest.value)); 
           
            ReadRamRequest.Prepare(0xC0, 16);
            ExecuteRequest(ReadRamRequest);
            AddOperationLog("Read 0xC0(16): " + DataHelper.ByteArrayToStr(ReadRamRequest.value));

            if (CalcEcuSn && ReadRamRequest.value != null)
            {
                ecuSn = DiagProtocolHelper.CalcEcuSn(ReadRamRequest.value);
            }
            else
            {
                ecuSn = DataHelper.StrToByteArray(EcuSn, 8);                
            }

            ecuSnHashBuffer = DiagProtocolHelper.InitEcuSnHashBuffer(ecuSn, 240);
            AddOperationLog("ECU SN: " + DataHelper.ByteArrayToStr(ecuSn));

            var index = 0;
            //TODO: чтение 176 байт 30h + 30h + 30h + 20h
            var buffer = new byte[0xB0];
            for (int i = 0; i < 3; i++)
            {
                if (!ReadRamPart(buffer, 0x30, ref index)) return;
            }

            if (!ReadRamPart(buffer, 0x20, ref index)) return;

            //AddOperationLog("SWDigest buffer: " + DataHelper.ByteArrayToStr(buffer));
            SWDigest = DataHelper.CalculateCRC(buffer, 0, buffer.Length);
            AddOperationLog("SWDigest: " + SWDigest.ToString("X4"));            
        }

        private bool ReadRamPart(byte[] buffer, int count, ref int address)
        {
            ReadRamRequest.Prepare(address, count);
            ExecuteRequest(ReadRamRequest);
            if (!ReadRamRequest.Valid) 
                return false;
            if (address < 0xF300)
                ReadRamRequest.value = DataHelper.Xor(ReadRamRequest.value, ecuSnHashBuffer);
            Buffer.BlockCopy(ReadRamRequest.value, 0, buffer, address, count);
            address += count;
            return true;
        }

        /// <summary>
        /// Выполнить запрос к ЭБУ
        /// </summary>
        /// <param name="request"></param>
        public void ExecuteRequest(Request request)
        {
            if (request == null || !serialPort.IsOpen) return;
            lock (lockObject)
            {                
                var buffer = request.GetRequest();
                byte[] reply = null;

                try
                {                    
                    if (buffer == null || buffer.Length == 0) return;

                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();

                    try
                    {
                        serialPort.Write(buffer, 0, buffer.Length);
                    }
                    catch (TimeoutException)
                    {
                        return;
                    }

                    int offset = 0;

                    do
                    {
                        int count;
                        try
                        {
                            count = serialPort.Read(tempBuffer, offset, 100);
                        }
                        catch (TimeoutException)
                        {                            
                            break;
                        }

                        offset += count;                        
                    } while (true);

                    reply = new byte[offset];
                    Buffer.BlockCopy(tempBuffer, 0, reply, 0, offset);                    

                    request.SetReply(ref reply);
                }
                catch{}
                finally
                {
                    if (TraceEnabled)
                    {
                        var source = String.Format("{0}\t\t->\t{1}", DataHelper.ByteArrayToStr(buffer),
                                                   DataHelper.ByteArrayToStr(reply));
                        WriteTrace(source);
                    }
                }
            }
        }

        private void WriteTrace(string source)
        {
            if (file == null)
                InitTraceFile();

            writer.WriteLine(source);
        }

        private void InitTraceFile()
        {
            var basePath = Application.StartupPath + @"\trace\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var fileName = String.Format("ecu_trace_{0}_{1}.txt", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss"));
            var filePath = basePath + fileName;
            file = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            writer = new StreamWriter(file);            
        }

        private void CloseTrace()
        {
            if (file == null) return;
            writer.Flush();
            writer.Close();
            writer = null;

            file.Close();
            file = null;
        }

        private void DoConnect(EventArgs e)
        {
            connectTime = DateTime.Now - Time;
            var connect = OnConnect;
            if (connect != null)
                connect(this, e);
        }

        private void DoDisconnect(EventArgs e)
        {
            CloseTrace();

            var disconnect = OnDisconnect;
            if (disconnect != null)
                disconnect(this, e);
        }

        #region Implementation of IDiagProtocol

        /// <summary>
        /// Событие обновились диагностические данные
        /// </summary>
        public event EventHandler OnDiagUpdate;

        private void DoDiagUpdate(EventArgs e)
        {
            var du = OnDiagUpdate;
            if (du != null)
                du(this, e);
        }        

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void DoPropertyChanged(PropertyChangedEventArgs e)
        {
            var pc = PropertyChanged;
            if (pc != null) pc(this, e);
        }

        #endregion

        public void ClearErrors()
        {
            if (!Connected) return;
            Requests.Enqueue(ClearErrorRequest);
        }

        public List<ECUError> ReadErrors()
        {
            if (!Connected) return new List<ECUError>();
            ExecuteRequest(ReadErrorDataRequest);
            return ReadErrorDataRequest.Errors;
        }

        public void StopCapture()
        {
            ExecuteRequest(StopCaptureRequest);
        }

        public void StartCapture(byte captureId)
        {
            StartCaptureRequest.Prepare(captureId);
            ExecuteRequest(StartCaptureRequest);
        }

        public bool StartIoControl(IoControlType ioControlType, byte rawValue)
        {
            ioControlRequest.StartCaptureAndSetValue((byte) ioControlType, rawValue);
            ExecuteRequest(ioControlRequest);
            return ioControlRequest.Test();
        }

        public void StopIoControl(IoControlType ioControlType)
        {
            ioControlRequest.StopCapture((byte)ioControlType);
            ExecuteRequest(ioControlRequest);
        }

        public void SetIoControlValue(IoControlType ioControlType, byte rawValue)
        {
            var request = new IoControlRequest();
            request.StartCaptureAndSetValue((byte)ioControlType, rawValue);
            Requests.Enqueue(request);
        }
    }
}

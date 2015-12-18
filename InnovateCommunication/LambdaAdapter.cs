using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Helper;

namespace WidebandLambdaCommunication
{
    public partial class LambdaAdapter : Component, INotifyPropertyChanged
    {
        #region Communication settings
        [Category("Communication settings")]
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
        [Category("Communication settings")]
        [DefaultValue(19200)]
        public int BaundRate
        {
            get { return serialPort.BaudRate; }
            set
            {
                if (serialPort.BaudRate == value) return;
                serialPort.BaudRate = value;
                DoPropertyChanged(new PropertyChangedEventArgs("BaundRate"));
            }
        }

        [Category("Communication settings")]
        [DefaultValue(200)]
        public int ReadTimeout
        {
            get { return serialPort.ReadTimeout; }
            set
            {
                if (serialPort.ReadTimeout == value) return;
                serialPort.ReadTimeout = value;
                readTimeoutTicks = value*10000;
                DoPropertyChanged(new PropertyChangedEventArgs("ReadTimeout"));
            }
        }

        [Category("Communication settings")]
        [DefaultValue(typeof(LambdaProtocol), "InnovateLC1")]
        public LambdaProtocol Protocol { get; set; }

        public LambdaState State { get; private set; }
        public short RawValue { get; private set; }        

        public byte SmoothingWindow { get; set; }
        public byte SmoothingFactor { get; set; }

        public int ErrorCode { get; private set; }
        public int O2Level { get; private set; }

        [Browsable(false)]
        public float AFR { get; private set; }
        [Browsable(false)]
        public float Lambda { get; private set; }
        [Browsable(false)]
        public float AF { get; private set; }

        [Browsable(false)]
        public bool TraceEnabled { get; set; }

        private bool connected;
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
            }
        }

        private FileStream file;
        private StreamWriter writer;

        private bool available;
        private int readTimeoutTicks = 100*10000;
        private long lastAvailableTicks;
        private const long availableTicksThreshold = 2000*10000;

        [Browsable(false)]
        public bool IsBusy { get; private set; }

        /// <summary>
        /// Доступность значения
        /// </summary>
        [Browsable(false)]
        public bool Available
        {
            get { return available; }
            private set
            {
                if (available == value) return;
                available = value;
                DoPropertyChanged(new PropertyChangedEventArgs("Available"));
            }
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

        public LambdaAdapter()
        {
            InitializeComponent();
            Init();
        }

        public LambdaAdapter(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        private void Init()
        {
            SmoothingWindow = 5;
            SmoothingFactor = 7;
        }

        private void readThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBusy = false;
            if (serialPort.IsOpen) serialPort.Close();
        }

        public void StartCommunication()
        {
            try
            {
                IsBusy = true;
                if (!serialPort.IsOpen)
                {
                    serialPort.BaudRate = Protocol == LambdaProtocol.MotorMasterALC1 ? 9600 : 19200;
                    serialPort.Open();
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                }
                readThread.RunWorkerAsync();                
            }
            catch
            {
                IsBusy = false;
                Connected = false;
            }
        }

        public void StopCommunication()
        {
            readThread.CancelAsync();
            BackgroundWorkerHelper.Wait(readThread);
            CloseTrace();
            Connected = false;
        }

        private void readThread_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (Protocol)
            {
                case LambdaProtocol.InnovateLC1:
                    ReadAFRInnovateLC1();
                    break;

                case LambdaProtocol.InnovateLM1:
                    ReadAFRInnovateLM1();
                    break;

                case LambdaProtocol.Techedge:
                    ReadAFRTechedge();
                    break;

                case LambdaProtocol.MotorMasterALC1:
                    ReadAFRMotorMasterALC1();
                    break;
            }
        }

        private void ReadAFRInnovateLM1()
        {
            var lambdaBuffer = new byte[4];
            lastAvailableTicks = DateTime.Now.Ticks;
            var length = lambdaBuffer.Length;

            while (true)
            {
                if (readThread.CancellationPending) break;

                long ticks = DateTime.Now.Ticks;
                try
                {
                    var data = (byte)serialPort.ReadByte();
                    WriteTrace(data.ToString("X2"));
                    if ((data & 0x80) == 0x80)
                    {
                        lambdaBuffer[0] = data;
                        var index = 1;

                        while (index < length)
                        {
                            try
                            {
                                index += serialPort.Read(lambdaBuffer, index, length - index);
                            }
                            catch (TimeoutException)
                            {
                                break;
                            }
                        }

                        if (TraceEnabled)
                            WriteTrace(DataHelper.ByteArrayToStr(lambdaBuffer, index) + Environment.NewLine);

                        if (index == length)
                        {
                            ParseLambdaBuffer(lambdaBuffer);
                            Connected = true;
                            Available = true;
                            lastAvailableTicks = ticks;
                            continue;
                        }
                    }
                }
                catch (TimeoutException)
                { }

                if ((ticks - lastAvailableTicks) > availableTicksThreshold)
                    Available = false;
            }
        }

        private void ReadAFRMotorMasterALC1()
        {
            var lambdaBuffer = new byte[11];
            var length = lambdaBuffer.Length;
            lastAvailableTicks = DateTime.Now.Ticks;

            while (true)
            {
                if (readThread.CancellationPending) break;
                var ticks = DateTime.Now.Ticks;

                try
                {
                    var data = (byte)serialPort.ReadByte();
                    WriteTrace(data.ToString("X2"));
                    if (data == 0xAA)
                    {
                        var index = 0;
                        while (index < length)
                        {
                            try
                            {                                
                                index += serialPort.Read(lambdaBuffer, index, length - index);
                            }
                            catch (TimeoutException)
                            {
                                break;
                            }
                        }

                        if (index > 3)
                        {
                            //lambdaBuffer = DataHelper.CharArrayToByteArray("1.012222200".ToCharArray(), 0, 11);
                            if (TraceEnabled)
                                WriteTrace(new string(DataHelper.ByteArrayToCharArray(lambdaBuffer, 0, index)) + Environment.NewLine);
                            var chars = DataHelper.ByteArrayToCharArray(lambdaBuffer, 0, 4);

                            float lambda;
                            if (float.TryParse(new string(chars), NumberStyles.AllowDecimalPoint,
                                               CultureInfo.InvariantCulture, out lambda))
                            {
                                Lambda = lambda;
                                AF = 14.7f;
                                AFR = lambda*AF;
                                Available = true;
                                Connected = true;
                                lastAvailableTicks = ticks;
                                continue;
                            }
                        }
                    }
                }
                catch
                {}

                if ((ticks - lastAvailableTicks) > availableTicksThreshold)
                    Available = false;
            }
        }

        private void ReadAFRTechedge()
        {
            while (true)
            {
                if (readThread.CancellationPending) break;

                try
                {
                    var data = (byte)serialPort.ReadByte();
                    WriteTrace(data.ToString("X2"));

                    AFR = (float) Math.Round(data/10f, 1, MidpointRounding.AwayFromZero);
                    AF = 14.7f;
                    Lambda = AFR/AF;
                    Available = true;
                    Connected = true;
                }
                catch (TimeoutException)
                {
                    Available = false;
                }                
            }
        }

        private void ReadAFRInnovateLC1()
        {
            var lambdaBuffer = new byte[4];
            lastAvailableTicks = DateTime.Now.Ticks;
            var length = lambdaBuffer.Length;

            while (true)
            {
                if (readThread.CancellationPending) break;

                long ticks = DateTime.Now.Ticks;
                try
                {                    
                    var data = (byte) serialPort.ReadByte();
                    WriteTrace(data.ToString("X2"));
                    if ((data & 0xB2) == 0xB2)
                    {
                        data = (byte) serialPort.ReadByte();
                        WriteTrace(data.ToString("X2"));
                        if ((data & 0x82) == 0x82)
                        {                           
                            var index = 0;                                                      
                            
                            while (index < length)
                            {
                                try
                                {                                    
                                    index += serialPort.Read(lambdaBuffer, index, length - index);
                                }
                                catch (TimeoutException)
                                {
                                    break;
                                }
                            }

                            if (TraceEnabled)
                                WriteTrace(DataHelper.ByteArrayToStr(lambdaBuffer, index) + Environment.NewLine);
                            
                            if (index == length)
                            {
                                ParseLambdaBuffer(lambdaBuffer);
                                Connected = true;
                                Available = true;
                                lastAvailableTicks = ticks;
                                continue;
                            }
                        }
                    }
                }
                catch (TimeoutException)
                {}

                if ((ticks - lastAvailableTicks) > availableTicksThreshold)
                    Available = false;
            }
        }

        private void WriteTrace(string source)
        {
            if (!TraceEnabled) return;
            if (file == null)
                InitTraceFile();

            writer.Write(source);
        }

        private void InitTraceFile()
        {
            var basePath = Application.StartupPath + @"\trace\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var fileName = String.Format("lambda_trace_{0}_{1}.txt", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss"));
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

        private void ParseLambdaBuffer(byte[] lambdaBuffer)
        {
            //B282
            //43130241

            State = (LambdaState) (lambdaBuffer[0] >> 2 & 0x7);
            ErrorCode = 0;            
            
            switch (State)
            {
                case LambdaState.LambdaValue:
                    AF = 14.7f; //(((lambdaBuffer[0] & 1) << 7) + (lambdaBuffer[1] & 0x7F))/10f;
                    Lambda = (((lambdaBuffer[2] & 0x3F) << 7) + (lambdaBuffer[3] & 0x7F) + 500f)/1000f;
                    AFR = Lambda*AF;                    
                    break;

                case LambdaState.O2Level:
                    O2Level = (((lambdaBuffer[2] & 0x3F) << 7) + (lambdaBuffer[3] & 0x7F)) / 10;                    
                    break;

                case LambdaState.ErrorCode:
                    ErrorCode = (((lambdaBuffer[2] & 0x3F) << 7) + (lambdaBuffer[3] & 0x7F));                    
                    break;
            }
        }        

        private void DoConnect(EventArgs e)
        {
            var connect = OnConnect;
            if (connect != null)
                connect(this, e);
        }

        private void DoDisconnect(EventArgs e)
        {            
            var disconnect = OnDisconnect;
            if (disconnect != null)
                disconnect(this, e);
        }

        public event EventHandler OnConnect;
        public event EventHandler OnDisconnect;
    }
}

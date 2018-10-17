using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using EcuCommunication.Protocols;
using EcuCommunication.Protocols.Requests;
using Helper;


namespace KWPTest
{
    public partial class KWPTestForm : Form
    {
        private readonly SynchronizationContext uiContext;
        private readonly Object thisLock = new Object();
        private byte[] firmwareBuffer = new byte[ushort.MaxValue];
        private byte[] keyBuffer = new byte[] { 0x01, 0x36, 0x57, 0x5C, 0x0F, 0x00, 0x00, 0x33 };
        private byte[] keyHashBuffer = new byte[8];        
        private readonly OltDiagForm oltDiagForm;
        private readonly OltDiagParams oltDiagParams;
        private readonly CommonDiagForm commonDiagForm;
        private readonly CommonDiagParams commonDiagParams;
        private readonly List<string> log = new List<string>();
        private readonly long ticks = DateTime.Now.Ticks;        
        private const long logUpdateTimeout = 5000000;
        private const int logMaxRows = 1000;
        private int currentLogRow;
        private readonly IDictionary<string, string> userProtocol = new Dictionary<string, string>();
        private readonly LC1Emul lc1Emul = new LC1Emul();
        private byte uoz_direct;
        private byte alf_direct;
        private byte oktan_direct;
        private byte faza_direct;
        private byte coeff_direct;
        private byte twat_direct;        
        private byte rxxstep_direct;        
        private byte xxrpm_direct;        
        private readonly Random random;
        private DiagData[] diagDataLog = new DiagData[0];        
        private int logIndex;
        private readonly List<string> ecuTraceLines = new List<string>();        
        private int traceIndex;
        private BootstrapMode bootstrapMode = BootstrapMode.No;
        private byte[] buffer;
        private int count;
        private int startAddress;
        private int size = 8;
        private readonly byte[] loader = new byte[1024*4];
        private int loaderIndex = 0;

        public KWPTestForm()
        {
            InitializeComponent();
            serialPort.ReadTimeout = 50;// SerialPort.InfiniteTimeout;
            serialPort.WriteTimeout = 50;
            uiContext = SynchronizationContext.Current;
            ecuSN.Text = DataHelper.ByteArrayToStr(keyBuffer, keyBuffer.Length);                                    
            oltDiagParams = new OltDiagParams();            
            commonDiagParams = new CommonDiagParams();
            oltDiagForm = new OltDiagForm(oltDiagParams);
            commonDiagForm = new CommonDiagForm(commonDiagParams);

            random = new Random((int) DateTime.Now.Ticks);

            InitKeyHashBuffer();
            CalcSNHash();

            InitUserProtocol();            

            portNumber.Items.AddRange(SerialPort.GetPortNames());
        }

        private void InitKeyHashBuffer()
        {
            byte b = 0;
            for (int i = 0; i < keyHashBuffer.Length; i++)
            {
                byte a = 3;
                a *= b;
                a += 0xA5;
                b = a;
                a = keyBuffer[i % 8];
                a += b;
                b = a;
                keyHashBuffer[i] = a;                
            }

            keyHashLabel.Text = DataHelper.ByteArrayToStr(keyHashBuffer);
        }

        private void InitKeyHashBuffer_v3()
        {
            byte b = 0xC7;
            var count = keyHashBuffer.Length;
            for (int i = 0; i < count; i++)
            {
                byte a = keyBuffer[i % 8];
                byte t = a;
                a = b;
                b = t;

                a ^= b;
                a = DataHelper.rl(a);
                a ^= (byte)(count - i);
                a = DataHelper.rl(a);
                t = a;
                a = b;
                b = t;  
                keyHashBuffer[i] = b;

                a = DataHelper.rl(a);
                a ^= 0x51;
                a = DataHelper.rl(a);
                b = a;
            }
        }        

        private void InitUserProtocol()
        {
            var path = Application.StartupPath + @"\protocol.txt";
            if (!File.Exists(path)) return;

            using (var textReader = new StreamReader(path))
            {
                while (!textReader.EndOfStream)
                {
                    var str = textReader.ReadLine();
                    if (String.IsNullOrEmpty(str)) continue;
                    var items = str.Split(' ');
                    if (items.Length < 2) continue;

                    userProtocol.Add(items[0], items[1]);
                }
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if ((string)btnListen.Tag == "1")
            {
                StopEcuEmul();
                btnListen.Text = "Start";
                btnListen.Tag = "0";
            }
            else
            {             
                SerialPortListen();
                btnListen.Text = "Stop";
                btnListen.Tag = "1";
            }
        }

        private void SerialPortListen()
        {                        
            serialPort.Close();
            serialPort.PortName = portNumber.Text;
            serialPort.BaudRate = int.Parse(serialSpeed.Text);
            serialPort.Open();
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            ecuEmulStatus.Text = "ecu emulation start";
            readThread.RunWorkerAsync();
        }

        private static void SaveLogToFile(string content)
        {
            if (String.IsNullOrEmpty(content)) return;
            var path = String.Format(@"{0}\log.txt", Application.StartupPath, DateTime.Now.Ticks/*DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss")*/);

            //MessageBox.Show(path);

            using (var logFile = new StreamWriter(path, true))
            {
                logFile.WriteLine(content);
                logFile.Flush();
                logFile.Close();
            }
        }

        private byte[] CreateAnswer(string requestStr)
        {
            byte[] answer;

            if (BootstrapAnswer(requestStr, out answer))
            {
                return answer;
            }

            if (ReverseAnswer(requestStr, out answer))
            {
                return answer;
            }

            if (UserProtocolAnswer(requestStr, out answer))
            {
                return answer;
            }            

            if (CommonAnswer(requestStr, out answer))
            {
                return answer;
            }

            if (OltAnswer(requestStr, out answer))
            {
                return answer;
            }

            if (TRSAnswer(requestStr, out answer))
                return answer;

            if (DiagAnswer(requestStr, out answer))
            {
                return answer;
            }

            if (SokolovSportAnswer(requestStr, out answer))
                return answer;

            answer = new byte[] { 0x83, 0xF1, 0x10, 0x7F, 0x21, 0x10, 0x34 };

            return answer;
        }

        private bool BootstrapAnswer(string requestStr, out byte[] answer)
        {
            answer = null;
           
            if (requestStr == "00")
            {

                answer = new byte[] {0x55};
                serialPort.StopBits = StopBits.Two;
                bootstrapMode = BootstrapMode.Yes;
                return true;
            }

            return false;
        }

        private bool ReverseAnswer(string requestStr, out byte[] answer)
        {
            answer = null;
            if (!ReverseData.instance.Enabled || !requestStr.Contains(ReverseData.instance.RequestHeader))
                return false;

            answer = ReverseData.instance.Answer;
            return true;
        }

        private bool SokolovSportAnswer(string requestStr, out byte[] answer)
        {
            answer = null;
            var request = DataHelper.StrToByteArray(requestStr);
            
            switch (request[0])
            {
                case (byte)'w':
                    answer = new byte[0];
                    break;

                case (byte)'r':
                    answer = new byte[1];
                    answer[0] = (byte) random.Next(byte.MaxValue);
                    break;
            }

            Thread.Sleep(50);

            return answer != null;
        }

        private bool TRSAnswer(string requestStr, out byte[] answer)
        {
            answer = null;

            switch (requestStr)
            {
                case "8210F1210DB1":
                    var count = oltDiagParams.bytes.Length;
                    answer = new byte[count + 7];
                    answer[0] = 0x80;
                    answer[1] = 0xF1;
                    answer[2] = 0x10;
                    answer[3] = (byte) (count + 2);
                    answer[4] = 0x61;
                    answer[5] = 0x0D;
                    Buffer.BlockCopy(oltDiagParams.bytes, 0, answer, 6, count);
                    DataHelper.CalcCRC(answer);
                    break;
            }

            return answer != null;
        }

        private bool UserProtocolAnswer(string requestStr, out byte[] answer)
        {
            answer = null;

            if (userProtocol.ContainsKey(requestStr))
                answer = DataHelper.StrToByteArray(userProtocol[requestStr]);

            return answer != null;
        }

        private bool CommonAnswer(string requestStr, out byte[] answer)
        {
            answer = null;

            switch (requestStr)
            {
                //	startCommunication
                case "8110F18103":
                    answer = new byte[] {0x83, 0xF1, 0x10, 0xC1, 0x6B, 0x8F, 0x3F};
                    break;

                //	stopCommunication
                case "8110F18204":
                    answer = new byte[] {0x81, 0xF1, 0x10, 0xC2, 0x44};
                    break;
                
                //	startDiagnosticSession
                case "8110F11092":
                case "8310F110810A1F":
                case "8310F11081263B":            
                case "8310F11081394E":                    
                    answer = new byte[] {0x82, 0xF1, 0x10, 0x50, 0x81, 0x54};
                    break;

                //	stopDiagnosticSession
                case "8110F120A2":
                    answer = new byte[] {0x81, 0xF1, 0x10, 0x60, 0xE2};
                    break;

                //	testerPresent
                case "8210F13E01C2":
                    answer = new byte[] {0x81, 0xF1, 0x10, 0x7E, 0x00};
                    break;                                   

                case "AA":
                    answer = new byte[] { 0xAA };
                    break;
            }

            return answer != null;
        }

        private bool OltAnswer(string requestStr, out byte[] answer)
        {
            answer = null;

            if (requestStr.Length < 12) return false;

            var cmd1 = requestStr.Substring(6, 4);            
            var cmd2 = requestStr.Substring(8, 4);
            //8510F1230000006009
            if (requestStr == "8510F12300F30008A4")
            {
                // answer = new byte[] { 0x80, 0xF1, 0x10, 0x09, 0x63, 0xC2, 0xAF, 0x90, 0xF3, 0x00, 0x78, 0xF4, 0x79, 0x00 };                
                answer = new byte[] { 0x80, 0xF1, 0x10, 0x09, 0x63, 00, 00, 00, 00, 00, 00, 00, 00, 0x00 };                
                DataHelper.CalcCRC(answer);
            }
            else if (cmd1 == "2300")
            {
                {
                    //  ************************* readMemoryByAddress ************************

                    ////	readMemoryByAddress MemAddr - (0xF300) MemSize - 0x08
                    //case "8510F12300F30008A4":
                    //    answer = new byte[] { 0x80, 0xF1, 0x10, 0x09, 0x63, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    //    DataHelper.CalcCRC(answer);
                    //    break;

                    ////	readMemoryByAddress MemAddr - (0x00C0) MemSize - 0x10 (ECU SN) 0x01, 0x71, 0x91, 0x45, 0x0B, 0x00, 0x00, 0x48
                    //case "8510F1230000C01079":
                    //    //017191450B000048    
                    //    //answer = new byte[] { 0x80, 0xF1, 0x10, 0x11, 0x63, 0xA6, 0x08, 0x4E, 0xD4, 0x2C, 0x29, 0x20, 0x4D, 0x8D, 0xBD, 0x6D, 0x31, 0x43, 0x6E, 0xEF, 0xBA, 0x00 };

                    //    //0136575C0F000033
                    //    answer = new byte[] { 0x80, 0xF1, 0x10, 0x11, 0x63, 0xA6, 0xCD, 0x63, 0x2A, 0x32, 0x3B, 0x56, 0xDA, 0x34, 0x77, 0x61, 0x24, 0x20, 0x05, 0xB4, 0xF4, 0x00 };
                    //    DataHelper.CalcCRC(answer);
                    //    break;

                    var count = byte.Parse(requestStr.Substring(14, 2), NumberStyles.HexNumber);
                    answer = new byte[count + 6];
                    answer[0] = 0x80;
                    answer[1] = 0xF1;
                    answer[2] = 0x10;
                    answer[3] = (byte) (count + 1);
                    answer[4] = 0x63;
                    var addr = ushort.Parse(requestStr.Substring(10, 4), NumberStyles.HexNumber);
                    ReadECUHash(addr, count, answer, 5);

                    DataHelper.CalcCRC(answer);
                }
            }
            //8010F165230000006000
            else if (cmd2 == "2300")
            {
                var count = byte.Parse(requestStr.Substring(16, 2), NumberStyles.HexNumber);
                answer = new byte[count + 6];
                answer[0] = 0x80;
                answer[1] = 0xF1;
                answer[2] = 0x10;
                answer[3] = (byte)(count + 1);
                answer[4] = 0x63;
                var addr = ushort.Parse(requestStr.Substring(12, 4), NumberStyles.HexNumber);
                ReadECUHash(addr, count, answer, 5);

                DataHelper.CalcCRC(answer);
            }
            else if (cmd1 == "3D00" || cmd2 == "3D00")
            {
                answer = new byte[8];
                answer[0] = 0x84;
                answer[1] = 0xF1;
                answer[2] = 0x10;
                answer[3] = 0x7D;
                answer[4] = 0x00;
                answer[5] = 0x71;
                answer[6] = 0xD8;
                DataHelper.CalcCRC(answer);
            }            
            else if (requestStr.Contains("10F1304A"))
            {
                answer = InputOutputControlByLocalIdentifier(ref uoz_direct);               
            }
            else if (requestStr.Contains("10F13049"))
            {
                answer = InputOutputControlByLocalIdentifier(ref alf_direct);
            }
            else if (requestStr.Contains("10F1304B"))
            {
                answer = InputOutputControlByLocalIdentifier(ref oktan_direct);
            }
            else if (requestStr.Contains("10F1304C"))
            {
                answer = InputOutputControlByLocalIdentifier(ref faza_direct);
            }
            else if (requestStr.Contains("10F1304D"))
            {
                answer = InputOutputControlByLocalIdentifier(ref coeff_direct);
            }
            else if (requestStr.Contains("10F1304E"))
            {
                answer = InputOutputControlByLocalIdentifier(ref twat_direct);
            }
            else if (requestStr.Contains("10F13041"))
            {
                answer = InputOutputControlByLocalIdentifier(ref rxxstep_direct, ref xxrpm_direct);
            }
            else if (requestStr.Contains("10F13042"))
            {
                answer = InputOutputControlByLocalIdentifier(ref rxxstep_direct, ref xxrpm_direct);
            }
            else
            {
                switch (requestStr)
                {
                    //  ************************* readDataByLocalIdentifier ************************
                    //	readDataByLocalIdentifier   LocalIdentifier - 0F  (Чтение ячейки 0xF97D)
                    case "8210F1210FB3":
                        //answer = new byte[]
                        //             {
                        //                 0x80, 0xF1, 0x10, 0x35, 0x61, 0x0F,
                        //                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  //2B 2C 93 5B 23 24 25 5F 49 61 4C 52 55 53 38 39 //15
                        //                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  //64 65 6F 4D 62 AC AD AE  AF 72    //25                                     
                        //           //26                                                                                    //RXX       UOZ  DPDZ DTOG                          RPM_XX     DK
                        //                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //F80C F80D F84D F8A9 F80B F80F F811 F810 F88F F8AE F849 F885 F5FF
                        //               //39                                                                        Твпр МРВ  ЦРВ       
                        //                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //F97D F98F F841 F808  F82E F862
                        //                 0x00
                        //             };

                        var byteList = new List<byte>();
                        byteList.AddRange(new byte[] {0x80, 0xF1, 0x10, 0x00, 0x61, 0x0F});
                        var dest = new byte[51];
                        Buffer.BlockCopy(oltDiagParams.bytes, 0, dest, 0, dest.Length);
                        byteList.AddRange(dest);
                        byteList.Add(0x00);
                        answer = byteList.ToArray();
                        answer[3] = (byte)(dest.Length + 2);
                        DataHelper.CalcCRC(answer);
                        break;

                    case "8210F1210EB2":
                        answer = new byte[]
                                     {
                                         0x80, 0xF1, 0x10, 0x12, 0x61, 0x0E,
                                         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  //2C 49 61 52 38 39 62                                                                                
                                                           //          DK
                                         0x00, 0x00, 0x50, //F8AE F885 F5FF                                                                                                                             
                                         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //F841 F808 F82E
                                         0x00
                                     };
                        DataHelper.CalcCRC(answer);
                        break;

                    //  ************************* inputOutputControlByLocalIdentifier ************************
                    //olt Switch To RAM                    
                    case "8410F1300F0601CB":
                        answer = new byte[] { 0x84, 0xF1, 0x10, 0x70, 0x0F, 0x06, 0x01, 0x0B };                        
                        break;
                }
            }            

            return answer != null;
        }

        private byte[] InputOutputControlByLocalIdentifier(ref byte imValue)
        {
            if (buffer[5] == 7)
            {
                imValue = buffer[6];
            }

            var answer = new byte[] { 0x84, 0xF1, 0x10, 0x70, buffer[4], buffer[5], imValue, 0x00 };
            DataHelper.CalcCRC(answer);

            return answer;
        }

        private byte[] InputOutputControlByLocalIdentifier(ref byte val1, ref byte val2)
        {
            if (buffer[5] == 7)
            {
                val1 = buffer[6];
                val2 = buffer[6];
            }

            var answer = new byte[] { 0x87, 0xF1, 0x10, 0x70, buffer[4], buffer[5], val1, val1, val2, val2, 0x00 };
            DataHelper.CalcCRC(answer);

            return answer;
        }

        private bool DiagAnswer(string requestStr, out byte[] answer)
        {
            answer = null;
            var byteList = new List<byte>();

            switch (requestStr)
            {
                //  ************************* readDataByLocalIdentifier ************************
                // 	readEcuIdentification
                case "8210F11A801D":
                    answer = new byte[] {
                        //0xBE52
                        0x83, 0xF1, 0x10, 0x61, 0x5A, 0x80, 
                        //0xF460
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                        //0x8000
                        0x32, 0x31, 0x31, 0x32, 0x34, 0x2D, 0x31, 0x34, 0x31, 0x31, 0x30, 0x32, 0x30, 0x2D, 0x33, 0x32,
                        //0x8011
                        0x4E, 0x4F, 0x54, 0x53, 0x55, 0x50, 0x50, 0x4F, 0x52, 0x54, 
                        //0x80C1
                        0x31, 0x34, 0x31, 0x31, 0x30, 0x31, 0x30, 0x2D, 0x33, 0x32, 
                        //0x8027
                        0x53, 0x41, 0x4D, 0x41, 0x52, 0x41, 0x2D, 0x31, 0x2E, 0x36, 0x4C, 0x2C, 0x31, 0x36, 0x56, 
                        //0xF474
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                        //0x8037
                        0x31, 0x35, 0x2D, 0x30, 0x32, 0x2D, 0x32, 0x30, 0x30, 0x35, 
                        //0x8042
                        0x49, 0x32, 0x30, 0x35, 0x44, 0x4D, 0x35, 0x33, 0x00};
                    //answer = new byte[] {0x80, 0xF1, 0x10, 0x61, 0x5A, 0x80,
                        
                    //    0x56, 0x41, 0x5A, 0x32, 0x31, 0x30, 0x38, 0x33, 0x2D, 0x30, 
                    //    0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x2D, 0x32, 0x30, 0x32, 
                    //    0x31, 0x31, 0x32, 0x20, 0x2D, 0x31, 0x34, 0x31, 0x31, 0x30, 
                    //    0x32, 0x30, 0x2D, 0x36, 0x30, 0x30, 0x32, 0x36, 0x31, 0x31, 
                    //    0x32, 0x33, 0x34, 0x35, 0x36, 0x31, 0x34, 0x31, 0x31, 0x30, 
                    //    0x30, 0x30, 0x2D, 0x30, 0x30, 0x53, 0x41, 0x4D, 0x41, 0x52, 
                    //    0x41, 0x2D, 0x31, 0x2E, 0x35, 0x6C, 0x2C, 0x20, 0x38, 0x56, 
                    //    0x32, 0x38, 0x35, 0x30, 0x33, 0x35, 0x38, 0x30, 0x35, 0x2D, 
                    //    0x30, 0x37, 0x2D, 0x31, 0x39, 0x39, 0x36, 0x4D, 0x31, 0x56, 
                    //    0x31, 0x33, 0x46, 0x30, 0x34, 0x00};
                    DataHelper.CalcCRC(answer);
                    break;

                //	************************************* readDataByLocalIdentifier **********************************
                //	afterSalesServiceRecordLocalIdentifier
                // ICD diag date
                case "8210F12101A5":
                    if (useTraceCheckBox.Checked && ecuTraceLines.Count > 0)
                    {
                        answer = DataHelper.StrToByteArray(ecuTraceLines[traceIndex]);
                        traceIndex = (traceIndex + 1) % ecuTraceLines.Count;
                    }
                    else if (cbxUseDiagLog.Checked && diagDataLog.Length > 0)
                    {
                        answer = Euro2DiagDataRequest.ToAnswerBuffer(diagDataLog[logIndex]);
                        logIndex = (logIndex + 1) % diagDataLog.Length;
                    }
                    else
                    {
                        //answer = new byte[]
                        //             {
                        //                 0x80, 0xF1, 0x10, 0x2С, 0x61, 0x01,
                        //                 //0xBB7B
                        //                 0x20, 0x21, 0x2B, 0x2C, 0x5B, 0x23, 0x24, 0x25, 0x49, 0x61, 0x52, 0x55, 0x53, 0x64, 0x65, 0x6F, //15
                        //                 //0xBB8C
                        //                 0xF8, 0x44, 0xF8, 0xAE, 0xF9, 0x78, 0xF8, 0x49, 0xF9, 0x64, 0xF8, 0x10,  //21
                        //                 //0xBB95
                        //                 0xF8, 0x41, 0xF8, 0x08, 0xF8, 0x2E, 0xF8, 0x62, 0xF8, 0x74, 0xF8, 0xF8, 0xF9, 0x3B, //35
                        //                 0x00
                        //             };
                        byteList.AddRange(new byte[] {0x80, 0xF1, 0x10, 0x26, 0x61, 0x01});
                        byteList.AddRange(commonDiagParams.bytes);
                        byteList.Add(0x00);
                        answer = byteList.ToArray();
                        DataHelper.CalcCRC(answer);
                    }
                    break;

                case "8210F12103A7":
                    byteList.AddRange(new byte[] { 0x80, 0xF1, 0x10, 0x26, 0x61, 0x03});
                    byteList.AddRange(new byte[10]);
                    byteList.Add(0x00);
                    answer = byteList.ToArray();

                    DataHelper.CalcCRC(answer);      
                    break;

                case "8210F121A044":
                    answer = new byte[]
                                 {
                                     0x80, 0xF1, 0x10, 0x05, 0x61, 
                                     0x00, 0x00, 0x03, 0x00, 0x00
                                 };
                    DataHelper.CalcCRC(answer);
                    break;

                //	readDiagnosticTroubleCodesByStatus
                case "8410F1180000009D":
                case "8410F11800FF009C":
                    answer = new byte[] {0x85, 0xF1, 0x10, 0x58, 0x01, 0x01, 0x34, 0xE0, 0x00};
                    DataHelper.CalcCRC(answer);
                    break;

                //	clearDiagnosticInformation
                case "8310F114FF0097":
                    answer = new byte[] {0x83, 0xF1, 0x10, 0x54, 0xFF, 0x00, 0xD7};
                    break;
            }

            return answer != null;
        }

        private void ReadECUHash(ushort addr, byte count, byte[] buffer, byte offset)
        {                        
            byte b = 0;
            var length = firmwareBuffer != null ? firmwareBuffer.Length : 0;
            for (int i = 0; i < count; i++)
            {
                byte a = 3;
                a *= b;
                a += 0xA5;
                b = a;
                a = keyBuffer[i % 8];
                a += b;
                b = a;
                if (addr < length)
                    a = (byte)(a ^ firmwareBuffer[addr]);
                addr++;
                buffer[i + offset] = a;
            }
        }

        private void ReadECUHash1(ushort addr, byte count, byte[] buffer, byte offset)
        {
            var length = firmwareBuffer != null ? firmwareBuffer.Length : 0;
            for (var i = 0; i < count; i++)
            {
                var a = keyHashBuffer[i % 8];
                if (addr < length)
                    a = (byte)(a ^ firmwareBuffer[addr]);
                addr++;
                buffer[i + offset] = a;
            }
        }

        private byte[] ECUHashToSN(ushort addr, byte[] buffer, byte offset)
        {
            byte b = 0;
            var key = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                byte a = 3;
                a *= b;
                a += 0xA5;
                b = a;

                a = buffer[i + offset];
                a = (byte)(a ^ firmwareBuffer[addr]);                
                key[i] = (byte) (a - b);
                b = a;                
                addr++;                 
            }

            return key;
        }         

        private void ReadECUHash2(ushort addr, byte count, byte[] buffer, byte offset)
        {
            byte b = 0xC7;
            var length = firmwareBuffer != null ? firmwareBuffer.Length : 0;
           
            for (int i = 0; i < count; i++)
            {
                byte a = keyBuffer[i % 8];               
                byte t = a;
                a = b;
                b = t;

                a ^= b;
                a = DataHelper.rl(a);
                a ^= (byte) (count - i);
                a = DataHelper.rl(a);
                t = a;
                a = b;
                b = t;

                if (addr < length)
                    a = firmwareBuffer[addr];
                addr++;
                a ^= b;                                
                buffer[i + offset] = a;

                a = DataHelper.rl(a);
                a ^= 0x51;
                a = DataHelper.rl(a);
                b = a;
            }
        }             

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopEcuEmul();
            lc1Emul.Stop();
            SaveLogToFile(protocolTrace.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            protocolTrace.ResetText();
        }

        private void StopEcuEmul()
        {
            readThread.CancelAsync();
            BackgroundWorkerHelper.Wait(readThread);
            serialPort.Close();

            ecuEmulStatus.Text = "ecu emulation stop";
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            var str = ecuSN.Text;                        

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                keyHashBuffer = DataHelper.StrToByteArray(str);
                //A610FA7D2A230E8E
                keyBuffer = ECUHashToSN(0xf300, keyHashBuffer, 0);                
                ecuSN.Text = DataHelper.ByteArrayToStr(keyBuffer);
            }
            else
            {
                keyBuffer = DataHelper.StrToByteArray(str);
                CalcSNHash();
            }            
        }

        private void CalcSNHash()
        {
            return;
            var count = keyBuffer.Length;
            var snHash = new byte[count];

            ReadECUHash(0xF300, 8, snHash, 0);            
            ReadECUHash1(0xF300, 8, snHash, 0);            
        }        

        private void openFirmwareBtn_Click(object sender, EventArgs e)
        {            
            if (openFirmware.ShowDialog(this) != DialogResult.OK || !File.Exists(openFirmware.FileName)) return;

            using (var firmware = File.OpenRead(openFirmware.FileName))
            {
                firmwareBuffer = new byte[firmware.Length];
                firmware.Read(firmwareBuffer, 0, firmwareBuffer.Length);
                firmware.Close();
            }

            firmwareStatusLabel.Text = Path.GetFileName(openFirmware.FileName);
            firmwareStatusLabel.ToolTipText = DataHelper.CalculateCRC(firmwareBuffer, 0, 176).ToString("X8");
        }       

        private void openOltDiagOptions_Click(object sender, EventArgs e)
        {
            if (oltDiagForm.Visible) return;
            oltDiagForm.Show(this);
        }

 
        private void btnCmnDiag_Click(object sender, EventArgs e)
        {
            if (commonDiagForm.Visible) return;
            commonDiagForm.Show(this);
        }

        private void lc1EmulStart_Click(object sender, EventArgs e)
        {
            if ((string)lc1EmulStart.Tag == "1")
            {
                lc1EmulStart.Text = "Start";
                lc1EmulStart.Tag = "0";
                lc1Emul.Stop();
                lc1EmulState.Text = "lc-1 emulation stop";
            }
            else
            {
                lc1EmulStart.Text = "Stop";
                lc1EmulStart.Tag = "1";
                lc1Emul.Start(lc1SerialNumber.Text);
                lc1EmulState.Text = "lc-1 emulation start";
            }
        }

        private void afrValue_TextChanged(object sender, EventArgs e)
        {
            float afr;
            var afrStr = afrValue.Text.Replace(',', '.');

            if (float.TryParse(afrStr, NumberStyles.Float, CultureInfo.InvariantCulture, out afr))
            {
                lc1Emul.SetAFR(afr);
            }
        }

        private void readThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            count = 256;
            buffer = new byte[count];

            while (true)
            {
                if (readThread.CancellationPending) break;

                if (bootstrapMode != BootstrapMode.No)
                {
                    BootstrapModeExecute();
                }
                else
                    Read();
            }
        }

        private void BootstrapModeExecute()
        {            
            int length = 0;
            Array.Clear(buffer, 0, buffer.Length);

            do
            {
                try
                {
                    buffer[length++] = (byte) serialPort.ReadByte();
                    serialPort.Write(buffer, length - 1, 1);
                }
                catch (TimeoutException)
                {
                }
            } while (length < size);
            
            var checkSumm = DataHelper.CalcXorCRC(buffer, 0, length - 1);
            if (checkSumm == buffer[length - 1])
            {
                buffer[length] = 0x55;
            }
            else
            {
                buffer[length] = 0xFE;
            }

            serialPort.Write(buffer, length, 1);            

            #region
            string requestStr = DataHelper.ByteArrayToStr(buffer, length);
            log.Add(String.Format("{0}\t->\t{1}", requestStr, buffer[length].ToString("X2")));
            var currentTicks = DateTime.Now.Ticks;
            if ((currentTicks - ticks) < logUpdateTimeout) return;
            uiContext.Send(
                delegate
                {
                    if (currentLogRow > logMaxRows)
                    {
                        SaveLogToFile(protocolTrace.Text);
                        protocolTrace.ResetText();
                        currentLogRow = 0;
                    }
                    protocolTrace.AppendText(Environment.NewLine);
                    protocolTrace.AppendText(String.Join(Environment.NewLine, log.ToArray()));
                }
                , null);
            currentLogRow += log.Count;
            log.Clear();
            #endregion

            if (buffer[0] == 00)
            {
                bootstrapMode = BootstrapMode.Yes;
            }

            switch (bootstrapMode)
            {
                case BootstrapMode.Yes:
                    #region                    
                    switch (buffer[1])
                    {
                        case 00:
                            bootstrapMode = BootstrapMode.Mode0;
                            startAddress = (buffer[2] << 8) + buffer[3];
                            size = buffer[6] + 2;
                            loaderIndex = 0;
                            break;

                        case 01:
                            bootstrapMode = BootstrapMode.Mode1;
                            startAddress = (buffer[2] << 8) + buffer[3];
                            break;

                        case 02:
                            bootstrapMode = BootstrapMode.Mode2;
                            break;

                        case 03:
                            bootstrapMode = BootstrapMode.Mode3;
                            break;
                    }
                    break;
                    #endregion

                case BootstrapMode.Mode0:
                    #region                    
                    switch (buffer[0])
                    {
                        case 01:
                            Buffer.BlockCopy(buffer, 1, loader, loaderIndex, size - 2);
                            loaderIndex += (size - 2);
                            break;

                        case 02:
                            bootstrapMode = BootstrapMode.Yes;
                            size = 8;
                            Buffer.BlockCopy(buffer, 2, loader, loaderIndex, size - 3);
                            loaderIndex += (size - 3);
                            var file = new byte[loaderIndex];
                            Buffer.BlockCopy(loader, 0, file, 0, loaderIndex);
                            File.WriteAllBytes(@"c:\loader.bin", file);
                            break;
                    }                   
                    break;
                    #endregion
            }
        }

        private void Read()
        {
            lock (thisLock)
            {
                if (!serialPort.IsOpen) return;                

                var length = 0;

                try
                {
                    var n = 0;
                    do
                    {
                        n = serialPort.Read(buffer, length, count - length);
                        length += n;
                    } while (n > 0);
                }
                catch (TimeoutException)
                {}

                if (length == 0) return;                

                if (echo.Checked)
                    serialPort.Write(buffer, 0, length);

                var requestStr = DataHelper.ByteArrayToStr(buffer, length);
                var answer = CreateAnswer(requestStr);

                length = 0;
                do
                {
                    var count = Math.Min(40, answer.Length - length);
                    if (count <= 0) break;
                    serialPort.Write(answer, length, count);
                    length += count;

                } while (true);
                log.Add(String.Format("{0}\t->\t{1}", requestStr, DataHelper.ByteArrayToStr(answer, answer.Length)));

                var currentTicks = DateTime.Now.Ticks;

                if ((currentTicks - ticks) < logUpdateTimeout) return;

                uiContext.Send(
                    delegate
                    {
                        if (currentLogRow > logMaxRows)
                        {
                            SaveLogToFile(protocolTrace.Text);
                            protocolTrace.ResetText();
                            currentLogRow = 0;
                        }
                        protocolTrace.AppendText(Environment.NewLine);
                        protocolTrace.AppendText(String.Join(Environment.NewLine, log.ToArray()));
                    }
                    , null);

                currentLogRow += log.Count;
                log.Clear();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            var number = byte.Parse(byteNumber.Text);
            var value = Convert.ToByte(byteValue.Text, 16);

            oltDiagParams.bytes[number] = value;
        }

        private void linkStatusLabel_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://ecusystems.ru");
            linkStatusLabel.LinkVisited = true;
        }

        private void lambdaNormal_CheckedChanged(object sender, EventArgs e)
        {
            lc1Emul.O2Level = o2level.Checked;
        }

        private void btnOpenDiagLog_Click(object sender, EventArgs e)
        {
            diagDataLog = DiagLogOpenForm.LoadDiagLog(this);
            logFileStatusLable.Text = "Log row count: " + diagDataLog.Length;
            timeBar.Maximum = diagDataLog.Length;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var openTrace = new OpenFileDialog())
            {
                openTrace.Filter = "Trace files|*.txt|All files|*.*";
                openTrace.CheckFileExists = true;
                openTrace.InitialDirectory = Application.StartupPath;
                if (openTrace.ShowDialog(this) != DialogResult.OK) return;

                using (var trace = new StreamReader(openTrace.FileName))
                {
                    while (!trace.EndOfStream)
                    {
                        var line = trace.ReadLine();
                        if (String.IsNullOrEmpty(line) || !line.Contains("8210F12101A5")) continue;

                        line = line.Replace("8210F12101A5\t\t->\t8210F12101A5", String.Empty);
                        ecuTraceLines.Add(line);
                    }
                }
            }            
        }

        private void btnOpenLCTrace_Click(object sender, EventArgs e)
        {
            using (var openTrace = new OpenFileDialog())
            {
                openTrace.Filter = "Trace files|*.txt|All files|*.*";
                openTrace.CheckFileExists = true;
                openTrace.InitialDirectory = Application.StartupPath;
                if (openTrace.ShowDialog(this) != DialogResult.OK) return;

                using (var trace = new StreamReader(openTrace.FileName))
                {
                    while (!trace.EndOfStream)
                    {
                        var line = trace.ReadLine();                        
                        lc1Emul.TraceLines.Add(line);
                    }
                }
            }   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReverseProtocolForm.ShowForm(this);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (diagDataLog.Length > 0) {
                oltDiagParams.bytes[0] = (byte)( diagDataLog[timeBar.Value].ErrorStatus << 8);
                oltDiagParams.bytes[8] = (byte)(diagDataLog[timeBar.Value].TWAT +40);

            }
            
        }
    }

    internal enum BootstrapMode
    {
        No,
        Yes,
        Mode0,
        Mode1,
        Mode2,
        Mode3
    }
}

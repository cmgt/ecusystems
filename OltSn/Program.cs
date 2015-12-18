using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace OltSn
{
    class Program
    {
        private const string startCommunication = "8110F18103";
        private const string stopCommunication = "8110F18204";

        private const string startDiagnosticSession = "8310F110810A1F";
        private const string stopDiagnosticSession = "8110F120A2";

        private const string testerPresent = "8210F13E01C2";

        private const string switchToRam = "8410F1300F0601CB";
        private const string readMemoryF300 = "8510F12300F30008A4";
        private const string readMemory00C0 = "8510F1230000C01079";

        private const string defaultCom = "COM3";

        static void Main(string[] args)
        {
            Console.WriteLine("olt ecu serial number reader. cm_gt inc. version 1.2. ecusystems.ru\r\n");
            Console.WriteLine("Usage: OltSn.exe [COM] [Timeout]");
            Console.WriteLine("\tExample: OltSn.exe COM3 300\r\n");
            var comName = args.Length > 0 ? args[0] : defaultCom;
            var timeoutStr = args.Length > 1 ? args[1] : "300";
            int timeout;
            if (!int.TryParse(timeoutStr, out timeout))
                timeout = 300;

            try
            {
                string serialNumber = String.Empty; 
                //serialNumber = CalcSerialNumber(StrToBytes("80F11011635DB43C59AB2AB633B1C07005C70E22A7DD"));
                //serialNumber = BytesToStr(CalcEcuSn(StrToBytes("5DB43C59AB2AB633B1C07005C70E22A7")));

                using (var serialPort = new SerialPort(comName, 10400))
                {                    
                    serialPort.Open();
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                    serialPort.ReadTimeout = timeout;
                    serialPort.WriteTimeout = timeout;

                    byte[] response;
                    Request(serialPort, startCommunication, out response);
                    Request(serialPort, startDiagnosticSession, out response);
                    Request(serialPort, testerPresent, out response);
                    Request(serialPort, switchToRam, out response);
                    Request(serialPort, readMemoryF300, out response);
                    Request(serialPort, readMemory00C0, out response);

                    serialNumber = CalcSerialNumber(response);

                    Request(serialPort, stopDiagnosticSession, out response);
                    Request(serialPort, stopCommunication, out response);
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                    serialPort.Close();                    
                }

                Console.WriteLine("\r\nOLT serial number: {0}", serialNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            Console.ReadKey(true);
        }

        private static string CalcSerialNumber(byte[] response)
        {
            //response = StrToBytes("80F1100963A6CD632A323B56DA8A");
            var str = BytesToStr(response, response.Length);            
            //80F1100963A6CD632A323B56DA8A);
            if (response.Length < 13) return "Error serial number response " + str;
            var offset = (response[0] & 0x0F) == 0 ? 5 : 4;
            var key = ECUHashToSN(response, (byte) offset);
            return BytesToStr(key, 8);
        }

        private static void Request(SerialPort serialPort, string data, out byte[] response)
        {
            response = SendCommand(serialPort, data);
            var success = response.Length > 3 && response[3] != 0x7F;
            if (!success) new Exception(String.Format("Error response: {0}", BytesToStr(response, response.Length)));
        }

        private static byte[] SendCommand(SerialPort serialPort, string command)
        {
            var response = new byte[0];
            if (!serialPort.IsOpen) return response;

            Thread.Sleep(200);
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            var cmd = StrToBytes(command);
            serialPort.Write(cmd, 0, cmd.Length);

            response = RecieveResponse(serialPort);
            var s = BytesToStr(response, response.Length).Replace(command, "");
            response = StrToBytes(s);
            
            Console.Write(command);
            Console.CursorLeft = 22;
            Console.WriteLine("-> {0}", s);

            return response;
        }

        private static string BytesToStr(byte[] buffer, int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.AppendFormat(buffer[i].ToString("X2"));
            }

            return sb.ToString();
        }

        private static string BytesToStr(byte[] buffer)
        {
            return BytesToStr(buffer, buffer != null ? buffer.Length : 0);
        }

        private static byte[] StrToBytes(string data)
        {
            var count = data.Length/2;
            var buffer = new byte[count];

            for (int i = 0; i < count; i++)
            {
                buffer[i] = Convert.ToByte(data.Substring(i*2, 2), 16);
            }

            return buffer;
        }

        private static byte[] RecieveResponse(SerialPort serialPort)
        {
            var data = new List<byte>();
            while (true)
            {
                try
                {
                    var d = serialPort.ReadByte();
                    if (d == -1) break;
                    data.Add((byte)(d & 0xFF));
                }
                catch (TimeoutException)
                {
                    break;                   
                }                
            }

            return data.ToArray();
        }

        private static byte[] ECUHashToSN(byte[] buffer, byte offset)
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
                a = (byte)(a ^ 0x00);
                key[i] = (byte)(a - b);
                b = a;                
            }

            return key;
        }  
    }
}

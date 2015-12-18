using System;
using System.IO;
using System.Windows.Forms;
using EcuCommunication.Protocols;

namespace OpenOLT
{
    class DataLogger: IDisposable
    {
        private FileStream file;
        private StreamWriter writer;
        private byte count;

        public bool Enabled { get; set; }

        public DataLogger()
        {        
            Enabled = true;
        }        

        public void WriteData(DiagData diagData)
        {
            if (!Enabled) return;

            if (file == null)
            {
                InitLogFile();
                writer.WriteLine(diagData.GetLogHeader());
            }

            writer.WriteLine(diagData.GetDataRow());
            count++;
            if (count < 100) return;
            Flush();
        }

        public void Flush()
        {
            if (count == 0 || writer == null) return;
            writer.Flush();
            count = 0;
        }

        private void InitLogFile()
        {            
            var basePath = Application.StartupPath + @"\logs\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var fileName = String.Format("{0}_{1}.csv", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss"));
            var filePath = basePath + fileName;
            file = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            writer = new StreamWriter(file);            
        }

        public void Close()
        {
            if (file == null) return;
            writer.Flush();
            writer.Close();
            writer = null;

            file.Close();
            file = null;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}

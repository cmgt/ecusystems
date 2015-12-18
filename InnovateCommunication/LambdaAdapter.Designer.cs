namespace WidebandLambdaCommunication
{
    partial class LambdaAdapter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            StopCommunication();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.readThread = new System.ComponentModel.BackgroundWorker();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 19200;
            this.serialPort.ReadTimeout = 100;
            // 
            // readThread
            // 
            this.readThread.WorkerSupportsCancellation = true;
            this.readThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.readThread_DoWork);
            this.readThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.readThread_RunWorkerCompleted);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.ComponentModel.BackgroundWorker readThread;
    }
}

namespace KWPTest
{
    partial class KWPTestForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeBar = new System.Windows.Forms.TrackBar();
            this.button4 = new System.Windows.Forms.Button();
            this.btnOpenLCTrace = new System.Windows.Forms.Button();
            this.useTraceCheckBox = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cbxUseDiagLog = new System.Windows.Forms.CheckBox();
            this.btnOpenDiagLog = new System.Windows.Forms.Button();
            this.portNumber = new System.Windows.Forms.ComboBox();
            this.lambdaNormal = new System.Windows.Forms.RadioButton();
            this.o2level = new System.Windows.Forms.RadioButton();
            this.afrValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lc1EmulStart = new System.Windows.Forms.Button();
            this.lc1SerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCmnDiag = new System.Windows.Forms.Button();
            this.echo = new System.Windows.Forms.CheckBox();
            this.openOltDiagOptions = new System.Windows.Forms.Button();
            this.openFirmwareBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ecuSN = new System.Windows.Forms.TextBox();
            this.serialSpeed = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.byteValue = new System.Windows.Forms.TextBox();
            this.byteNumber = new System.Windows.Forms.TextBox();
            this.protocolTrace = new System.Windows.Forms.TextBox();
            this.openFirmware = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ecuEmulStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lc1EmulState = new System.Windows.Forms.ToolStripStatusLabel();
            this.firmwareStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.keyHashLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logFileStatusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.readThread = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 10400;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timeBar);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnOpenLCTrace);
            this.panel1.Controls.Add(this.useTraceCheckBox);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cbxUseDiagLog);
            this.panel1.Controls.Add(this.btnOpenDiagLog);
            this.panel1.Controls.Add(this.portNumber);
            this.panel1.Controls.Add(this.lambdaNormal);
            this.panel1.Controls.Add(this.o2level);
            this.panel1.Controls.Add(this.afrValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lc1EmulStart);
            this.panel1.Controls.Add(this.lc1SerialNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnCmnDiag);
            this.panel1.Controls.Add(this.echo);
            this.panel1.Controls.Add(this.openOltDiagOptions);
            this.panel1.Controls.Add(this.openFirmwareBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ecuSN);
            this.panel1.Controls.Add(this.serialSpeed);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnListen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 129);
            this.panel1.TabIndex = 0;
            // 
            // timeBar
            // 
            this.timeBar.Location = new System.Drawing.Point(0, 84);
            this.timeBar.Name = "timeBar";
            this.timeBar.Size = new System.Drawing.Size(596, 45);
            this.timeBar.TabIndex = 27;
            this.timeBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(407, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "Reverse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnOpenLCTrace
            // 
            this.btnOpenLCTrace.Location = new System.Drawing.Point(5, 59);
            this.btnOpenLCTrace.Name = "btnOpenLCTrace";
            this.btnOpenLCTrace.Size = new System.Drawing.Size(93, 23);
            this.btnOpenLCTrace.TabIndex = 25;
            this.btnOpenLCTrace.Text = "Open LC trace";
            this.btnOpenLCTrace.UseVisualStyleBackColor = true;
            this.btnOpenLCTrace.Click += new System.EventHandler(this.btnOpenLCTrace_Click);
            // 
            // useTraceCheckBox
            // 
            this.useTraceCheckBox.AutoSize = true;
            this.useTraceCheckBox.Location = new System.Drawing.Point(397, 63);
            this.useTraceCheckBox.Name = "useTraceCheckBox";
            this.useTraceCheckBox.Size = new System.Drawing.Size(95, 17);
            this.useTraceCheckBox.TabIndex = 24;
            this.useTraceCheckBox.Text = "Use diag trace";
            this.useTraceCheckBox.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(495, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Open trace";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbxUseDiagLog
            // 
            this.cbxUseDiagLog.AutoSize = true;
            this.cbxUseDiagLog.Location = new System.Drawing.Point(215, 63);
            this.cbxUseDiagLog.Name = "cbxUseDiagLog";
            this.cbxUseDiagLog.Size = new System.Drawing.Size(85, 17);
            this.cbxUseDiagLog.TabIndex = 22;
            this.cbxUseDiagLog.Text = "Use diag log";
            this.cbxUseDiagLog.UseVisualStyleBackColor = true;
            // 
            // btnOpenDiagLog
            // 
            this.btnOpenDiagLog.Location = new System.Drawing.Point(317, 58);
            this.btnOpenDiagLog.Name = "btnOpenDiagLog";
            this.btnOpenDiagLog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDiagLog.TabIndex = 21;
            this.btnOpenDiagLog.Text = "Open log";
            this.btnOpenDiagLog.UseVisualStyleBackColor = true;
            this.btnOpenDiagLog.Click += new System.EventHandler(this.btnOpenDiagLog_Click);
            // 
            // portNumber
            // 
            this.portNumber.FormattingEnabled = true;
            this.portNumber.Location = new System.Drawing.Point(42, 5);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(56, 21);
            this.portNumber.TabIndex = 20;
            this.portNumber.Text = "COM4";
            // 
            // lambdaNormal
            // 
            this.lambdaNormal.AutoSize = true;
            this.lambdaNormal.Checked = true;
            this.lambdaNormal.Location = new System.Drawing.Point(111, 61);
            this.lambdaNormal.Name = "lambdaNormal";
            this.lambdaNormal.Size = new System.Drawing.Size(46, 17);
            this.lambdaNormal.TabIndex = 19;
            this.lambdaNormal.TabStop = true;
            this.lambdaNormal.Text = "AFR";
            this.lambdaNormal.UseVisualStyleBackColor = true;
            this.lambdaNormal.CheckedChanged += new System.EventHandler(this.lambdaNormal_CheckedChanged);
            // 
            // o2level
            // 
            this.o2level.AutoSize = true;
            this.o2level.Location = new System.Drawing.Point(163, 61);
            this.o2level.Name = "o2level";
            this.o2level.Size = new System.Drawing.Size(45, 17);
            this.o2level.TabIndex = 18;
            this.o2level.Text = "O2L";
            this.o2level.UseVisualStyleBackColor = true;
            this.o2level.CheckedChanged += new System.EventHandler(this.lambdaNormal_CheckedChanged);
            // 
            // afrValue
            // 
            this.afrValue.Location = new System.Drawing.Point(160, 35);
            this.afrValue.Name = "afrValue";
            this.afrValue.Size = new System.Drawing.Size(37, 20);
            this.afrValue.TabIndex = 17;
            this.afrValue.Text = "14.7";
            this.afrValue.TextChanged += new System.EventHandler(this.afrValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "AFR:";
            // 
            // lc1EmulStart
            // 
            this.lc1EmulStart.Location = new System.Drawing.Point(215, 32);
            this.lc1EmulStart.Name = "lc1EmulStart";
            this.lc1EmulStart.Size = new System.Drawing.Size(45, 23);
            this.lc1EmulStart.TabIndex = 14;
            this.lc1EmulStart.Tag = "0";
            this.lc1EmulStart.Text = "Start";
            this.lc1EmulStart.UseVisualStyleBackColor = true;
            this.lc1EmulStart.Click += new System.EventHandler(this.lc1EmulStart_Click);
            // 
            // lc1SerialNumber
            // 
            this.lc1SerialNumber.Location = new System.Drawing.Point(67, 36);
            this.lc1SerialNumber.Name = "lc1SerialNumber";
            this.lc1SerialNumber.Size = new System.Drawing.Size(50, 20);
            this.lc1SerialNumber.TabIndex = 13;
            this.lc1SerialNumber.Text = "COM6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "LC-1 COM:";
            // 
            // btnCmnDiag
            // 
            this.btnCmnDiag.Location = new System.Drawing.Point(528, 4);
            this.btnCmnDiag.Name = "btnCmnDiag";
            this.btnCmnDiag.Size = new System.Drawing.Size(44, 23);
            this.btnCmnDiag.TabIndex = 11;
            this.btnCmnDiag.Text = "Diag";
            this.btnCmnDiag.UseVisualStyleBackColor = true;
            this.btnCmnDiag.Click += new System.EventHandler(this.btnCmnDiag_Click);
            // 
            // echo
            // 
            this.echo.AutoSize = true;
            this.echo.Checked = true;
            this.echo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.echo.Location = new System.Drawing.Point(162, 8);
            this.echo.Name = "echo";
            this.echo.Size = new System.Drawing.Size(51, 17);
            this.echo.TabIndex = 10;
            this.echo.Text = "Echo";
            this.echo.UseVisualStyleBackColor = true;
            // 
            // openOltDiagOptions
            // 
            this.openOltDiagOptions.Location = new System.Drawing.Point(469, 4);
            this.openOltDiagOptions.Name = "openOltDiagOptions";
            this.openOltDiagOptions.Size = new System.Drawing.Size(54, 23);
            this.openOltDiagOptions.TabIndex = 9;
            this.openOltDiagOptions.Text = "Olt diag";
            this.openOltDiagOptions.UseVisualStyleBackColor = true;
            this.openOltDiagOptions.Click += new System.EventHandler(this.openOltDiagOptions_Click);
            // 
            // openFirmwareBtn
            // 
            this.openFirmwareBtn.Location = new System.Drawing.Point(317, 4);
            this.openFirmwareBtn.Name = "openFirmwareBtn";
            this.openFirmwareBtn.Size = new System.Drawing.Size(84, 23);
            this.openFirmwareBtn.TabIndex = 8;
            this.openFirmwareBtn.Text = "Open firmware";
            this.openFirmwareBtn.UseVisualStyleBackColor = true;
            this.openFirmwareBtn.Click += new System.EventHandler(this.openFirmwareBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ECU #:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Apply #";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ecuSN
            // 
            this.ecuSN.Location = new System.Drawing.Point(317, 34);
            this.ecuSN.Name = "ecuSN";
            this.ecuSN.Size = new System.Drawing.Size(120, 20);
            this.ecuSN.TabIndex = 4;
            // 
            // serialSpeed
            // 
            this.serialSpeed.FormattingEnabled = true;
            this.serialSpeed.Items.AddRange(new object[] {
            "10400",
            "38400",
            "57600"});
            this.serialSpeed.Location = new System.Drawing.Point(104, 5);
            this.serialSpeed.Name = "serialSpeed";
            this.serialSpeed.Size = new System.Drawing.Size(54, 21);
            this.serialSpeed.TabIndex = 2;
            this.serialSpeed.Text = "10400";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(215, 4);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(45, 23);
            this.btnListen.TabIndex = 1;
            this.btnListen.Tag = "0";
            this.btnListen.Text = "Start";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnSet);
            this.panel2.Controls.Add(this.byteValue);
            this.panel2.Controls.Add(this.byteNumber);
            this.panel2.Location = new System.Drawing.Point(400, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 24);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // btnSet
            // 
            this.btnSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSet.Location = new System.Drawing.Point(101, 0);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 24);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set olt byte";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // byteValue
            // 
            this.byteValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.byteValue.Location = new System.Drawing.Point(48, 0);
            this.byteValue.Name = "byteValue";
            this.byteValue.Size = new System.Drawing.Size(48, 20);
            this.byteValue.TabIndex = 1;
            // 
            // byteNumber
            // 
            this.byteNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.byteNumber.Location = new System.Drawing.Point(0, 0);
            this.byteNumber.Name = "byteNumber";
            this.byteNumber.Size = new System.Drawing.Size(48, 20);
            this.byteNumber.TabIndex = 0;
            // 
            // protocolTrace
            // 
            this.protocolTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolTrace.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protocolTrace.Location = new System.Drawing.Point(0, 129);
            this.protocolTrace.Multiline = true;
            this.protocolTrace.Name = "protocolTrace";
            this.protocolTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.protocolTrace.Size = new System.Drawing.Size(596, 112);
            this.protocolTrace.TabIndex = 1;
            // 
            // openFirmware
            // 
            this.openFirmware.Filter = "firmware|*.bin;*.bir|All files|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.linkStatusLabel,
            this.ecuEmulStatus,
            this.lc1EmulState,
            this.firmwareStatusLabel,
            this.keyHashLabel,
            this.logFileStatusLable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 241);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(596, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 19);
            this.toolStripStatusLabel1.Text = "v. 1.9";
            // 
            // linkStatusLabel
            // 
            this.linkStatusLabel.IsLink = true;
            this.linkStatusLabel.Name = "linkStatusLabel";
            this.linkStatusLabel.Size = new System.Drawing.Size(82, 19);
            this.linkStatusLabel.Text = "ecusystems.ru";
            this.linkStatusLabel.Click += new System.EventHandler(this.linkStatusLabel_Click);
            // 
            // ecuEmulStatus
            // 
            this.ecuEmulStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ecuEmulStatus.Name = "ecuEmulStatus";
            this.ecuEmulStatus.Size = new System.Drawing.Size(113, 19);
            this.ecuEmulStatus.Text = "ecu emulation stop";
            // 
            // lc1EmulState
            // 
            this.lc1EmulState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lc1EmulState.Name = "lc1EmulState";
            this.lc1EmulState.Size = new System.Drawing.Size(114, 19);
            this.lc1EmulState.Text = "lc-1 emulation stop";
            // 
            // firmwareStatusLabel
            // 
            this.firmwareStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.firmwareStatusLabel.Name = "firmwareStatusLabel";
            this.firmwareStatusLabel.Size = new System.Drawing.Size(109, 19);
            this.firmwareStatusLabel.Text = "firmware not open";
            // 
            // keyHashLabel
            // 
            this.keyHashLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.keyHashLabel.Name = "keyHashLabel";
            this.keyHashLabel.Size = new System.Drawing.Size(4, 19);
            // 
            // logFileStatusLable
            // 
            this.logFileStatusLable.Name = "logFileStatusLable";
            this.logFileStatusLable.Size = new System.Drawing.Size(101, 19);
            this.logFileStatusLable.Text = "diag log not open";
            // 
            // readThread
            // 
            this.readThread.WorkerSupportsCancellation = true;
            this.readThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.readThread_DoWork);
            // 
            // KWPTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 265);
            this.Controls.Add(this.protocolTrace);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KWPTestForm";
            this.Text = "KWPTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox protocolTrace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox serialSpeed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ecuSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFirmware;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button openFirmwareBtn;
        private System.Windows.Forms.Button openOltDiagOptions;
        private System.Windows.Forms.CheckBox echo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnCmnDiag;
        private System.Windows.Forms.Button lc1EmulStart;
        private System.Windows.Forms.TextBox lc1SerialNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox afrValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel ecuEmulStatus;
        private System.Windows.Forms.ToolStripStatusLabel lc1EmulState;
        private System.ComponentModel.BackgroundWorker readThread;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox byteValue;
        private System.Windows.Forms.TextBox byteNumber;
        private System.Windows.Forms.ToolStripStatusLabel linkStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel firmwareStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel keyHashLabel;
        private System.Windows.Forms.RadioButton lambdaNormal;
        private System.Windows.Forms.RadioButton o2level;
        private System.Windows.Forms.ComboBox portNumber;
        private System.Windows.Forms.CheckBox cbxUseDiagLog;
        private System.Windows.Forms.Button btnOpenDiagLog;
        private System.Windows.Forms.ToolStripStatusLabel logFileStatusLable;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox useTraceCheckBox;
        private System.Windows.Forms.Button btnOpenLCTrace;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar timeBar;
    }
}


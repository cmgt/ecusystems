namespace KWPTest
{
    partial class DiagLogOpenForm
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
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbInj = new System.Windows.Forms.RadioButton();
            this.rbMatrix = new System.Windows.Forms.RadioButton();
            this.rbICD = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tRTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPM40DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kUOZ1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kUOZ2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kUOZ3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kUOZ4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tWATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tAIRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aFRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aLFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lC1AFRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lC1ALFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uFRXXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOEFFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGTCLEANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGTCRICHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNJDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aIRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCKNOCKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCMAFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCTWATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCTAIRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCTPSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCUBATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDCLAMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fSTOPDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fXXDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fPOWDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fFUELOFFDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fDETZONEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fDETDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fADSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fLAMREGDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fLAMDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fLEARNDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fLAMRDYDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fLAMHEATDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsDiagData = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.openLogFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDiagData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(12, 350);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLog.TabIndex = 0;
            this.btnOpenLog.Text = "Open file ...";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInj);
            this.groupBox1.Controls.Add(this.rbMatrix);
            this.groupBox1.Controls.Add(this.rbICD);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log file type";
            // 
            // rbInj
            // 
            this.rbInj.AutoSize = true;
            this.rbInj.Enabled = false;
            this.rbInj.Location = new System.Drawing.Point(245, 19);
            this.rbInj.Name = "rbInj";
            this.rbInj.Size = new System.Drawing.Size(164, 17);
            this.rbInj.TabIndex = 5;
            this.rbInj.Text = "Injector online [by Andy Frost]";
            this.rbInj.UseVisualStyleBackColor = true;
            // 
            // rbMatrix
            // 
            this.rbMatrix.AutoSize = true;
            this.rbMatrix.Enabled = false;
            this.rbMatrix.Location = new System.Drawing.Point(93, 19);
            this.rbMatrix.Name = "rbMatrix";
            this.rbMatrix.Size = new System.Drawing.Size(117, 17);
            this.rbMatrix.TabIndex = 4;
            this.rbMatrix.Text = "Matrix [by emmibox]";
            this.rbMatrix.UseVisualStyleBackColor = true;
            // 
            // rbICD
            // 
            this.rbICD.AutoSize = true;
            this.rbICD.Checked = true;
            this.rbICD.Location = new System.Drawing.Point(15, 19);
            this.rbICD.Name = "rbICD";
            this.rbICD.Size = new System.Drawing.Size(43, 17);
            this.rbICD.TabIndex = 3;
            this.rbICD.TabStop = true;
            this.rbICD.Text = "ICD";
            this.rbICD.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tRTDataGridViewTextBoxColumn,
            this.rPMDataGridViewTextBoxColumn,
            this.rPM40DataGridViewTextBoxColumn,
            this.uOZDataGridViewTextBoxColumn,
            this.kUOZ1DataGridViewTextBoxColumn,
            this.kUOZ2DataGridViewTextBoxColumn,
            this.kUOZ3DataGridViewTextBoxColumn,
            this.kUOZ4DataGridViewTextBoxColumn,
            this.tWATDataGridViewTextBoxColumn,
            this.tAIRDataGridViewTextBoxColumn,
            this.aFRDataGridViewTextBoxColumn,
            this.aLFDataGridViewTextBoxColumn,
            this.lC1AFRDataGridViewTextBoxColumn,
            this.lC1ALFDataGridViewTextBoxColumn,
            this.uFRXXDataGridViewTextBoxColumn,
            this.sSMDataGridViewTextBoxColumn,
            this.cOEFFDataGridViewTextBoxColumn,
            this.dGTCLEANDataGridViewTextBoxColumn,
            this.dGTCRICHDataGridViewTextBoxColumn,
            this.fazaDataGridViewTextBoxColumn,
            this.iNJDataGridViewTextBoxColumn,
            this.aIRDataGridViewTextBoxColumn,
            this.gBCDataGridViewTextBoxColumn,
            this.sPDDataGridViewTextBoxColumn,
            this.aDCKNOCKDataGridViewTextBoxColumn,
            this.aDCMAFDataGridViewTextBoxColumn,
            this.aDCTWATDataGridViewTextBoxColumn,
            this.aDCTAIRDataGridViewTextBoxColumn,
            this.aDCTPSDataGridViewTextBoxColumn,
            this.aDCUBATDataGridViewTextBoxColumn,
            this.aDCLAMDataGridViewTextBoxColumn,
            this.fSTOPDataGridViewCheckBoxColumn,
            this.fXXDataGridViewCheckBoxColumn,
            this.fPOWDataGridViewCheckBoxColumn,
            this.fFUELOFFDataGridViewCheckBoxColumn,
            this.fDETZONEDataGridViewCheckBoxColumn,
            this.fDETDataGridViewCheckBoxColumn,
            this.fADSDataGridViewCheckBoxColumn,
            this.fLAMREGDataGridViewCheckBoxColumn,
            this.fLAMDataGridViewCheckBoxColumn,
            this.fLEARNDataGridViewCheckBoxColumn,
            this.fLAMRDYDataGridViewCheckBoxColumn,
            this.fLAMHEATDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.bsDiagData;
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1141, 275);
            this.dataGridView1.TabIndex = 2;
            // 
            // tRTDataGridViewTextBoxColumn
            // 
            this.tRTDataGridViewTextBoxColumn.DataPropertyName = "TRT";
            this.tRTDataGridViewTextBoxColumn.HeaderText = "Дроссель";
            this.tRTDataGridViewTextBoxColumn.Name = "tRTDataGridViewTextBoxColumn";
            this.tRTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rPMDataGridViewTextBoxColumn
            // 
            this.rPMDataGridViewTextBoxColumn.DataPropertyName = "RPM";
            this.rPMDataGridViewTextBoxColumn.HeaderText = "Обороты";
            this.rPMDataGridViewTextBoxColumn.Name = "rPMDataGridViewTextBoxColumn";
            this.rPMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rPM40DataGridViewTextBoxColumn
            // 
            this.rPM40DataGridViewTextBoxColumn.DataPropertyName = "RPM40";
            this.rPM40DataGridViewTextBoxColumn.HeaderText = "Обороты_40";
            this.rPM40DataGridViewTextBoxColumn.Name = "rPM40DataGridViewTextBoxColumn";
            this.rPM40DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uOZDataGridViewTextBoxColumn
            // 
            this.uOZDataGridViewTextBoxColumn.DataPropertyName = "UOZ";
            this.uOZDataGridViewTextBoxColumn.HeaderText = "УОЗ";
            this.uOZDataGridViewTextBoxColumn.Name = "uOZDataGridViewTextBoxColumn";
            this.uOZDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kUOZ1DataGridViewTextBoxColumn
            // 
            this.kUOZ1DataGridViewTextBoxColumn.DataPropertyName = "KUOZ1";
            this.kUOZ1DataGridViewTextBoxColumn.HeaderText = "Отскок УОЗ_1 при детонации";
            this.kUOZ1DataGridViewTextBoxColumn.Name = "kUOZ1DataGridViewTextBoxColumn";
            this.kUOZ1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kUOZ2DataGridViewTextBoxColumn
            // 
            this.kUOZ2DataGridViewTextBoxColumn.DataPropertyName = "KUOZ2";
            this.kUOZ2DataGridViewTextBoxColumn.HeaderText = "Отскок УОЗ_2 при детонации";
            this.kUOZ2DataGridViewTextBoxColumn.Name = "kUOZ2DataGridViewTextBoxColumn";
            this.kUOZ2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kUOZ3DataGridViewTextBoxColumn
            // 
            this.kUOZ3DataGridViewTextBoxColumn.DataPropertyName = "KUOZ3";
            this.kUOZ3DataGridViewTextBoxColumn.HeaderText = "Отскок УОЗ_3 при детонации";
            this.kUOZ3DataGridViewTextBoxColumn.Name = "kUOZ3DataGridViewTextBoxColumn";
            this.kUOZ3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kUOZ4DataGridViewTextBoxColumn
            // 
            this.kUOZ4DataGridViewTextBoxColumn.DataPropertyName = "KUOZ4";
            this.kUOZ4DataGridViewTextBoxColumn.HeaderText = "Отскок УОЗ_4 при детонации";
            this.kUOZ4DataGridViewTextBoxColumn.Name = "kUOZ4DataGridViewTextBoxColumn";
            this.kUOZ4DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tWATDataGridViewTextBoxColumn
            // 
            this.tWATDataGridViewTextBoxColumn.DataPropertyName = "TWAT";
            this.tWATDataGridViewTextBoxColumn.HeaderText = "ТОЖ";
            this.tWATDataGridViewTextBoxColumn.Name = "tWATDataGridViewTextBoxColumn";
            this.tWATDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tAIRDataGridViewTextBoxColumn
            // 
            this.tAIRDataGridViewTextBoxColumn.DataPropertyName = "TAIR";
            this.tAIRDataGridViewTextBoxColumn.HeaderText = "Т воздуха";
            this.tAIRDataGridViewTextBoxColumn.Name = "tAIRDataGridViewTextBoxColumn";
            this.tAIRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aFRDataGridViewTextBoxColumn
            // 
            this.aFRDataGridViewTextBoxColumn.DataPropertyName = "AFR";
            this.aFRDataGridViewTextBoxColumn.HeaderText = "Состав смеси (AFR)";
            this.aFRDataGridViewTextBoxColumn.Name = "aFRDataGridViewTextBoxColumn";
            this.aFRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aLFDataGridViewTextBoxColumn
            // 
            this.aLFDataGridViewTextBoxColumn.DataPropertyName = "ALF";
            this.aLFDataGridViewTextBoxColumn.HeaderText = "ALF";
            this.aLFDataGridViewTextBoxColumn.Name = "aLFDataGridViewTextBoxColumn";
            this.aLFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lC1AFRDataGridViewTextBoxColumn
            // 
            this.lC1AFRDataGridViewTextBoxColumn.DataPropertyName = "LC1_AFR";
            this.lC1AFRDataGridViewTextBoxColumn.HeaderText = "Состав смеси (AFR) от ШДК";
            this.lC1AFRDataGridViewTextBoxColumn.Name = "lC1AFRDataGridViewTextBoxColumn";
            this.lC1AFRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lC1ALFDataGridViewTextBoxColumn
            // 
            this.lC1ALFDataGridViewTextBoxColumn.DataPropertyName = "LC1_ALF";
            this.lC1ALFDataGridViewTextBoxColumn.HeaderText = "ALF от ШДК";
            this.lC1ALFDataGridViewTextBoxColumn.Name = "lC1ALFDataGridViewTextBoxColumn";
            this.lC1ALFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uFRXXDataGridViewTextBoxColumn
            // 
            this.uFRXXDataGridViewTextBoxColumn.DataPropertyName = "UFRXX";
            this.uFRXXDataGridViewTextBoxColumn.HeaderText = "Желаемое положение РХХ";
            this.uFRXXDataGridViewTextBoxColumn.Name = "uFRXXDataGridViewTextBoxColumn";
            this.uFRXXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sSMDataGridViewTextBoxColumn
            // 
            this.sSMDataGridViewTextBoxColumn.DataPropertyName = "SSM";
            this.sSMDataGridViewTextBoxColumn.HeaderText = "Текущее положение РХХ";
            this.sSMDataGridViewTextBoxColumn.Name = "sSMDataGridViewTextBoxColumn";
            this.sSMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOEFFDataGridViewTextBoxColumn
            // 
            this.cOEFFDataGridViewTextBoxColumn.DataPropertyName = "COEFF";
            this.cOEFFDataGridViewTextBoxColumn.HeaderText = "Корр. времени впрыска";
            this.cOEFFDataGridViewTextBoxColumn.Name = "cOEFFDataGridViewTextBoxColumn";
            this.cOEFFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dGTCLEANDataGridViewTextBoxColumn
            // 
            this.dGTCLEANDataGridViewTextBoxColumn.DataPropertyName = "DGTC_LEAN";
            this.dGTCLEANDataGridViewTextBoxColumn.HeaderText = "Корр. GTC при обеднении";
            this.dGTCLEANDataGridViewTextBoxColumn.Name = "dGTCLEANDataGridViewTextBoxColumn";
            this.dGTCLEANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dGTCRICHDataGridViewTextBoxColumn
            // 
            this.dGTCRICHDataGridViewTextBoxColumn.DataPropertyName = "DGTC_RICH";
            this.dGTCRICHDataGridViewTextBoxColumn.HeaderText = "Корр. GTC при обогащении";
            this.dGTCRICHDataGridViewTextBoxColumn.Name = "dGTCRICHDataGridViewTextBoxColumn";
            this.dGTCRICHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fazaDataGridViewTextBoxColumn
            // 
            this.fazaDataGridViewTextBoxColumn.DataPropertyName = "Faza";
            this.fazaDataGridViewTextBoxColumn.HeaderText = "Фаза впрыска";
            this.fazaDataGridViewTextBoxColumn.Name = "fazaDataGridViewTextBoxColumn";
            this.fazaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iNJDataGridViewTextBoxColumn
            // 
            this.iNJDataGridViewTextBoxColumn.DataPropertyName = "INJ";
            this.iNJDataGridViewTextBoxColumn.HeaderText = "Время впрыска";
            this.iNJDataGridViewTextBoxColumn.Name = "iNJDataGridViewTextBoxColumn";
            this.iNJDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aIRDataGridViewTextBoxColumn
            // 
            this.aIRDataGridViewTextBoxColumn.DataPropertyName = "AIR";
            this.aIRDataGridViewTextBoxColumn.HeaderText = "Массовый расход воздуха";
            this.aIRDataGridViewTextBoxColumn.Name = "aIRDataGridViewTextBoxColumn";
            this.aIRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gBCDataGridViewTextBoxColumn
            // 
            this.gBCDataGridViewTextBoxColumn.DataPropertyName = "GBC";
            this.gBCDataGridViewTextBoxColumn.HeaderText = "Цикловый расход воздуха";
            this.gBCDataGridViewTextBoxColumn.Name = "gBCDataGridViewTextBoxColumn";
            this.gBCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPDDataGridViewTextBoxColumn
            // 
            this.sPDDataGridViewTextBoxColumn.DataPropertyName = "SPD";
            this.sPDDataGridViewTextBoxColumn.HeaderText = "Скорость";
            this.sPDDataGridViewTextBoxColumn.Name = "sPDDataGridViewTextBoxColumn";
            this.sPDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCKNOCKDataGridViewTextBoxColumn
            // 
            this.aDCKNOCKDataGridViewTextBoxColumn.DataPropertyName = "ADCKNOCK";
            this.aDCKNOCKDataGridViewTextBoxColumn.HeaderText = "АЦП ДД";
            this.aDCKNOCKDataGridViewTextBoxColumn.Name = "aDCKNOCKDataGridViewTextBoxColumn";
            this.aDCKNOCKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCMAFDataGridViewTextBoxColumn
            // 
            this.aDCMAFDataGridViewTextBoxColumn.DataPropertyName = "ADCMAF";
            this.aDCMAFDataGridViewTextBoxColumn.HeaderText = "АЦП ДМРВ";
            this.aDCMAFDataGridViewTextBoxColumn.Name = "aDCMAFDataGridViewTextBoxColumn";
            this.aDCMAFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCTWATDataGridViewTextBoxColumn
            // 
            this.aDCTWATDataGridViewTextBoxColumn.DataPropertyName = "ADCTWAT";
            this.aDCTWATDataGridViewTextBoxColumn.HeaderText = "АЦП ДТОЖ";
            this.aDCTWATDataGridViewTextBoxColumn.Name = "aDCTWATDataGridViewTextBoxColumn";
            this.aDCTWATDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCTAIRDataGridViewTextBoxColumn
            // 
            this.aDCTAIRDataGridViewTextBoxColumn.DataPropertyName = "ADCTAIR";
            this.aDCTAIRDataGridViewTextBoxColumn.HeaderText = "АЦП ДТВ";
            this.aDCTAIRDataGridViewTextBoxColumn.Name = "aDCTAIRDataGridViewTextBoxColumn";
            this.aDCTAIRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCTPSDataGridViewTextBoxColumn
            // 
            this.aDCTPSDataGridViewTextBoxColumn.DataPropertyName = "ADCTPS";
            this.aDCTPSDataGridViewTextBoxColumn.HeaderText = "АЦП ДПДЗ";
            this.aDCTPSDataGridViewTextBoxColumn.Name = "aDCTPSDataGridViewTextBoxColumn";
            this.aDCTPSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCUBATDataGridViewTextBoxColumn
            // 
            this.aDCUBATDataGridViewTextBoxColumn.DataPropertyName = "ADCUBAT";
            this.aDCUBATDataGridViewTextBoxColumn.HeaderText = "АЦП напр. бортсети";
            this.aDCUBATDataGridViewTextBoxColumn.Name = "aDCUBATDataGridViewTextBoxColumn";
            this.aDCUBATDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDCLAMDataGridViewTextBoxColumn
            // 
            this.aDCLAMDataGridViewTextBoxColumn.DataPropertyName = "ADCLAM";
            this.aDCLAMDataGridViewTextBoxColumn.HeaderText = "АЦП ДК";
            this.aDCLAMDataGridViewTextBoxColumn.Name = "aDCLAMDataGridViewTextBoxColumn";
            this.aDCLAMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fSTOPDataGridViewCheckBoxColumn
            // 
            this.fSTOPDataGridViewCheckBoxColumn.DataPropertyName = "fSTOP";
            this.fSTOPDataGridViewCheckBoxColumn.HeaderText = "Флаг остановки двигателя";
            this.fSTOPDataGridViewCheckBoxColumn.Name = "fSTOPDataGridViewCheckBoxColumn";
            this.fSTOPDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fXXDataGridViewCheckBoxColumn
            // 
            this.fXXDataGridViewCheckBoxColumn.DataPropertyName = "fXX";
            this.fXXDataGridViewCheckBoxColumn.HeaderText = "Флаг ХХ";
            this.fXXDataGridViewCheckBoxColumn.Name = "fXXDataGridViewCheckBoxColumn";
            this.fXXDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fPOWDataGridViewCheckBoxColumn
            // 
            this.fPOWDataGridViewCheckBoxColumn.DataPropertyName = "fPOW";
            this.fPOWDataGridViewCheckBoxColumn.HeaderText = "Флаг мощн. обогащения";
            this.fPOWDataGridViewCheckBoxColumn.Name = "fPOWDataGridViewCheckBoxColumn";
            this.fPOWDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fFUELOFFDataGridViewCheckBoxColumn
            // 
            this.fFUELOFFDataGridViewCheckBoxColumn.DataPropertyName = "fFUELOFF";
            this.fFUELOFFDataGridViewCheckBoxColumn.HeaderText = "Флаг отключения топлива";
            this.fFUELOFFDataGridViewCheckBoxColumn.Name = "fFUELOFFDataGridViewCheckBoxColumn";
            this.fFUELOFFDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fDETZONEDataGridViewCheckBoxColumn
            // 
            this.fDETZONEDataGridViewCheckBoxColumn.DataPropertyName = "fDETZONE";
            this.fDETZONEDataGridViewCheckBoxColumn.HeaderText = "Флаг зоны детонации";
            this.fDETZONEDataGridViewCheckBoxColumn.Name = "fDETZONEDataGridViewCheckBoxColumn";
            this.fDETZONEDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fDETDataGridViewCheckBoxColumn
            // 
            this.fDETDataGridViewCheckBoxColumn.DataPropertyName = "fDET";
            this.fDETDataGridViewCheckBoxColumn.HeaderText = "Флаг детонации";
            this.fDETDataGridViewCheckBoxColumn.Name = "fDETDataGridViewCheckBoxColumn";
            this.fDETDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fADSDataGridViewCheckBoxColumn
            // 
            this.fADSDataGridViewCheckBoxColumn.DataPropertyName = "fADS";
            this.fADSDataGridViewCheckBoxColumn.HeaderText = "Флаг продувки адсорбера";
            this.fADSDataGridViewCheckBoxColumn.Name = "fADSDataGridViewCheckBoxColumn";
            this.fADSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fLAMREGDataGridViewCheckBoxColumn
            // 
            this.fLAMREGDataGridViewCheckBoxColumn.DataPropertyName = "fLAMREG";
            this.fLAMREGDataGridViewCheckBoxColumn.HeaderText = "Флаг регулирования по ДК";
            this.fLAMREGDataGridViewCheckBoxColumn.Name = "fLAMREGDataGridViewCheckBoxColumn";
            this.fLAMREGDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fLAMDataGridViewCheckBoxColumn
            // 
            this.fLAMDataGridViewCheckBoxColumn.DataPropertyName = "fLAM";
            this.fLAMDataGridViewCheckBoxColumn.HeaderText = "Флаг текущего сост. по ДК";
            this.fLAMDataGridViewCheckBoxColumn.Name = "fLAMDataGridViewCheckBoxColumn";
            this.fLAMDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fLEARNDataGridViewCheckBoxColumn
            // 
            this.fLEARNDataGridViewCheckBoxColumn.DataPropertyName = "fLEARN";
            this.fLEARNDataGridViewCheckBoxColumn.HeaderText = "Флаг сохранения обучения";
            this.fLEARNDataGridViewCheckBoxColumn.Name = "fLEARNDataGridViewCheckBoxColumn";
            this.fLEARNDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fLAMRDYDataGridViewCheckBoxColumn
            // 
            this.fLAMRDYDataGridViewCheckBoxColumn.DataPropertyName = "fLAMRDY";
            this.fLAMRDYDataGridViewCheckBoxColumn.HeaderText = "Флаг готовность ДК";
            this.fLAMRDYDataGridViewCheckBoxColumn.Name = "fLAMRDYDataGridViewCheckBoxColumn";
            this.fLAMRDYDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fLAMHEATDataGridViewCheckBoxColumn
            // 
            this.fLAMHEATDataGridViewCheckBoxColumn.DataPropertyName = "fLAMHEAT";
            this.fLAMHEATDataGridViewCheckBoxColumn.HeaderText = "Флаг прогрев ДК";
            this.fLAMHEATDataGridViewCheckBoxColumn.Name = "fLAMHEATDataGridViewCheckBoxColumn";
            this.fLAMHEATDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // bsDiagData
            // 
            this.bsDiagData.AllowNew = false;
            this.bsDiagData.DataSource = typeof(EcuCommunication.Protocols.DiagData);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openLogFileDialog
            // 
            this.openLogFileDialog.Filter = "icd|*.txt|matrix; inj_online|*.csv|All files|*.*";
            // 
            // loadProgressBar
            // 
            this.loadProgressBar.Location = new System.Drawing.Point(457, 25);
            this.loadProgressBar.Name = "loadProgressBar";
            this.loadProgressBar.Size = new System.Drawing.Size(696, 23);
            this.loadProgressBar.TabIndex = 4;
            // 
            // DiagLogOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 385);
            this.Controls.Add(this.loadProgressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiagLogOpenForm";
            this.Text = "Diag log open";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDiagData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rbInj;
        private System.Windows.Forms.RadioButton rbMatrix;
        private System.Windows.Forms.RadioButton rbICD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openLogFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPM40DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kUOZ1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kUOZ2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kUOZ3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kUOZ4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tWATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tAIRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aFRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aLFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lC1AFRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lC1ALFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uFRXXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOEFFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGTCLEANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGTCRICHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fazaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNJDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aIRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCKNOCKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCMAFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCTWATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCTAIRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCTPSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCUBATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDCLAMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fSTOPDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fXXDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fPOWDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fFUELOFFDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fDETZONEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fDETDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fADSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fLAMREGDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fLAMDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fLEARNDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fLAMRDYDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fLAMHEATDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource bsDiagData;
        private System.Windows.Forms.ProgressBar loadProgressBar;

    }
}
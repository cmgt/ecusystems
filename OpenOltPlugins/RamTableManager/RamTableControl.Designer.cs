namespace RamTablePlugin
{
    partial class RamTableControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.currentRam = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ramTablesComboBox = new System.Windows.Forms.ComboBox();
            this.ramTablesBS = new System.Windows.Forms.BindingSource(this.components);
            this.rtGrid = new CalibrGui.TableControl();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramTablesBS)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.label3);
            this.controlPanel.Controls.Add(this.btnRestore);
            this.controlPanel.Controls.Add(this.btnReturn);
            this.controlPanel.Controls.Add(this.currentRam);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Controls.Add(this.btnCapture);
            this.controlPanel.Controls.Add(this.label1);
            this.controlPanel.Controls.Add(this.ramTablesComboBox);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(902, 55);
            this.controlPanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(609, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 43);
            this.label3.TabIndex = 9;
            this.label3.Text = "A, W, S, D - перемещение по ячейкам\r\nL, K - увеличение/уменьшение значений\r\nShift" +
    " + L, K - быстрое увеличение/уменьшение\r\n";
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(516, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(87, 23);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Восстановить";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.Location = new System.Drawing.Point(435, 31);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Вернуть";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // currentRam
            // 
            this.currentRam.AutoSize = true;
            this.currentRam.BackColor = System.Drawing.Color.Gold;
            this.currentRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentRam.Location = new System.Drawing.Point(139, 38);
            this.currentRam.Name = "currentRam";
            this.currentRam.Size = new System.Drawing.Size(67, 13);
            this.currentRam.TabIndex = 4;
            this.currentRam.Text = "отсутствует";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Текущая RAM таблица:";
            // 
            // btnCapture
            // 
            this.btnCapture.Enabled = false;
            this.btnCapture.Location = new System.Drawing.Point(435, 4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 2;
            this.btnCapture.Text = "Захватить";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RAM таблицы:";
            // 
            // ramTablesComboBox
            // 
            this.ramTablesComboBox.DataSource = this.ramTablesBS;
            this.ramTablesComboBox.DisplayMember = "Name";
            this.ramTablesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ramTablesComboBox.FormattingEnabled = true;
            this.ramTablesComboBox.Location = new System.Drawing.Point(93, 5);
            this.ramTablesComboBox.Name = "ramTablesComboBox";
            this.ramTablesComboBox.Size = new System.Drawing.Size(336, 21);
            this.ramTablesComboBox.TabIndex = 0;
            // 
            // ramTablesBS
            // 
            this.ramTablesBS.DataSource = typeof(CtpMaps.DataTypes.MapEntry);
            // 
            // rtGrid
            // 
            this.rtGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtGrid.CurrentCol = 0;
            this.rtGrid.CurrentRow = 0;
            this.rtGrid.EnableHeadersVisualStyles = false;
            this.rtGrid.FollowTableRt = true;
            this.rtGrid.HandleValueChanged = true;
            this.rtGrid.HeaderWidth = 60;
            this.rtGrid.Location = new System.Drawing.Point(6, 60);
            this.rtGrid.MinimumSize = new System.Drawing.Size(750, 380);
            this.rtGrid.Name = "rtGrid";
            this.rtGrid.ReadOnly = true;
            this.rtGrid.Size = new System.Drawing.Size(890, 425);
            this.rtGrid.TabIndex = 2;
            this.rtGrid.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.rtGrid_PropertyChanged);
            // 
            // RamTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.rtGrid);
            this.Controls.Add(this.controlPanel);
            this.Enabled = false;
            this.Name = "RamTableControl";
            this.Size = new System.Drawing.Size(902, 490);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramTablesBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ComboBox ramTablesComboBox;
        private System.Windows.Forms.Label currentRam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.BindingSource ramTablesBS;
        private CalibrGui.TableControl rtGrid;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label3;
    }
}

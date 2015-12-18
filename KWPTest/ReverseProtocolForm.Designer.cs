namespace KWPTest
{
    partial class ReverseProtocolForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.requestHeader = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.ByteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerBytesCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.answerHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reverseEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заголовок запроса:";
            // 
            // requestHeader
            // 
            this.requestHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestHeader.Location = new System.Drawing.Point(124, 36);
            this.requestHeader.Name = "requestHeader";
            this.requestHeader.Size = new System.Drawing.Size(236, 20);
            this.requestHeader.TabIndex = 1;
            this.requestHeader.Text = "8210F1210DB1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGrid);
            this.groupBox1.Controls.Add(this.answerBytesCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.answerHeader);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(362, 623);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Параметры ответа: ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(263, 77);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Применить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(263, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "FF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(263, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "00";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ByteColumn});
            this.dataGrid.Location = new System.Drawing.Point(9, 76);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(248, 540);
            this.dataGrid.TabIndex = 6;
            // 
            // ByteColumn
            // 
            this.ByteColumn.HeaderText = "Bytes";
            this.ByteColumn.Name = "ByteColumn";
            // 
            // answerBytesCount
            // 
            this.answerBytesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBytesCount.Location = new System.Drawing.Point(161, 50);
            this.answerBytesCount.Name = "answerBytesCount";
            this.answerBytesCount.Size = new System.Drawing.Size(96, 20);
            this.answerBytesCount.TabIndex = 5;
            this.answerBytesCount.Text = "85";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кол-во байт секции данных:";
            // 
            // answerHeader
            // 
            this.answerHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerHeader.Location = new System.Drawing.Point(112, 21);
            this.answerHeader.Name = "answerHeader";
            this.answerHeader.Size = new System.Drawing.Size(244, 20);
            this.answerHeader.TabIndex = 3;
            this.answerHeader.Text = "80F11057610D";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Заголовок ответа:";
            // 
            // reverseEnabled
            // 
            this.reverseEnabled.AutoSize = true;
            this.reverseEnabled.Location = new System.Drawing.Point(12, 12);
            this.reverseEnabled.Name = "reverseEnabled";
            this.reverseEnabled.Size = new System.Drawing.Size(83, 17);
            this.reverseEnabled.TabIndex = 3;
            this.reverseEnabled.Text = "Применить";
            this.reverseEnabled.UseVisualStyleBackColor = true;
            this.reverseEnabled.CheckedChanged += new System.EventHandler(this.reverseEnabled_CheckedChanged);
            // 
            // ReverseProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 693);
            this.Controls.Add(this.reverseEnabled);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.requestHeader);
            this.Controls.Add(this.label1);
            this.Name = "ReverseProtocolForm";
            this.Text = "ReverseProtocolForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReverseProtocolForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox requestHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox answerHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox answerBytesCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ByteColumn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox reverseEnabled;
        private System.Windows.Forms.Button button4;
    }
}
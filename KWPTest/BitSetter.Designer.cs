namespace KWPTest
{
    partial class BitSetter : IByteSetter
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
            this.bit0 = new System.Windows.Forms.CheckBox();
            this.bit1 = new System.Windows.Forms.CheckBox();
            this.bit2 = new System.Windows.Forms.CheckBox();
            this.bit3 = new System.Windows.Forms.CheckBox();
            this.bit4 = new System.Windows.Forms.CheckBox();
            this.bit5 = new System.Windows.Forms.CheckBox();
            this.bit6 = new System.Windows.Forms.CheckBox();
            this.bit7 = new System.Windows.Forms.CheckBox();
            this.byteDescription = new System.Windows.Forms.Label();
            this.bitPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bit0
            // 
            this.bit0.AutoSize = true;
            this.bit0.Location = new System.Drawing.Point(3, 3);
            this.bit0.Name = "bit0";
            this.bit0.Size = new System.Drawing.Size(14, 14);
            this.bit0.TabIndex = 0;
            this.bit0.UseVisualStyleBackColor = true;
            this.bit0.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit1
            // 
            this.bit1.AutoSize = true;
            this.bit1.Location = new System.Drawing.Point(3, 23);
            this.bit1.Name = "bit1";
            this.bit1.Size = new System.Drawing.Size(14, 14);
            this.bit1.TabIndex = 1;
            this.bit1.UseVisualStyleBackColor = true;
            this.bit1.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit2
            // 
            this.bit2.AutoSize = true;
            this.bit2.Location = new System.Drawing.Point(3, 43);
            this.bit2.Name = "bit2";
            this.bit2.Size = new System.Drawing.Size(14, 14);
            this.bit2.TabIndex = 2;
            this.bit2.UseVisualStyleBackColor = true;
            this.bit2.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit3
            // 
            this.bit3.AutoSize = true;
            this.bit3.Location = new System.Drawing.Point(3, 63);
            this.bit3.Name = "bit3";
            this.bit3.Size = new System.Drawing.Size(14, 14);
            this.bit3.TabIndex = 3;
            this.bit3.UseVisualStyleBackColor = true;
            this.bit3.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit4
            // 
            this.bit4.AutoSize = true;
            this.bit4.Location = new System.Drawing.Point(3, 83);
            this.bit4.Name = "bit4";
            this.bit4.Size = new System.Drawing.Size(14, 14);
            this.bit4.TabIndex = 4;
            this.bit4.UseVisualStyleBackColor = true;
            this.bit4.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit5
            // 
            this.bit5.AutoSize = true;
            this.bit5.Location = new System.Drawing.Point(3, 103);
            this.bit5.Name = "bit5";
            this.bit5.Size = new System.Drawing.Size(14, 14);
            this.bit5.TabIndex = 5;
            this.bit5.UseVisualStyleBackColor = true;
            this.bit5.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit6
            // 
            this.bit6.AutoSize = true;
            this.bit6.Location = new System.Drawing.Point(3, 123);
            this.bit6.Name = "bit6";
            this.bit6.Size = new System.Drawing.Size(14, 14);
            this.bit6.TabIndex = 6;
            this.bit6.UseVisualStyleBackColor = true;
            this.bit6.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // bit7
            // 
            this.bit7.AutoSize = true;
            this.bit7.Location = new System.Drawing.Point(3, 143);
            this.bit7.Name = "bit7";
            this.bit7.Size = new System.Drawing.Size(14, 14);
            this.bit7.TabIndex = 7;
            this.bit7.UseVisualStyleBackColor = true;
            this.bit7.CheckedChanged += new System.EventHandler(this.bits_CheckedChanged);
            // 
            // byteDescription
            // 
            this.byteDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.byteDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.byteDescription.Location = new System.Drawing.Point(0, 0);
            this.byteDescription.Name = "byteDescription";
            this.byteDescription.Size = new System.Drawing.Size(149, 18);
            this.byteDescription.TabIndex = 1;
            this.byteDescription.Text = "Byte description";
            this.byteDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bitPanel
            // 
            this.bitPanel.ColumnCount = 2;
            this.bitPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bitPanel.Controls.Add(this.label8, 1, 7);
            this.bitPanel.Controls.Add(this.label7, 1, 6);
            this.bitPanel.Controls.Add(this.label6, 1, 5);
            this.bitPanel.Controls.Add(this.label5, 1, 4);
            this.bitPanel.Controls.Add(this.label4, 1, 3);
            this.bitPanel.Controls.Add(this.label3, 1, 2);
            this.bitPanel.Controls.Add(this.label2, 1, 1);
            this.bitPanel.Controls.Add(this.label1, 1, 0);
            this.bitPanel.Controls.Add(this.bit0, 0, 0);
            this.bitPanel.Controls.Add(this.bit1, 0, 1);
            this.bitPanel.Controls.Add(this.bit2, 0, 2);
            this.bitPanel.Controls.Add(this.bit3, 0, 3);
            this.bitPanel.Controls.Add(this.bit4, 0, 4);
            this.bitPanel.Controls.Add(this.bit5, 0, 5);
            this.bitPanel.Controls.Add(this.bit6, 0, 6);
            this.bitPanel.Controls.Add(this.bit7, 0, 7);
            this.bitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bitPanel.Location = new System.Drawing.Point(0, 18);
            this.bitPanel.Name = "bitPanel";
            this.bitPanel.RowCount = 8;
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bitPanel.Size = new System.Drawing.Size(149, 161);
            this.bitPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(23, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(23, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(23, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(23, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(23, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(23, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(23, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "label7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(23, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "label8";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BitSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bitPanel);
            this.Controls.Add(this.byteDescription);
            this.Name = "BitSetter";
            this.Size = new System.Drawing.Size(149, 179);
            this.bitPanel.ResumeLayout(false);
            this.bitPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox bit0;
        private System.Windows.Forms.CheckBox bit1;
        private System.Windows.Forms.CheckBox bit2;
        private System.Windows.Forms.CheckBox bit3;
        private System.Windows.Forms.CheckBox bit4;
        private System.Windows.Forms.CheckBox bit5;
        private System.Windows.Forms.CheckBox bit6;
        private System.Windows.Forms.CheckBox bit7;
        private System.Windows.Forms.Label byteDescription;
        private System.Windows.Forms.TableLayoutPanel bitPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

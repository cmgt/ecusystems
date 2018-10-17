namespace OpenOLT.GUI
{
    partial class FirmwareEditPanel
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
            this.firmwareMap = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.firmwareMapOpen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firmwareMap
            // 
            this.firmwareMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firmwareMap.Location = new System.Drawing.Point(3, 39);
            this.firmwareMap.Name = "firmwareMap";
            this.firmwareMap.Size = new System.Drawing.Size(243, 669);
            this.firmwareMap.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.58356F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.41644F));
            this.tableLayoutPanel1.Controls.Add(this.firmwareMap, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.firmwareMapOpen, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.203938F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.79606F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1107, 711);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // firmwareMapOpen
            // 
            this.firmwareMapOpen.Location = new System.Drawing.Point(3, 3);
            this.firmwareMapOpen.Name = "firmwareMapOpen";
            this.firmwareMapOpen.Size = new System.Drawing.Size(78, 30);
            this.firmwareMapOpen.TabIndex = 1;
            this.firmwareMapOpen.Text = "OpenMap";
            this.firmwareMapOpen.UseVisualStyleBackColor = true;
            this.firmwareMapOpen.Click += new System.EventHandler(this.firmwareMapOpen_Click);
            // 
            // FirmwareEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FirmwareEditPanel";
            this.Size = new System.Drawing.Size(1107, 711);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView firmwareMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button firmwareMapOpen;
    }
}

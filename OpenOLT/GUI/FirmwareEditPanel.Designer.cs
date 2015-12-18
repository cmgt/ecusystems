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
            this.SuspendLayout();
            // 
            // firmwareMap
            // 
            this.firmwareMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.firmwareMap.Location = new System.Drawing.Point(0, 0);
            this.firmwareMap.Name = "firmwareMap";
            this.firmwareMap.Size = new System.Drawing.Size(313, 711);
            this.firmwareMap.TabIndex = 0;
            // 
            // FirmwareEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.firmwareMap);
            this.Name = "FirmwareEditPanel";
            this.Size = new System.Drawing.Size(1107, 711);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView firmwareMap;
    }
}

namespace RpmQuantRecalc
{
    partial class MainForm
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
            this.rpmQuantControl2 = new RpmQuantRecalc.RpmQuantControl();
            this.rpmQuantControl1 = new RpmQuantRecalc.RpmQuantControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpmQuantControl2
            // 
            this.rpmQuantControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpmQuantControl2.Location = new System.Drawing.Point(0, 0);
            this.rpmQuantControl2.Name = "rpmQuantControl2";
            this.rpmQuantControl2.Size = new System.Drawing.Size(759, 686);
            this.rpmQuantControl2.TabIndex = 1;
            // 
            // rpmQuantControl1
            // 
            this.rpmQuantControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpmQuantControl1.Location = new System.Drawing.Point(0, 0);
            this.rpmQuantControl1.Name = "rpmQuantControl1";
            this.rpmQuantControl1.Size = new System.Drawing.Size(761, 686);
            this.rpmQuantControl1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rpmQuantControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rpmQuantControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1524, 686);
            this.splitContainer1.SplitterDistance = 761;
            this.splitContainer1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 686);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "RpmQuantRecalc";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RpmQuantControl rpmQuantControl1;
        private RpmQuantControl rpmQuantControl2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}


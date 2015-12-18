namespace IoControlPlugin
{
    partial class IoControl
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
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.captureLed = new Helper.Led();
            this.currentValue = new System.Windows.Forms.TextBox();
            this.currentValueTrack = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.currentValueTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(-1, 4);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description";
            // 
            // captureLed
            // 
            this.captureLed.Active = false;
            this.captureLed.ColorMouseCapture = System.Drawing.Color.LawnGreen;
            this.captureLed.ColorOff = System.Drawing.SystemColors.Control;
            this.captureLed.ColorOn = System.Drawing.Color.LawnGreen;
            this.captureLed.Location = new System.Drawing.Point(2, 20);
            this.captureLed.Name = "captureLed";
            this.captureLed.Size = new System.Drawing.Size(20, 20);
            this.captureLed.TabIndex = 1;
            this.captureLed.Text = "led1";
            this.toolTip1.SetToolTip(this.captureLed, "Захватить/вернуть управление");
            this.captureLed.Click += new System.EventHandler(this.captureLed_Click);
            // 
            // currentValue
            // 
            this.currentValue.Location = new System.Drawing.Point(168, 20);
            this.currentValue.Name = "currentValue";
            this.currentValue.Size = new System.Drawing.Size(42, 20);
            this.currentValue.TabIndex = 2;
            this.currentValue.Text = "0";
            this.currentValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currentValue_KeyPress);
            // 
            // currentValueTrack
            // 
            this.currentValueTrack.Location = new System.Drawing.Point(22, 17);
            this.currentValueTrack.Name = "currentValueTrack";
            this.currentValueTrack.Size = new System.Drawing.Size(146, 45);
            this.currentValueTrack.TabIndex = 3;
            this.currentValueTrack.Scroll += new System.EventHandler(this.currentValueTrack_Scroll);
            // 
            // IoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentValueTrack);
            this.Controls.Add(this.currentValue);
            this.Controls.Add(this.captureLed);
            this.Controls.Add(this.descriptionLabel);
            this.Name = "IoControl";
            this.Size = new System.Drawing.Size(217, 46);
            ((System.ComponentModel.ISupportInitialize)(this.currentValueTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel;
        private Helper.Led captureLed;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox currentValue;
        private System.Windows.Forms.TrackBar currentValueTrack;
    }
}

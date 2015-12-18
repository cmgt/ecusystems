namespace KWPTest
{
    partial class WordSetter
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
            this.byteValue = new System.Windows.Forms.TextBox();
            this.byteDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // byteValue
            // 
            this.byteValue.Location = new System.Drawing.Point(0, 0);
            this.byteValue.Name = "byteValue";
            this.byteValue.Size = new System.Drawing.Size(36, 20);
            this.byteValue.TabIndex = 3;
            this.byteValue.Text = "0000";
            this.byteValue.TextChanged += new System.EventHandler(this.byteValue_TextChanged);
            this.byteValue.DoubleClick += new System.EventHandler(this.ByteSetter_DoubleClick);
            // 
            // byteDescription
            // 
            this.byteDescription.AutoSize = true;
            this.byteDescription.Location = new System.Drawing.Point(42, 3);
            this.byteDescription.Name = "byteDescription";
            this.byteDescription.Size = new System.Drawing.Size(60, 13);
            this.byteDescription.TabIndex = 2;
            this.byteDescription.Text = "Description";
            this.byteDescription.DoubleClick += new System.EventHandler(this.ByteSetter_DoubleClick);
            // 
            // WordSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.byteValue);
            this.Controls.Add(this.byteDescription);
            this.Name = "WordSetter";
            this.Size = new System.Drawing.Size(187, 20);
            this.DoubleClick += new System.EventHandler(this.ByteSetter_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox byteValue;
        private System.Windows.Forms.Label byteDescription;
    }
}

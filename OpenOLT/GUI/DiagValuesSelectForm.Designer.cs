namespace OpenOLT.GUI
{
    partial class DiagValuesSelectForm
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
            this.diagValuesList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // diagValuesList
            // 
            this.diagValuesList.CheckOnClick = true;
            this.diagValuesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagValuesList.FormattingEnabled = true;
            this.diagValuesList.Location = new System.Drawing.Point(0, 0);
            this.diagValuesList.Name = "diagValuesList";
            this.diagValuesList.Size = new System.Drawing.Size(157, 309);
            this.diagValuesList.TabIndex = 0;
            // 
            // DiagValuesSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 309);
            this.Controls.Add(this.diagValuesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiagValuesSelectForm";
            this.Text = "Индикаторы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox diagValuesList;
    }
}
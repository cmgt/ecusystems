namespace OpenOLT.GUI
{
    partial class DiagValuesPanel
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.addBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.valuesPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.addBtn);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(150, 20);
            this.headerPanel.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.Control;
            this.addBtn.BackgroundImage = global::OpenOLT.Properties.Resources.layout_add;
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBtn.Location = new System.Drawing.Point(0, 0);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(18, 18);
            this.addBtn.TabIndex = 0;
            this.toolTip.SetToolTip(this.addBtn, "Добавить/удалить индикатор");
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // valuesPanel
            // 
            this.valuesPanel.AutoScroll = true;
            this.valuesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuesPanel.Location = new System.Drawing.Point(0, 20);
            this.valuesPanel.Name = "valuesPanel";
            this.valuesPanel.Size = new System.Drawing.Size(150, 573);
            this.valuesPanel.TabIndex = 1;
            // 
            // DiagValuesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valuesPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "DiagValuesPanel";
            this.Size = new System.Drawing.Size(150, 593);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel valuesPanel;
        private System.Windows.Forms.Button addBtn;
    }
}

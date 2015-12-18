namespace OpenOLT.GUI
{
    partial class OpenCharts
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
            this.allAvailabeCharts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.delSet = new System.Windows.Forms.Button();
            this.chartSetsComboBox = new System.Windows.Forms.ComboBox();
            this.selectedChars = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // allAvailabeCharts
            // 
            this.allAvailabeCharts.ColumnWidth = 170;
            this.allAvailabeCharts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allAvailabeCharts.FormattingEnabled = true;
            this.allAvailabeCharts.Location = new System.Drawing.Point(0, 216);
            this.allAvailabeCharts.MultiColumn = true;
            this.allAvailabeCharts.Name = "allAvailabeCharts";
            this.allAvailabeCharts.Size = new System.Drawing.Size(709, 173);
            this.allAvailabeCharts.TabIndex = 0;
            this.allAvailabeCharts.DoubleClick += new System.EventHandler(this.allAvailabeCharts_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.delSet);
            this.panel1.Controls.Add(this.chartSetsComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 28);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(436, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpen.Location = new System.Drawing.Point(355, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // delSet
            // 
            this.delSet.Location = new System.Drawing.Point(253, 2);
            this.delSet.Name = "delSet";
            this.delSet.Size = new System.Drawing.Size(96, 23);
            this.delSet.TabIndex = 1;
            this.delSet.Text = "Удалить набор";
            this.delSet.UseVisualStyleBackColor = true;
            this.delSet.Click += new System.EventHandler(this.delSet_Click);
            // 
            // chartSetsComboBox
            // 
            this.chartSetsComboBox.FormattingEnabled = true;
            this.chartSetsComboBox.Location = new System.Drawing.Point(3, 3);
            this.chartSetsComboBox.Name = "chartSetsComboBox";
            this.chartSetsComboBox.Size = new System.Drawing.Size(244, 21);
            this.chartSetsComboBox.TabIndex = 0;
            this.chartSetsComboBox.SelectedIndexChanged += new System.EventHandler(this.chartSetsComboBox_SelectedIndexChanged);
            this.chartSetsComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chartSetsComboBox_KeyDown);
            this.chartSetsComboBox.Leave += new System.EventHandler(this.chartSetsComboBox_Leave);
            // 
            // selectedChars
            // 
            this.selectedChars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedChars.FormattingEnabled = true;
            this.selectedChars.Location = new System.Drawing.Point(0, 28);
            this.selectedChars.Name = "selectedChars";
            this.selectedChars.Size = new System.Drawing.Size(709, 188);
            this.selectedChars.TabIndex = 2;
            this.selectedChars.DoubleClick += new System.EventHandler(this.selectedChars_DoubleClick);
            // 
            // OpenCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 389);
            this.Controls.Add(this.selectedChars);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.allAvailabeCharts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpenCharts";
            this.Text = "Графики";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox allAvailabeCharts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox chartSetsComboBox;
        private System.Windows.Forms.ListBox selectedChars;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button delSet;
        private System.Windows.Forms.Button btnCancel;
    }
}
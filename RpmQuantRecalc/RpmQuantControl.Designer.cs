namespace RpmQuantRecalc
{
    partial class RpmQuantControl
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
            this.quantGrid = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.binOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.firmwareLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.quant16Grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.quant32Grid = new System.Windows.Forms.DataGridView();
            this.ctpMapTree = new CtpMaps.GUI.CtpMapTree();
            this.tableControl1 = new CalibrGui.TableControl();
            ((System.ComponentModel.ISupportInitialize)(this.quantGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quant16Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quant32Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // quantGrid
            // 
            this.quantGrid.AllowUserToAddRows = false;
            this.quantGrid.AllowUserToDeleteRows = false;
            this.quantGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quantGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.quantGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quantGrid.Location = new System.Drawing.Point(3, 50);
            this.quantGrid.Name = "quantGrid";
            this.quantGrid.ReadOnly = true;
            this.quantGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.quantGrid.ShowEditingIcon = false;
            this.quantGrid.Size = new System.Drawing.Size(859, 64);
            this.quantGrid.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // binOpenDialog
            // 
            this.binOpenDialog.Filter = "buffer|*.bin;*.bir|All files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Квантование оборотов";
            // 
            // firmwareLabel
            // 
            this.firmwareLabel.AutoSize = true;
            this.firmwareLabel.Location = new System.Drawing.Point(120, 8);
            this.firmwareLabel.Name = "firmwareLabel";
            this.firmwareLabel.Size = new System.Drawing.Size(0, 13);
            this.firmwareLabel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Квантование оборотов на 16";
            // 
            // quant16Grid
            // 
            this.quant16Grid.AllowUserToAddRows = false;
            this.quant16Grid.AllowUserToDeleteRows = false;
            this.quant16Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quant16Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.quant16Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quant16Grid.Location = new System.Drawing.Point(3, 155);
            this.quant16Grid.Name = "quant16Grid";
            this.quant16Grid.ReadOnly = true;
            this.quant16Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.quant16Grid.ShowEditingIcon = false;
            this.quant16Grid.Size = new System.Drawing.Size(859, 64);
            this.quant16Grid.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Квантование оборотов на 32";
            // 
            // quant32Grid
            // 
            this.quant32Grid.AllowUserToAddRows = false;
            this.quant32Grid.AllowUserToDeleteRows = false;
            this.quant32Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quant32Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.quant32Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quant32Grid.Location = new System.Drawing.Point(3, 257);
            this.quant32Grid.Name = "quant32Grid";
            this.quant32Grid.ReadOnly = true;
            this.quant32Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.quant32Grid.ShowEditingIcon = false;
            this.quant32Grid.Size = new System.Drawing.Size(859, 64);
            this.quant32Grid.TabIndex = 6;
            // 
            // ctpMapTree
            // 
            this.ctpMapTree.Location = new System.Drawing.Point(6, 327);
            this.ctpMapTree.Name = "ctpMapTree";
            this.ctpMapTree.Size = new System.Drawing.Size(365, 354);
            this.ctpMapTree.TabIndex = 8;
            // 
            // tableControl1
            // 
            this.tableControl1.CurrentCol = 0;
            this.tableControl1.CurrentRow = 0;
            this.tableControl1.EnableHeadersVisualStyles = false;
            this.tableControl1.HeaderWidth = 60;
            this.tableControl1.Location = new System.Drawing.Point(377, 327);
            this.tableControl1.Name = "tableControl1";
            this.tableControl1.ReadOnly = true;
            this.tableControl1.Size = new System.Drawing.Size(485, 354);
            this.tableControl1.TabIndex = 9;
            // 
            // RpmQuantControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableControl1);
            this.Controls.Add(this.ctpMapTree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quant32Grid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quant16Grid);
            this.Controls.Add(this.firmwareLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.quantGrid);
            this.Name = "RpmQuantControl";
            this.Size = new System.Drawing.Size(865, 684);
            ((System.ComponentModel.ISupportInitialize)(this.quantGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quant16Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quant32Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView quantGrid;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog binOpenDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label firmwareLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView quant16Grid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView quant32Grid;
        private CtpMaps.GUI.CtpMapTree ctpMapTree;
        private CalibrGui.TableControl tableControl1;
    }
}

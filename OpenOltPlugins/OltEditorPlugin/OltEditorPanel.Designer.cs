namespace OltEditorPlugin
{
    partial class OltEditorPanel
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
            this.ctpMapTree = new CtpMaps.GUI.CtpMapTree();
            this.calibrTable = new CalibrGui.TableControl();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.openMapDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctpMapTree
            // 
            this.ctpMapTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctpMapTree.Location = new System.Drawing.Point(0, 0);
            this.ctpMapTree.Name = "ctpMapTree";
            this.ctpMapTree.Size = new System.Drawing.Size(270, 485);
            this.ctpMapTree.TabIndex = 0;
            // 
            // calibrTable
            // 
            this.calibrTable.CurrentCol = 0;
            this.calibrTable.CurrentRow = 0;
            this.calibrTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrTable.EnableHeadersVisualStyles = false;
            this.calibrTable.HeaderWidth = 60;
            this.calibrTable.Location = new System.Drawing.Point(0, 0);
            this.calibrTable.Name = "calibrTable";
            this.calibrTable.ReadOnly = true;
            this.calibrTable.Size = new System.Drawing.Size(537, 485);
            this.calibrTable.TabIndex = 1;
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.ctpMapTree);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.calibrTable);
            this.mainSplit.Size = new System.Drawing.Size(811, 485);
            this.mainSplit.SplitterDistance = 270;
            this.mainSplit.TabIndex = 2;
            // 
            // openMapDialog
            // 
            this.openMapDialog.Filter = "olt map|*.j7|All files|*.*";
            // 
            // OltEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplit);
            this.Name = "OltEditorPanel";
            this.Size = new System.Drawing.Size(811, 485);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CtpMaps.GUI.CtpMapTree ctpMapTree;
        private CalibrGui.TableControl calibrTable;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.OpenFileDialog openMapDialog;
    }
}

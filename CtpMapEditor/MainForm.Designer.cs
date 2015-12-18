namespace CtpMapEditor
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.btnIda = new System.Windows.Forms.Button();
            this.entryEditor = new System.Windows.Forms.PropertyGrid();
            this.ctpMapTree = new CtpMaps.GUI.CtpMapTree();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuptureListBox = new System.Windows.Forms.ListBox();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.lbFiltredItems = new System.Windows.Forms.ListBox();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.syncronizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.treeContextMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open ctp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Map files|*.j5;*.j7|All files|*.*";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.DataSource = this.bindingSource1;
            this.listBox1.DisplayMember = "Name";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(460, 173);
            this.listBox1.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CtpMaps.DataTypes.MapEntry);
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save ctp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(375, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save olt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Map files|*.j5;*.j7|All files|*.*";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(93, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Check Id";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnIda
            // 
            this.btnIda.Location = new System.Drawing.Point(174, 12);
            this.btnIda.Name = "btnIda";
            this.btnIda.Size = new System.Drawing.Size(95, 23);
            this.btnIda.TabIndex = 5;
            this.btnIda.Text = "Create ida desc";
            this.btnIda.UseVisualStyleBackColor = true;
            this.btnIda.Click += new System.EventHandler(this.btnIda_Click);
            // 
            // entryEditor
            // 
            this.entryEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryEditor.Location = new System.Drawing.Point(478, 41);
            this.entryEditor.Name = "entryEditor";
            this.entryEditor.Size = new System.Drawing.Size(401, 702);
            this.entryEditor.TabIndex = 6;
            // 
            // ctpMapTree
            // 
            this.ctpMapTree.ContextMenuStrip = this.treeContextMenu;
            this.ctpMapTree.Location = new System.Drawing.Point(12, 606);
            this.ctpMapTree.Name = "ctpMapTree";
            this.ctpMapTree.Size = new System.Drawing.Size(460, 140);
            this.ctpMapTree.TabIndex = 7;
            this.ctpMapTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ctpMapTree_AfterSelect);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.saveToFileToolStripMenuItem,
            this.syncronizationToolStripMenuItem});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(153, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Paste";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to file";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "treeContextMenu";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 48);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem3.Text = "Copy";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem4.Text = "Paste";
            // 
            // cuptureListBox
            // 
            this.cuptureListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cuptureListBox.DataSource = this.bindingSource2;
            this.cuptureListBox.DisplayMember = "Name";
            this.cuptureListBox.FormattingEnabled = true;
            this.cuptureListBox.Location = new System.Drawing.Point(12, 222);
            this.cuptureListBox.Name = "cuptureListBox";
            this.cuptureListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cuptureListBox.Size = new System.Drawing.Size(460, 199);
            this.cuptureListBox.TabIndex = 8;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(CtpMaps.DataTypes.MapEntry);
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // lbFiltredItems
            // 
            this.lbFiltredItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFiltredItems.DataSource = this.bindingSource3;
            this.lbFiltredItems.DisplayMember = "Name";
            this.lbFiltredItems.FormattingEnabled = true;
            this.lbFiltredItems.Location = new System.Drawing.Point(12, 427);
            this.lbFiltredItems.Name = "lbFiltredItems";
            this.lbFiltredItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFiltredItems.Size = new System.Drawing.Size(460, 173);
            this.lbFiltredItems.TabIndex = 9;
            // 
            // bindingSource3
            // 
            this.bindingSource3.DataSource = typeof(CtpMaps.DataTypes.MapEntry);
            this.bindingSource3.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // syncronizationToolStripMenuItem
            // 
            this.syncronizationToolStripMenuItem.Name = "syncronizationToolStripMenuItem";
            this.syncronizationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.syncronizationToolStripMenuItem.Text = "Syncronization";
            this.syncronizationToolStripMenuItem.Click += new System.EventHandler(this.syncronizationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 755);
            this.Controls.Add(this.lbFiltredItems);
            this.Controls.Add(this.cuptureListBox);
            this.Controls.Add(this.ctpMapTree);
            this.Controls.Add(this.entryEditor);
            this.Controls.Add(this.btnIda);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Ctp map editor";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.treeContextMenu.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnIda;
        private System.Windows.Forms.PropertyGrid entryEditor;
        private CtpMaps.GUI.CtpMapTree ctpMapTree;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ListBox cuptureListBox;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.ListBox lbFiltredItems;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.ToolStripMenuItem syncronizationToolStripMenuItem;
    }
}


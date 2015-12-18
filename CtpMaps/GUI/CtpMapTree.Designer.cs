namespace CtpMaps.GUI
{
    partial class CtpMapTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtpMapTree));
            this.entriesTree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // entriesTree
            // 
            this.entriesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entriesTree.HideSelection = false;
            this.entriesTree.ImageIndex = 0;
            this.entriesTree.ImageList = this.imageList;
            this.entriesTree.Location = new System.Drawing.Point(0, 0);
            this.entriesTree.Name = "entriesTree";
            this.entriesTree.SelectedImageIndex = 0;
            this.entriesTree.Size = new System.Drawing.Size(223, 752);
            this.entriesTree.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "1.png");
            this.imageList.Images.SetKeyName(1, "2.png");
            this.imageList.Images.SetKeyName(2, "3.png");
            this.imageList.Images.SetKeyName(3, "4.png");
            this.imageList.Images.SetKeyName(4, "5.png");
            this.imageList.Images.SetKeyName(5, "6.png");
            this.imageList.Images.SetKeyName(6, "7.png");
            // 
            // CtpMapTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.entriesTree);
            this.Name = "CtpMapTree";
            this.Size = new System.Drawing.Size(223, 752);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView entriesTree;
        private System.Windows.Forms.ImageList imageList;
    }
}

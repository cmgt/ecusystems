using System.Drawing;

namespace CalibrGui
{
    partial class GraphControl
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
            this.valueGraph = new Gigasoft.ProEssentials.Pesgo();
            this.SuspendLayout();
            // 
            // valueGraph
            // 
            this.valueGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueGraph.Location = new System.Drawing.Point(0, 0);
            this.valueGraph.Name = "valueGraph";
            this.valueGraph.Size = new System.Drawing.Size(300, 122);
            this.valueGraph.TabIndex = 0;
            this.valueGraph.Text = "Value graph";
            // 
            // GraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.valueGraph);
            this.MinimumSize = new System.Drawing.Size(300, 120);
            this.Name = "GraphControl";
            this.Size = new System.Drawing.Size(300, 122);
            this.ResumeLayout(false);

        }

        #endregion

        private Gigasoft.ProEssentials.Pesgo valueGraph;
    }
}

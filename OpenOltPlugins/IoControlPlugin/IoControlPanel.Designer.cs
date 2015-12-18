namespace IoControlPlugin
{
    partial class IoControlPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.ioControl8 = new IoControlPlugin.IoControl();
            this.ioControl7 = new IoControlPlugin.IoControl();
            this.ioControl6 = new IoControlPlugin.IoControl();
            this.ioControl5 = new IoControlPlugin.IoControl();
            this.ioControl4 = new IoControlPlugin.IoControl();
            this.ioControl3 = new IoControlPlugin.IoControl();
            this.ioControl2 = new IoControlPlugin.IoControl();
            this.ioControl1 = new IoControlPlugin.IoControl();
            this.btnRestoreAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Захват управления выполняется щелчком мыши по индикатору активности";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ioControl8
            // 
            this.ioControl8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl8.Description = "Температура ОЖ";
            this.ioControl8.Location = new System.Drawing.Point(2, 446);
            this.ioControl8.Max = 195F;
            this.ioControl8.Min = -60F;
            this.ioControl8.Name = "ioControl8";
            this.ioControl8.Size = new System.Drawing.Size(214, 46);
            this.ioControl8.TabIndex = 8;
            this.ioControl8.Tag = "Twat";
            this.ioControl8.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl8.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl7
            // 
            this.ioControl7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl7.Description = "Коэфф. коррекции времени впрыска";
            this.ioControl7.FloatPoint = true;
            this.ioControl7.Location = new System.Drawing.Point(2, 394);
            this.ioControl7.Max = 1.496F;
            this.ioControl7.Min = 0.5F;
            this.ioControl7.Name = "ioControl7";
            this.ioControl7.Size = new System.Drawing.Size(214, 46);
            this.ioControl7.TabIndex = 7;
            this.ioControl7.Tag = "InjCoeff";
            this.ioControl7.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl7.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl6
            // 
            this.ioControl6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl6.Description = "Фаза впрыска";
            this.ioControl6.Location = new System.Drawing.Point(2, 342);
            this.ioControl6.Max = 720F;
            this.ioControl6.Min = -720F;
            this.ioControl6.Name = "ioControl6";
            this.ioControl6.Size = new System.Drawing.Size(214, 46);
            this.ioControl6.TabIndex = 6;
            this.ioControl6.Tag = "Faza";
            this.ioControl6.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl6.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl5
            // 
            this.ioControl5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl5.Description = "Октан корректор УОЗ";
            this.ioControl5.Location = new System.Drawing.Point(2, 290);
            this.ioControl5.Min = -10F;
            this.ioControl5.Name = "ioControl5";
            this.ioControl5.Size = new System.Drawing.Size(214, 46);
            this.ioControl5.TabIndex = 5;
            this.ioControl5.Tag = "Duoz";
            this.ioControl5.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl5.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl4
            // 
            this.ioControl4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl4.Description = "УОЗ";
            this.ioControl4.FloatPoint = true;
            this.ioControl4.Location = new System.Drawing.Point(2, 238);
            this.ioControl4.Max = 55F;
            this.ioControl4.Min = -15F;
            this.ioControl4.Name = "ioControl4";
            this.ioControl4.Size = new System.Drawing.Size(214, 46);
            this.ioControl4.TabIndex = 4;
            this.ioControl4.Tag = "Uoz";
            this.ioControl4.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl4.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl3
            // 
            this.ioControl3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl3.Description = "Состав смеси (AFR)";
            this.ioControl3.FloatPoint = true;
            this.ioControl3.Location = new System.Drawing.Point(2, 186);
            this.ioControl3.Max = 21.99F;
            this.ioControl3.Min = 7.35F;
            this.ioControl3.Name = "ioControl3";
            this.ioControl3.Size = new System.Drawing.Size(214, 46);
            this.ioControl3.TabIndex = 3;
            this.ioControl3.Tag = "Alf";
            this.ioControl3.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl3.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl2
            // 
            this.ioControl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl2.Description = "Обороты ХХ";
            this.ioControl2.Location = new System.Drawing.Point(2, 134);
            this.ioControl2.Max = 2550F;
            this.ioControl2.Name = "ioControl2";
            this.ioControl2.Size = new System.Drawing.Size(214, 46);
            this.ioControl2.TabIndex = 1;
            this.ioControl2.Tag = "XxRpm";
            this.ioControl2.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl2.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // ioControl1
            // 
            this.ioControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ioControl1.Description = "Положение РХХ";
            this.ioControl1.Location = new System.Drawing.Point(2, 82);
            this.ioControl1.Max = 150F;
            this.ioControl1.Name = "ioControl1";
            this.ioControl1.Size = new System.Drawing.Size(214, 46);
            this.ioControl1.TabIndex = 0;
            this.ioControl1.Tag = "RxxStep";
            this.ioControl1.ActiveChanging += new System.EventHandler(this.ioControl1_ActiveChanging);
            this.ioControl1.CurrentValueChange += new System.EventHandler(this.ioControl1_CurrentValueChange);
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.Location = new System.Drawing.Point(6, 53);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(135, 23);
            this.btnRestoreAll.TabIndex = 9;
            this.btnRestoreAll.Text = "Вернуть управление";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.btnRestoreAll_Click);
            // 
            // IoControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRestoreAll);
            this.Controls.Add(this.ioControl8);
            this.Controls.Add(this.ioControl7);
            this.Controls.Add(this.ioControl6);
            this.Controls.Add(this.ioControl5);
            this.Controls.Add(this.ioControl4);
            this.Controls.Add(this.ioControl3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ioControl2);
            this.Controls.Add(this.ioControl1);
            this.Enabled = false;
            this.Name = "IoControlPanel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(219, 838);
            this.ResumeLayout(false);

        }

        #endregion

        private IoControl ioControl1;
        private IoControl ioControl2;
        private System.Windows.Forms.Label label1;
        private IoControl ioControl3;
        private IoControl ioControl4;
        private IoControl ioControl5;
        private IoControl ioControl6;
        private IoControl ioControl7;
        private IoControl ioControl8;
        private System.Windows.Forms.Button btnRestoreAll;
    }
}

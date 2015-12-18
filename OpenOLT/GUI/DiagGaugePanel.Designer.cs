namespace OpenOLT.GUI
{
    partial class DiagGaugePanel
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
            this.thrTextBox = new System.Windows.Forms.TextBox();
            this.rpmTextBox = new System.Windows.Forms.TextBox();
            this.tempTextBox = new System.Windows.Forms.TextBox();
            this.tempGauge = new AGauge.AGauge();
            this.rpmGauge = new AGauge.AGauge();
            this.thrGauge = new AGauge.AGauge();
            this.afrGauge = new AGauge.AGauge();
            this.lc1AfrGauge = new AGauge.AGauge();
            this.afrTextBox = new System.Windows.Forms.TextBox();
            this.lc1AfrTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // thrTextBox
            // 
            this.thrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thrTextBox.Location = new System.Drawing.Point(75, 117);
            this.thrTextBox.Name = "thrTextBox";
            this.thrTextBox.ReadOnly = true;
            this.thrTextBox.Size = new System.Drawing.Size(40, 20);
            this.thrTextBox.TabIndex = 2;
            this.thrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rpmTextBox
            // 
            this.rpmTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rpmTextBox.Location = new System.Drawing.Point(75, 275);
            this.rpmTextBox.Name = "rpmTextBox";
            this.rpmTextBox.ReadOnly = true;
            this.rpmTextBox.Size = new System.Drawing.Size(40, 20);
            this.rpmTextBox.TabIndex = 4;
            this.rpmTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tempTextBox
            // 
            this.tempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempTextBox.Location = new System.Drawing.Point(75, 435);
            this.tempTextBox.Name = "tempTextBox";
            this.tempTextBox.ReadOnly = true;
            this.tempTextBox.Size = new System.Drawing.Size(40, 20);
            this.tempTextBox.TabIndex = 6;
            this.tempTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tempGauge
            // 
            this.tempGauge.BaseArcColor = System.Drawing.Color.LightSlateGray;
            this.tempGauge.BaseArcRadius = 60;
            this.tempGauge.BaseArcStart = 135;
            this.tempGauge.BaseArcSweep = 270;
            this.tempGauge.BaseArcWidth = 1;
            this.tempGauge.Cap_Idx = ((byte)(0));
            this.tempGauge.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.tempGauge.CapPosition = new System.Drawing.Point(65, 135);
            this.tempGauge.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(65, 135),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.tempGauge.CapsText = new string[] {
        "ТОЖ, град",
        "",
        "",
        "",
        ""};
            this.tempGauge.CapText = "ТОЖ, град";
            this.tempGauge.Center = new System.Drawing.Point(90, 80);
            this.tempGauge.Location = new System.Drawing.Point(4, 325);
            this.tempGauge.MaxValue = 110F;
            this.tempGauge.MinValue = -30F;
            this.tempGauge.Name = "tempGauge";
            this.tempGauge.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.tempGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.tempGauge.NeedleRadius = 60;
            this.tempGauge.NeedleType = 0;
            this.tempGauge.NeedleWidth = 2;
            this.tempGauge.Range_Idx = ((byte)(2));
            this.tempGauge.RangeColor = System.Drawing.Color.Red;
            this.tempGauge.RangeEnabled = true;
            this.tempGauge.RangeEndValue = 110F;
            this.tempGauge.RangeInnerRadius = 40;
            this.tempGauge.RangeOuterRadius = 55;
            this.tempGauge.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.tempGauge.RangesEnabled = new bool[] {
        true,
        true,
        true,
        false,
        false};
            this.tempGauge.RangesEndValue = new float[] {
        90F,
        95F,
        110F,
        0F,
        0F};
            this.tempGauge.RangesInnerRadius = new int[] {
        40,
        40,
        40,
        70,
        70};
            this.tempGauge.RangesOuterRadius = new int[] {
        55,
        55,
        55,
        80,
        80};
            this.tempGauge.RangesStartValue = new float[] {
        -30F,
        85F,
        95F,
        0F,
        0F};
            this.tempGauge.RangeStartValue = 95F;
            this.tempGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.tempGauge.ScaleLinesInterInnerRadius = 56;
            this.tempGauge.ScaleLinesInterOuterRadius = 60;
            this.tempGauge.ScaleLinesInterWidth = 1;
            this.tempGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.tempGauge.ScaleLinesMajorInnerRadius = 50;
            this.tempGauge.ScaleLinesMajorOuterRadius = 60;
            this.tempGauge.ScaleLinesMajorStepValue = 10F;
            this.tempGauge.ScaleLinesMajorWidth = 2;
            this.tempGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.tempGauge.ScaleLinesMinorInnerRadius = 56;
            this.tempGauge.ScaleLinesMinorNumOf = 9;
            this.tempGauge.ScaleLinesMinorOuterRadius = 60;
            this.tempGauge.ScaleLinesMinorWidth = 1;
            this.tempGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.tempGauge.ScaleNumbersFormat = null;
            this.tempGauge.ScaleNumbersRadius = 75;
            this.tempGauge.ScaleNumbersRotation = 0;
            this.tempGauge.ScaleNumbersStartScaleLine = 0;
            this.tempGauge.ScaleNumbersStepScaleLines = 1;
            this.tempGauge.Size = new System.Drawing.Size(180, 155);
            this.tempGauge.TabIndex = 5;
            this.tempGauge.Text = "ТОЖ";
            this.tempGauge.Value = 0F;
            // 
            // rpmGauge
            // 
            this.rpmGauge.BaseArcColor = System.Drawing.Color.LightSlateGray;
            this.rpmGauge.BaseArcRadius = 60;
            this.rpmGauge.BaseArcStart = 135;
            this.rpmGauge.BaseArcSweep = 270;
            this.rpmGauge.BaseArcWidth = 1;
            this.rpmGauge.Cap_Idx = ((byte)(0));
            this.rpmGauge.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.rpmGauge.CapPosition = new System.Drawing.Point(65, 135);
            this.rpmGauge.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(65, 135),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.rpmGauge.CapsText = new string[] {
        "RPM x100",
        "",
        "",
        "",
        ""};
            this.rpmGauge.CapText = "RPM x100";
            this.rpmGauge.Center = new System.Drawing.Point(90, 80);
            this.rpmGauge.Location = new System.Drawing.Point(4, 164);
            this.rpmGauge.MaxValue = 90F;
            this.rpmGauge.MinValue = 0F;
            this.rpmGauge.Name = "rpmGauge";
            this.rpmGauge.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.rpmGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.rpmGauge.NeedleRadius = 60;
            this.rpmGauge.NeedleType = 0;
            this.rpmGauge.NeedleWidth = 2;
            this.rpmGauge.Range_Idx = ((byte)(2));
            this.rpmGauge.RangeColor = System.Drawing.Color.Red;
            this.rpmGauge.RangeEnabled = true;
            this.rpmGauge.RangeEndValue = 90F;
            this.rpmGauge.RangeInnerRadius = 40;
            this.rpmGauge.RangeOuterRadius = 55;
            this.rpmGauge.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.rpmGauge.RangesEnabled = new bool[] {
        true,
        true,
        true,
        false,
        false};
            this.rpmGauge.RangesEndValue = new float[] {
        60F,
        70F,
        90F,
        0F,
        0F};
            this.rpmGauge.RangesInnerRadius = new int[] {
        40,
        40,
        40,
        70,
        70};
            this.rpmGauge.RangesOuterRadius = new int[] {
        55,
        55,
        55,
        80,
        80};
            this.rpmGauge.RangesStartValue = new float[] {
        0F,
        60F,
        70F,
        0F,
        0F};
            this.rpmGauge.RangeStartValue = 70F;
            this.rpmGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.rpmGauge.ScaleLinesInterInnerRadius = 56;
            this.rpmGauge.ScaleLinesInterOuterRadius = 60;
            this.rpmGauge.ScaleLinesInterWidth = 1;
            this.rpmGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.rpmGauge.ScaleLinesMajorInnerRadius = 50;
            this.rpmGauge.ScaleLinesMajorOuterRadius = 60;
            this.rpmGauge.ScaleLinesMajorStepValue = 10F;
            this.rpmGauge.ScaleLinesMajorWidth = 2;
            this.rpmGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.rpmGauge.ScaleLinesMinorInnerRadius = 56;
            this.rpmGauge.ScaleLinesMinorNumOf = 9;
            this.rpmGauge.ScaleLinesMinorOuterRadius = 60;
            this.rpmGauge.ScaleLinesMinorWidth = 1;
            this.rpmGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.rpmGauge.ScaleNumbersFormat = null;
            this.rpmGauge.ScaleNumbersRadius = 75;
            this.rpmGauge.ScaleNumbersRotation = 0;
            this.rpmGauge.ScaleNumbersStartScaleLine = 0;
            this.rpmGauge.ScaleNumbersStepScaleLines = 1;
            this.rpmGauge.Size = new System.Drawing.Size(180, 155);
            this.rpmGauge.TabIndex = 3;
            this.rpmGauge.Text = "Обороты двигателя";
            this.rpmGauge.Value = 0F;
            // 
            // thrGauge
            // 
            this.thrGauge.BaseArcColor = System.Drawing.Color.LightSlateGray;
            this.thrGauge.BaseArcRadius = 60;
            this.thrGauge.BaseArcStart = 135;
            this.thrGauge.BaseArcSweep = 270;
            this.thrGauge.BaseArcWidth = 1;
            this.thrGauge.Cap_Idx = ((byte)(0));
            this.thrGauge.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.thrGauge.CapPosition = new System.Drawing.Point(60, 135);
            this.thrGauge.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(60, 135),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.thrGauge.CapsText = new string[] {
        "Дроссель, %",
        "",
        "",
        "",
        ""};
            this.thrGauge.CapText = "Дроссель, %";
            this.thrGauge.Center = new System.Drawing.Point(90, 80);
            this.thrGauge.Location = new System.Drawing.Point(4, 3);
            this.thrGauge.MaxValue = 100F;
            this.thrGauge.MinValue = 0F;
            this.thrGauge.Name = "thrGauge";
            this.thrGauge.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.thrGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.thrGauge.NeedleRadius = 60;
            this.thrGauge.NeedleType = 0;
            this.thrGauge.NeedleWidth = 2;
            this.thrGauge.Range_Idx = ((byte)(0));
            this.thrGauge.RangeColor = System.Drawing.Color.LightGreen;
            this.thrGauge.RangeEnabled = true;
            this.thrGauge.RangeEndValue = 85F;
            this.thrGauge.RangeInnerRadius = 50;
            this.thrGauge.RangeOuterRadius = 55;
            this.thrGauge.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.thrGauge.RangesEnabled = new bool[] {
        true,
        true,
        false,
        false,
        false};
            this.thrGauge.RangesEndValue = new float[] {
        85F,
        100F,
        0F,
        0F,
        0F};
            this.thrGauge.RangesInnerRadius = new int[] {
        50,
        1,
        70,
        70,
        70};
            this.thrGauge.RangesOuterRadius = new int[] {
        55,
        55,
        80,
        80,
        80};
            this.thrGauge.RangesStartValue = new float[] {
        0F,
        85F,
        0F,
        0F,
        0F};
            this.thrGauge.RangeStartValue = 0F;
            this.thrGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.thrGauge.ScaleLinesInterInnerRadius = 56;
            this.thrGauge.ScaleLinesInterOuterRadius = 60;
            this.thrGauge.ScaleLinesInterWidth = 1;
            this.thrGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.thrGauge.ScaleLinesMajorInnerRadius = 50;
            this.thrGauge.ScaleLinesMajorOuterRadius = 60;
            this.thrGauge.ScaleLinesMajorStepValue = 10F;
            this.thrGauge.ScaleLinesMajorWidth = 2;
            this.thrGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.thrGauge.ScaleLinesMinorInnerRadius = 56;
            this.thrGauge.ScaleLinesMinorNumOf = 9;
            this.thrGauge.ScaleLinesMinorOuterRadius = 60;
            this.thrGauge.ScaleLinesMinorWidth = 1;
            this.thrGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.thrGauge.ScaleNumbersFormat = null;
            this.thrGauge.ScaleNumbersRadius = 75;
            this.thrGauge.ScaleNumbersRotation = 0;
            this.thrGauge.ScaleNumbersStartScaleLine = 0;
            this.thrGauge.ScaleNumbersStepScaleLines = 1;
            this.thrGauge.Size = new System.Drawing.Size(180, 155);
            this.thrGauge.TabIndex = 1;
            this.thrGauge.Text = "Положение дросселя, %";
            this.thrGauge.Value = 0F;
            // 
            // afrGauge
            // 
            this.afrGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.afrGauge.BaseArcRadius = 500;
            this.afrGauge.BaseArcStart = 180;
            this.afrGauge.BaseArcSweep = 90;
            this.afrGauge.BaseArcWidth = 0;
            this.afrGauge.Cap_Idx = ((byte)(0));
            this.afrGauge.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.afrGauge.CapPosition = new System.Drawing.Point(5, 90);
            this.afrGauge.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(5, 90),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.afrGauge.CapsText = new string[] {
        "AFR",
        "",
        "",
        "",
        ""};
            this.afrGauge.CapText = "AFR";
            this.afrGauge.Center = new System.Drawing.Point(70, 70);
            this.afrGauge.Font = new System.Drawing.Font("Arial", 9F);
            this.afrGauge.Location = new System.Drawing.Point(4, 486);
            this.afrGauge.MaxValue = 22F;
            this.afrGauge.MinValue = 7F;
            this.afrGauge.Name = "afrGauge";
            this.afrGauge.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.afrGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.afrGauge.NeedleRadius = 48;
            this.afrGauge.NeedleType = 1;
            this.afrGauge.NeedleWidth = 3;
            this.afrGauge.Range_Idx = ((byte)(0));
            this.afrGauge.RangeColor = System.Drawing.Color.LightGreen;
            this.afrGauge.RangeEnabled = false;
            this.afrGauge.RangeEndValue = 300F;
            this.afrGauge.RangeInnerRadius = 70;
            this.afrGauge.RangeOuterRadius = 80;
            this.afrGauge.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.afrGauge.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.afrGauge.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.afrGauge.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.afrGauge.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.afrGauge.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.afrGauge.RangeStartValue = -100F;
            this.afrGauge.ScaleLinesInterColor = System.Drawing.Color.RosyBrown;
            this.afrGauge.ScaleLinesInterInnerRadius = 42;
            this.afrGauge.ScaleLinesInterOuterRadius = 55;
            this.afrGauge.ScaleLinesInterWidth = 1;
            this.afrGauge.ScaleLinesMajorColor = System.Drawing.Color.Gray;
            this.afrGauge.ScaleLinesMajorInnerRadius = 40;
            this.afrGauge.ScaleLinesMajorOuterRadius = 55;
            this.afrGauge.ScaleLinesMajorStepValue = 7F;
            this.afrGauge.ScaleLinesMajorWidth = 2;
            this.afrGauge.ScaleLinesMinorColor = System.Drawing.Color.DarkSalmon;
            this.afrGauge.ScaleLinesMinorInnerRadius = 43;
            this.afrGauge.ScaleLinesMinorNumOf = 5;
            this.afrGauge.ScaleLinesMinorOuterRadius = 50;
            this.afrGauge.ScaleLinesMinorWidth = 1;
            this.afrGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.afrGauge.ScaleNumbersFormat = null;
            this.afrGauge.ScaleNumbersRadius = 62;
            this.afrGauge.ScaleNumbersRotation = 90;
            this.afrGauge.ScaleNumbersStartScaleLine = 1;
            this.afrGauge.ScaleNumbersStepScaleLines = 2;
            this.afrGauge.Size = new System.Drawing.Size(84, 107);
            this.afrGauge.TabIndex = 13;
            this.afrGauge.Text = "aGauge6";
            this.afrGauge.Value = 14.7F;
            // 
            // lc1AfrGauge
            // 
            this.lc1AfrGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.lc1AfrGauge.BaseArcRadius = 500;
            this.lc1AfrGauge.BaseArcStart = 180;
            this.lc1AfrGauge.BaseArcSweep = 90;
            this.lc1AfrGauge.BaseArcWidth = 0;
            this.lc1AfrGauge.Cap_Idx = ((byte)(0));
            this.lc1AfrGauge.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.lc1AfrGauge.CapPosition = new System.Drawing.Point(0, 90);
            this.lc1AfrGauge.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(0, 90),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.lc1AfrGauge.CapsText = new string[] {
        "LC-1 AFR",
        "",
        "",
        "",
        ""};
            this.lc1AfrGauge.CapText = "LC-1 AFR";
            this.lc1AfrGauge.Center = new System.Drawing.Point(70, 70);
            this.lc1AfrGauge.Font = new System.Drawing.Font("Arial", 9F);
            this.lc1AfrGauge.Location = new System.Drawing.Point(94, 486);
            this.lc1AfrGauge.MaxValue = 22F;
            this.lc1AfrGauge.MinValue = 7F;
            this.lc1AfrGauge.Name = "lc1AfrGauge";
            this.lc1AfrGauge.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.lc1AfrGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.lc1AfrGauge.NeedleRadius = 48;
            this.lc1AfrGauge.NeedleType = 1;
            this.lc1AfrGauge.NeedleWidth = 3;
            this.lc1AfrGauge.Range_Idx = ((byte)(0));
            this.lc1AfrGauge.RangeColor = System.Drawing.Color.LightGreen;
            this.lc1AfrGauge.RangeEnabled = false;
            this.lc1AfrGauge.RangeEndValue = 300F;
            this.lc1AfrGauge.RangeInnerRadius = 70;
            this.lc1AfrGauge.RangeOuterRadius = 80;
            this.lc1AfrGauge.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.lc1AfrGauge.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.lc1AfrGauge.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.lc1AfrGauge.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.lc1AfrGauge.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.lc1AfrGauge.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.lc1AfrGauge.RangeStartValue = -100F;
            this.lc1AfrGauge.ScaleLinesInterColor = System.Drawing.Color.RosyBrown;
            this.lc1AfrGauge.ScaleLinesInterInnerRadius = 42;
            this.lc1AfrGauge.ScaleLinesInterOuterRadius = 55;
            this.lc1AfrGauge.ScaleLinesInterWidth = 1;
            this.lc1AfrGauge.ScaleLinesMajorColor = System.Drawing.Color.Gray;
            this.lc1AfrGauge.ScaleLinesMajorInnerRadius = 40;
            this.lc1AfrGauge.ScaleLinesMajorOuterRadius = 55;
            this.lc1AfrGauge.ScaleLinesMajorStepValue = 7F;
            this.lc1AfrGauge.ScaleLinesMajorWidth = 2;
            this.lc1AfrGauge.ScaleLinesMinorColor = System.Drawing.Color.DarkSalmon;
            this.lc1AfrGauge.ScaleLinesMinorInnerRadius = 43;
            this.lc1AfrGauge.ScaleLinesMinorNumOf = 5;
            this.lc1AfrGauge.ScaleLinesMinorOuterRadius = 50;
            this.lc1AfrGauge.ScaleLinesMinorWidth = 1;
            this.lc1AfrGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.lc1AfrGauge.ScaleNumbersFormat = null;
            this.lc1AfrGauge.ScaleNumbersRadius = 62;
            this.lc1AfrGauge.ScaleNumbersRotation = 90;
            this.lc1AfrGauge.ScaleNumbersStartScaleLine = 1;
            this.lc1AfrGauge.ScaleNumbersStepScaleLines = 2;
            this.lc1AfrGauge.Size = new System.Drawing.Size(84, 107);
            this.lc1AfrGauge.TabIndex = 14;
            this.lc1AfrGauge.Text = "aGauge1";
            this.lc1AfrGauge.Value = 14.7F;
            // 
            // afrTextBox
            // 
            this.afrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.afrTextBox.Location = new System.Drawing.Point(38, 573);
            this.afrTextBox.Name = "afrTextBox";
            this.afrTextBox.ReadOnly = true;
            this.afrTextBox.Size = new System.Drawing.Size(35, 20);
            this.afrTextBox.TabIndex = 15;
            this.afrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lc1AfrTextBox
            // 
            this.lc1AfrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lc1AfrTextBox.Location = new System.Drawing.Point(152, 573);
            this.lc1AfrTextBox.Name = "lc1AfrTextBox";
            this.lc1AfrTextBox.ReadOnly = true;
            this.lc1AfrTextBox.Size = new System.Drawing.Size(35, 20);
            this.lc1AfrTextBox.TabIndex = 16;
            this.lc1AfrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DiagGaugePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lc1AfrTextBox);
            this.Controls.Add(this.afrTextBox);
            this.Controls.Add(this.lc1AfrGauge);
            this.Controls.Add(this.afrGauge);
            this.Controls.Add(this.tempTextBox);
            this.Controls.Add(this.tempGauge);
            this.Controls.Add(this.rpmTextBox);
            this.Controls.Add(this.rpmGauge);
            this.Controls.Add(this.thrTextBox);
            this.Controls.Add(this.thrGauge);
            this.Name = "DiagGaugePanel";
            this.Size = new System.Drawing.Size(189, 603);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AGauge.AGauge thrGauge;
        private System.Windows.Forms.TextBox thrTextBox;
        private AGauge.AGauge rpmGauge;
        private System.Windows.Forms.TextBox rpmTextBox;
        private AGauge.AGauge tempGauge;
        private System.Windows.Forms.TextBox tempTextBox;
        private AGauge.AGauge afrGauge;
        private AGauge.AGauge lc1AfrGauge;
        private System.Windows.Forms.TextBox afrTextBox;
        private System.Windows.Forms.TextBox lc1AfrTextBox;
    }
}

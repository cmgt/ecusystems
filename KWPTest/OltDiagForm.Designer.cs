namespace KWPTest
{
    partial class OltDiagForm
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.byte7 = new KWPTest.ByteSetter();
            this.byte18 = new KWPTest.ByteSetter();
            this.byte24 = new KWPTest.ByteSetter();
            this.byte23 = new KWPTest.ByteSetter();
            this.byte22 = new KWPTest.ByteSetter();
            this.byte21 = new KWPTest.ByteSetter();
            this.byte17 = new KWPTest.ByteSetter();
            this.byte13 = new KWPTest.ByteSetter();
            this.byte9 = new KWPTest.ByteSetter();
            this.word47 = new KWPTest.WordSetter();
            this.word45 = new KWPTest.WordSetter();
            this.word43 = new KWPTest.WordSetter();
            this.byte36 = new KWPTest.ByteSetter();
            this.byte19 = new KWPTest.ByteSetter();
            this.byte20 = new KWPTest.ByteSetter();
            this.byte12 = new KWPTest.ByteSetter();
            this.byte16 = new KWPTest.ByteSetter();
            this.byte11 = new KWPTest.ByteSetter();
            this.byte8 = new KWPTest.ByteSetter();
            this.byte1 = new KWPTest.BitSetter();
            this.byte0 = new KWPTest.BitSetter();
            this.byte27 = new KWPTest.ByteSetter();
            this.byte35 = new KWPTest.ByteSetter();
            this.byte25 = new KWPTest.ByteSetter();
            this.wordSetter14 = new KWPTest.WordSetter();
            this.wordSetter44 = new KWPTest.WordSetter();
            this.wordSetter42 = new KWPTest.WordSetter();
            this.byteSetter37 = new KWPTest.ByteSetter();
            this.byteSetter26 = new KWPTest.ByteSetter();
            this.byteSetter29 = new KWPTest.ByteSetter();
            this.byteSetter31 = new KWPTest.ByteSetter();
            this.byteSetter30 = new KWPTest.ByteSetter();
            this.byteSetter38 = new KWPTest.ByteSetter();
            this.byte3 = new KWPTest.ByteSetter();
            this.byte4 = new KWPTest.ByteSetter();
            this.byte5 = new KWPTest.ByteSetter();
            this.byte6 = new KWPTest.ByteSetter();
            this.byteSetter1 = new KWPTest.ByteSetter();
            this.SuspendLayout();
            // 
            // byte7
            // 
            this.byte7.ByteDescription = "RPM_GBC_3D_RT";
            this.byte7.Location = new System.Drawing.Point(284, 264);
            this.byte7.Name = "byte7";
            this.byte7.Size = new System.Drawing.Size(140, 20);
            this.byte7.TabIndex = 13;
            this.byte7.Tag = "7";
            this.toolTip1.SetToolTip(this.byte7, "Номер режимной точки для 3D таблицы RPM - GBC");
            this.byte7.Value = ((byte)(0));
            this.byte7.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte18
            // 
            this.byte18.ByteDescription = "COEFF";
            this.byte18.Location = new System.Drawing.Point(814, 186);
            this.byte18.Name = "byte18";
            this.byte18.Size = new System.Drawing.Size(75, 20);
            this.byte18.TabIndex = 37;
            this.byte18.Tag = "18";
            this.toolTip1.SetToolTip(this.byte18, "Коэфф. коррекции");
            this.byte18.Value = ((byte)(0));
            this.byte18.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte24
            // 
            this.byte24.ByteDescription = "Детонация 4";
            this.byte24.Location = new System.Drawing.Point(4, 264);
            this.byte24.Name = "byte24";
            this.byte24.Size = new System.Drawing.Size(107, 20);
            this.byte24.TabIndex = 20;
            this.byte24.Tag = "24";
            this.byte24.Value = ((byte)(0));
            this.byte24.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte23
            // 
            this.byte23.ByteDescription = "Детонация 3";
            this.byte23.Location = new System.Drawing.Point(4, 238);
            this.byte23.Name = "byte23";
            this.byte23.Size = new System.Drawing.Size(107, 20);
            this.byte23.TabIndex = 19;
            this.byte23.Tag = "23";
            this.byte23.Value = ((byte)(0));
            this.byte23.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte22
            // 
            this.byte22.ByteDescription = "Детонация 2";
            this.byte22.Location = new System.Drawing.Point(4, 212);
            this.byte22.Name = "byte22";
            this.byte22.Size = new System.Drawing.Size(107, 20);
            this.byte22.TabIndex = 18;
            this.byte22.Tag = "22";
            this.byte22.Value = ((byte)(0));
            this.byte22.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte21
            // 
            this.byte21.ByteDescription = "Детонация 1";
            this.byte21.Location = new System.Drawing.Point(4, 186);
            this.byte21.Name = "byte21";
            this.byte21.Size = new System.Drawing.Size(107, 20);
            this.byte21.TabIndex = 17;
            this.byte21.Tag = "21";
            this.byte21.Value = ((byte)(0));
            this.byte21.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte17
            // 
            this.byte17.ByteDescription = "Текущее положение РХХ";
            this.byte17.Location = new System.Drawing.Point(515, 212);
            this.byte17.Name = "byte17";
            this.byte17.Size = new System.Drawing.Size(187, 20);
            this.byte17.TabIndex = 16;
            this.byte17.Tag = "17";
            this.byte17.Value = ((byte)(0));
            this.byte17.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte13
            // 
            this.byte13.ByteDescription = "Обороты двигателя на ХХ";
            this.byte13.Location = new System.Drawing.Point(515, 108);
            this.byte13.Name = "byte13";
            this.byte13.Size = new System.Drawing.Size(187, 20);
            this.byte13.TabIndex = 15;
            this.byte13.Tag = "13";
            this.byte13.Value = ((byte)(0));
            this.byte13.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte9
            // 
            this.byte9.ByteDescription = "ALF";
            this.byte9.Location = new System.Drawing.Point(515, 264);
            this.byte9.Name = "byte9";
            this.byte9.Size = new System.Drawing.Size(140, 20);
            this.byte9.TabIndex = 14;
            this.byte9.Tag = "9";
            this.byte9.Value = ((byte)(0));
            this.byte9.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // word47
            // 
            this.word47.ByteDescription = "Цикловый РВ";
            this.word47.Location = new System.Drawing.Point(708, 56);
            this.word47.Name = "word47";
            this.word47.Size = new System.Drawing.Size(187, 20);
            this.word47.TabIndex = 12;
            this.word47.Tag = "47";
            this.word47.Value = ((ushort)(0));
            this.word47.OnValueChange += new System.EventHandler(this.word_OnValueChange);
            // 
            // word45
            // 
            this.word45.ByteDescription = "Массовый РВ";
            this.word45.Location = new System.Drawing.Point(708, 30);
            this.word45.Name = "word45";
            this.word45.Size = new System.Drawing.Size(187, 20);
            this.word45.TabIndex = 11;
            this.word45.Tag = "45";
            this.word45.Value = ((ushort)(0));
            this.word45.OnValueChange += new System.EventHandler(this.word_OnValueChange);
            // 
            // word43
            // 
            this.word43.ByteDescription = "Время впрыска";
            this.word43.Location = new System.Drawing.Point(708, 4);
            this.word43.Name = "word43";
            this.word43.Size = new System.Drawing.Size(187, 20);
            this.word43.TabIndex = 10;
            this.word43.Tag = "43";
            this.word43.Value = ((ushort)(0));
            this.word43.OnValueChange += new System.EventHandler(this.word_OnValueChange);
            // 
            // byte36
            // 
            this.byte36.ByteDescription = "Желаемые обороты ХХ";
            this.byte36.Location = new System.Drawing.Point(515, 238);
            this.byte36.Name = "byte36";
            this.byte36.Size = new System.Drawing.Size(187, 20);
            this.byte36.TabIndex = 9;
            this.byte36.Tag = "36";
            this.byte36.Value = ((byte)(0));
            this.byte36.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte19
            // 
            this.byte19.ByteDescription = "Фаза впрыска";
            this.byte19.Location = new System.Drawing.Point(515, 160);
            this.byte19.Name = "byte19";
            this.byte19.Size = new System.Drawing.Size(187, 20);
            this.byte19.TabIndex = 8;
            this.byte19.Tag = "19";
            this.byte19.Value = ((byte)(0));
            this.byte19.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte20
            // 
            this.byte20.ByteDescription = "УОЗ";
            this.byte20.Location = new System.Drawing.Point(515, 134);
            this.byte20.Name = "byte20";
            this.byte20.Size = new System.Drawing.Size(187, 20);
            this.byte20.TabIndex = 7;
            this.byte20.Tag = "20";
            this.byte20.Value = ((byte)(0));
            this.byte20.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte12
            // 
            this.byte12.ByteDescription = "Обороты двигателя";
            this.byte12.Location = new System.Drawing.Point(515, 82);
            this.byte12.Name = "byte12";
            this.byte12.Size = new System.Drawing.Size(187, 20);
            this.byte12.TabIndex = 6;
            this.byte12.Tag = "12";
            this.byte12.Value = ((byte)(0));
            this.byte12.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte16
            // 
            this.byte16.ByteDescription = "Желаемое положение РХХ";
            this.byte16.Location = new System.Drawing.Point(515, 186);
            this.byte16.Name = "byte16";
            this.byte16.Size = new System.Drawing.Size(187, 20);
            this.byte16.TabIndex = 5;
            this.byte16.Tag = "16";
            this.byte16.Value = ((byte)(0));
            this.byte16.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte11
            // 
            this.byte11.ByteDescription = "Положение дросселя";
            this.byte11.Location = new System.Drawing.Point(515, 56);
            this.byte11.Name = "byte11";
            this.byte11.Size = new System.Drawing.Size(187, 20);
            this.byte11.TabIndex = 4;
            this.byte11.Tag = "11";
            this.byte11.Value = ((byte)(0));
            this.byte11.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte8
            // 
            this.byte8.ByteDescription = "Температура ОЖ";
            this.byte8.Location = new System.Drawing.Point(515, 4);
            this.byte8.Name = "byte8";
            this.byte8.Size = new System.Drawing.Size(187, 20);
            this.byte8.TabIndex = 3;
            this.byte8.Tag = "8";
            this.byte8.Value = ((byte)(0));
            this.byte8.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte1
            // 
            this.byte1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte1.ByteDescription = "Байт 1 (флаги режимов):";
            this.byte1.Location = new System.Drawing.Point(225, 4);
            this.byte1.Name = "byte1";
            this.byte1.Size = new System.Drawing.Size(284, 179);
            this.byte1.TabIndex = 2;
            this.byte1.Tag = "1";
            this.byte1.ToolTips = new string[] {
        "0",
        "Признак ХХ в прошлом цикле",
        "Разрешение блокировки выхода из ХХ",
        "Попадание в зону детонации в прошлом цикле",
        "Наличие продувки адсорбера в прошлом цикле",
        "Обнаружение детонации",
        "Прошлое состояния датчика кислорода",
        "Текущее состояния датчика кислорода"};
            this.byte1.Value = ((byte)(0));
            this.byte1.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte0
            // 
            this.byte0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte0.ByteDescription = "Байт 0 (флаги режимов):";
            this.byte0.Location = new System.Drawing.Point(4, 4);
            this.byte0.Name = "byte0";
            this.byte0.Size = new System.Drawing.Size(215, 179);
            this.byte0.TabIndex = 0;
            this.byte0.Tag = "0";
            this.byte0.ToolTips = new string[] {
        "Флаг остановки двигателя",
        "Флаг холостого хода",
        "Флаг мощностного обогащения",
        "Флаг отключения топливоподачи",
        "Флаг ДК регулирования",
        "Флаг попадания в зону детонации",
        "Флаг продувки адсорбера",
        "Флаг сохранения"};
            this.byte0.Value = ((byte)(0));
            this.byte0.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte27
            // 
            this.byte27.ByteDescription = "АЦП замка зажигания";
            this.byte27.Location = new System.Drawing.Point(117, 186);
            this.byte27.Name = "byte27";
            this.byte27.Size = new System.Drawing.Size(161, 20);
            this.byte27.TabIndex = 21;
            this.byte27.Tag = "27";
            this.byte27.Value = ((byte)(192));
            this.byte27.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte35
            // 
            this.byte35.ByteDescription = "Скорость";
            this.byte35.Location = new System.Drawing.Point(708, 160);
            this.byte35.Name = "byte35";
            this.byte35.Size = new System.Drawing.Size(140, 20);
            this.byte35.TabIndex = 22;
            this.byte35.Tag = "35";
            this.byte35.Value = ((byte)(0));
            this.byte35.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte25
            // 
            this.byte25.ByteDescription = "АЦП ДД";
            this.byte25.Location = new System.Drawing.Point(117, 212);
            this.byte25.Name = "byte25";
            this.byte25.Size = new System.Drawing.Size(187, 20);
            this.byte25.TabIndex = 23;
            this.byte25.Tag = "25";
            this.byte25.Value = ((byte)(0));
            this.byte25.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // wordSetter14
            // 
            this.wordSetter14.ByteDescription = "Время цикла";
            this.wordSetter14.Location = new System.Drawing.Point(708, 82);
            this.wordSetter14.Name = "wordSetter14";
            this.wordSetter14.Size = new System.Drawing.Size(187, 20);
            this.wordSetter14.TabIndex = 24;
            this.wordSetter14.Tag = "14";
            this.wordSetter14.Value = ((ushort)(0));
            this.wordSetter14.OnValueChange += new System.EventHandler(this.word_OnValueChange);
            // 
            // wordSetter44
            // 
            this.wordSetter44.ByteDescription = "DGTC_LEAN";
            this.wordSetter44.Location = new System.Drawing.Point(708, 108);
            this.wordSetter44.Name = "wordSetter44";
            this.wordSetter44.Size = new System.Drawing.Size(187, 20);
            this.wordSetter44.TabIndex = 25;
            this.wordSetter44.Tag = "41";
            this.wordSetter44.Value = ((ushort)(0));
            this.wordSetter44.OnValueChange += new System.EventHandler(this.word_OnValueChange);
            // 
            // wordSetter42
            // 
            this.wordSetter42.ByteDescription = "DGTC_RICH";
            this.wordSetter42.Location = new System.Drawing.Point(708, 134);
            this.wordSetter42.Name = "wordSetter42";
            this.wordSetter42.Size = new System.Drawing.Size(187, 20);
            this.wordSetter42.TabIndex = 26;
            this.wordSetter42.Tag = "39";
            this.wordSetter42.Value = ((ushort)(0));
            this.wordSetter42.OnValueChange += new System.EventHandler(this.word_OnValueChange);
            // 
            // byteSetter37
            // 
            this.byteSetter37.ByteDescription = "Температура воздуха";
            this.byteSetter37.Location = new System.Drawing.Point(515, 30);
            this.byteSetter37.Name = "byteSetter37";
            this.byteSetter37.Size = new System.Drawing.Size(154, 20);
            this.byteSetter37.TabIndex = 27;
            this.byteSetter37.Tag = "37";
            this.byteSetter37.Value = ((byte)(0));
            this.byteSetter37.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byteSetter26
            // 
            this.byteSetter26.ByteDescription = "АЦП ДМРВ";
            this.byteSetter26.Location = new System.Drawing.Point(117, 238);
            this.byteSetter26.Name = "byteSetter26";
            this.byteSetter26.Size = new System.Drawing.Size(134, 20);
            this.byteSetter26.TabIndex = 28;
            this.byteSetter26.Tag = "26";
            this.byteSetter26.Value = ((byte)(0));
            this.byteSetter26.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byteSetter29
            // 
            this.byteSetter29.ByteDescription = "АЦП ДПДЗ";
            this.byteSetter29.Location = new System.Drawing.Point(117, 264);
            this.byteSetter29.Name = "byteSetter29";
            this.byteSetter29.Size = new System.Drawing.Size(134, 20);
            this.byteSetter29.TabIndex = 29;
            this.byteSetter29.Tag = "29";
            this.byteSetter29.Value = ((byte)(0));
            this.byteSetter29.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byteSetter31
            // 
            this.byteSetter31.ByteDescription = "АЦП ДТВ";
            this.byteSetter31.Location = new System.Drawing.Point(284, 212);
            this.byteSetter31.Name = "byteSetter31";
            this.byteSetter31.Size = new System.Drawing.Size(187, 20);
            this.byteSetter31.TabIndex = 30;
            this.byteSetter31.Tag = "31";
            this.byteSetter31.Value = ((byte)(0));
            this.byteSetter31.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byteSetter30
            // 
            this.byteSetter30.ByteDescription = "АЦП ДТОЖ";
            this.byteSetter30.Location = new System.Drawing.Point(284, 186);
            this.byteSetter30.Name = "byteSetter30";
            this.byteSetter30.Size = new System.Drawing.Size(187, 20);
            this.byteSetter30.TabIndex = 31;
            this.byteSetter30.Tag = "30";
            this.byteSetter30.Value = ((byte)(0));
            this.byteSetter30.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byteSetter38
            // 
            this.byteSetter38.ByteDescription = "АЦП ДК";
            this.byteSetter38.Location = new System.Drawing.Point(284, 238);
            this.byteSetter38.Name = "byteSetter38";
            this.byteSetter38.Size = new System.Drawing.Size(187, 20);
            this.byteSetter38.TabIndex = 32;
            this.byteSetter38.Tag = "38";
            this.byteSetter38.Value = ((byte)(0));
            this.byteSetter38.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte3
            // 
            this.byte3.ByteDescription = "Error1";
            this.byte3.Location = new System.Drawing.Point(708, 186);
            this.byte3.Name = "byte3";
            this.byte3.Size = new System.Drawing.Size(75, 20);
            this.byte3.TabIndex = 33;
            this.byte3.Tag = "3";
            this.byte3.Value = ((byte)(0));
            this.byte3.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte4
            // 
            this.byte4.ByteDescription = "Error2";
            this.byte4.Location = new System.Drawing.Point(708, 212);
            this.byte4.Name = "byte4";
            this.byte4.Size = new System.Drawing.Size(75, 20);
            this.byte4.TabIndex = 34;
            this.byte4.Tag = "4";
            this.byte4.Value = ((byte)(0));
            this.byte4.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte5
            // 
            this.byte5.ByteDescription = "Error3";
            this.byte5.Location = new System.Drawing.Point(708, 238);
            this.byte5.Name = "byte5";
            this.byte5.Size = new System.Drawing.Size(75, 20);
            this.byte5.TabIndex = 35;
            this.byte5.Tag = "5";
            this.byte5.Value = ((byte)(0));
            this.byte5.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byte6
            // 
            this.byte6.ByteDescription = "Error4";
            this.byte6.Location = new System.Drawing.Point(708, 264);
            this.byte6.Name = "byte6";
            this.byte6.Size = new System.Drawing.Size(75, 20);
            this.byte6.TabIndex = 36;
            this.byte6.Tag = "6";
            this.byte6.Value = ((byte)(0));
            this.byte6.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // byteSetter1
            // 
            this.byteSetter1.ByteDescription = "RPM_RT";
            this.byteSetter1.Location = new System.Drawing.Point(814, 212);
            this.byteSetter1.Name = "byteSetter1";
            this.byteSetter1.Size = new System.Drawing.Size(81, 20);
            this.byteSetter1.TabIndex = 38;
            this.byteSetter1.Tag = "52";
            this.toolTip1.SetToolTip(this.byteSetter1, "RPM_RT");
            this.byteSetter1.Value = ((byte)(0));
            this.byteSetter1.OnValueChange += new System.EventHandler(this.bytes_OnValueChange);
            // 
            // OltDiagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 288);
            this.Controls.Add(this.byteSetter1);
            this.Controls.Add(this.byte18);
            this.Controls.Add(this.byte6);
            this.Controls.Add(this.byte5);
            this.Controls.Add(this.byte4);
            this.Controls.Add(this.byte3);
            this.Controls.Add(this.byteSetter38);
            this.Controls.Add(this.byteSetter30);
            this.Controls.Add(this.byteSetter31);
            this.Controls.Add(this.byteSetter29);
            this.Controls.Add(this.byteSetter26);
            this.Controls.Add(this.byteSetter37);
            this.Controls.Add(this.wordSetter42);
            this.Controls.Add(this.wordSetter44);
            this.Controls.Add(this.wordSetter14);
            this.Controls.Add(this.byte25);
            this.Controls.Add(this.byte35);
            this.Controls.Add(this.byte27);
            this.Controls.Add(this.byte24);
            this.Controls.Add(this.byte23);
            this.Controls.Add(this.byte22);
            this.Controls.Add(this.byte21);
            this.Controls.Add(this.byte17);
            this.Controls.Add(this.byte13);
            this.Controls.Add(this.byte9);
            this.Controls.Add(this.byte7);
            this.Controls.Add(this.word47);
            this.Controls.Add(this.word45);
            this.Controls.Add(this.word43);
            this.Controls.Add(this.byte36);
            this.Controls.Add(this.byte19);
            this.Controls.Add(this.byte20);
            this.Controls.Add(this.byte12);
            this.Controls.Add(this.byte16);
            this.Controls.Add(this.byte11);
            this.Controls.Add(this.byte8);
            this.Controls.Add(this.byte1);
            this.Controls.Add(this.byte0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OltDiagForm";
            this.Text = "Параметры диагностики olt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OltDiagForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BitSetter byte0;
        private BitSetter byte1;
        private ByteSetter byte8;
        private ByteSetter byte11;
        private ByteSetter byte16;
        private ByteSetter byte12;
        private ByteSetter byte20;
        private ByteSetter byte19;
        private ByteSetter byte36;
        private WordSetter word43;
        private WordSetter word45;
        private WordSetter word47;
        private ByteSetter byte7;
        private System.Windows.Forms.ToolTip toolTip1;
        private ByteSetter byte9;
        private ByteSetter byte13;
        private ByteSetter byte17;
        private ByteSetter byte21;
        private ByteSetter byte22;
        private ByteSetter byte24;
        private ByteSetter byte23;
        private ByteSetter byte27;
        private ByteSetter byte35;
        private ByteSetter byte25;
        private WordSetter wordSetter14;
        private WordSetter wordSetter44;
        private WordSetter wordSetter42;
        private ByteSetter byteSetter37;
        private ByteSetter byteSetter26;
        private ByteSetter byteSetter29;
        private ByteSetter byteSetter31;
        private ByteSetter byteSetter30;
        private ByteSetter byteSetter38;
        private ByteSetter byte3;
        private ByteSetter byte4;
        private ByteSetter byte5;
        private ByteSetter byte6;
        private ByteSetter byte18;
        private ByteSetter byteSetter1;

    }
}
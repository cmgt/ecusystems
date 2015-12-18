namespace KWPTest
{
    partial class CommonDiagForm
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
            this.word32_33 = new KWPTest.WordSetter();
            this.word30_31 = new KWPTest.WordSetter();
            this.word28_29 = new KWPTest.WordSetter();
            this.word26_27 = new KWPTest.WordSetter();
            this.word24_25 = new KWPTest.WordSetter();
            this.word34_35 = new KWPTest.WordSetter();
            this.word22_23 = new KWPTest.WordSetter();
            this.byte21 = new KWPTest.BitSetter();
            this.byte20 = new KWPTest.ByteSetter();
            this.byte19 = new KWPTest.ByteSetter();
            this.byte18 = new KWPTest.ByteSetter();
            this.byte17 = new KWPTest.ByteSetter();
            this.byte16 = new KWPTest.ByteSetter();
            this.byte15 = new KWPTest.ByteSetter();
            this.byte14 = new KWPTest.ByteSetter();
            this.byte13 = new KWPTest.ByteSetter();
            this.byte12 = new KWPTest.ByteSetter();
            this.byte11 = new KWPTest.ByteSetter();
            this.byte10 = new KWPTest.ByteSetter();
            this.byte9 = new KWPTest.ByteSetter();
            this.byte8 = new KWPTest.ByteSetter();
            this.byte7 = new KWPTest.BitSetter();
            this.byte6 = new KWPTest.BitSetter();
            this.byte5 = new KWPTest.BitSetter();
            this.byte4 = new KWPTest.BitSetter();
            this.byte3 = new KWPTest.BitSetter();
            this.byte2 = new KWPTest.BitSetter();
            this.byte1 = new KWPTest.BitSetter();
            this.byte0 = new KWPTest.BitSetter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // word32_33
            // 
            this.word32_33.ByteDescription = "Контрольная сумма ПЗУ";
            this.word32_33.Location = new System.Drawing.Point(229, 363);
            this.word32_33.Name = "word32_33";
            this.word32_33.Size = new System.Drawing.Size(187, 20);
            this.word32_33.TabIndex = 28;
            this.word32_33.Tag = "32";
            this.word32_33.Value = ((ushort)(0));
            this.word32_33.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // word30_31
            // 
            this.word30_31.ByteDescription = "Путевой расход топлива";
            this.word30_31.Location = new System.Drawing.Point(229, 337);
            this.word30_31.Name = "word30_31";
            this.word30_31.Size = new System.Drawing.Size(187, 20);
            this.word30_31.TabIndex = 27;
            this.word30_31.Tag = "30";
            this.word30_31.Value = ((ushort)(0));
            this.word30_31.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // word28_29
            // 
            this.word28_29.ByteDescription = "Часовой расход топлива ";
            this.word28_29.Location = new System.Drawing.Point(4, 415);
            this.word28_29.Name = "word28_29";
            this.word28_29.Size = new System.Drawing.Size(187, 20);
            this.word28_29.TabIndex = 26;
            this.word28_29.Tag = "28";
            this.word28_29.Value = ((ushort)(0));
            this.word28_29.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // word26_27
            // 
            this.word26_27.ByteDescription = "Цикловой расход воздуха ";
            this.word26_27.Location = new System.Drawing.Point(4, 389);
            this.word26_27.Name = "word26_27";
            this.word26_27.Size = new System.Drawing.Size(187, 20);
            this.word26_27.TabIndex = 25;
            this.word26_27.Tag = "26";
            this.word26_27.Value = ((ushort)(0));
            this.word26_27.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // word24_25
            // 
            this.word24_25.ByteDescription = "Массовый расход воздуха ";
            this.word24_25.Location = new System.Drawing.Point(4, 363);
            this.word24_25.Name = "word24_25";
            this.word24_25.Size = new System.Drawing.Size(187, 20);
            this.word24_25.TabIndex = 24;
            this.word24_25.Tag = "24";
            this.word24_25.Value = ((ushort)(0));
            this.word24_25.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // word34_35
            // 
            this.word34_35.ByteDescription = "34 -35";
            this.word34_35.Location = new System.Drawing.Point(229, 389);
            this.word34_35.Name = "word34_35";
            this.word34_35.Size = new System.Drawing.Size(187, 20);
            this.word34_35.TabIndex = 23;
            this.word34_35.Tag = "34";
            this.word34_35.Value = ((ushort)(0));
            this.word34_35.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // word22_23
            // 
            this.word22_23.ByteDescription = "Длительность импульса впрыска ";
            this.word22_23.Location = new System.Drawing.Point(4, 337);
            this.word22_23.Name = "word22_23";
            this.word22_23.Size = new System.Drawing.Size(219, 20);
            this.word22_23.TabIndex = 22;
            this.word22_23.Tag = "22";
            this.word22_23.Value = ((ushort)(0));
            this.word22_23.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte21
            // 
            this.byte21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte21.ByteDescription = "Флаги состояния ДК";
            this.byte21.Location = new System.Drawing.Point(417, 363);
            this.byte21.Name = "byte21";
            this.byte21.Size = new System.Drawing.Size(204, 60);
            this.byte21.TabIndex = 21;
            this.byte21.Tag = "21";
            this.byte21.ToolTips = new string[] {
        "Флаг готовности ДК",
        "Флаг разрешения нагрева ДК"};
            this.byte21.Value = ((byte)(0));
            this.byte21.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte20
            // 
            this.byte20.ByteDescription = "Напряжение на ДК";
            this.byte20.Location = new System.Drawing.Point(417, 337);
            this.byte20.Name = "byte20";
            this.byte20.Size = new System.Drawing.Size(204, 20);
            this.byte20.TabIndex = 20;
            this.byte20.Tag = "20";
            this.byte20.Value = ((byte)(0));
            this.byte20.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte19
            // 
            this.byte19.ByteDescription = "Желаемые обороты ХХ";
            this.byte19.Location = new System.Drawing.Point(417, 296);
            this.byte19.Name = "byte19";
            this.byte19.Size = new System.Drawing.Size(157, 20);
            this.byte19.TabIndex = 19;
            this.byte19.Tag = "19";
            this.byte19.Value = ((byte)(0));
            this.byte19.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte18
            // 
            this.byte18.ByteDescription = "Напряжение бортсети";
            this.byte18.Location = new System.Drawing.Point(417, 270);
            this.byte18.Name = "byte18";
            this.byte18.Size = new System.Drawing.Size(157, 20);
            this.byte18.TabIndex = 18;
            this.byte18.Tag = "18";
            this.byte18.Value = ((byte)(0));
            this.byte18.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte17
            // 
            this.byte17.ByteDescription = "Скорость автомобиля";
            this.byte17.Location = new System.Drawing.Point(417, 244);
            this.byte17.Name = "byte17";
            this.byte17.Size = new System.Drawing.Size(157, 20);
            this.byte17.TabIndex = 17;
            this.byte17.Tag = "17";
            this.byte17.Value = ((byte)(0));
            this.byte17.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte16
            // 
            this.byte16.ByteDescription = "УОЗ";
            this.byte16.Location = new System.Drawing.Point(417, 218);
            this.byte16.Name = "byte16";
            this.byte16.Size = new System.Drawing.Size(157, 20);
            this.byte16.TabIndex = 16;
            this.byte16.Tag = "16";
            this.byte16.Value = ((byte)(0));
            this.byte16.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte15
            // 
            this.byte15.ByteDescription = "Коррекция времени впрыска";
            this.byte15.Location = new System.Drawing.Point(2, 296);
            this.byte15.Name = "byte15";
            this.byte15.Size = new System.Drawing.Size(186, 20);
            this.byte15.TabIndex = 15;
            this.byte15.Tag = "15";
            this.byte15.Value = ((byte)(0));
            this.byte15.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte14
            // 
            this.byte14.ByteDescription = "Текущее  положение РХХ";
            this.byte14.Location = new System.Drawing.Point(190, 296);
            this.byte14.Name = "byte14";
            this.byte14.Size = new System.Drawing.Size(229, 20);
            this.byte14.TabIndex = 14;
            this.byte14.Tag = "14";
            this.byte14.Value = ((byte)(0));
            this.byte14.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte13
            // 
            this.byte13.ByteDescription = "Желаемое положение РХХ";
            this.byte13.Location = new System.Drawing.Point(190, 270);
            this.byte13.Name = "byte13";
            this.byte13.Size = new System.Drawing.Size(229, 20);
            this.byte13.TabIndex = 13;
            this.byte13.Tag = "13";
            this.byte13.Value = ((byte)(0));
            this.byte13.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte12
            // 
            this.byte12.ByteDescription = "Скорость вращения двигателя на ХХ";
            this.byte12.Location = new System.Drawing.Point(190, 244);
            this.byte12.Name = "byte12";
            this.byte12.Size = new System.Drawing.Size(229, 20);
            this.byte12.TabIndex = 12;
            this.byte12.Tag = "12";
            this.byte12.Value = ((byte)(0));
            this.byte12.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte11
            // 
            this.byte11.ByteDescription = "Скорость вращения двигателя";
            this.byte11.Location = new System.Drawing.Point(190, 218);
            this.byte11.Name = "byte11";
            this.byte11.Size = new System.Drawing.Size(204, 20);
            this.byte11.TabIndex = 11;
            this.byte11.Tag = "11";
            this.byte11.Value = ((byte)(0));
            this.byte11.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte10
            // 
            this.byte10.ByteDescription = "Положение дросселя";
            this.byte10.Location = new System.Drawing.Point(2, 270);
            this.byte10.Name = "byte10";
            this.byte10.Size = new System.Drawing.Size(150, 20);
            this.byte10.TabIndex = 10;
            this.byte10.Tag = "10";
            this.byte10.Value = ((byte)(0));
            this.byte10.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte9
            // 
            this.byte9.ByteDescription = "ALF";
            this.byte9.Location = new System.Drawing.Point(2, 244);
            this.byte9.Name = "byte9";
            this.byte9.Size = new System.Drawing.Size(72, 20);
            this.byte9.TabIndex = 9;
            this.byte9.Tag = "9";
            this.byte9.Value = ((byte)(0));
            this.byte9.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte8
            // 
            this.byte8.ByteDescription = "ТОЖ";
            this.byte8.Location = new System.Drawing.Point(2, 218);
            this.byte8.Name = "byte8";
            this.byte8.Size = new System.Drawing.Size(72, 20);
            this.byte8.TabIndex = 8;
            this.byte8.Tag = "8";
            this.byte8.Value = ((byte)(0));
            this.byte8.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte7
            // 
            this.byte7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte7.ByteDescription = "Ошибки входных/выходных цепей";
            this.byte7.Location = new System.Drawing.Point(233, 5);
            this.byte7.Name = "byte7";
            this.byte7.Size = new System.Drawing.Size(321, 179);
            this.byte7.TabIndex = 7;
            this.byte7.Tag = "7";
            this.byte7.ToolTips = new string[] {
        "0325 - Обрыв датчика детонации",
        "1600 - Нет связи с иммобилайзером",
        "3999 - Не используется",
        "0134 - Нет активности датчика кислорода",
        "0172 - Нет отклика датчика кислорода при обеднении",
        "0171 - Нет отклика датчика кислорода при обогащении",
        "0501 - Ошибка датчика скорости автомобиля",
        "0505 - Ошибка регулятора холостого хода"};
            this.byte7.Value = ((byte)(0));
            this.byte7.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte6
            // 
            this.byte6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte6.ByteDescription = "Высокие уровни сигнала";
            this.byte6.Location = new System.Drawing.Point(287, 5);
            this.byte6.Name = "byte6";
            this.byte6.Size = new System.Drawing.Size(283, 179);
            this.byte6.TabIndex = 6;
            this.byte6.Tag = "6";
            this.byte6.ToolTips = new string[] {
        "0563 - Высокий уровень бортового напряжения",
        "1172 - Высокий уровень сигнала RCO",
        "0113 - Высокий уровень сигнала ДТВ",
        "0118 - Высокий уровень сигнала ДТОЖ",
        "0132 - Высокий уровень сигнала с ДК",
        "0123 - Высокий уровень сигнала ДПДЗ",
        "0103 - Высокий уровень сигнала ДМРВ",
        "0328 - Высокий уровень шума двигателя"};
            this.byte6.Value = ((byte)(0));
            this.byte6.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte5
            // 
            this.byte5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte5.ByteDescription = "Низкие уровни сигналов";
            this.byte5.Location = new System.Drawing.Point(8, 5);
            this.byte5.Name = "byte5";
            this.byte5.Size = new System.Drawing.Size(273, 179);
            this.byte5.TabIndex = 5;
            this.byte5.Tag = "5";
            this.byte5.ToolTips = new string[] {
        "0562 - Низкий уровень бортового напряжения",
        "1171 - Низкий уровень сигнала RCO",
        "0112 - Низкий уровень сигнала ДТВ",
        "0117 - Низкий уровень сигнала ДТОЖ",
        "0131 - Низкий уровень сигнала с ДК",
        "0122 - Низкий уровень сигнала ДПДЗ",
        "0102 - Низкий уровень сигнала ДМРВ",
        "0327 - Низкий уровень шума двигателя"};
            this.byte5.Value = ((byte)(0));
            this.byte5.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte4
            // 
            this.byte4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte4.ByteDescription = "Текущие неисправности 1";
            this.byte4.Location = new System.Drawing.Point(8, 5);
            this.byte4.Name = "byte4";
            this.byte4.Size = new System.Drawing.Size(219, 179);
            this.byte4.TabIndex = 4;
            this.byte4.Tag = "4";
            this.byte4.ToolTips = new string[] {
        "Ошибка ДПКВ",
        "Недостаточно времени в цикле 1мс",
        "Ошибка EEPROM",
        "Ошибка нагревателя ДК",
        "Ошибка ДФ",
        "Ошибка сброса процессора",
        "Ошибка ОЗУ",
        "Ошибка ПЗУ"};
            this.byte4.Value = ((byte)(0));
            this.byte4.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte3
            // 
            this.byte3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte3.ByteDescription = "Режим работы 2";
            this.byte3.Location = new System.Drawing.Point(305, 5);
            this.byte3.Name = "byte3";
            this.byte3.Size = new System.Drawing.Size(321, 179);
            this.byte3.TabIndex = 3;
            this.byte3.Tag = "3";
            this.byte3.ToolTips = new string[] {
        "0",
        "Признак ХХ в прошлом цикле",
        "Разрешение блокировки выхода из ХХ",
        "Признак попадания в зону детонации в прошлом цикле",
        "Признак наличия продувки адсорбера в прошлом цикле",
        "Признак обнаружения детонации",
        "Признак прошлого состояния датчика кислорода",
        "Признак текущего состояния датчика кислорода"};
            this.byte3.Value = ((byte)(0));
            this.byte3.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte2
            // 
            this.byte2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte2.ByteDescription = "Режим работы 1";
            this.byte2.Location = new System.Drawing.Point(8, 5);
            this.byte2.Name = "byte2";
            this.byte2.Size = new System.Drawing.Size(291, 179);
            this.byte2.TabIndex = 2;
            this.byte2.Tag = "2";
            this.byte2.ToolTips = new string[] {
        "Признак выключения двигателя",
        "Признак ХХ",
        "Мощностное обогащение",
        "Блокировка топливоподачи",
        "Признак зоны регулирования по ДК",
        "Признак попадания в зону детонации",
        "Признак разрешения продувки адсорбера",
        "Признак сохранения результатов обучения по ДК"};
            this.byte2.Value = ((byte)(0));
            this.byte2.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte1
            // 
            this.byte1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte1.ByteDescription = "Флаги комплектации 2";
            this.byte1.Location = new System.Drawing.Point(200, 5);
            this.byte1.Name = "byte1";
            this.byte1.Size = new System.Drawing.Size(298, 179);
            this.byte1.TabIndex = 1;
            this.byte1.Tag = "1";
            this.byte1.ToolTips = new string[] {
        "Потенциометр регулировки CO",
        "Адаптация нуля дросселя",
        "Асинхронная топливоподача при повторном пуске",
        "Постоянное хранение ошибок",
        "Датчик скорости автомобиля",
        "Разрешение одновременного впрыска",
        "Асинхронное обогащение при ускорении",
        "Пуск в фазированном режиме"};
            this.byte1.Value = ((byte)(0));
            this.byte1.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // byte0
            // 
            this.byte0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byte0.ByteDescription = "Флаги комплектации 1";
            this.byte0.Location = new System.Drawing.Point(8, 5);
            this.byte0.Name = "byte0";
            this.byte0.Size = new System.Drawing.Size(186, 179);
            this.byte0.TabIndex = 0;
            this.byte0.Tag = "0";
            this.byte0.ToolTips = new string[] {
        "ДК",
        "Адсорбер",
        "Клапан рециркуляции",
        "ДД",
        "ДТВ",
        "ДФ",
        "Постоянная топливоподача",
        "Адаптация уставки ХХ"};
            this.byte0.Value = ((byte)(0));
            this.byte0.OnValueChange += new System.EventHandler(this.byte_OnValueChange);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 216);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.byte1);
            this.tabPage1.Controls.Add(this.byte0);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Флаги комплектации";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.byte2);
            this.tabPage2.Controls.Add(this.byte3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(631, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Режимы работы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.byte4);
            this.tabPage3.Controls.Add(this.byte7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(575, 190);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Текущие неисправности";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.byte5);
            this.tabPage4.Controls.Add(this.byte6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(575, 190);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Высокий/низкие уровни";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CommonDiagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 439);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.word32_33);
            this.Controls.Add(this.word30_31);
            this.Controls.Add(this.word28_29);
            this.Controls.Add(this.word26_27);
            this.Controls.Add(this.word24_25);
            this.Controls.Add(this.word34_35);
            this.Controls.Add(this.word22_23);
            this.Controls.Add(this.byte21);
            this.Controls.Add(this.byte20);
            this.Controls.Add(this.byte19);
            this.Controls.Add(this.byte18);
            this.Controls.Add(this.byte17);
            this.Controls.Add(this.byte16);
            this.Controls.Add(this.byte15);
            this.Controls.Add(this.byte14);
            this.Controls.Add(this.byte13);
            this.Controls.Add(this.byte12);
            this.Controls.Add(this.byte11);
            this.Controls.Add(this.byte10);
            this.Controls.Add(this.byte9);
            this.Controls.Add(this.byte8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CommonDiagForm";
            this.Text = "Параметры диагностики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OltDiagForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BitSetter byte0;
        private BitSetter byte1;
        private BitSetter byte2;
        private BitSetter byte3;
        private BitSetter byte4;
        private BitSetter byte5;
        private BitSetter byte6;
        private BitSetter byte7;
        private ByteSetter byte8;
        private ByteSetter byte9;
        private ByteSetter byte10;
        private ByteSetter byte11;
        private ByteSetter byte12;
        private ByteSetter byte13;
        private ByteSetter byte14;
        private ByteSetter byte15;
        private ByteSetter byte16;
        private ByteSetter byte17;
        private ByteSetter byte18;
        private ByteSetter byte19;
        private ByteSetter byte20;
        private BitSetter byte21;
        private WordSetter word22_23;
        private WordSetter word34_35;
        private WordSetter word24_25;
        private WordSetter word26_27;
        private WordSetter word28_29;
        private WordSetter word30_31;
        private WordSetter word32_33;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}
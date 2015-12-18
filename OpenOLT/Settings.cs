using System;
using System.ComponentModel;
using EcuCommunication.Protocols;
using Helper;
using SerialPortEx;
using WidebandLambdaCommunication;

namespace OpenOLT
{
    class Settings: INotifyPropertyChanged
    {
        [Category("Параметры соединения c ЭБУ"), DisplayName(@"COM порт"), DefaultValue("COM1")]
        [TypeConverter(typeof(SerialPortNameConverter))]
        public string PortName { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Скорость"), TypeConverter(typeof(EnumTypeConverter)), DefaultValue(typeof(enBaundRate), "Medium")]        
        public enBaundRate BaundRate { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Диагностический протокол"), TypeConverter(typeof(EnumTypeConverter)), DefaultValue(typeof(OltProtocolVersion), "OltDiagV1")]
        public OltProtocolVersion OltProtocolVersion { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Timeout чтения, мкс"), DefaultValue(100)]
        public int ReadTimeout { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Timeout записи, мкс"), DefaultValue(100)]
        public int WriteTimeout { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Timeout опроса, мкс"), DefaultValue(0)]
        public int ReadFreqNew { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Писать протокол обмена"), DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool TraceECU { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Писать лог параметров"), DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool LogECU { get; set; }
        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Формат времени в логе"), DefaultValue(false), TypeConverter(typeof(LogTimeModeTypeConverter))]
        public bool LogFullTimeMode { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Создавать новый лог файл при каждом соединении с ЭБУ"), DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter)), 
        Description("Если включен данный параметр, то лог файл будет создаваться каждый раз в момент соединения с ЭБУ. Если параметр выключен, то создается один лог файл в момент первого соединения с ЭБУ и используется до закрытия программы")]
        public bool NewLogOnConnectECU { get; set; }

        [Category("Параметры соединения c ШДК"), DisplayName(@"СОМ порт"), DefaultValue("COM5")]
        public string LambdaPortName { get; set; }

        [Category("Параметры соединения c ШДК"), DisplayName(@"Скорость"), DefaultValue(19200)]
        [Browsable(false)]
        public int LambdaBaundRate { get; set; }

        [Category("Параметры соединения c ШДК"), DisplayName(@"Писать протокол обмена"), DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool TraceLambda { get; set; }

        [Category("Параметры соединения c ШДК"), DisplayName(@"Timeout чтения, мкс"), DefaultValue(200)]
        public int ReadLambdaTimeout { get; set; }

        [Category("Параметры соединения c ШДК"), DisplayName(@"Протокол обмена c ШДК")]
        [TypeConverter(typeof(EnumTypeConverter)), DefaultValue(typeof(LambdaProtocol), "InnovateLC1")]
        public LambdaProtocol LambdaProtocol { get; set; }       

        [Category("Номер DS2401"), DisplayName(@"Вычислять номер автоматически"), DefaultValue(true),
         TypeConverter(typeof(BooleanTypeConverter))]
        public bool CalcEcuSn { get; set; }
        [Category("Номер DS2401"), DisplayName(@"Указать номер вручную"), DefaultValue("0000000000000000")]
        public string EcuSn { get; set; }

        [Category("Параметры online режима"), DisplayName(@"Загружаемые калибровки"), TypeConverter(typeof(EnumTypeConverter)), DefaultValue(typeof(LoadFirmwareToEcuType), "OnlyCorrectionTable"),
        Description("Калибровки загружаемые в ЭБУ при открытии прошивки")]
        public LoadFirmwareToEcuType LoadFirmwareToEcuType { get; set; }

        [Category("Параметры online режима"), DisplayName(@"Автосброс ошибок ЭБУ"), TypeConverter(typeof(BooleanTypeConverter)), DefaultValue(false),
        Description("Выполнять автоматический сброс при обнаружении ошибок ЭБУ")]
        public bool AutoClearErrors { get; set; }

        [Category("Параметры обучения топливоподачи"), DisplayName(@"Не обучать при дросселе менее, %"), DefaultValue((byte)1), Description("Запрет обучения при дросселе менее указанного значения")]
        public byte THRThresholdLineFuelCorrection { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"Только точное регулирование"), Description("Отключается пропорциональная составляющая ПД-регулятора"), 
         DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool DisableFuelCorrectionProportional { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"Высокая стационарность по дросселю"), 
         DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool THRHiStability { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"Высокая стационарность по оборотам"),
         DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool RPMHiStability { get; set; }

        private bool disabledThrZeroFuelCutoff;

        [Category("Параметры обучения топливоподачи"), DisplayName(@"Запрет отсечки топливоподачи по 0% дросселя"), Description("Разрешить постоянную подачу топлива"),
         DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool DisabledTHRZeroFuelCutoff
        {
            get { return disabledThrZeroFuelCutoff; }
            set
            {
                if (disabledThrZeroFuelCutoff == value) return;
                disabledThrZeroFuelCutoff = value;
                DoPropertyChanged(new PropertyChangedEventArgs("DisabledTHRZeroFuelCutoff"));
            }
        }        

        [Category("Параметры обучения топливоподачи"), DisplayName(@"Корректировать БЦН"), Description("Разрешить корректирование таблицы БЦН"),
         DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool EnabledGBCCorrection { get; set; }

        [Category("Параметры обучения топливоподачи"), DisplayName(@"Проверять отклонение СС при корректировке БЦН"), Description("Выполнять проверку отклонения реального состава смеси от заданного при корректировке таблицы БЦН. Если СС отличается от заданного, то не корректировать БЦН"),
         DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool TestAfrBeforeGBCCorrection { get; set; }

        [Category("Параметры обучения топливоподачи"), DisplayName(@"Запрет экстраполяции результатов при регулировании"), Description("Не корректировать соседнии точки"),
         DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool DisabledFuelExtrapolation { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"Стационарность по режимной точке"), DefaultValue((byte)4), Description("Количество циклов опроса, в течении которых режимная точка не изменялась")]
        public byte FuelRtStability { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"ПИД-регулятор пропорциональный коэффициент, %"), DefaultValue((byte)60), Description("Настройка топливоподачи ведется с применением ПИД-регулятора")]
        public byte FuelCorrectionProportional { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"ПИД-регулятор дифференциальный коэффициент, %"), DefaultValue((byte)10), Description("Настройка топливоподачи ведется с применением ПИД-регулятора")]
        public byte FuelCorrectionDifferential { get; set; }
        [Category("Параметры обучения топливоподачи"), DisplayName(@"ПИД-регулятор интегральный коэффициент, %"), DefaultValue((byte)5), Description("Настройка топливоподачи ведется с применением ПИД-регулятора")]
        public byte FuelCorrectionIntegral { get; set; }

        [Category("Общие параметры"), DisplayName(@"Интервал обновления данных"), DefaultValue(50)]
        public int UpdateDiagValuesFreq { get; set; }
        [Category("Общие параметры"), DisplayName(@"Открывать последнюю прошивку"), Description("При запуске программы автоматически открывать файл последней используемой прошивки"),
        DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool AutoLoadLastFirmware { get; set; }
        [Browsable(false)]
        public string LastFirmwarePath { get; set; }

        [Category("Детектор аварийных состояний"), DisplayName(@"Температура ОЖ"), DefaultValue(105)]
        public int WarnTwat { get; set; }
        [Category("Детектор аварийных состояний"), DisplayName(@"Температура воздуха на впуске"), DefaultValue(70)]
        public int WarnTair { get; set; }
        [Category("Детектор аварийных состояний"), DisplayName(@"Загруженность форсунок, %"), DefaultValue(90)]
        public int WarnFuse { get; set; }
        [Category("Детектор аварийных состояний"), DisplayName(@"Напряжение бортсети мин, В"), DefaultValue(10f)]
        public float WarnUBatMin { get; set; }
        [Category("Детектор аварийных состояний"), DisplayName(@"Напряжение бортсети мах, В"), DefaultValue(16f)]
        public float WarnUBatMax { get; set; }
        [Category("Детектор аварийных состояний"), DisplayName(@"Давление (ДАД) мин, кПа"), DefaultValue(0)]
        public int WarnPressMin { get; set; }
        [Category("Детектор аварийных состояний"), DisplayName(@"Давление (ДАД) макс, кПа"), DefaultValue(600)]
        public int WarnPressMax { get; set; }

        internal static readonly LocalSettingsKeeper settingsKeeper = new LocalSettingsKeeper();

        public Settings()
        {
            PortName = "COM1";
            BaundRate = enBaundRate.Medium;
            ReadFreqNew = 0;
            ReadTimeout = 100;
            WriteTimeout = 100;
            LogECU = true;

            LambdaPortName = "COM5";
            LambdaBaundRate = 19200;
            ReadLambdaTimeout = 200;
            LambdaProtocol = LambdaProtocol.InnovateLC1;

            UpdateDiagValuesFreq = 50;

            NewLogOnConnectECU = true;

            OltProtocolVersion = OltProtocolVersion.OltDiagV1;

            CalcEcuSn = true;
            EcuSn = "0000000000000000";

            LoadFirmwareToEcuType = LoadFirmwareToEcuType.OnlyCorrectionTable;

            THRThresholdLineFuelCorrection = 1;
            DisabledTHRZeroFuelCutoff = true;
            FuelRtStability = 4;
            FuelCorrectionProportional = 60;
            FuelCorrectionDifferential = 10;
            FuelCorrectionIntegral = 5;

            AutoClearErrors = false;
#if DEBUG
            PortName = "COM3";
            BaundRate = enBaundRate.Low;            
#endif

            AutoLoadLastFirmware = true;
            LogFullTimeMode = false;
            TestAfrBeforeGBCCorrection = true;
            EnabledGBCCorrection = true;

            WarnTwat = 105;
            WarnTair = 70;
            WarnFuse = 90;
            WarnUBatMin = 10;
            WarnUBatMax = 16;
            WarnPressMin = 0;
            WarnPressMax = 600;
        }

        public void LoadFromFile()
        {
            settingsKeeper.LoadSettings(this);
        }

        public void SaveToFile()
        {
            settingsKeeper.SaveSettings(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void DoPropertyChanged(PropertyChangedEventArgs e)
        {
            var pc = PropertyChanged;
            if (pc != null) pc(this, e);
        }
    }

    internal class LogTimeModeTypeConverter: BaseBooleanTypeConverter
    {
        protected LogTimeModeTypeConverter() : base("H:MM:SS.ms", "SS.ms") { }
    }
}

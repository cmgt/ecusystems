using System;
using System.Collections.Generic;
using System.ComponentModel;
using Helper;
using SerialPortEx;

namespace SokolovSport.Options
{
    class OptionsEntity
    {
        [Category("Параметры соединения c ЭБУ"), DisplayName(@"COM порт"), DefaultValue("COM1")]
        [TypeConverter(typeof(SerialPortNameConverter))]
        public string PortName { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Timeout чтения, мс"), DefaultValue(200)]
        public int ReadTimeout { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Timeout записи, мс"), DefaultValue(100)]
        public int WriteTimeout { get; set; }

        [Browsable(false), Category("Параметры соединения c ЭБУ"), DisplayName(@"Timeout опроса, мс"), DefaultValue(50)]
        public int ReadFreq { get; set; }

        [Browsable(false), Category("Параметры соединения c ЭБУ"), DisplayName(@"Писать протокол обмена"), DefaultValue(false), TypeConverter(typeof(BooleanTypeConverter))]
        public bool TraceECU { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Писать лог параметров"), DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool LogECU { get; set; }

        [Category("Параметры соединения c ЭБУ"), DisplayName(@"Создавать новый лог файл при каждом соединении с ЭБУ"), DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter)),
        Description("Если включен данный параметр, то лог файл будет создаваться каждый раз в момент соединения с ЭБУ. Если параметр выключен, то создается один лог файл в момент первого соединения с ЭБУ и используется до закрытия программы")]
        public bool NewLogOnConnectECU { get; set; }

        [Category("Параметры визуализации"), DisplayName(@"Timeout обновления значений, мс"), DefaultValue(500)]
        public int VisualSyncFreq { get; set; }

        [Category("Общие параметры"), DisplayName(@"Автоматически загружать последний dat файл"), DefaultValue(true), TypeConverter(typeof(BooleanTypeConverter))]
        public bool LoadLastDatFile { get; set; }

        public readonly List<String> OpenedDatFile = new List<string>();

        public OptionsEntity()
        {
            PortName = "COM1";            
            ReadFreq = 50;
            ReadTimeout = 200;
            WriteTimeout = 100;
            VisualSyncFreq = 500;
            LogECU = true;            
            NewLogOnConnectECU = true;
            LoadLastDatFile = true;
#if DEBUG
            PortName = "COM3";            
#endif            
        }
    }
}

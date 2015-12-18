using System;
using System.ComponentModel;
using System.Globalization;

namespace EcuCommunication.Protocols
{
    public class DiagData
    {
        internal static Type type = typeof (DiagData);
        public readonly static DiagData Empty = new DiagData();
        public static bool FullTimeMode = true;        

        public virtual string GetLogHeader()
        {
            return
                "TIME,TRT,RPM,RPM40,RPM_GBC_RT,UFRXX,SSM,TWAT,TAIR,ALF,AFR,ALF_LC1,AFR_LC1,COEFF,DGTC_RICH,DGTC_LEAN,UOZ,KUOZ1,KUOZ2,KUOZ3,KUOZ4,FAZ,INJ,FUSE,AIR,"+
                "GBC,SPD,ADCKNOCK,ADCMAF,ADCTWAT,ADCTAIR,ADCTPS,ADCUBAT,ADCLAM,Err,fSTOP,fXX,fXXPrev,fXXFix,fPOW,fFUELOFF,fDETZONE,fDET,fADS,fLAMREG,fLAM,fLEARN,fLAMRDY,fLAMHEAT";
        }
        
        public void Load(string data)
        {
            throw new NotSupportedException();

            var dataItems = data.Split(',');
            if (dataItems.Length != 45) return;

            Time = TimeSpan.Parse(dataItems[0]);
            TRT = byte.Parse(dataItems[1]);
            RPM = ushort.Parse(dataItems[2]);
            RPM40 = ushort.Parse(dataItems[3]);            
            UFRXX = byte.Parse(dataItems[4]);
            SSM = byte.Parse(dataItems[5]);
            TWAT = sbyte.Parse(dataItems[6]);
            TAIR = sbyte.Parse(dataItems[7]);
            ALF = float.Parse(dataItems[8], CultureInfo.InvariantCulture);
            AFR = float.Parse(dataItems[9], CultureInfo.InvariantCulture);    
            LC1_ALF = float.Parse(dataItems[10], CultureInfo.InvariantCulture);
            LC1_AFR = float.Parse(dataItems[11], CultureInfo.InvariantCulture);                        
            COEFF = float.Parse(dataItems[12], CultureInfo.InvariantCulture);
            DGTC_RICH = float.Parse(dataItems[13], CultureInfo.InvariantCulture);
            DGTC_LEAN = float.Parse(dataItems[14], CultureInfo.InvariantCulture);
            UOZ = sbyte.Parse(dataItems[15]);
            KUOZ1 = sbyte.Parse(dataItems[16]);
            KUOZ2 = sbyte.Parse(dataItems[17]);
            KUOZ3 = sbyte.Parse(dataItems[18]);
            KUOZ4 = sbyte.Parse(dataItems[19]);
            Faza = short.Parse(dataItems[20]);
            INJ = float.Parse(dataItems[21], CultureInfo.InvariantCulture);
            FUSE = float.Parse(dataItems[22], CultureInfo.InvariantCulture);
            AIR = float.Parse(dataItems[23], CultureInfo.InvariantCulture);
            GBC = float.Parse(dataItems[24], CultureInfo.InvariantCulture);
            SPD = byte.Parse(dataItems[25]);
            ADCKNOCK = float.Parse(dataItems[26], CultureInfo.InvariantCulture);
            ADCMAF = float.Parse(dataItems[27], CultureInfo.InvariantCulture);
            ADCTWAT = float.Parse(dataItems[28], CultureInfo.InvariantCulture);
            ADCTAIR = float.Parse(dataItems[29], CultureInfo.InvariantCulture);
            ADCTPS = float.Parse(dataItems[30], CultureInfo.InvariantCulture);
            ADCUBAT = float.Parse(dataItems[31], CultureInfo.InvariantCulture);
            ADCLAM = float.Parse(dataItems[32], CultureInfo.InvariantCulture);
            fSTOP = dataItems[33] == "1";
            fXX = dataItems[34] == "1";
            fPOW = dataItems[35] == "1";
            fFUELOFF = dataItems[36] == "1";
            fDETZONE = dataItems[37] == "1";
            fDET = dataItems[38] == "1";
            fADS = dataItems[39] == "1";
            fLAMREG = dataItems[40] == "1";
            fLAM = dataItems[41] == "1";
            fLEARN = dataItems[42] == "1";
            fLAMRDY = dataItems[43] == "1";
            fLAMHEAT = dataItems[44] == "1";
        }

        [Browsable(false)]
        public byte RPM_GBC_RT { get; set; }
        [DisplayName("Время"), Browsable(false)]
        public TimeSpan Time { get;  set; }
        [Browsable(false)]
        public DateTime _Time { get { return new DateTime(Time.Ticks); } }
        [DisplayName("Дроссель")]
        public byte TRT { get;  set; }
        [DisplayName("Обороты")]
        public ushort RPM { get;  set; }
        [DisplayName("Обороты_40")]
        public ushort RPM40 { get;  set; }
        [DisplayName("Обороты_XX")]
        public ushort RPM_XX { get; set; }
        [DisplayName("УОЗ")]
        public float UOZ { get;  set; }
        [DisplayName("Отскок УОЗ_1 при детонации")]
        public float KUOZ1 { get; set; }
        [DisplayName("Отскок УОЗ_2 при детонации")]
        public float KUOZ2 { get; set; }
        [DisplayName("Отскок УОЗ_3 при детонации")]
        public float KUOZ3 { get; set; }
        [DisplayName("Отскок УОЗ_4 при детонации")]
        public float KUOZ4 { get; set; }
        [DisplayName("ТОЖ")]
        public sbyte TWAT { get;  set; }
        [DisplayName("Т воздуха")]
        public sbyte TAIR { get;  set; }
        [DisplayName("Состав смеси (AFR)")]
        public float AFR { get;  set; }
        [DisplayName("ALF")]
        public float ALF { get;  set; }
        [DisplayName("Состав смеси (AFR) от ШДК")]
        public float LC1_AFR { get; set; }
        [DisplayName("ALF от ШДК")]
        public float LC1_ALF { get; set; }
        [DisplayName("Желаемое положение РХХ")]
        public byte UFRXX { get;  set; }
        [DisplayName("Текущее положение РХХ")]
        public byte SSM { get;  set; }
        [DisplayName("Корр. времени впрыска")]
        public float COEFF { get;  set; }
        [DisplayName("Корр. GTC при обеднении")]
        public float DGTC_LEAN { get;  set; }
        [DisplayName("Корр. GTC при обогащении")]
        public float DGTC_RICH { get; set; }
        [DisplayName("Фаза впрыска")]
        public short Faza { get;  set; }
        [DisplayName("Время впрыска")]
        public float INJ { get;  set; }
        [DisplayName("Загруженность форсунок")]
        public float FUSE { get; set; }
        [DisplayName("Массовый расход воздуха")]
        public float AIR { get;  set; }
        [DisplayName("Цикловый расход воздуха")]
        public float GBC { get;  set; }
        [DisplayName("Скорость")]
        public byte SPD { get;  set; }        
        /// <summary>
        /// АЦП ДД
        /// </summary>
        [DisplayName("АЦП ДД")]
        public float ADCKNOCK { get;  set; }
        /// <summary>
        /// АЦП ДМРВ
        /// </summary>
        [DisplayName("АЦП ДМРВ")]
        public float ADCMAF { get;  set; }
        /// <summary>
        /// АЦП ДТОЖ
        /// </summary>
        [DisplayName("АЦП ДТОЖ")]
        public float ADCTWAT { get;  set; }
        /// <summary>
        /// АЦП ДТВ
        /// </summary>
        [DisplayName("АЦП ДТВ")]
        public float ADCTAIR { get;  set; }
        /// <summary>
        /// АЦП ДПДЗ
        /// </summary>
        [DisplayName("АЦП ДПДЗ")]
        public float ADCTPS { get;  set; } 
        /// <summary>
        /// АЦП напр. бортсети
        /// </summary>
        [DisplayName("АЦП напр. бортсети")]
        public float ADCUBAT { get;  set; }
        /// <summary>
        /// АЦП ДК
        /// </summary>
        [DisplayName("АЦП ДК")]
        public float ADCLAM { get;  set; }
        [DisplayName("Флаг остановки двигателя")]
        public bool fSTOP { get;  set; }
        [DisplayName("Флаг ХХ")]
        public bool fXX { get;  set; }
        [DisplayName("Флаг ХХ в прошлом цикле")]
        public bool fXXPrev { get; set; }
        [DisplayName("Флаг блокировки ХХ")]
        public bool fXXFix { get; set; }
        [DisplayName("Флаг мощн. обогащения")]
        public bool fPOW { get;  set; }
        [DisplayName("Флаг отключения топлива")]
        public bool fFUELOFF { get;  set; }
        [DisplayName("Флаг зоны детонации")]
        public bool fDETZONE { get;  set; }
        [DisplayName("Флаг детонации")]
        public bool fDET { get;  set; }
        [DisplayName("Флаг продувки адсорбера")]
        public bool fADS { get;  set; }
        [DisplayName("Флаг регулирования по ДК")]
        public bool fLAMREG { get;  set; }
        [DisplayName("Флаг текущего сост. по ДК")]
        public bool fLAM { get;  set; }
        [DisplayName("Флаг сохранения обучения")]
        public bool fLEARN { get;  set; }
        [DisplayName("Флаг готовность ДК")]
        public bool fLAMRDY { get;  set; }
        [DisplayName("Флаг прогрев ДК")]
        public bool fLAMHEAT { get;  set; }

        [Browsable(false)]
        public uint ErrorStatus { get; set; }
        [Browsable(false)]
        public byte ErrorCount { get; set; }

        [Browsable(false)]
        public bool IsErrorFound { get { return ErrorCount != 0 || ErrorStatus != 0; } }

        public virtual string GetDataRow()
        {
            return String.Join(",", new[]
                                        {
                                            FullTimeMode ? Time.ToString() : Time.TotalSeconds.ToString(CultureInfo.InvariantCulture),
                                            TRT.ToString(),
                                            RPM.ToString(),
                                            RPM40.ToString(),
                                            RPM_GBC_RT.ToString(),
                                            UFRXX.ToString(),
                                            SSM.ToString(),
                                            TWAT.ToString(),
                                            TAIR.ToString(),
                                            ALF.ToString("0.#", CultureInfo.InvariantCulture),
                                            AFR.ToString("0.#", CultureInfo.InvariantCulture),
                                            LC1_ALF.ToString("0.###", CultureInfo.InvariantCulture),
                                            LC1_AFR.ToString("0.#", CultureInfo.InvariantCulture),
                                            COEFF.ToString("0.###", CultureInfo.InvariantCulture),
                                            DGTC_RICH.ToString("0.###", CultureInfo.InvariantCulture),
                                            DGTC_LEAN.ToString("0.###", CultureInfo.InvariantCulture),
                                            UOZ.ToString("0.#", CultureInfo.InvariantCulture),
                                            KUOZ1.ToString("0.#", CultureInfo.InvariantCulture),
                                            KUOZ2.ToString("0.#", CultureInfo.InvariantCulture),
                                            KUOZ3.ToString("0.#", CultureInfo.InvariantCulture),
                                            KUOZ4.ToString("0.#", CultureInfo.InvariantCulture),
                                            Faza.ToString(),
                                            INJ.ToString("0.###", CultureInfo.InvariantCulture),
                                            FUSE.ToString("0.#", CultureInfo.InvariantCulture),
                                            AIR.ToString("0.#", CultureInfo.InvariantCulture),
                                            GBC.ToString("0.##", CultureInfo.InvariantCulture),
                                            SPD.ToString(),
                                            ADCKNOCK.ToString("0.###", CultureInfo.InvariantCulture),
                                            ADCMAF.ToString("0.###", CultureInfo.InvariantCulture),
                                            ADCTWAT.ToString("0.###", CultureInfo.InvariantCulture),
                                            ADCTAIR.ToString("0.###", CultureInfo.InvariantCulture),
                                            ADCTPS.ToString("0.###", CultureInfo.InvariantCulture),
                                            ADCUBAT.ToString("0.###", CultureInfo.InvariantCulture),
                                            ADCLAM.ToString("0.###", CultureInfo.InvariantCulture),
                                            ErrorCount.ToString(),
                                            fSTOP ? "1" : "0",
                                            fXX ? "1" : "0",
                                            fXXPrev ? "1" : "0",
                                            fXXFix ? "1" : "0",
                                            fPOW ? "1" : "0",
                                            fFUELOFF ? "1" : "0",
                                            fDETZONE ? "1" : "0",
                                            fDET ? "1" : "0",
                                            fADS ? "1" : "0",
                                            fLAMREG ? "1" : "0",
                                            fLAM ? "1" : "0",
                                            fLEARN ? "1" : "0",
                                            fLAMRDY ? "1" : "0",
                                            fLAMHEAT ? "1" : "0"
                                        }

                );
        }

        public virtual string GetValue(string name)
        {
            //var property = type.GetProperty(name);
            //return property == null ? String.Empty : Convert.ToSingle(property.GetValue(this, null)).ToString("0.##");

            var j7EsDiagData = this as J7esDiagData;

            switch (name)
            {
                case "RPM":
                    return RPM.ToString(CultureInfo.InvariantCulture);

                case "UOZ":
                    return UOZ.ToString("0.#", CultureInfo.InvariantCulture);

                case "DUOZ":
                    return j7EsDiagData != null ? j7EsDiagData.DUOZ.ToString("0.#", CultureInfo.InvariantCulture) : "-";

                case "TRT":
                    return TRT.ToString(CultureInfo.InvariantCulture);

                case "TWAT":
                    return TWAT.ToString(CultureInfo.InvariantCulture);

                case "TAIR":
                    return TAIR.ToString(CultureInfo.InvariantCulture);

                case "ALF":
                    return ALF.ToString("0.##", CultureInfo.InvariantCulture);

                case "LC1_ALF":
                    return LC1_ALF.ToString("0.##", CultureInfo.InvariantCulture);

                case "COEFF":
                    return COEFF.ToString("0.###", CultureInfo.InvariantCulture);

                case "INJ":
                    return INJ.ToString("0.###", CultureInfo.InvariantCulture);

                case "FUSE":
                    return FUSE.ToString("0.#", CultureInfo.InvariantCulture);

                case "AIR":
                    return AIR.ToString("0", CultureInfo.InvariantCulture);

                case "GBC":
                    return GBC.ToString("0", CultureInfo.InvariantCulture);

                case "SPD":
                    return SPD.ToString(CultureInfo.InvariantCulture);

                case "Press":
                    return j7EsDiagData != null ? j7EsDiagData.Press.ToString("0.##", CultureInfo.InvariantCulture) : "-";

                case "TARGET_BOOST":
                    return j7EsDiagData != null ? j7EsDiagData.TARGET_BOOST.ToString("0.##", CultureInfo.InvariantCulture) : "-";

                case "WGDC":
                    return j7EsDiagData != null ? j7EsDiagData.WGDC.ToString(CultureInfo.InvariantCulture) : "-";

                case "TURBO_DYNAMICS":
                    return j7EsDiagData != null ? j7EsDiagData.TURBO_DYNAMICS.ToString(CultureInfo.InvariantCulture) : "-";

                case "UGB_RXX":
                    return j7EsDiagData != null ? j7EsDiagData.UGB_RXX.ToString("0.##", CultureInfo.InvariantCulture) : "-";

                default:
                    return String.Empty;
            }
        }
    }
}

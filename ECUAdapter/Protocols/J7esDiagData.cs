using System;
using System.Globalization;

namespace EcuCommunication.Protocols
{
    public class J7esDiagData: DiagData
    {
        public byte PRESS_RT { get; set; }     
        public sbyte Tcharge { get; set; }
        public float TchargeCoeff { get; set; }
        public float DUOZ { get; set; }
        public float KGTC { get; set; }
        public float KBARR_GTC { get; set; }
        public short LaunchFuelCutOff { get; set; }
        public ushort FchargeGBCFin { get; set; }
        public float Press { get; set; }
        public ushort FchargeGBC { get; set; }
        public byte KnockFlags { get; set; }
        public byte MisFireFlags { get; set; }
        public float DGTC_DadRich { get; set; }
        public float KGBC_DAD { get; set; }

        public byte TWAT_RT { get; set; }
        public byte RPM_RT { get; set; }               
        public byte RPM_RT_16 { get; set; }               
        public byte RPM_THR_RT { get; set; }
        public byte StartFlags { get; set; }        

        public float UOZ_TCORR { get; set; }
        public int JUFRXX { get; set; }
        public int JFRXX1 { get; set; }
        public int JFRXX2 { get; set; }
        public int DELTA_RPM_XX { get; set; }
        public byte PXX_ZONE { get; set; }
        public float UGB_RXX { get; set; }
        public float KINJ_AIRFREE { get; set; }
        public float DUOZ_REGXX { get; set; }

        public int DUOZ_LAUNCH { get; set; }

        public short DERR_RPM { get; set; }
        public float DIUOZ { get; set; }
        public byte DELAY_FUEL_CUTOFF { get; set; }

        public byte TLE_PIN_0_7 { get; set; }
        public byte TLE_PIN_8_15 { get; set; }

        public byte GBC_RT { get; set; }
        public byte GBC_RT_16 { get; set; }

        public byte THR_RT_16 { get; set; }

        public float TARGET_BOOST { get; set; }
        public byte TURBO_DYNAMICS { get; set; }
        public byte WGDC { get; set; }

        public ushort Knock { get; set; }

        public override string GetDataRow()
        {
            var ic = CultureInfo.InvariantCulture;
            return String.Join(",",
                               new []
                                   {
                                       base.GetDataRow(), KINJ_AIRFREE.ToString("0.##", ic), UOZ_TCORR.ToString("0.#", ic), DUOZ_REGXX.ToString("0.#", ic), DIUOZ.ToString(ic), JUFRXX.ToString(ic), JFRXX1.ToString(ic), JFRXX2.ToString(ic), 
                                       DELTA_RPM_XX.ToString(ic), DERR_RPM.ToString(ic), PXX_ZONE.ToString(ic), UGB_RXX.ToString("0.##", ic),
                                       StartFlags.ToString("X2"), 
                                       TWAT_RT.ToString(ic), THR_RT_16.ToString(ic), RPM_RT.ToString(ic), RPM_RT_16.ToString(ic), RPM_THR_RT.ToString(ic), GBC_RT.ToString(ic),GBC_RT_16.ToString(ic),
                                       KGTC.ToString("0.#", ic), KBARR_GTC.ToString("0.#", ic), DUOZ.ToString("0.#", ic), 
                                       DUOZ_LAUNCH.ToString(ic), LaunchFuelCutOff.ToString(ic), DELAY_FUEL_CUTOFF.ToString(ic), PRESS_RT.ToString(ic), Press.ToString("0.##", ic),
                                       TARGET_BOOST.ToString("0.##", ic), TURBO_DYNAMICS.ToString(ic), WGDC.ToString(ic),
                                       Tcharge.ToString(ic), TchargeCoeff.ToString("0.##", ic), FchargeGBC.ToString(ic), KGBC_DAD.ToString("0.##", ic), FchargeGBCFin.ToString(ic), Knock.ToString("X4"),
                                       KnockFlags.ToString("X2"), MisFireFlags.ToString("X2"), DGTC_DadRich.ToString("0.###", ic),
                                       TLE_PIN_0_7.ToString("X2"), TLE_PIN_8_15.ToString("X2")
                                   });
        }

        public override string GetLogHeader()
        {
            var baseHeader = base.GetLogHeader();

            return baseHeader + ",KINJ_AIRFREE,UOZ_TCORR,DUOZ_REGXX,DIUOZ,JUFRXX,JFRXX1,JFRXX2,DELTA_RPM_XX,DERR_RPM,PXX_ZONE,UGB_RXX,StartFlags,TWAT_RT,THR_RT_16,RPM_RT,RPM_RT_16,RPM_THR_RT,GBC_RT,GBC_RT_16,KGTC,KBARR_GTC,DUOZ," +
                "DUOZ_LAUNCH,LaunchFuelCutOff,DELAY_FUEL_CUTOFF,PRESS_RT,PRESS,TARGET_BOOST,TURBO_DYNAMICS,WGDC," +
                "TCHARGE,TCHARGE_COEFF,FCHARGE_GBC,KGBC_DAD,FCRG_GBC_FIN,KNOCK,KNOCK_FLAGS,MISFIRE_FLAGS,DGTC_DAD_RICH,TLE_PIN_0_7,TLE_PIN_8_15";
        }
    }
}

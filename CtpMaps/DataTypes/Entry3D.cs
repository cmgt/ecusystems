using System;
using System.ComponentModel;
using Helper;

namespace CtpMaps.DataTypes
{
    [TypeConverter(typeof(PropertyConverter))]
    public unsafe class Entry3D: EntryTableBase
	{
		//j5unk<8,0> unk1;
        public byte[] unk1 { get; set; }
		//j5str<32> z_units;
        public string zUnits { get; set; }
		//j5str<255> z_table;
        public string zTable { get; set; }
        public ushort ShiftMask { get; set; } //------?
        public byte zPoints { get; set; }

		//j5unk<1,0xff> unk2;
        public byte unk2 { get; set; }

		//j5unk<1,0xff> unk3;
        public byte unk3 { get; set; }

        public double zStart { get; set; }
        public double zEnd { get; set; }
		
		//j5unk<1,0xff> unk4;
        public byte unk4 { get; set; }

		//j5unk<1,0> unk5;
        public byte unk5 { get; set; }

        public byte gbc_thrott { get; set; } // 00 - 02	

		//j5unk<1,0xff> unk6;	
		//j5unk<1,0> unk7;
        public byte[] unk6 { get; set; }

		public Entry3D(ref byte* ptr, bool olt)
		{
			Comp_id = MapDataHelper.LoadUint(ref ptr);
			Addr = MapDataHelper.LoadUint(ref ptr);
			if (!olt)
			{
				Addr ^= MapDataHelper.XorKey;
				unk1 = MapDataHelper.LoadBytes(ref ptr, 8);
			}
			else
			{
				unk1 = MapDataHelper.LoadBytes(ref ptr, 4);
			}

			xUnits = MapDataHelper.LoadString(ref ptr, 32);
			Units = MapDataHelper.LoadString(ref ptr, 32);
			zUnits = MapDataHelper.LoadString(ref ptr, 32);
			xTable = MapDataHelper.LoadString(ref ptr, 255);
			zTable = MapDataHelper.LoadString(ref ptr, 255);

			xPoints = MapDataHelper.LoadUshort(ref ptr);
			ShiftMask = MapDataHelper.LoadUshort(ref ptr);
			zPoints = *(ptr++);

			xStart = MapDataHelper.LoadDouble(ref ptr);
			xEnd = MapDataHelper.LoadDouble(ref ptr);

			unk2 = *(ptr++); //FF

			Lower_lim = MapDataHelper.LoadDouble(ref ptr);
			Upper_lim = MapDataHelper.LoadDouble(ref ptr);

			unk3 = *(ptr++); //FF

			zStart = MapDataHelper.LoadDouble(ref ptr);
			zEnd = MapDataHelper.LoadDouble(ref ptr);

			unk4 = *(ptr++); //FF
			Const_type = *(ptr++);
			unk5 = *(ptr++); //00
			gbc_thrott = *(ptr++);

			unk6 = MapDataHelper.LoadBytes(ref ptr, 2); //FF00

			Convert = new ConvertInfo(ref ptr);

			if (olt) return;
			Cs = MapDataHelper.LoadUshort(ref ptr);
		}

		public void WriteToBuffer(ref byte* ptr, bool olt)
		{
			MapDataHelper.SaveUint(ref ptr, Comp_id);
			if (!olt) Addr ^= MapDataHelper.XorKey;

			MapDataHelper.SaveUint(ref ptr, Addr);
            MapDataHelper.SaveBytes(ref ptr, unk1, olt ? 4 : 8);
			MapDataHelper.SaveString(ref ptr, xUnits, 32);
			MapDataHelper.SaveString(ref ptr, Units, 32);
			MapDataHelper.SaveString(ref ptr, zUnits, 32);
			MapDataHelper.SaveString(ref ptr, xTable, 255);
			MapDataHelper.SaveString(ref ptr, zTable, 255);

			MapDataHelper.SaveUshort(ref ptr, xPoints);
			MapDataHelper.SaveUshort(ref ptr, ShiftMask);
			*(ptr++) = zPoints;

			MapDataHelper.SaveDouble(ref ptr, xStart);
			MapDataHelper.SaveDouble(ref ptr, xEnd);

			*(ptr++) = unk2; //FF

			MapDataHelper.SaveDouble(ref ptr, Lower_lim);
			MapDataHelper.SaveDouble(ref ptr, Upper_lim);

			*(ptr++) = unk3; //FF

			MapDataHelper.SaveDouble(ref ptr, zStart);
			MapDataHelper.SaveDouble(ref ptr, zEnd);

			*(ptr++) = unk4; //FF
			*(ptr++) = Const_type;
			*(ptr++) = unk5; //FF
			*(ptr++) = gbc_thrott;

			MapDataHelper.SaveBytes(ref ptr, unk6); //0000FF	

			Convert.WriteToBuffer(ref ptr);

			if (olt) return;
			MapDataHelper.SaveUshort(ref ptr, Cs);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CtpMaps.DataTypes
{
    public enum MapEntryType: byte
    {
        //0 - folder, 
        //1 - 1d value (y=f(x)), 
        //2 - 2d value (y=f(x,z)), 
        //3 - 0d value,
        //4 - flags (Flagi komplektatsii, Maska Oshibok)
        //5 - id data (Identifikatsionnie dannie)  
        Folder = 0,
        Entry2D = 1,
        Entry3D = 2,
        Entry1D = 3,
        Flags = 4,
        Ident = 5
    }
}

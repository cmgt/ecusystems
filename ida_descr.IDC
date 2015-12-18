#include <idc.idc>

static DefArray(Addr, Descr, Count)
{
	auto	ea;
	  
      MakeComm(Addr, ltoa(Addr, 16) + " - " + Descr);		
	  MakeArray(Addr, Count);
	  
	  ea = 0;      
      while (1) 
      { 	  
          ea = FindImmediate(ea, 3, Addr);
           					 	  
          if( ea == BADADDR) 
          {
              break;
          }
          MakeComm(ea, Descr);	
      }

	Message("DefArray Adr: %x Count: %u Descr: %s\n", Addr, Count, Descr);		  
}

static DefConst(Addr, Descr, Type)
{
	auto	ea;
	  
      MakeComm(Addr, ltoa(Addr, 16) + " - " + Descr);		
	  if (Type == 1)
		MakeWord(Addr);
	  
	  ea = 0;      
      while (1) 
      { 	  
          ea = FindImmediate(ea, 3, Addr);
           					 	  
          if( ea == BADADDR) 
          {
              break;
          }
          MakeComm(ea, Descr);	
      }	

      Message("DefConst Adr: %x Type: %u Descr: %s\n", Addr, Type, Descr);	  
}


//////////////////////////////////////////////////////////////////////////
static main(void)
{
   auto     File;
   auto     Handle;
   auto     Line;
   auto     Adr;
   auto     Text;
   auto     ea;
   auto		Type;
   auto		sepIndex;
   auto		Name;
   auto		Units;
   auto		xPoints;
   auto		zPoints;

   File = AskFile(0,"*.fid", "");

   Handle = fopen(File,"rt");

   if (Handle == 0)
   {
      Warning("Error open input file %s",File);
      return;
   }

   Message("Proceed Input File: %s\n",File);

   while (1)
   {
      Line = readstr(Handle);

      if (Line == -1)
         break;

      // Parse String
	  sepIndex = strstr(Line, ":");
      	Type = atol(substr(Line, 0, sepIndex));
	  Line = substr(Line, sepIndex + 1, -1);

	  sepIndex = strstr(Line, ":");
	  Name = substr(Line, 0, sepIndex);
	  Line = substr(Line, sepIndex + 1, -1);

	  sepIndex = strstr(Line, ":");
	  Adr  = xtol(substr(Line, 0, sepIndex));
	  Line = substr(Line, sepIndex + 1, -1);

	  if (Type == 1)
	  {
		sepIndex = strstr(Line, ":");
		Units  = substr(Line, 0, sepIndex);
		Line = substr(Line, sepIndex + 1, -1);

		sepIndex = strstr(Line, ":");
		xPoints  = atol(substr(Line, 0, sepIndex));
		Line = substr(Line, sepIndex + 1, -1);

		DefArray(Adr, Name + " | " + Units, xPoints);
	  }
	  else if (Type == 2)
	  {
	    sepIndex = strstr(Line, ":");
		Units  = substr(Line, 0, sepIndex);
		Line = substr(Line, sepIndex + 1, -1);

		sepIndex = strstr(Line, ":");
		xPoints  = atol(substr(Line, 0, sepIndex));
		Line = substr(Line, sepIndex + 1, -1);

		sepIndex = strstr(Line, ":");
		zPoints  = atol(substr(Line, 0, sepIndex));
		Line = substr(Line, sepIndex + 1, -1);

		DefArray(Adr, Name + " | " + Units, xPoints * zPoints);
	  }
	  else if (Type == 3)
	  {
		sepIndex = strstr(Line, ":");
		Units  = substr(Line, 0, sepIndex);
		Line = substr(Line, sepIndex + 1, -1);
		
		sepIndex = strstr(Line, ":");
		xPoints  = atol(substr(Line, 0, sepIndex));
		Line = substr(Line, sepIndex + 1, -1);  
		
		DefConst(Adr, Name + " | " + Units, xPoints);  
	  }            
   }

   fclose(Handle);

   Warning("Done");
}


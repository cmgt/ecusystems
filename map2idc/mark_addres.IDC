#include <idc.idc>

//////////////////////////////////////////////////////////////////////////
static GetAddress(Line)
{
   return xtol(substr(Line,0,4));
}


//////////////////////////////////////////////////////////////////////////
static GetText(Line)
{
   auto  LL;

   LL = substr(Line,4,-1);
   LL = substr(LL,0,strstr(LL,"\n"));

   return LL;
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

   File = AskFile(0,"*.adr", "");

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
      Message("Read line: %s\n", Line); 

      if (Line == -1)
         break;

      // Parse String
      Adr  = GetAddress(Line);      
      Text = GetText(Line);
      Message("Adr: %s Text: %s\n", Adr, Text);

      ea = 0;      
      while (1) 
      { 	  
          ea = FindImmediate(ea, 7, Adr);
           					 	  
          if( ea == BADADDR) 
          {
              break;
          }
          MakeComm(ea, Text);	
      }
   }

   fclose(Handle);

   Warning("Done");
}


#include <idc.idc>

static main(void)
{
   auto     Adr1, Adr2;
   auto     ea;
   auto     count;

   Adr1 = xtol(AskStr("", "Enter start address:\n"));
   if (Adr1 != 0)
{
   Adr2 = xtol(AskStr("", "Enter stop address:\n"));  
  
if (Adr2 != 0)
{    
	  if (Adr2 < Adr1)
	  {
		Warning("Error. Adr2 < Adr1");
	  }
	  else
	  {
	  	  while (1) 
	  { 	  
		  ea = FindImmediate(0, 7, Adr1);
								  
		  if( ea == BADADDR) 
		  {
			  Message("%x - success\n", Adr1);
		  }
		  else
		  {         
			  Message("%x - fail\n", Adr1);
		  }
		  Adr1++;
		  if (Adr1 == Adr2) break;	
	  }
   Warning("Done");
   }
}
}
}
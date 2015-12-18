#include <idc.idc>

static main(void)
{
   auto     Adr;
   auto     comment;
   auto     ea;
   auto     count;

   Adr = xtol(AskStr("", "Enter target addres:\n"));
   if (Adr != 0)
{
   comment = AskStr("", "Enter comment string:\n");
  
if (comment != 0)
{
      ea = 0;      
      while (1) 
      { 	  
          ea = FindImmediate(ea, 7, Adr);
           					 	  
          if( ea == BADADDR) 
          {
              break;
          }
          MakeComm(ea, comment);
          count++;
          Message("Find target by addres %x\n", ea);	
      }
      Message("%d items find", count);

   Warning("Done");
}
}
}
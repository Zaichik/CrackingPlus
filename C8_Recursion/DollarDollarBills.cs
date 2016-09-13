using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8_Recursion
{
    public static class DollarDollarBills
    {
        public static void CallMakeChange()
        {
            int amount = 100;
            MakeChange(amount, 0);
        }
        public static void MakeChange(int amount, int something)
        {
            if (amount == 0)
            {
                
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.SpecialCaseDemo
{
    internal class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; }
        public IWarranty ExpressWarranty { get; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            // Ctor preconditions:
            if (moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));
            if (express == null)
                throw new ArgumentNullException(nameof(express));

            MoneyBackGuarantee = moneyBack;
            ExpressWarranty = express;
        }
    }
}

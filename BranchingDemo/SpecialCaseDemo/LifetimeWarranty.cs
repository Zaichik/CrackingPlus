using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.SpecialCaseDemo
{
    // Special Case pattern example.
    class LifetimeWarranty : IWarranty
    {
        private DateTime IssuingDate { get; }

        public LifetimeWarranty(DateTime issuingDate)
        {
            IssuingDate = issuingDate.Date;
        }
        public bool IsValidOn(DateTime date) => date.Date >= this.IssuingDate;
    }
}

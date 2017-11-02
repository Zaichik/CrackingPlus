using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.SpecialCaseDemo
{
    class TimeLimitedWarranty : IWarranty
    {
        private DateTime DateIssued { get; }
        private TimeSpan Duration { get; }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            DateIssued = dateIssued;
            Duration = TimeSpan.FromDays(duration.Days);
        }

        public bool IsValidOn(DateTime date) =>
                date.Date >= DateIssued && date.Date < DateIssued + Duration;
    }
}

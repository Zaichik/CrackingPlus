using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsLib
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class SmallDate
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public SmallDate(int month, int day, int year)
        {
            _value = day + month*32 + year*512;
        }

        private readonly int _value;

        public int Month => _value % 512 / 32;
        public int Day { get; }
        public int Year => _value / 512;

        public override string ToString()
        {
            return Month + "/" + Day + "/" + Year;
        }

        public override bool Equals(object x)
        {
            if (this == x) return true;
            if (x == null) return false;
            if (this.GetType() != x.GetType()) return false;
            QuickDate theOtherDate = (QuickDate) x;
            if (Month != theOtherDate.Month) return false;
            if (Day != theOtherDate.Day) return false;
            if (Year != theOtherDate.Year) return false;
            if (this == x) return true;

            return true;
        }
    }
}

namespace FundamentalsChapter
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class QuickDate
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public QuickDate(int month, int day, int year)
        {
            Month = month;
            Day = day;
            Year = year;
        }

        public int Month { get; }
        public int Day { get; }
        public int Year { get; }

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

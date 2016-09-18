using System;

namespace FundamentalsChapter
{
    public static class StdRandom
    {
        private static int _seed = DateTime.Now.Millisecond;
        private static Random _random = new Random(_seed);

        public static int Seed {
            get { return _seed;}
            set
            {
                _seed = value;
                _random = new Random(_seed);
            }
        }

        // Random real number uniformly in [0, 1)
        public static double Uniform()
        {
            return _random.NextDouble();
        }

        // Random int uniformly in [0, N)
        public static int Uniform(int n)
        {
            if(n <= 0) throw new ArgumentOutOfRangeException(nameof(n), "must be positive");
            return _random.Next();
        }

        [Obsolete("Use " + nameof(Uniform), error: false)]
        public static double Random()
        {
            return Uniform();
        }

        public static int Uniform(int a, int b)
        {
            if(b <= a) throw new ArgumentOutOfRangeException(nameof(a) + nameof(b), "Invalid Range");
            if((long)b - a >= Int32.MaxValue) throw new ArgumentOutOfRangeException(nameof(a) + ", " + nameof(b), "Invalid Range");
            return a + Uniform(b - a);
        }

        public static double Uniform(double a, double b)
        {
            if (!(a < b)) throw new ArgumentOutOfRangeException(nameof(a) + nameof(b), "Invalid Range");
            return a + Uniform() * (b - a);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiscConsole
{
    class Primes
    {
        public static List<uint> AllPrimes(uint from, uint to)
        {
            var result = new List<uint>();

            for (uint i = from; i <= to; i++)
                if(IsPrime(i))
                    result.Add(i);

            return result;
        }

        private static bool IsPrime(uint n)
        {
            if (n % 2 == 0 && n != 2) return false;

            uint root = (uint) Math.Ceiling(Math.Sqrt(n));

            for(uint i=3;i<=root;i+=2)
                if (n%i == 0 && n!= i) return false;

            return true;
        }

        public static List<uint> AllPrimesParallelWithLock(uint from, uint to)
        {
            var result = new List<uint>();

            Parallel.For((int) from, (int) to, i =>
            {
                if (IsPrime((uint) i))
                {
                    lock (result)
                    {
                        result.Add((uint)i);
                    }
                }
            });

            return result;
        }

        static void AtomicMultiply(ref int shared, int x)
        {
            int old, result;
            do
            {
                old = shared;
                result = old * x;
            } while (old != Interlocked.CompareExchange(ref shared, old, result));
        }
    }
}

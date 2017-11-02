using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StringsChapter;

namespace MiscConsole
{
    class Program
    {
        private const int Repetitions = 10;
        private const int From = 2;
        //private const int To = 1000000;
        private const int To =   1000000;

        static void Main(string[] args)
        {
            Driver driverA = new Driver();


            //var SuffixArray = new SuffixArray();
            //string str = "ababaa$";
            //var count = SuffixArray.SortCharacters(str);
            //for (int i = 0; i < count.Length; i++)
            //{
            //    Console.WriteLine($"{i} = {str[count[i]]}");
            //}


            //var result = RabinKarp.FindPattern("abababdabc", "abd");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Kmp2.TestMe();

            //Measure("PrimesSerial", () => Primes.AllPrimes(From, To));
            //Measure("PrimesParallel", () => Primes.AllPrimesParallelWithLock(From, To));
            //Measure("PrimesAggregate", () => Primes.AllPrimesParallelAggregated(From, To));

            //SequentialIO();
            //ParallelIO();

            Console.ReadLine();

        }
        private static void Measure(string what, Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Repetitions; ++i)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine("{0}\tAverage time: {1:0.000}ms",
                what, sw.ElapsedMilliseconds / (1.0 * Repetitions));
        }
    }
}

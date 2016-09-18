using System;

using FundamentalsChapter;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStaticSetOfInts.Run();

            var callObsoleteMethod = StdRandom.Random();

            Console.WriteLine("... Press ENTER to exit ...");
            Console.ReadLine();
        }
    }
}

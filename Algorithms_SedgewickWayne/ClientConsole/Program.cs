using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using FundamentalsLib;

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

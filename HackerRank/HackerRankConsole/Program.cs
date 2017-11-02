using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HackerRankLib;
using HackerRankLib.CTCI;

namespace HackerRankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //DijkstraShortestReach2.PrintShortestPaths();
            string a = "m";
            string b = "nm";
            Stopwatch w = Stopwatch.StartNew();
            MakingAnagrams.MakingAnagramsDictionary(a, b);
            Console.WriteLine("time: " + w.ElapsedTicks);
            w.Restart();
            MakingAnagrams.MakingAnagramsArray(a, b);
            Console.WriteLine("time: " + w.ElapsedTicks);

            Console.WriteLine("... Press ENTER to exit ...");
            Console.ReadLine();
        }
    }
}

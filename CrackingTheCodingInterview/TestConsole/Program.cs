using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C1_3_RemoveDupChars;

using C3_StacksAndQueues;

using C8_Recursion;

using MiscLib;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Uri
            //UriExamples.PrintExamples();
            //#endregion Uri

            //var myStackArray = new MyStackArraySimple(3);
            //var arr = myStackArray.AddToStackArray("abcdefg");
            //foreach (var element in arr)
            //{
            //    Console.WriteLine(element);
            //}



            //TowersOfHanoi_3_4.Start();
            //Stack<int> source = new Stack<int>(new[] { 6, 5, 4, 3, 2, 1 });
            //Stack<int> dest = new Stack<int>();
            //Stack<int> temp = new Stack<int>();
            //Console.WriteLine("source:");
            //foreach (var i in source)
            //{
            //    Console.WriteLine(i);
            //}

            //TowerT.MoveDisks(source, dest, temp, source.Count);

            //Console.WriteLine("dest:");
            //foreach (var i in dest)
            //{
            //    Console.WriteLine(i);
            //}

            //TestStackSortAsc_3_6();
            //TestStackSortAscT_3_6();

            //Task3_RemoveDuplicateChar.RemoveDuplicateChar("aabac".ToCharArray());


            TestRobotRecursion_8_2();
            //TestRobotRecursion_8_2_Try2();
            Console.ReadLine();
        }

        private static void TestStackSortAsc_3_6()
        {
            var sortedStack = StackSortAsc_3_6.SortAsc(InitCollection<int>(MyCollection.UnsortedStackInt));
            Print("Sorted Stack", sortedStack);
        }

        private static void TestStackSortAscT_3_6()
        {
            var sortedStack = StackSortAscT_3_6<char>.SortAsc(InitCollection<char>(MyCollection.UnsortedStackChar));
            Print("Sorted Stack<T>", sortedStack);
        }

        private static void TestRobotRecursion_8_2()
        {
            var paths = new Robot().GetPaths(1, 1);

            Console.WriteLine($"Count: {paths.Count}");

            int count = 0;
            foreach (var path in paths)
            {
                count++;
                Console.WriteLine($"{count}:");
                foreach (Point point in path)
                {
                    Console.WriteLine($"({point.X}, {point.Y})");
                }
            }
        }

        private static void TestRobotRecursion_8_2_Try2()
        {
            int x = 2;
            int y = 2;

            var paths = new Robot2().CalcPaths(x, y);
            int count = paths.Count;

            Console.WriteLine($"Count: {count}");
            foreach (List<Point> path in paths)
            {
                foreach (Point point in path)
                    Console.WriteLine($"({point.X}, {point.Y})");

                Console.WriteLine();
            }
        }

        #region Helpers
        private static void Print<T>(string comment, IEnumerable<T> collection)
        {
            Console.WriteLine("{0}: ", comment);
            foreach (var i in collection)
            {
                Console.WriteLine(i);
            }

        }

        private static Stack<T> InitCollection<T>(MyCollection myCollection)
        {
            Stack<T> unsortedStack;

            switch (myCollection)
            {
                case MyCollection.UnsortedStackInt:
                    unsortedStack = new Stack<int>(new[] { 3, 4, 2, 6, 1, 5, 8 }) as Stack<T>;
                    Print("Unsorted Stack<T>", unsortedStack);
                    return unsortedStack;

                case MyCollection.UnsortedStackChar:
                    unsortedStack = new Stack<char>(new[] { 'T', 'a', 't', 'y', 'a', 'n', 'a' }) as Stack<T>;
                    Print("Unsorted Stack<T>", unsortedStack);
                    return unsortedStack;

                default:
                    return null;
            }

        }

        public enum MyCollection
        {
            UnsortedStackInt = 1,
            UnsortedStackChar = 2,
        }
        #endregion
    }
}

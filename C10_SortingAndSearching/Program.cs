using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_SortingAndSearching
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchInRotatedArray = new SearchInRotatedArray<int>();
            // ReSharper disable once JoinDeclarationAndInitializer
            int index;
            //int index = searchInRotatedArray.Search(new[] {15, 16, 19, 20, 1, 3, 5, 7, 10, 14}, 5);
            //Console.WriteLine($"6 == {index}");

            //index = searchInRotatedArray.Search(new[] { 15, 16, 19, 0, 1, 3, 5, 7, 10, 14 }, 5);
            //Console.WriteLine($"6 == {index}");

            index = searchInRotatedArray.Search(new[] { 16, 19, 0, 1, 3, 5, 7, 10, 14 }, 5);
            Console.WriteLine($"5 == {index}");

            //index = searchInRotatedArray.Search(new[] { 16, 19, 0, 1, 3, 5, 7, 10, 14 }, 18);
            //Console.WriteLine($"-1 == {index}");

            //index = searchInRotatedArray.Search(new[] { 16, 19, 0, 1, 3, 5, 7, 10, 14 }, 14);
            //Console.WriteLine($"8 == {index}");

            index = searchInRotatedArray.Search(new[] { 16, 19, 0, 1, 3, 5, 7, 10, 14 }, 16);
            Console.WriteLine($"0 == {index}");

            //index = searchInRotatedArray.Search(new[] { 15, 16, 19, 0, 1}, 0);
            //Console.WriteLine($"3 == {index}");

            index = searchInRotatedArray.Search(new[] { 16, 16, 16, 16, 16, 5, 7, 10, 16 }, 10);
            Console.WriteLine($"7 == {index}");

            index = searchInRotatedArray.Search(new[] { 16, 19, 0, 1, 16, 16, 16, 16, 16 }, 19);
            Console.WriteLine($"1 == {index}");

            index = searchInRotatedArray.Search(new[] { 16, 16, 16, 16, 16, 16, 16, 19, 16 }, 19);
            Console.WriteLine($"7 == {index}, Count = {searchInRotatedArray.Count}");


            TestHeaps();

            Console.ReadLine();
        }

        private static void TestHeaps()
        {
            //System.Collections.Generic.
        }
    }
}

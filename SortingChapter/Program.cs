using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SortingChapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = {2, 5, 6, 3, 1, 4, 8, 7};
            int[] arr = {8, 7, 6, 5, 4, 3, 2, 1};
            MergeSortTopDown<int>.Sort(arr);

            Console.ReadLine();
        }

        private static void Print(int[] arr, string message)
        {
            Console.WriteLine(message);

            foreach (int item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}

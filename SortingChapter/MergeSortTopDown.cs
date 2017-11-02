using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingChapter
{
    class MergeSortTopDown<T> where T:IComparable
    {
        private static T[] _aux;

        public static void Sort(T[] a)
        {
            _aux = new T[a.Length];
            Sort(a, 0, a.Length - 1, String.Empty);
            Print(a, "Sorted: ");
        }

        private static void Sort(T[] a, int lo, int hi, string spacer)
        {
            if (hi <= lo) return;
            Print(a, $"{spacer}Sort({lo}, {hi})");
            int mid = (lo + hi) / 2;
            Sort(a, lo, mid, spacer + "   ");
            Sort(a, mid + 1, hi, spacer + "   ");
            Merge(a, lo, mid, hi, spacer + "   ");
        }

        private static void Merge(T[] a, int lo, int mid, int hi, string spacer)
        {
            int left = lo;
            int midPlus = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                _aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (left > mid)
                    a[k] = _aux[midPlus++];
                else if(midPlus > hi)
                    a[k] = _aux[left++];
                else if(_aux[midPlus].CompareTo(_aux[left]) < 0)
                    a[k] = _aux[midPlus++];
                else
                    a[k] = _aux[left++];
            }
        }

        private static void Print(T[] arr, string message)
        {
            Console.WriteLine(message);

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

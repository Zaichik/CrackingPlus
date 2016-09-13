using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_StacksAndQueues
{
    public class StackSortAsc_3_6
    {
        public static Stack<int> SortAsc(Stack<int> orig)
        {
            if (orig.Count < 2) return orig;

            var sorted = new Stack<int>();

            while (orig.Count > 0)
            {
                var popped = orig.Pop();

                while (sorted.Count > 0 && sorted.Peek() < popped)
                {
                    orig.Push(sorted.Pop());
                }

                sorted.Push(popped);
            }

            return sorted;
        }
    }

    public class StackSortAscT_3_6<T> where T:IComparable
    {
        public static Stack<T> SortAsc(Stack<T> orig)
        {
            if (orig.Count < 2) return orig;

            var sorted = new Stack<T>();

            while (orig.Count > 0)
            {
                var popped = orig.Pop();

                while (sorted.Count > 0 && sorted.Peek().CompareTo(popped) < 0)
                {
                    orig.Push(sorted.Pop());
                }

                sorted.Push(popped);
            }

            return sorted;
        }
    }

}

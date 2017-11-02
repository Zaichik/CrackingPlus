using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo.IteratorDemo
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence.Aggregate((T) null, (best, cur) =>
                    best == null || criterion(cur).CompareTo(criterion(best)) < 0
                        ? cur
                        : best);
    }
}

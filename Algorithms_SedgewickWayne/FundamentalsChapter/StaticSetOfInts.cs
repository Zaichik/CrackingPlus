using System;

namespace FundamentalsChapter
{
    public class StaticSetOfInts
    {
        private readonly int[] _a;

        public StaticSetOfInts(int[] keys)
        {
            _a = new int[keys.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                _a[i] = keys[i]; // defensive copy
            }
            Array.Sort(_a);
        }

        public bool Contains(int key)
        {
            return Rank(key) != -1;
        }

        public int Rank(int key)
        {
            // Binary search
            int lo = 0;
            int hi = _a.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < _a[mid])
                    hi = mid - 1;
                else if (key > _a[mid])
                    lo = mid + 1;
                else
                    return mid;
            }
            return -1;
        }
    }
}

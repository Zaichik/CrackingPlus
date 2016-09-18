using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.SymbolTable
{
    public class BinarySearchST<Key, Value> : IEnumerable<Key> where Key : IComparable<Key>
    {
        private Key[] keys;
        private Value[] vals;

        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];
        }

        public int Size { get; private set; }

        public Value Get(Key key)
        {
            if (Size == 0)
                return default(Value);

            int rank = Rank(key);
            if (rank < Size && keys[rank].CompareTo(key) == 0)
                return vals[rank];
            else
                return default(Value);
        }

        public int Rank(Key key)
        {
            int lo = 0;
            int hi = Size - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0)
                    hi = mid - 1;
                else if (cmp > 0)
                    lo = mid + 1;
                else
                    return mid;
            }

            return lo;
        }

        public void Put(Key key, Value value)
        {
            int rank = Rank(key);
            if (rank < Size && keys[rank].CompareTo(key) == 0)
            {
                vals[rank] = value;
                return;
            }

            for (int j = Size; j < rank; j--)
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }

            keys[rank] = key;
            vals[rank] = value;
            Size++;
        }

        public void Delete(Key key)
        {
            int rank = Rank(key);
            //if()

        }

        public Key Min()
        {
            throw new NotImplementedException();
        }

        public Key Max()
        {
            throw new NotImplementedException();
        }

        public Key Floor(Key key)
        {
            throw new NotImplementedException();
        }

        public Key Ceiling(Key key)
        {
            throw new NotImplementedException();
        }

        public Key Select(int k)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Key> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

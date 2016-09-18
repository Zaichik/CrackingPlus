using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree.BinaryTrees
{
    public class RedBlackTree<Key, Value> where Key : IComparable<Key>
    {
        private Node _root;
        private class Node
        {
            internal Key Key;
            internal Value Val;
            internal Node Left;
            internal Node Right;
            internal int N;

            public Node(Key key, Value val, int n)
            {
                this.Key = key;
                this.Val = val;
                N = n;
            }
        }

        public int Size()
        {
            return Size(_root);
        }

        private static int Size(Node x)
        {
            return x?.N ?? 0;
        }

        public Value Get(Key key)
        {
            return Get(_root, key);
        }

        private Value Get(Node x, Key key)
        {
            if (x == null) return default(Value);

            var compareTo = key.CompareTo(x.Key);

            if (compareTo < 0)
                return Get(x.Left, key);

            if (compareTo > 0)
                return Get(x.Right, key);
                
            return x.Val;
        }

        public void Put(Key key, Value val)
        {
            Put(_root, key, val);
        }

        private Node Put(Node x, Key key, Value val)
        {
            if (x == null)
                return new Node(key, val, 1);

            int cmp = key.CompareTo(x.Key);
            if(cmp < 0)
                x.Left = Put(x.Left, key, val);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, val);
            else
                x.Val = val;

            x.N = Size(x.Left) + Size(x.Right) + 1;

            return x;
        }

        public Key Min()
        {
            return Min(_root).Key;

        }

        private Node Min(Node x)
        {
            if (x.Left == null)
                return x;

            return Min(x.Left);
        }

        public Key Floor(Key key)
        {
            Node x = Floor(_root, key);
            return x == null
                    ? default(Key)
                    : x.Key;
        }

        private Node Floor(Node x, Key key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;

            if (cmp < 0)
                return Floor(x.Left, key);

            Node t = Floor(x.Right, key);
            return t ?? x;
        }

        public Key Select(int k)
        {
            return Select(_root, k).Key;
        }

        // TODO: understand
        private Node Select(Node x, int rank)
        {
            if (x == null)
                return null;
            int t = Size(x.Left);
            if (t > rank)
                return Select(x.Left, rank);

            if (t < rank)
                return Select(x.Right, rank - t - 1);

            return x;
        }

        public int Rank(Key key)
        {
            return Rank(key, _root);
        }

        // TODO: understand
        private int Rank(Key key, Node x)
        {
            if (x == null)
                return 0;

            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Rank(key, x.Left);

            if (cmp > 0)
                return 1 + Size(x.Left) + Rank(key, x.Right);

            return Size(x.Left);
        }

        public void DeleteMin()
        {
            _root = DeleteMin(_root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null) return x.Right;

            x.Left = DeleteMin(x.Left);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public void DeleteMax()
        {

        }

        private void DeleteMax(Node x)
        {

        }

        public void Delete(Key key)
        {

        }
        private void Delete(Node x)
        {

        }

    }
}

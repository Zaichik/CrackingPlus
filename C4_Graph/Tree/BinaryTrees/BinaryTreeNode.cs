// 
// Copyright (c) 2016, Elekta AB
// 

using System;
using System.Runtime.Remoting;

namespace C4_Graph.Tree.BinaryTrees
{
    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
    {
        internal T Value;
        internal BinaryTreeNode<T> Parent;
        internal BinaryTreeNode<T> LeftChild;
        internal BinaryTreeNode<T> RightChild;

        public BinaryTreeNode(T value)
        {
            if(value == null) throw new ArgumentNullException("TODO message");

            Value = value;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }

        public override string ToString() => Value.ToString();

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BinaryTreeNode<T> other = (BinaryTreeNode<T>) obj;
            return CompareTo(other) == 0;
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
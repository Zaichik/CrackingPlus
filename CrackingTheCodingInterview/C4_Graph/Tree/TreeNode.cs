using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree
{
    public class TreeNode<T>
    {
        public T Value;
        private bool _hasParent;

        private readonly List<TreeNode<T>> _children;

        public TreeNode(T value)
        {
            if(value == null) throw new ArgumentNullException("TODO");

            Value = value;
            _children = new List<TreeNode<T>>();
        }

        public int ChildrenCount => _children.Count;

        public void AddChild(TreeNode<T> child)
        {
            if(child == null) throw new ArgumentNullException("TODO");

            if(child._hasParent) throw new ArgumentException("The node already has a parent.");

            child._hasParent = true;
            _children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            if(index > (_children.Count-1) ) throw new ArgumentOutOfRangeException("Invalid index");

            return _children[index];
        }
    }
}

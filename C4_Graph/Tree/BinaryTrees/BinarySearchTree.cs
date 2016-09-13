using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree.BinaryTrees
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        public void Insert(T value)
        {
            Insert(value, null, _root);
        }

        private void Insert(T value, BinaryTreeNode<T> parent, BinaryTreeNode<T> node)
        {
            if (node == null) // root node
            {
                _root = new BinaryTreeNode<T>(value);
                return;
            }

            while (node != null)
            {
                var compareToCurr = value.CompareTo(node.Value);
                if(compareToCurr == 0) return;

                parent = node;
                node = compareToCurr < 0
                        ? node.LeftChild
                        : node.RightChild;
            }
        }

        public BinaryTreeNode<T> Find(T value)
        {
            if (value == null) return null;

            return Find(new BinaryTreeNode<T>(value), _root);
        }

        private BinaryTreeNode<T> Find(BinaryTreeNode<T> findNode, BinaryTreeNode<T> currNode)
        {
            while (currNode != null)
            {
                var compareToCurr = findNode.Value.CompareTo(currNode.Value);
                if (compareToCurr == 0)
                    return currNode;

                currNode = compareToCurr < 0
                        ? currNode.LeftChild
                        : currNode.RightChild;
            }

            return null;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public void Remove(T value)
        {
            var nodeToRemove = Find(value);
            if(nodeToRemove != null)
                Remove(nodeToRemove);
        }

        private void Remove(BinaryTreeNode<T> nodeToRemove)
        {
            if (nodeToRemove.LeftChild != null && nodeToRemove.RightChild != null)
            {
                var replacementNode = nodeToRemove.RightChild;
                while (replacementNode.LeftChild != null)
                {
                    replacementNode = replacementNode.LeftChild;
                }
                nodeToRemove.Value = replacementNode.Value;
                nodeToRemove = replacementNode;
            }

            var child = nodeToRemove.LeftChild ?? nodeToRemove.RightChild;
            if (child != null)
            {
                if (nodeToRemove.Parent == null)
                    _root = child;
                else
                {
                    if (ReferenceEquals(nodeToRemove.Parent.LeftChild, nodeToRemove))
                        nodeToRemove.Parent.LeftChild = nodeToRemove;
                    else
                        nodeToRemove.Parent.RightChild = nodeToRemove;
                }

                return;
            }

            //no children
            if (nodeToRemove.Parent == null) // deleting the root node
                _root = null;
            else
            {
                if (ReferenceEquals(nodeToRemove.Parent.LeftChild, nodeToRemove))
                    nodeToRemove.Parent.LeftChild = null;
                else
                    nodeToRemove.Parent.RightChild = null;
            }
        }
    }
}

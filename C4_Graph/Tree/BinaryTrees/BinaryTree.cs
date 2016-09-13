using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree.BinaryTrees
{
    public class BinaryTree<T>
    {
        public T Value { get; set; }
        public BinaryTree<T> LeftChild { get; }
        public BinaryTree<T> RightChild { get; }

        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public BinaryTree(T value) : this(value, null, null)
        {
        }

        public void PrintInOrder()
        {
            LeftChild?.PrintInOrder();
            Console.WriteLine(Value);
            RightChild?.PrintInOrder();
        }

        public void PrintPreOrder()
        {
            Console.WriteLine(Value);
            LeftChild?.PrintPreOrder();
            RightChild?.PrintPreOrder();
        }

        public void PrintPostOrder()
        {
            Console.WriteLine(Value);
            LeftChild?.PrintPostOrder();
            RightChild?.PrintPostOrder();
        }

        public static void BinaryTreeExample()
        {
            BinaryTree<int> binaryTree = 
                new BinaryTree<int>(14,
                    new BinaryTree<int>(19,
                        new BinaryTree<int>(23),
                        new BinaryTree<int>(6,
                            new BinaryTree<int>(10),
                            new BinaryTree<int>(21))),
                    new BinaryTree<int>(15,
                        new BinaryTree<int>(3), null));
            Console.WriteLine("Print in-order:");
            binaryTree.PrintInOrder();
            Console.WriteLine("Print pre-order:");
            binaryTree.PrintPreOrder();
            Console.WriteLine("Print post-order:");
            binaryTree.PrintPostOrder();
        }
    }
}

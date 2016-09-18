using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; }

        public Tree(T value)
        {
            if(value == null) throw new ArgumentNullException();

            Root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children): this(value)
        {
            foreach (Tree<T> child in children)
                Root.AddChild(child.Root);
        }

        public void TraverseDFS()
        {
            PrintDFS(Root, String.Empty);
        }

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (root == null) return;

            Console.WriteLine(spaces + root.Value);
            for (int index = 0; index < root.ChildrenCount; index++)
            {
                PrintDFS(root.GetChild(index), spaces + "   ");
            }
        }
    }
}

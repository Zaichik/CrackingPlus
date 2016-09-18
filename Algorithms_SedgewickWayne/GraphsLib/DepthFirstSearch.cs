using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public class DepthFirstSearch
    {
        private readonly bool[] _marked;
        private int _count;

        public int Count => _count;

        public bool Marked(int v) => _marked[v];

        public DepthFirstSearch(Graph g, int s)
        {
            _marked = new bool[g.V];
            //DFS(g, s);
            DFSNonRecursive(g, s);
        }

        private void DFS(Graph g, int v)
        {
            _count++;
            _marked[v] = true;
            foreach(int w in g.Adj[v])
            {
                if(!_marked[w])
                    DFS(g, w);
            }
        }

        private void DFSNonRecursive(Graph g, int v)
        {
            _count++;
            _marked[v] = true;
            var stack = new Stack<int>();
            stack.Push(v);
            while (stack.Count > 0)
            {
                int vertex = stack.Pop();
                foreach (int w in g.Adj[vertex])
                {
                    if (!_marked[w])
                    {
                        stack.Push(w);
                        _marked[w] = true;
                        _count++;
                    }
                }
            }
        }
    }
}

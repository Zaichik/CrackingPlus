using System.Collections.Generic;

namespace GraphsChapter
{
    public class DepthFirstPaths
    {
        private readonly bool[] _marked;
        private readonly int[] _edgeTo;
        private readonly int _s;

        public bool HasPathTo(int v) => _marked[v];

        public DepthFirstPaths(Graph g, int s)
        {
            _s = s;
            _edgeTo = new int[g.V];
            _marked = new bool[g.V];
            DFS(g, s);
        }

        private void DFS(Graph g, int v)
        {
            _marked[v] = true;
            foreach (int w in g.Adj[v])
            {
                if (!_marked[w])
                {
                    _marked[w] = true;
                    _edgeTo[w] = v;
                    DFS(g, w);
                }
            }
        }

        public IEnumerable<int> PathTo(int v)
        {
            if(!HasPathTo(v)) return null;

            var path = new Stack<int>();
            for (int i = v; i != _s; i = _edgeTo[i])
                path.Push(i);

            path.Push(_s);
            return path;
        }
    }
}
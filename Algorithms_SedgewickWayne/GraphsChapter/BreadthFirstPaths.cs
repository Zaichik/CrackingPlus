using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GraphsChapter
{
    public class BreadthFirstPaths
    {
        private readonly bool[] _marked;
        private readonly int[] _edgeTo;
        private readonly int[] _distTo;

        public bool HasPathTo(int v) => _marked[v];
        public int DistTo(int v) => _distTo[v];

        public BreadthFirstPaths(Graph g, int s)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _distTo = new int[g.V];
            for (int i = 0; i < g.V; i++)
                _distTo[i] = int.MaxValue;

            BFS(g, s);

            Debug.Assert(Check(g, s), "Check failed");
        }

        public BreadthFirstPaths(Graph g, IEnumerable<int> sources)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _distTo = new int[g.V];
            for (int i = 0; i < g.V; i++)
                _distTo[i] = int.MaxValue;

            BFS(g, sources);
        }

        private void BFS(Graph g, IEnumerable<int> sources)
        {
            var q = new Queue<int>();
            foreach (int source in sources)
            {
                _marked[source] = true;
                _distTo[source] = 0;
                q.Enqueue(source);
            }
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                var edges = g.Adj[v];
                foreach (int edge in edges)
                {
                    if (!_marked[edge])
                    {
                        _distTo[edge] = _distTo[v] + 1;
                        _edgeTo[edge] = v;
                        _marked[edge] = true;
                        q.Enqueue(edge);
                    }
                }
            }
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;

            Stack<int> path = new Stack<int>();
            int w = 0;
            for (w = v; _distTo[w] != 0; w = _edgeTo[w])
                path.Push(w);

            path.Push(w);

            return path;
        }

        private bool Check(Graph g, int s)
        {
            if (_distTo[s] != 0)
            {
                Console.WriteLine($"Distance of source {s} to itself = {_distTo[s]}.");
                return false;
            }


            // TODO
            // check that for each edge v-w dist[w] <= dist[v] + 1
            // provided v is reachable from s
            for (int v = 0; v < g.V; v++)
            {
                foreach (int w in g.Adj[v])
                {
                    if (HasPathTo(w) != HasPathTo(v))
                    {
                        Console.WriteLine();
                        Console.WriteLine("edge " + v + "-" + w);
                        Console.WriteLine("hasPathTo(" + v + ") = " + HasPathTo(v));
                        Console.WriteLine("hasPathTo(" + w + ") = " + HasPathTo(w));
                        return false;
                    }
                    if (HasPathTo(v) && _distTo[w] > _distTo[v] + 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("edge " + v + "-" + w);
                        Console.WriteLine("DistTo(" + v + ") = " + DistTo(v));
                        Console.WriteLine("DistTo(" + w + ") = " + DistTo(w));
                        return false;
                    }
                }
            }

            // TODO
            // check that v = edgeTo[w] satisfies distTo[w] = distTo[v] + 1
            // provided v is reachable from s
            for (int w = 0; w < g.V; w++)
            {
                if (!HasPathTo(w) || w == s) continue;
                int v = _edgeTo[w];
                if (DistTo(w) != DistTo(v) + 1)
                {
                    Console.WriteLine("shortest path edge " + v + "-" + w);
                    Console.WriteLine("DistTo[" + v + "] = " + DistTo(v));
                    Console.WriteLine("DistTo[" + w + "] = " + DistTo(w));
                    return false;
                }
            }

            return true;
        }

        private void BFS(Graph g, int s)
        {
            var q = new Queue<int>();
            q.Enqueue(s);
            _marked[s] = true;

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                var edges = g.Adj[v];
                foreach (int w in edges)
                {
                    if (!_marked[w])
                    {
                        _edgeTo[w] = v;
                        _distTo[w] = _distTo[v] + 1;
                        _marked[w] = true;
                        q.Enqueue(w);
                    }
                }
            }
        }
    }
}

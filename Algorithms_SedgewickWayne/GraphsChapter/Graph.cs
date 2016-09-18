using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsChapter
{
    public class Graph
    {
        public int V { get;}
        public int E { get; private set; }
        public List<int>[] Adj { get; }

        public Graph(int v)
        {
            if (V < 0) throw new ArgumentOutOfRangeException(nameof(v), "Number of vertices must be nonnegative");
            V = v;
            Adj = new List<int>[V];
            for (int i = 0; i < V; i++)
                Adj[i] = new List<int>();
        }

        public Graph(string[] input):this(int.Parse(input[0]))
        {
            if (input.Length < 3) throw new ArgumentException("Where are the edges??");
            int edgeCount = int.Parse(input[1]);
            for (int i = 2; i < edgeCount; i++)
            {
                int[] line = Array.ConvertAll(input[i].Split(' '), int.Parse);
                AddEdge(line[0], line[1]);
            }
        }

        /// <summary> Deep copy </summary>
        public Graph(Graph g):this(g.V)
        {
            E = g.E;
            for (int v = 0; v < g.V; v++)
                foreach (int w in g.Adj[v])
                    Adj[v].Add(w);
        }

        private void validateVertex(int v)
        {
            if (v < 0 || v >= V)
                throw new ArgumentOutOfRangeException(nameof(v), $"Not between 0 & {V-1}");
        }

        public void AddEdge(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            E++;
            Adj[v].Add(w);
            Adj[w].Add(v);
        }

        public int Degree(int v)
        {
            validateVertex(v);
            return Adj[v].Count;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append(V + " vertices, " + E + " edges \n");
            for (int v = 0; v < V; v++)
            {
                s.Append(v + ": ");
                foreach (int w in Adj[v])
                {
                    s.Append(w + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}

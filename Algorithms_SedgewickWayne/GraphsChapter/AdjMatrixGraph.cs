using System;
using System.Text;

namespace GraphsChapter
{
    public class AdjMatrixGraph
    {
        public int V { get; }
        public int E { get; private set; }
        public bool[,] Adj { get; }

        public AdjMatrixGraph(int v)
        {
            if (V < 0) throw new ArgumentOutOfRangeException(nameof(v), "Number of vertices must be nonnegative");
            V = v;
            Adj = new bool[V, V];
        }

        public AdjMatrixGraph(string[] input):this(int.Parse(input[0]))
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
        public AdjMatrixGraph(AdjMatrixGraph g) :this(g.V)
        {
            E = g.E;
            for (int v = 0; v < g.V; v++)
                for (int w = 0; w < g.E; w++)
                    Adj[v,w] = g.Adj[v,w];
        }

        private void validateVertex(int v)
        {
            if (v < 0 || v >= V)
                throw new ArgumentOutOfRangeException(nameof(v), $"Not between 0 & {V - 1}");
        }

        public void AddEdge(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            if(!Adj[v,w])
                E++;

            Adj[v,w] = true;
            Adj[w,v] = true;
        }

        public int Degree(int v)
        {
            validateVertex(v);
            int count = 0;
            for (int w = 0; w < V; w++)
                if (Adj[v, w])
                    count++;
            return count;
        }

        public bool Contains(int v, int w) =>Adj[v, w];

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append(V + " vertices, " + E + " edges \n");
            for (int v = 0; v < V; v++)
            {
                s.Append(v + ": ");
                for (int w = 0; w < E; w++)
                {
                    if(Adj[v,w])
                    s.Append(w + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static C4_Graph.Skiena.Constants;

namespace C4_Graph.Skiena
{
    public class GraphSearch
    {
        readonly bool[] _processed = new bool[MaxV];
        readonly bool[] _discovered = new bool[MaxV];
        readonly int[] _parent = new int[MaxV];
        public int Edges = 0;

        public GraphSearch(GraphT g)
        {
            for (int i = 1; i < g.VertexCount; i++)
                _parent[i] = -1;
        }

        public void BFS(GraphT g, int start)
        {
            var q = new Queue<int>();

            q.Enqueue(start);
            _discovered[start] = true;

            while (q.Count > 0)
            {
                int currV = q.Dequeue();
                ProcessVertexEarly(currV);
                _processed[currV] = true;

                EdgeNode adjNode = g.Edges[currV];
                while (adjNode != null)
                {
                    int y = adjNode.Y;

                    if (_processed[y] == false)
                        ProcessEdge(currV, y);

                    if (_discovered[y] == false)
                    {
                        q.Enqueue(y);
                        _discovered[y] = true;
                        _parent[y] = currV;
                    }

                    adjNode = adjNode.Next;
                }

                ProcessVertextLate(currV);
            }
        }

        private void ProcessVertextLate(int i)
        {
        }

        private void ProcessEdge(int i, int i1)
        {
            Console.WriteLine($"Processed edge {i} -> {i1}");
            Edges++;
        }

        private void ProcessVertexEarly(int v)
        {
            Console.WriteLine($"Processed vertex {v}");
        }

        public void FindPath(int start, int end, int[] parents)
        {
            Console.WriteLine("FindPath()");
            if(start == end || end == -1)
                Console.WriteLine($"{start}");
            else
            {
                FindPath(start, parents[end],parents);
                Console.WriteLine($"{end}");
            }
        }
    }
}

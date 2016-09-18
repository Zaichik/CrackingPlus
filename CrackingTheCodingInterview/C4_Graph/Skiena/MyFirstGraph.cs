// 
// Copyright (c) 2016, Elekta AB
// 

using System;
using System.IO;

using C4_Graph.Skiena;

namespace C4_Graph
{
    public class EdgeNode
    {
        public int Y { get; set; }
        public int Weight { get; set; }
        public EdgeNode Next { get; set; }
    }


    public class GraphT
    {
        public EdgeNode[] Edges = new EdgeNode[Constants.MaxV + 1];
        public int[] Degree = new int[Constants.MaxV + 1];
        public int VertexCount;
        public int EdgesCount;
        public bool Directed;

    }
    public class MyFirstGraph
    {
        public void ReadGraph(GraphT graphT, bool directed)
        {
            InitializeGraph(graphT, directed);

            Console.WriteLine("Enter number of vertices: ");
            graphT.VertexCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of edges: ");
            int numOfEdges = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter x y:");
            for (int i = 1; i <= numOfEdges; i++)
            {
                string[] strs = Console.ReadLine().Split(' ');
                int[] xy = Array.ConvertAll(strs, Int32.Parse);
                InsertEdge(xy[0], xy[1], directed, graphT);
            }
        }

        private void InitializeGraph(GraphT graphT, bool directed)
        {
            for (int i = 1; i <= Constants.MaxV; i++)
            {
                graphT.Degree[i] = 0;
                graphT.Edges[i] = null;
            }
        }

        private void InsertEdge(int x, int y, bool directed, GraphT graphT)
        {
            EdgeNode p = new EdgeNode
            {
                Y = y,
                Next = graphT.Edges[x]
            };

            graphT.Edges[x] = p;
            graphT.Degree[x]++;

            if (directed)
                graphT.EdgesCount++;
            else
                InsertEdge(y, x, directed: true, graphT: graphT);
        }

        public void PrintGraph(GraphT graphT)
        {
            EdgeNode p;

            Console.WriteLine("GraphT:");
            for (int i = 1; i <= graphT.VertexCount; i++)
            {
                Console.WriteLine($"Edges for {i}: ");
                p = graphT.Edges[i];
                while (p!= null)
                {
                    Console.WriteLine($"{p.Y}");
                    p = p.Next;
                }
                Console.WriteLine();
            }
        }


    }
}
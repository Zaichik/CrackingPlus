// 
// Copyright (c) 2016, Elekta AB
// 

using System;
using System.Collections.Generic;

namespace C4_Graph.MySnakesAndLadders
{
    public class MySnakesAndLadders
    {
        public int stepCount = -1;

        public void ReadGraph(MySnakesAndLaddersGraph graph)
        {
            //InitWithCmdPrompt(graph);
            InitWithTestData(graph);

            InitializeGraph(graph);
            BFS(graph, 1);
            FindPath(1, 100, graph.Parents);
            Console.WriteLine($"StepCount = {stepCount}");
        }

        private void InitWithCmdPrompt(MySnakesAndLaddersGraph graph)
        {
            Console.WriteLine("Enter number of ladders: ");

            int ladderCount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter x y:");
            for (int i = 1; i <= ladderCount; i++)
            {
                string[] strs = Console.ReadLine().Split(' ');
                int[] xy = Array.ConvertAll(strs, Int32.Parse);
                graph.Ladders[xy[0]] = xy[1];
            }

            Console.WriteLine("Enter number of snakes: ");

            int snakeCount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter x y:");
            for (int i = 1; i <= snakeCount; i++)
            {
                string[] strs = Console.ReadLine().Split(' ');
                int[] xy = Array.ConvertAll(strs, Int32.Parse);
                graph.Snakes[xy[0]] = xy[1];
            }
        }

        private void InitWithTestData(MySnakesAndLaddersGraph graph)
        {
            graph.Ladders[32] = 62;
            graph.Ladders[42] = 68;
            graph.Ladders[12] = 98;

            graph.Snakes[95] = 13;
            graph.Snakes[97] = 25;
            graph.Snakes[93] = 37;
            graph.Snakes[79] = 27;
            graph.Snakes[75] = 19;
            graph.Snakes[49] = 47;
            graph.Snakes[67] = 17;

        }

        private void InitializeGraph(MySnakesAndLaddersGraph graph)
        {
            for (int vertex = 1; vertex < 100; vertex++)
            {
                graph.AdjNodes[vertex] = new List<Node>();
                for (int edgeVertext = vertex + 1; (edgeVertext <= vertex + 6) && edgeVertext <= 100; edgeVertext++)
                {
                    if(graph.Snakes[edgeVertext] > 0)
                        InsertEdge(vertex, graph.Snakes[edgeVertext], graph);
                    else if (graph.Ladders[edgeVertext] > 0)
                        InsertEdge(vertex, graph.Ladders[edgeVertext], graph);
                    else
                        InsertEdge(vertex, edgeVertext, graph);
                }
                graph.AdjNodes[vertex].Sort(CompareNodes);
            }
        }

        private int CompareNodes(Node x, Node y)
        {
            if (x.Val == y.Val)
                return 0;
            if (x.Val < y.Val)
                return 1;
            return -1;
        }

        private void InsertEdge(int x, int y, MySnakesAndLaddersGraph graph)
        {
            Node p = new Node
            {
                Val = y,
            };

            graph.AdjNodes[x].Add(p);
        }

        public void BFS(MySnakesAndLaddersGraph graph, int start)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(start);
            graph.Discovered[start] = true;

            while (q.Count > 0)
            {
                int currVertext = q.Dequeue();
                List<Node> edgeNodes = graph.AdjNodes[currVertext];
                if(edgeNodes == null) continue;
                
                foreach (var edgeNode in edgeNodes)
                {
                    int edgeVertex = edgeNode.Val;
                    if (graph.Discovered[edgeVertex] ==  false)
                    {
                        q.Enqueue(edgeVertex);
                        graph.Discovered[edgeVertex] = true;
                        graph.Parents[edgeVertex] = currVertext;
                    }
                }
            }
        }

        public void FindPath(int start, int end, int[] parents)
        {
            if (start == end || end == -1)
            {
                stepCount++;
                //Console.WriteLine($"Start = {start}");
            }
            else
            {
                stepCount++;
                FindPath(start, parents[end], parents);
                //Console.WriteLine($"{end}");
            }
        }
    }
}
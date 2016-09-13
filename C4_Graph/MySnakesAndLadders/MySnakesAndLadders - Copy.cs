// 
// Copyright (c) 2016, Elekta AB
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using C4_Graph.Skiena;

namespace C4_Graph.MySnakesAndLadders
{
    public class MySnakesAndLaddersOld
    {
        public int stepCount = -1;

        public void ReadGraph(MySnakesAndLaddersGraph graph)
        {
            //InitWithCmdPrompt(graph);
            InitWithTestData(graph);

            InitializeGraph(graph);
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

        //private void InitializeGraph(MySnakesAndLaddersGraph graph)
        //{
        //    for (int i = 1; i <= Constants.MaxV; i++)
        //    {
        //        graph.AdjNodes[i] = null;
        //    }
        //}
        private void InitializeGraph(MySnakesAndLaddersGraph graph)
        {
            for (int vertex = 1; vertex < Constants.MaxV; vertex++)
            {
                for (int edgeVertext = vertex + 1; (edgeVertext <= vertex + 6) && edgeVertext <= 100; edgeVertext++)
                {
                    if(graph.Snakes[edgeVertext] > 0)
                        InsertEdge(vertex, graph.Snakes[edgeVertext], true, graph);
                    else if (graph.Ladders[edgeVertext] > 0)
                        InsertEdge(vertex, graph.Ladders[edgeVertext], true, graph);
                    else
                        InsertEdge(vertex, edgeVertext, true, graph);
                }
            }
        }

        private void InsertEdge(int x, int y, bool directed, MySnakesAndLaddersGraph graph)
        {
            //Node p = new Node
            //{
            //    Val = y,
            //    //Next = graph.AdjNodes[x]
            //};

            //graph.AdjNodes[x] = p;
        }

        public void PrintGraph(MySnakesAndLaddersGraph graph)
        {
            //Node p;
            //Console.WriteLine("GraphT:");
            //p = graph.AdjNodes[1];
            //while (p != graph.AdjNodes[100])
            //{
            //    //Console.WriteLine($"Edges for {i}: ");
            //    //p = graph.AdjNodes[i];
            //    int val = 0;
            //    int index = 0;
            //    while (true)
            //    {
            //        if (val < p.Val)
            //        {
            //            biggestNode = p;
            //            val = p.Val;
            //        }
            //        p = p.Next;
            //    }
            //    count++;

            //    indexNextNode += index;
            //}
            //Queue<int> temp = new Queue<int>();
            //Console.WriteLine();
        }

        public void BFS(MySnakesAndLaddersGraph graph, int start)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(start);
            graph.Discovered[start] = true;

            while (q.Count > 0)
            {
                int currVertext = q.Dequeue();
                //Node edgeNode = graph.AdjNodes[currVertext];
                //while (edgeNode != null)
                //{
                //    int edgeVertex = edgeNode.Val;
                //    if (graph.Discovered[edgeVertex] ==  false)
                //    {
                //        q.Enqueue(edgeVertex);
                //        graph.Discovered[edgeVertex] = true;
                //        graph.Parents[edgeVertex] = currVertext;
                //    }
                //    edgeNode = edgeNode.Next;
                //}
            }
        }

        public void FindPath(int start, int end, int[] parents)
        {
            if (start == end || end == -1)
            {
                stepCount++;
                Console.WriteLine($"{start}");
            }
            else
            {
                stepCount++;
                FindPath(start, parents[end], parents);
                Console.WriteLine($"{end}");
            }

            Console.WriteLine($"{stepCount}");
        }
    }
}
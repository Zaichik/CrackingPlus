using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HackerRankLib
{
    public class DijkstraShortestReach2
    {
        private class Node
        {
            public int V;
            public int W;
            public Node Next;
        }


        public static void PrintShortestPaths()
        {
            Stopwatch watch = new Stopwatch();
            long inputTime = 0;
            long calcTime = 0;
            long dictTime = 0;
            const string neg = "-1 ";
            
            watch.Start();
            Dictionary<int, int>[] edges = new Dictionary<int, int>[3000 + 1];
            var parse = new Dictionary<string, int>();
            for (int b = 1; b <= 3000; b++)
            {
                parse[b.ToString()] = b;
                edges[b] = new Dictionary<int, int>();
            }
            dictTime = watch.ElapsedMilliseconds;

            int start = 0;
            int n = 0;
            //Node[] edges = null;
            int[] distance = null;
            int[] parent = null;
            bool[] inTree = null;
            
            try
            {
                watch.Start();
                //using (StreamReader sr = new StreamReader(@"C:\RD\Training\CrackingPlus\HackerRankLib\DijkstraShortestReach2.txt"))
                //using (StreamReader sr = new StreamReader(@"C:\RD\Training\CrackingPlus\HackerRankLib\mediumEWG.txt"))
                //using (StreamReader sr = new StreamReader(@"C:\RD\Training\CrackingPlus\HackerRankLib\N3000Heavy.txt"))
                using (StreamReader sr = new StreamReader(@"C:\RD\Training\CrackingPlus\HackerRankLib\N3000.txt"))
                {
                    int cases = Convert.ToInt32(sr.ReadLine());
                    string inX = string.Empty;
                    string inY = string.Empty;
                    int inW = 0;
                    for (int i = 0; i < cases; i++)
                    {
                        string[] tokens = sr.ReadLine().Split(' ');
                        n = int.Parse(tokens[0]);
                        int m = int.Parse(tokens[1]);
                        //edges = new Node[n + 1];

                        inTree = new bool[n + 1];
                        distance = new int[n + 1];
                        parent = new int[n + 1];
                        //var parse = new Dictionary<string, int>();
                        for (int b = 1; b <= n; b++)
                        {
                            //    parse[b.ToString()] = b;
                            distance[b] = int.MaxValue;
                            parent[b] = -1;
                        }

                        for (int x = 0; x < m; x++)
                        {
                            string[] newNode = sr.ReadLine().Split(' ');
                            inX = newNode[0];
                            inY = newNode[1];
                            inW = int.Parse(newNode[2]);

                            edges[parse[inX]].Add(parse[inY], inW);
                            edges[parse[inY]].Add(parse[inX], inW);
                            //edges.Add(Tuple.Create(parse[inX], parse[inY]), inW);
                            //edges.Add(Tuple.Create(parse[inY], parse[inX]), inW);

                            //Node node = new Node
                            //{
                            //    V = parse[inY],
                            //    W = inW,
                            //    Next = edges[parse[inX]]
                            //};
                            //edges[parse[inX]] = node;

                            //node = new Node
                            //{
                            //    V = parse[inX],
                            //    W = inW,
                            //    Next = edges[parse[inY]]
                            //};
                            //edges[parse[inY]] = node;
                        }
                        start = int.Parse(sr.ReadLine());
                    }
                }
                inputTime = watch.ElapsedMilliseconds;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return;
            }


            Console.WriteLine($"start: {start}");

            watch.Start();
            //bool[] inTree = new bool[n + 1];
            //int[] distance = new int[n + 1];
            //int[] parent = new int[n + 1];
            //for (int z = 1; z <= n; z++)
            //{
            //    distance[z] = Int32.MaxValue;
            //    parent[z] = -1;
            //}

            distance[start] = 0;
            int v = start;
            while (inTree[v] == false)
            {
                inTree[v] = true;
                //Node p = edges[v];
                Dictionary<int, int> p = edges[v];
                foreach (KeyValuePair<int, int> keyValuePair in p)
                {
                    int w = keyValuePair.Key;
                    int weight = keyValuePair.Value;
                    int newDistance = distance[v] + weight;
                    if (distance[w] > newDistance)
                    {
                        distance[w] = newDistance;
                        parent[w] = v;
                    }
                    //p = p.Next;
                }

                v = 1;
                int dist = int.MaxValue;
                for (int t = 1; t <= n; t++)
                {
                    if ((inTree[t] == false) && (dist > distance[t]))
                    {
                        dist = distance[t];
                        v = t;
                    }
                }
            }

            for (int y = 1; y <= n; y++)
            {
                if (y == start) continue;
                if (distance[y] == int.MaxValue)
                    Console.Write(neg);
                else
                    Console.Write(distance[y] + " ");
            }

            Console.WriteLine();
            calcTime = watch.ElapsedMilliseconds;

            Console.WriteLine($"dictTime={dictTime}");
            Console.WriteLine($"inputTime={inputTime}");
            Console.WriteLine($"calcTime={calcTime}");
        }
    }
}

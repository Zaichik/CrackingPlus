using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C4_Graph.MySnakesAndLadders;
using C4_Graph.Tree;
using C4_Graph.Tree.BinaryTrees;
using C4_Graph.Tree.TraverseHardDrive;

using Microsoft.VisualStudio.GraphModel;

namespace C4_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestGraphWithWeights();
            //TestGraph();
            //TestMyFirstGraph();
            //TestMySnakesAndLadders(); // works
            //TreeExample.ShowTreeExample(); // works
            //DirectoryTraverseDFS.TraverseDir("C:\\RD\\Training\\AG1"); // works
            //DirectoryTraverseBFS.TraverseDir("C:\\RD\\Training\\AG1"); // works
            BinaryTree<int>.BinaryTreeExample();
            Console.WriteLine("Press a key to exit.");
            Console.ReadLine();
        }

        private static void TestMyFirstGraph()
        {
            GraphT graphT = new GraphT();

            MyFirstGraph graphTest = new MyFirstGraph();
            graphTest.ReadGraph(graphT, directed: true);
            graphTest.PrintGraph(graphT);
        }

        private static void TestMySnakesAndLadders()
        {
            MySnakesAndLaddersGraph graph = new MySnakesAndLaddersGraph();
            MySnakesAndLadders.MySnakesAndLadders laddersTest = new MySnakesAndLadders.MySnakesAndLadders();
            laddersTest.ReadGraph(graph);
            laddersTest.BFS(graph, 1);
            laddersTest.FindPath(1, 100, graph.Parents);
        }

        private static void TestGraph()
        {
            Console.WriteLine("Enter number of vertices: ");
            int vertices = Int32.Parse(Console.ReadLine());
            AdjacencyList adjacencyList = new AdjacencyList(vertices + 1);

            Console.WriteLine("Enter number of edges: ");
            int edges = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter edges: ");
            int startVertex;
            int endVertex;

            for (int i = 0; i < edges; i++)
            {
                startVertex = Int32.Parse(Console.ReadLine());
                endVertex = Int32.Parse(Console.ReadLine());

                adjacencyList.AddEdgeAtEnd(startVertex, endVertex);
            }

            adjacencyList.Print();

            Console.WriteLine("\nRemove 1->2:");
            adjacencyList.RemoveEdge(1, 2);
            adjacencyList.Print();

            Console.ReadLine();
        }

        private static void TestGraphWithWeights()
        {
            Console.WriteLine("Enter number of vertices: ");
            int vertices = Int32.Parse(Console.ReadLine());
            AdjacencyListWithWeights adjacencyListWithWeights = new AdjacencyListWithWeights(vertices + 1);

            Console.WriteLine("Enter number of edges: ");
            int edges = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter edges with weights: ");
            int startVertex;
            int endVertex;
            int weight;

            for (int i = 0; i < edges; i++)
            {
                startVertex = Int32.Parse(Console.ReadLine());
                endVertex = Int32.Parse(Console.ReadLine());
                weight = Int32.Parse(Console.ReadLine());

                adjacencyListWithWeights.AddEdgeAtEnd(startVertex, endVertex, weight);
            }

            adjacencyListWithWeights.Print();
            adjacencyListWithWeights.RemoveEdge(1, 2, 1);
            adjacencyListWithWeights.Print();

            Console.ReadLine();
        }

        public void Blah()
        {
            Microsoft.VisualStudio.GraphModel.Graph testGraph = new Microsoft.VisualStudio.GraphModel.Graph();
            testGraph.Nodes.Add(new GraphNode[1]);
        }
    }
}

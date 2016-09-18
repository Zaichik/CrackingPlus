using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph
{
    public class AdjacencyListWithWeights
    {
        LinkedList<Tuple<int, int>>[] adjacencyList;

        public AdjacencyListWithWeights(int vertices)
        {
            adjacencyList = new LinkedList<Tuple<int, int>>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList[i] = new LinkedList<Tuple<int, int>>();
            }
        }

        public void AddEdgeAtEnd(int startVertex, int endVertex, int weight)
        {
            adjacencyList[startVertex].AddLast(new Tuple<int, int>(endVertex, weight));
        }

        public void AddEdgeAtBeginning(int startVertex, int endVertex, int weight)
        {
            adjacencyList[startVertex].AddFirst(new Tuple<int, int>(endVertex, weight));
        }

        public int GetNumberOfVertices => adjacencyList.Length;

        public LinkedList<Tuple<int, int>> this[int index]
        {
            get
            {
                var edgeList = new LinkedList<Tuple<int, int>>(adjacencyList[index]);
                return edgeList;
            }
        }

        public void Print()
        {
            int i = 0;
            foreach (var linkedList in adjacencyList)
            {
                Console.Write($"adjacencyList[{i}] -> ");
                foreach (var edgeTuple in linkedList)
                {
                    Console.WriteLine($"{edgeTuple.Item1}({edgeTuple.Item2})");
                }

                i++;
                Console.WriteLine();
            }
        }

        public bool RemoveEdge(int startVertex, int endVertex, int weight)
        {
            Tuple<int, int> edge = new Tuple<int, int>(endVertex, weight);
            return adjacencyList[startVertex].Remove(edge);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph
{
    public class AdjacencyList
    {
        readonly LinkedList<int>[] _adjacencyList;

        public AdjacencyList(int vertices)
        {
            _adjacencyList = new LinkedList<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = new LinkedList<int>();
            }
        }

        public void AddEdgeAtEnd(int startVertex, int endVertex)
        {
            _adjacencyList[startVertex].AddLast(endVertex);
        }

        public void AddEdgeAtBeginning(int startVertex, int endVertex)
        {
            _adjacencyList[startVertex].AddFirst(endVertex);
        }

        public int GetNumberOfVertices => _adjacencyList.Length;
        public LinkedList<int> this[int index] => _adjacencyList[index];

        public void Print()
        {
            for (int i = 0; i < _adjacencyList.Length; i++)
            {
                var linkedList = _adjacencyList[i];
                Console.Write($"adjacencyList[{i}] -> ");
                foreach (var edge in linkedList)
                {
                    Console.WriteLine($"{edge}");
                }

                Console.WriteLine();
            }
        }

        public bool RemoveEdge(int startVertex, int endVertex)
        {
            return _adjacencyList[startVertex].Remove(endVertex);
        }
    }
}

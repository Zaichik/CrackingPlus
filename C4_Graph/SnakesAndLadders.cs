using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph
{
    public class Node
    {
        public int Val;
        public Node Next;

    }

    public class SnakesAndLadders
    {
        Node Add(Node head, int vertex)
        {
            var traverse = new Node
            {
                Next = head,
                Val = vertex
            };

            return traverse;
        }

        // The Breadth First Search Algorithm procedure. Takes empty parent and level
        // arrays and fills them with corresponding values that we get while applying BFS
        public void BFS(Node[] adjList, int vertices, int[] parent, int[] level)
        {
            int flag = 1;
            int lev = 0;
            level[1] = lev;

            while (flag > 0)
            {
                flag = 0;
                for (int i = 1; i <= vertices; i++)
                {
                    if (level[i] == lev)
                    {
                        flag = 1;
                        Node temp = adjList[i];
                        int par = i;
                        while (temp != null)
                        {
                            if (parent[temp.Val] != 0)
                            {

                                // A level for this is already set
                                temp = temp.Next;
                                continue;
                            }

                            level[temp.Val] = lev + 1;
                            parent[temp.Val] = par;
                            temp = temp.Next;
                        }
                    }
                }

                ++lev;
            }
        }

        // Replaces the value of an edge (u -->) v to (u --> v')
        // Traverses the entire list of adjacencyList[u] => O(|E|) operation
        // Here, "v" is stored as "oldVertex" and "v'" is stored as "newVertex"
        public void Replace(Node head, int oldVertex, int newVertex)
        {
            Node traverse = head;
     
            // Search for the occurrence of 'oldVertex'
            while (traverse.Next != null) {
                if (traverse.Val == oldVertex) {
                    break;
                }
         
                traverse = traverse.Next;
            }
     
            // replace it with the new value
            traverse.Val = newVertex;
        }
 
        // Prints the Adjacency List from vertex 1 to |V|
        public void printAdjacencyList(Node[] adjList, int vertices)
        {
            int i;

            // Printing Adjacency List
            Console.WriteLine("\nAdjacency List -\n");
            for (i = 1; i <= vertices; ++i)
            {
                Console.WriteLine($"{i} -> ");

                Node temp = adjList[i];
 
                while (temp != null)
                {
                    Console.WriteLine($"{temp.Val} -> ");
                    temp = temp.Next;
                }

                Console.WriteLine("NULL\n");
            }
        }
 
        // A recursive procedure to print the shortest path. Recursively
        // looks at the parent of a vertex till the 'startVertex' is reached
        public void printShortestPath(int[] parent, int currentVertex, int startVertex)
        {
            if (currentVertex == startVertex)
            {
                Console.WriteLine("%d ", currentVertex);
            }
            else if (parent[currentVertex] == 0)
            {
                printShortestPath(parent, startVertex, startVertex);
                Console.WriteLine("%d ", currentVertex);
            }
            else
            {
                printShortestPath(parent, parent[currentVertex], startVertex);
                Console.WriteLine("%d ", currentVertex);
            }
        }
    }
}

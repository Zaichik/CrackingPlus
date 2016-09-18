using System.Collections.Generic;

namespace C4_Graph.MySnakesAndLadders
{
    public class MySnakesAndLaddersGraph
    {
        public const int VertexCount = 100;
        public List<Node>[] AdjNodes = new List<Node>[VertexCount + 1];

        internal int[] Snakes = new int[VertexCount + 1];
        internal int[] Ladders = new int[VertexCount + 1];

        public int[] Parents = new int[VertexCount + 1];
        public bool[] Discovered = new bool[VertexCount + 1];
    }
}
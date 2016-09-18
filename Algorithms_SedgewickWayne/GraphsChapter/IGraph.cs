using System.Collections.Generic;

namespace GraphsChapter
{
    public interface IGraph
    {
        int V { get; }
        int E { get; set; }
        List<int>[] Adj { get; set; }

        void AddEdge(int v, int w);

        int Degree(int v);

        string ToString();
    }
}
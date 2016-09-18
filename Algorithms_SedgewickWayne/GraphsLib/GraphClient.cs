using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public static class GraphClient
    {
        public static int MaxDegree(Graph g)
        {
            int max = 0;
            for (int v = 0; v < g.V; v++)
                if (max < g.Degree(v)) 
                    max = g.Degree(v);

            return max;
        }

        public static int AvgDegree(Graph g)
        {
            return 2 * g.E / g.V;
        }

        public static int NumberOfSelfLoops(Graph g)
        {
            int count = 0;
            for (int v = 0; v < g.V; v++)
                foreach (int w in g.Adj[v])
                    if (v == w) count++;
            return count/2;
        }
    }
}

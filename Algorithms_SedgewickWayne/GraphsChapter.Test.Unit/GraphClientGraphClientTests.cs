using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphsChapter.Test.Unit
{
    [TestClass()]
    public class GraphClientTests
    {
        private static Graph g;

        [TestInitialize]
        public void Initialize()
        {
            string filePath = @"..\..\..\Algorithms_SedgewickWayne\GraphsLib\Txt\TinyG.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            g = new Graph(lines);
        }
        [TestMethod()]
        public void MaxDegreeTest()
        {
            int maxDegree = GraphClient.MaxDegree(g);
            Console.WriteLine(maxDegree);
        }

        [TestMethod()]
        public void AvgDegreeTest()
        {
            int avgDegree = GraphClient.AvgDegree(g);
            Console.WriteLine(avgDegree);
        }

        [TestMethod()]
        public void NumberOfSelfLoopsTest()
        {
            int numberOfSelfLoops = GraphClient.NumberOfSelfLoops(g);
            Console.WriteLine(numberOfSelfLoops);
        }
    }
}
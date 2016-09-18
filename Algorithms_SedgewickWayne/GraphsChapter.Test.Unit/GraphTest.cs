using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphsChapter.Test.Unit
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string filePath = @"..\..\..\GraphsChapter\Txt\TinyG.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            Graph g = new Graph(lines);
            Graph g2 = new Graph(g);
            Console.WriteLine(g);
            Console.WriteLine(g2);
        }
    }
}

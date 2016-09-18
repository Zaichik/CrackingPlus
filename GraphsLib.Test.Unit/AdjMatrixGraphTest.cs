using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphsLib.Test.Unit
{
    [TestClass]
    public class AdjMatrixGraphTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string filePath = @"..\..\..\Algorithms_SedgewickWayne\GraphsLib\Txt\TinyG.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            var g = new AdjMatrixGraph(lines);
            var g2 = new AdjMatrixGraph(g);
            Console.WriteLine(g);
            Console.WriteLine(g2);
        }
    }
}

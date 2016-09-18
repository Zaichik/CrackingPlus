using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphsChapter.Test.Unit
{
    [TestClass]
    public class DepthFirstPathsTests
    {
        [TestMethod]
        public void HasPathToTest()
        {
            //string filePath = @"..\..\..\GraphsChapter\Txt\TinyCG.txt";
            string filePath = @"..\..\..\GraphsChapter\Txt\TinyG.txt";
            //string filePath = @"..\..\..\GraphsChapter\Txt\MediumG.txt";
            //string filePath = @"..\..\..\GraphsChapter\Txt\LargeG.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            var g = new Graph(lines);
            var depthFirstPaths = new DepthFirstPaths(g, 5);

            for (int i = 0; i < g.V; i++)
            {
                bool hasPathTo = depthFirstPaths.HasPathTo(i);
                if (hasPathTo)
                {
                    Console.Write($"\n{i}: ");

                    var pathTo = depthFirstPaths.PathTo(i);
                    foreach (int w in pathTo)
                        Console.Write($"{w} ");
                }
                else
                    Console.Write($"\n{i}: None");
            }
        }
    }
}
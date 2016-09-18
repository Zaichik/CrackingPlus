using System;

using FundamentalsChapter;

namespace ClientConsole
{
    class TestStaticSetOfInts
    {
        public static void Run()
        {
            int[] clientInts = { 186034, 45454545, 99999901, 84421, 352239, 7058, 489910, 123 };
            string filePath = @"..\..\..\Txt\LargeW.txt";
            int[] lines = Array.ConvertAll(System.IO.File.ReadAllLines(filePath), Int32.Parse);

            var staticSetOfInts = new StaticSetOfInts(lines);
            foreach (int clientInt in clientInts)
            {
                int key = staticSetOfInts.Rank(clientInt);
                Console.WriteLine(key == -1
                        ? "not today"
                        : "bingo");
            }
        }
    }
}
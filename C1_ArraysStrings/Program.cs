using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_ArraysStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallIsUniqueCharString_ASCII();

            //CallIsUniqueCharString_BitVector();

            //CallIsUniqueCharString_CheckEveryChar();
            int[,] myArray = new int[,]
            {
                { 1, 2, 3, 4, 5},
                { 6, 7, 8, 9, 10},
                { 11, 12, 13, 14, 15},
                { 16, 17, 18, 19, 20},
                { 21, 22, 23, 24, 25},
            };

//            int[,] myArray = new int[,]
//{
//                { 5, 10, 15, 20, 25},
//                { 4, 9, 14, 19, 24},
//                { 3, 8, 13, 18, 23},
//                { 2, 7, 12, 17, 22},
//                { 1, 6, 11, 16, 21},
//};


            int length = 5;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"  {myArray[i,j]}");
                }
                Console.WriteLine();
            }

            Turn90_6.Turn90(myArray, length);

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(myArray[i,j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void CallIsUniqueCharString_ASCII()
        {
            string testStr;
            bool IsMyStrUnique;

            Console.WriteLine("   IsUniqueCharString_ASCII");

            testStr = "abcdc";
            IsMyStrUnique = IsUniqueCharString1.IsUniqueCharString_ASCII(testStr);
            Console.WriteLine("String '{0}' is {1} unique", testStr, IsMyStrUnique ? "" : "NOT");

            testStr = "abcd";
            IsMyStrUnique = IsUniqueCharString1.IsUniqueCharString_ASCII(testStr);
            Console.WriteLine("String '{0}' is {1} unique", testStr, IsMyStrUnique ? "" : "NOT");

            Console.WriteLine();
        }

        private static void CallIsUniqueCharString_BitVector()
        {
            Console.WriteLine("   IsUniqueCharString_BitVector");
            string testStr;
            bool IsMyStrUnique;
            //testStr = "abcdc";
            testStr = "$A$";
            IsMyStrUnique = IsUniqueCharString1.IsUniqueCharString_BitVector(testStr);
            Console.WriteLine("String '{0}' is {1} unique", testStr, IsMyStrUnique ? "" : "NOT");

            Console.WriteLine();
            Console.WriteLine();


            testStr = "abcd";
            IsMyStrUnique = IsUniqueCharString1.IsUniqueCharString_BitVector(testStr);
            Console.WriteLine("String '{0}' is {1} unique", testStr, IsMyStrUnique ? "" : "NOT");
        }

        private static void CallIsUniqueCharString_CheckEveryChar()
        {
            Console.WriteLine("   IsUniqueCharString_CheckEveryChar");
            string testStr;
            bool IsMyStrUnique;
            testStr = "abcdc";
            //testStr = "$A$";
            IsMyStrUnique = IsUniqueCharString1.IsUniqueCharString_CheckEveryChar(testStr);
            Console.WriteLine("String '{0}' is {1} unique", testStr, IsMyStrUnique ? "" : "NOT");

            Console.WriteLine();
            Console.WriteLine();


            testStr = "abcd";
            IsMyStrUnique = IsUniqueCharString1.IsUniqueCharString_CheckEveryChar(testStr);
            Console.WriteLine("String '{0}' is {1} unique", testStr, IsMyStrUnique ? "" : "NOT");
        }

    }
}

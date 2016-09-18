using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DP
{
    class Program
    {
        private class TheClass
        {
            public string willIChange;
        }

        static void Main(string[] args)
        {
            //CalcUniqueChars_Bit();
            //CalcUniqueChars_Bool();
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //    int cases = Convert.ToInt32(Console.ReadLine());
            //    for (int i = 0; i < cases; i++)
            //    {
            //        //BigInteger k = BigInteger.Parse(Console.ReadLine());
            //        //string str = Console.ReadLine();
            //        //str = str.Trim();
            //        //BigInteger a = BigInteger.Parse(str, NumberStyles.AllowHexSpecifier);
            //        //str = Console.ReadLine();
            //        //str = str.Trim();
            //        ////Console.WriteLine($"str b: '{str}'");
            //        BigInteger b = BigInteger.Parse("09E", NumberStyles.AllowHexSpecifier);
            //        //BigInteger c = BigInteger.Parse(Console.ReadLine(), NumberStyles.AllowHexSpecifier);
            //        //Console.WriteLine($"a: {a}");
            //        //Console.WriteLine($"b: {b}");
            //        //Console.WriteLine($"b: " + b.ToString("X"));
            //        //Console.WriteLine($"c: {c}");

            //        //BigInteger count = new BigInteger(0);

            //        //BigInteger shift = new BigInteger(1);
            //        //BigInteger subA = new BigInteger(0);
            //        //BigInteger subB = new BigInteger(0);
            //        //BigInteger subC = new BigInteger(0);

            //        //Console.WriteLine($"k: " + k.ToString("X"));
            //        //Console.WriteLine($"count: " + count.ToString("X"));
            //        //int index = 0;
            //        ////while(k > count){
            //        //while (index < 15)
            //        //{
            //        //    Console.WriteLine("index: " + index++);
            //        //    subA = a & shift;
            //        //    subB = b & shift;
            //        //    subC = c & shift;
            //        //    Console.WriteLine("    Before:");
            //        //    Console.WriteLine($"b: {b}");
            //        //    Console.WriteLine($"a: {a & shift}");
            //        //    Console.WriteLine($"b: {b & shift}");
            //        //    Console.WriteLine($"c: {c & shift}");

            //        //    if ((subA | subB) != subC)
            //        //    {
            //        //        if (subC == 0)
            //        //        {
            //        //            if (subA == shift)
            //        //            {
            //        //                a = a ^ shift;
            //        //                count = count + 1;
            //        //            }
            //        //            if (subB == shift)
            //        //            {
            //        //                b = b ^ shift;
            //        //                count = count + 1;
            //        //            }
            //        //        }
            //        //        else
            //        //        {
            //        //            b = b | shift;
            //        //            count = count + 1;
            //        //        }
            //        //    }
            //        //    Console.WriteLine("    After:");
            //        //    Console.WriteLine($"a: {a & shift}");
            //        //    Console.WriteLine($"b: {b & shift}");
            //        //    Console.WriteLine($"c: {c & shift}");

            //        //    Console.WriteLine($"shift: {shift}");
            //        //    //if(count > k){
            //        //    //    break;
            //        //    //}

            //        //    shift = shift << 1;
            //        //    //Console.WriteLine($"shift: {shift}");
            //        //    //Console.WriteLine($"b: {b}");
            //        //}

            //        //if ((a | b) == c)
            //        //{
            //        //    Console.WriteLine("" + a.ToString("X"));
            //        //    Console.WriteLine("" + b.ToString("X"));
            //        //}
            //        //else
            //        //{
            //        //    Console.WriteLine(-1);
            //        //    Console.WriteLine("" + a.ToString("X"));
            //        //    Console.WriteLine("" + b.ToString("X"));
            //        //    var blah2 = a | b;
            //        //    Console.WriteLine("" + blah2.ToString("X"));
            //        //    Console.WriteLine("" + c.ToString("X"));

            //        //}

            //        //break; // TODO
            //    }

            //int cases = 1;
            //for (int i = 0; i < cases; i++)
            //{
            //    int count = 0;
            //    string s = "abba";
            //    List<string> str = new List<string>();
            //    for (int a = 0; a < s.Length - 1; a++)
            //    {
            //        for (int b = a + 1; b < s.Length; b++)
            //        {
            //            char start = s[a];
            //            char end = s[b];
            //            string temp = s.Substring(a, b - a + 1);

            //            if (s[a] == s[b])
            //            {
            //                str.Add(s.Substring(a, b - a + 1));
            //                count += Calc(s.Substring(a, b - a + 1));
            //            }
            //        }
            //    }
            //    Console.WriteLine($"count: {count}");
            //}
            Console.ReadLine();
        }

        private static void UpdateTheClass(TheClass theClass)
        {
            theClass.willIChange = "Changed";
        }

        private static void UpdatePoint(Point p1)
        {
            p1.Y = 100;
        }

        private static void CalcUniqueChars_Bool()
        {
            string str = "abzad";
            bool[] flags = new bool[256];
            foreach (char c in str)
            {
                if (flags[c])
                {
                    Console.WriteLine("not unique");
                    return;
                }

                flags[c] = true;
            }
            Console.WriteLine("unique");
        }

        private static void CalcUniqueChars_Bit()
        {
            string str = "abzad";
            int flag = 0;
            foreach (char c in str)
            {
                int mask = c - 97;
                int shifted = 1 << mask;

                if ((flag & shifted) == 1)
                {
                    Console.WriteLine("not unique");
                    return;
                }

                flag |= shifted;
            }
            Console.WriteLine("unique");
        }

        private static bool Permutation_Sort(char[] ch1, char[] ch2)
        {
            if (ch1.Length != ch2.Length)
                return false;

            ch1 = "dbac".ToCharArray();
            ch2 = "cadb".ToCharArray();

            Array.Sort(ch1);
            Array.Sort(ch2);

            bool isPerm = ch1.Equals(ch2);
            return isPerm;
        }

        private static bool Permutation_Count(char[] ch1, char[] ch2)
        {
            if (ch1.Length != ch2.Length)
                return false;

            if (ch1.Length > 256)
                return false;

            int[] flags = new int[256];
            foreach(char c in ch1)
            {
                flags[c]++;
            }

            foreach (char c in ch2)
            {
                flags[c]--;
                if (flags[c] < 0) return false;
            }

            return true;
        }

        private static char[] Percent20(char[] ch, int len)
        {
             int right = ch.Length - 1;
            int left = len - 1;

            for(int i = left; i >= 0; i--)
            {
                if(ch[i] == 32)
                {
                    ch[right] = '0';
                    right--;
                    ch[right] = '2';
                    right--;
                    ch[right] = '%';
                    right--;
                }
                else
                {
                    ch[right] = ch[i];
                    right--;
                }
            }

            return ch;
        }

        //private static int Calc(string blah)
        //{
        //    if (blah.Length == 2) return 1;
        //    Console.WriteLine($"sub: {blah}");
        //    return 1;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsChapter
{
    public class Kmp2
    {
        public Kmp2(){}

        public IList<int> Search(string txt, string pattern)
        {
            var startIndexes = new List<int>();
            string s = pattern + '$' + txt;
            var b = ComputePrefixFunction(s);
            for (var i = pattern.Length + 1; i < b.Length; i++)
            {
                if (b[i] == pattern.Length)
                    startIndexes.Add(i - 2 * pattern.Length);
            }
            return startIndexes;
        }

        public int[] ComputePrefixFunction(string pattern)
        {
            int[] b = new int[pattern.Length];
            int border = 0;
            for (int i = 1; i < pattern.Length; i++)
            {
                while (border > 0 && pattern[i] != pattern[border])
                {
                    border = b[border - 1];
                }

                if (pattern[i] == pattern[border])
                    border++;
                //else
                //    border = 0;

                b[i] = border;
            }

            PrintBorders(pattern, b);

            return b;
        }

        private void PrintBorders(string pattern, int[] b)
        {
            StringBuilder sbP = new StringBuilder();
            StringBuilder sbB = new StringBuilder();
            for (int i = 0; i < pattern.Length; i++)
            {
                sbP.Append($" {pattern[i]}");
                sbB.Append($"{b[i],2}");
            }
            Console.WriteLine(sbP);
            Console.WriteLine(sbB);
        }

        public static void TestMe()
        {
            string txt = "AABRAACADABRAACAADABRA";
            //string pattern = "AACAA";
            string pattern = "AACA";

            TestMe2(pattern, txt);
            TestMe2("ababcababbcab", "ababcababacababcababacababcababacababcababac");
        }

        public static void TestMe2(string pattern, string txt)
        {
            Kmp2 kmp = new Kmp2();
            IList<int> indexes = kmp.Search(txt, pattern);
            Console.WriteLine("text:    " + txt);
            foreach (int index in indexes)
            {
                Console.Write("pattern: ");
                for (int i = 0; i < index; i++)
                    Console.Write(" ");
                Console.Write(pattern);
                Console.WriteLine();
            }
        }
    }
}

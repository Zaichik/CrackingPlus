using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsChapter
{
    public class KMP
    {
        private readonly string _pattern;
        private readonly int[,] _dfa;

        public KMP(string pattern)
        {
            _pattern = pattern;
            int patternLength = pattern.Length;
            const int AsciiLen = 256;
            _dfa = new int[AsciiLen, patternLength];
            _dfa[pattern[0], 0] = 1;

            int col = 0;
            for (int patternIndex = 1; patternIndex < patternLength; patternIndex++)
            {
                for (int row = 0; row < AsciiLen; row++)
                {
                    _dfa[row, patternIndex] = _dfa[row, col];
                }

                _dfa[pattern[patternIndex], patternIndex] = patternIndex + 1;
                col = _dfa[pattern[patternIndex], col];
            }
        }

        public int Search(string txt)
        {
            int m = _pattern.Length;
            int n = txt.Length;
            int i = n;
            int j = n;

            for (i = 0, j = 0; i < n && j < m; i++)
                j = _dfa[txt[i], j];

            if (j == m) return i - m;

            return n;
        }

        public static void TestMe()
        {
            string txt = "AABRAACADABRAACAADABRA";
            string pattern = "AACAA";

            TestMe2(pattern, txt);
        }

        public static void TestMe2(string pattern, string txt)
        {
            KMP kmp = new KMP(pattern);
            int offset = kmp.Search(txt);
            Console.WriteLine($"Index: {offset}");
            Console.WriteLine("text:    " + txt);
            Console.Write("pattern: ");
            for (int i = 0; i < offset; i++)
                Console.Write(" ");
            Console.Write(pattern);
        }
    }
}

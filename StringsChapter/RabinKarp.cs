using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsChapter
{
    public class RabinKarp
    {
        public static IList<int> FindPattern(string text, string pattern)
        {
            IList<int> result = new List<int>();

            int p = 503;
            //int x = new Random().Next(1, p - 1);
            int x = 2;

            var pHash = PolyHash(pattern, p, x);

            var H = PrecomputeHashes(text, pattern.Length, p, x);
            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                if(pHash != H[i]) continue;
                if(AreEqual(text.Substring(i,pattern.Length), pattern)) result.Add(i);
            }

            return result;
        }

        private static bool AreEqual(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            for (var index = 0; index < str1.Length; index++)
            {
                if (str1[index] != str2[index]) return false;
            }

            return true;
        }

        private static IList<int> PrecomputeHashes(string text, int patternLength, int p, int x)
        {
            var H = new int[text.Length - patternLength + 1];
            var S = text.Substring(text.Length - patternLength, patternLength);
            H[text.Length - patternLength] = PolyHash(S, p, x);
            int y = (int)Math.Pow(x, patternLength) % p;
            int y2 = 1;
            for (int i = 1; i <= patternLength; i++)
            {
                y2 = (y2 * x) % p;
            }

            Debug.Assert(y == y2);

            for (int i = text.Length - patternLength - 1; i >= 0; i--)
            {
                H[i] = (x * H[i+1] + text[i] - y * text[i + patternLength]) % p;
            }
            return H;
        }

        private static int PolyHash(string pattern, int p, int x)
        {
            int hash = 0;
            int y = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                hash += pattern[i] * y;
                y *= x;
            }
            hash %= p;

            return hash;
        }
    }
}

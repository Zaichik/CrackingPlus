using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsChapter
{
    public class SubstringSearchBruteForce
    {
        public static int Search(string pat, string txt)
        {
            int m = pat.Length;
            int n = txt.Length;
            for (int i = 0; i <= n-m; i++)
            {
                int j;

                for (j = 0; j < m; j++)
                    if (txt[i + j] != pat[j]) break;

                if (j == m) return i;
            }
            return n;
        }
        public static int SearchExplicitBackup(string pat, string txt)
        {
            int m = pat.Length;
            int j = m;
            int n = txt.Length;
            int i = n;

            for (i = 0, j=0; i <= n && j < m; i++)
            {
                if (txt[i] == pat[j])
                    j++;
                else
                {
                    i -= j;
                    j = 0;
                }
            }

            if (j == m) 
                return i - m;

            return n;
        }
    }
}

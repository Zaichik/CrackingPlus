using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_3_RemoveDupChars
{
    public static class Class1
    {
        public static void RemoveDuplicateChar(char[] str)
        {
            if (str.Length < 2) return;

            int len = str.Length;
            int tail = 1;

            for (int i1 = 1; i1 < len; i1++)
            {
                int i2;
                for (i2 = 0; i2 < tail; i2++)
                {
                    if (str[i1] == str[i2]) break;
                }

                if (i2 == tail)
                {
                    str[tail] = str[i1];
                    tail++;
                }
            }

            str[tail] = '\0';

            Console.WriteLine(str);
        }

        public static string RemoveDuplicateCharsWithReturnFast(string str)
        {
            var h1 = new HashSet<char>();
            var h2 = new HashSet<char>();

            foreach (var ch in str)
            {
                if (!h1.Add(ch))
                {
                    h2.Add(ch);
                }
            }

            h1.ExceptWith(h2); // remove duplicates

            var chars = new char[h1.Count];
            h1.CopyTo(chars);
            var result = new string(chars);

            return result;
        }

        public static string RemoveDuplicateCharsWithReturnShort(string str)
        {
            var duplicates = str.Where(ch => str.Count(c => c == ch) > 1);
            var result = new string(str.Except(duplicates).ToArray());

            return result;
        }

        public static string RemoveDuplicates(string s)
        {
            int[] c = new int[255];
            for (int i = 0; i < s.Length; i++)
            {
                c[s[i]]++;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (c[s[i]] == 1) sb.Append(s[i]);
            }
            return sb.ToString();
        }
    }
}

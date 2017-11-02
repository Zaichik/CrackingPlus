using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankLib.CTCI
{
    public static class MakingAnagrams
    {
        public static void MakingAnagramsDictionary(string a="apojsafnlasdflkasdfdf", string b="zlkjasdfioliasdf")
        {
            int count = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in a)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }
            foreach (char c in b)
            {
                if (dict.ContainsKey(c))
                    dict[c]--;
                else
                    dict[c] = -1;
            }
            foreach (var item in dict)
                count += Math.Abs(item.Value);

            Console.WriteLine(count);
        }

        public static void MakingAnagramsArray(string a = "apojsafnlasdflkasdfdf", string b = "zlkjasdfioliasdf")
        {
            int count = 0;
            int[] arr = new int[26];
            foreach (char c in a)
            {
                arr[c-'a']++;
            }
            foreach (char c in b)
            {
                arr[c - 'a']--;
            }
            foreach (var item in arr)
                count += Math.Abs(item);

            Console.WriteLine(count);
        }
    }
}

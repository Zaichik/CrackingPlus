using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace C1_ArraysStrings
{
    public static class IsUniqueCharString1
    {
        public static bool IsUniqueCharString_ASCII(string myStr)
        {
            if (myStr.Length == 0) return true;

            bool[] charSet = new bool[256];
            foreach (char t in myStr)
            {
                if (charSet[t]) return false;

                charSet[t] = true;
            }
            return true;
        }

        public static bool IsUniqueCharString_BitVector_Orig(string myStr)
        {
            if (myStr.Length == 0) return true;

            int checker = 0;
            foreach (char t in myStr)
            {
                int val = t - 'a';
                int shifted = 1 << val;
                if ((checker & shifted) > 0) return false;

                checker |= shifted;
            }
            return true;
        }

        public static bool IsUniqueCharString_BitVector(string myStr)
        {
            if (myStr.Length == 0) return true;

            int checker = 0;
            foreach (char t in myStr)
            {
                //int val = t - 'a';
                int shifted = 1 << t;
                if ((checker & shifted) > 0) return false;

                checker |= shifted;
            }
            return true;
        }

        public static bool IsUniqueCharString_CheckEveryChar(string myStr)
        {
            if (myStr.Length == 0) return true;

            for (int i1 = 0; i1 < myStr.Length - 1; i1++)
            {
                var t1 = myStr[i1];
                for (int i2 = i1 + 1; i2 < myStr.Length; i2++)
                {
                    var t2 = myStr[i2];
                    if (t1.CompareTo(t2) == 0) return false;
                }
            }
            return true;
        }

        public static bool IsUniqueCharString_DestroySortAllowed(string myStr)
        {
            if (myStr.Length == 0) return true;

            IEnumerable<char> str2 = myStr.ToCharArray().OrderBy(a => a);
            IEnumerable<char> str3 = myStr.ToCharArray().Distinct();
            return str2.Count() == str3.Count();
        }

        public static bool IsUniqueCharString_DestroySortAllowed2(string myStr)
        {
            if (myStr.Length == 0) return true;

            int longestRun = myStr.Select((c, i) => myStr.Substring(i).TakeWhile(x => x == c).Count()).Max();
            
            return longestRun == 0;
        }
    }

}

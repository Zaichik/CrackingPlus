using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankLib
{
    public class HashTablesRansomNote
    {
        private int _countMag = 6;
        private int _countNote = 4;
        private string[] _mag = {"give", "me", "one", "grand", "today", "tonight"};
        private string[] _note = {"give", "one", "grand", "today"};

        public HashTablesRansomNote()
        {

        }

        public string Calc()
        {
            Dictionary<string, int> dictM = new Dictionary<string,int>();
            foreach (string s in _mag)
            {
                if(dictM.ContainsKey(s))
                    dictM[s]++;
                else
                    dictM[s]++;
            }
            Dictionary<string, int> dictN = new Dictionary<string, int>();
            foreach (string s in _note)
            {
                if (dictN.ContainsKey(s))
                    dictN[s]++;
                else
                    dictN[s]++;
            }

            foreach (KeyValuePair<string, int> keyValuePair in dictN)
            {
                //if(dictM.ContainsKey(keyValuePair.Key) &&)
            }
            return "Yes";
        }
    }
}

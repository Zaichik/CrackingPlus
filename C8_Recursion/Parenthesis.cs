using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8_Recursion
{
    // 8.5
    public class Parenthesis
    {
        List<List<char>> allCombos = new List<List<char>>();
        private bool start = true;
        private int _pairCount;

        private void BuildCombinations(int lCount, int rCount, List<char> currentCombo )
        {
            if (start)
            {
                currentCombo.Add('(');
                lCount++;
                start = false;
            }

            if(lCount < 1)
            BuildCombinations(lCount, rCount, currentCombo);
            BuildCombinations(lCount, rCount, currentCombo);
        }

        public List<List<char>> GetCombinations(int pairCount) // TODO
        {
            _pairCount = pairCount;

            //BuildCombinations(pairCount, pairCount, pairCount, new List<char>);

            return allCombos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_StacksAndQueues
{
    public class MyStackArraySimple
    {
        private char[] _arr = new char[2];
        private int _stackPos;
        private readonly int _stackSize;

        public MyStackArraySimple(int stackSize)
        {
            _stackSize = stackSize;
        }
        public char[] AddToStackArray(string myString)
        {
            foreach (var item in myString)
            {
                Push(item);
            }
            return _arr;
        }

        private void Push(char value)
        {
            if (_stackPos >= _arr.Length)
            {
                Resize(ref _arr, _arr.Length + _stackSize);
            }
            _arr[_stackPos] = value;
            _stackPos++;
        }

        private static void Resize(ref char[] arrToResize, int newSize)
        {
            var arr2 = arrToResize;
            var arr3 = new char[newSize];
            Copy(arr2, arr3);
            arrToResize = arr3;
        }

        private static void Copy(char[] arrSource, char[] arrDestination)
        {
            if (arrDestination.Length < arrSource.Length)
                return;

            for (int index = 0; index < arrSource.Length; index++)
            {
                arrDestination[index] = arrSource[index];
            }
        }
    }
}

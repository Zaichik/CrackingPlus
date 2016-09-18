using System;

namespace C3_StacksAndQueues
{
    public class MyStackArray
    {
        int[] arr;
        private int[] _stack;
        private int _position;
        private int _stackSize;


        public MyStackArray(int stackSize)  
        {
            _stack = new int[1];
            _position = 0;
            _stackSize = stackSize;
            arr = new int[stackSize];
        }

        public void AddToStackArray(string myString)
        {
            foreach (var item in myString)
            {
                Push(item);
            }
        }

        //public char Pop()
        //{
            
        //}

        private void Push(char value)
        {
            int arrayPosition = _stack[_position] * _stack.Length;

            // stack is full, create a new one
            if (_position >= _stackSize)
            {
                Resize(ref _stack, _stackSize);
            }

            if (arrayPosition >= arr.Length)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }
            arr[arrayPosition] = value;
            _stack[_position]++;
        }

        private static void Resize<T>(ref T[] arrToResize, int size)
        {
            if (size < 1) return;

            var arr2 = arrToResize;
            var arr3 = new T[arrToResize.Length + size];
            Copy(ref arr2, ref arr3);
            arrToResize = arr3;
        }

        private static void Copy<T>(ref T[] arrSource, ref T[] arrDestination)
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

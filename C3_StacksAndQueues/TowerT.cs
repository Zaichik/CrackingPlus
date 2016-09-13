using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_StacksAndQueues
{
    public class TowerT
    {
        public static void MoveDisks(Stack<int> source, Stack<int> dest, Stack<int> temp, int numOfDisks)
        {
            if (numOfDisks > 1) MoveDisks(source, temp, dest, numOfDisks-1);
            dest.Push(source.Pop());
            if (numOfDisks > 1) MoveDisks(temp, dest, source, numOfDisks-1);
        }

        public static void MoveDisksNonRec(Stack<int> source, Stack<int> dest, Stack<int> temp, int numOfDisks)
        {
            if (numOfDisks > 1) MoveDisks(source, temp, dest, numOfDisks - 1);
            dest.Push(source.Pop());
            if (numOfDisks > 1) MoveDisks(temp, dest, source, numOfDisks - 1);

            // 1
            for (int i = 0; i < numOfDisks; i++)
            {
                if(i == 0) dest.Push(source.Pop());
            }

            // 2
            for (int i = 0; i < numOfDisks; i++)
            {
                if (i == 0) temp.Push(source.Pop());
                if (i == 1) dest.Push(source.Pop());
                if (i == 2) dest.Push(temp.Pop());
            }

            // 3
            for (int i = 0; i < numOfDisks; i++)
            {
                if (i == 0) dest.Push(source.Pop());
                if (i == 0) dest.Push(source.Pop());
                if (i == 0) dest.Push(source.Pop());
                if (i == 0) dest.Push(source.Pop());
            }
        }

    }
}

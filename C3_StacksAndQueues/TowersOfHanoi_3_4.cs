using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_StacksAndQueues
{
    class Tower
    {
        private readonly Stack<int> disks;
        private readonly int index;

        public Tower(int i)
        {
            disks = new Stack<int>();
            index = i;
        }

        public void Add(int d)
        {
            if (disks.Count > 0 &&  disks.Peek() <= d)
                Console.WriteLine("Error placing disk {0}", d);
            else
                disks.Push(d);
        }

        private void MoveTopTo(Tower t)
        {
            if(disks.Count == 0) return;

            int top = disks.Pop();
            t.Add(top);
            Console.WriteLine("{0}: from {1} to {2}", top, index, t.index);
        }

        public void Print()
        {
            Console.WriteLine("Contents of Tower {0}", index);
            foreach (var disk in disks)
            {
                Console.WriteLine("   " + disk);
            }
        }

        public void MoveDisks(int n, Tower destination, Tower buffer)
        {
            if (n <= 0) return;
            Console.WriteLine("- Start {0}", n);
            MoveDisks(n - 1, buffer, destination);
            MoveTopTo(destination);
            buffer.MoveDisks(n - 1, destination, this);
            Console.WriteLine("- End {0}", n);
        }
    }


    public static class TowersOfHanoi_3_4
    {
        public static void Start()
        {
            var n = 6;

            Console.WriteLine("Start: ");
            var towers = new Tower[3];
            for (var i = 0; i < 3; i++) towers[i] = new Tower(i);
            for (var i = n; i > 0; i--) towers[0].Add(i);
            towers[0].MoveDisks(n, towers[2], towers[1]);

            towers[0].Print();
            towers[1].Print();
            towers[2].Print();
        }
    }
}

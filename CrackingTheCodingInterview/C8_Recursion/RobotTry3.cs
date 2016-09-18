using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8_Recursion
{
    class RobotTry3
    {
        public List<Point> Path { get; set; }

        public List<List<Point>> AllPaths { get; set; }
        public int N { get; set; }

        public bool CalcPaths(int x, int y)
        {
            if(x < N || y < N) return false;

            if (x == N && y == N)
            {
                
            }

            return true;
        }
    }
}

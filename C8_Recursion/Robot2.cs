using System.Collections.Generic;
using System.Drawing;

namespace C8_Recursion
{
    public class Robot2
    {
        private List<List<Point>> AllPaths;

        public Robot2()
        {
            AllPaths = new List<List<Point>>();
        }

        private void CalcPaths(int x, int y, IEnumerable<Point> currentPath)
        {
            var point = new Point(x, y);
            var fullPath = new List<Point>(currentPath) {point};

            if (x == 1 && y == 1)
            {
                AllPaths.Add(fullPath);
                return;
            }

            if(x > 1)
                CalcPaths(x - 1, y, fullPath);

            if(y > 1)
                CalcPaths(x, y - 1, fullPath);
        }

        public List<List<Point>> CalcPaths(int x, int y)
        {
            CalcPaths(x, y, new List<Point>());
            return AllPaths;
        }
    }
}

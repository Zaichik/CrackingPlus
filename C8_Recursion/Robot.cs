using System.Collections.Generic;
using System.Drawing;

namespace C8_Recursion
{
    public class Robot
    {
        private readonly List<List<Point>> _allPaths = new List<List<Point>>();

        private void GetPaths(int x, int y, List<Point> currentPath)
        {
            var point = new Point(x, y);
            var singlePath = new List<Point>(currentPath) {point};

            if (x == 1 && y == 1)
            {
                _allPaths.Add(singlePath);
                return;
            }

            if (x > 1)
                GetPaths(x - 1, y, singlePath);

            if (y > 1)
                GetPaths(x, y - 1, singlePath);
        }

        public List<List<Point>> GetPaths(int x, int y)
        {
            GetPaths(x, y, new List<Point>());
            return _allPaths;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree.TraverseHardDrive
{
    public static class DirectoryTraverseDFS
    {
        private static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            if (dir == null) return;

            Console.WriteLine(spaces + dir.FullName);

            DirectoryInfo[] children;
            try
            { children = dir.GetDirectories(); }
            catch (SecurityException)
            {
                Console.WriteLine("Security exception.");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Dir not found exception.");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException.");
                return;
            }


            foreach (DirectoryInfo child in children)
            {
                TraverseDir(child, spaces + "   ");
            }
        }

        public static void TraverseDir(string directoryPath)
        {
            DirectoryInfo rootDir;
            try
            {
                rootDir = new DirectoryInfo(directoryPath);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path is null");
                return;
            }
            catch (SecurityException)
            {
                Console.WriteLine("Security exception.");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Argument exception.");
                return;
            }

            TraverseDir(rootDir, String.Empty);
        }
    }
}

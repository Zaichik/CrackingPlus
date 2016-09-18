using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace C4_Graph.Tree.TraverseHardDrive
{
    public static class DirectoryTraverseBFS
    {
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

            TraverseDir(rootDir, string.Empty);
        }

        private static void TraverseDir(DirectoryInfo rootDir, string spaces)
        {
            if(rootDir == null) return;

            Queue<DirectoryInfo> q = new Queue<DirectoryInfo>();
            q.Enqueue(rootDir);
            Console.WriteLine(rootDir.FullName);

            while (q.Count > 0)
            {
                DirectoryInfo curDir = q.Dequeue();
                //Console.WriteLine(curDir.FullName);

                var children = curDir.GetDirectories();
                foreach (var child in children)
                {
                    q.Enqueue(child);
                    Console.WriteLine(child.FullName);
                }
            }
        }
    }
}

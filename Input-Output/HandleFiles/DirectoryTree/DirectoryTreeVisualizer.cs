using System;
using System.IO;
using System.Threading;

namespace DirectoryTree
{
    public class DirectoryTreeVisualizer
    {
        private int numberOfSpaces;
        public void DirectorySearch(string root)
        {
            foreach (var dir in Directory.GetDirectories(root))
            {
                //Thread.Sleep(800);   // to delay outputing time
                Console.Write(new string(' ', numberOfSpaces));
                Console.WriteLine(dir);
                if (Directory.GetDirectories(dir).Length == 0) continue;
                numberOfSpaces += 2;
                DirectorySearch(dir);
                numberOfSpaces -= 2;
            }
        }
    }
}

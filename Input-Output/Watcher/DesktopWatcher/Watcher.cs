using System;
using System.IO;

namespace DesktopWatcher
{
    public class Watcher
    {
        public static void WatchDesktop()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fsWatcher = new FileSystemWatcher(desktopPath) { EnableRaisingEvents = true };

            fsWatcher.Created += OnChanged;
            fsWatcher.Changed += OnChanged;
            fsWatcher.Deleted += OnChanged;
            fsWatcher.Renamed += OnRenamed;

            while (Console.Read() == 'q')
            {
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }
    }
}

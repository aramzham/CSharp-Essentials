using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FolderShield
{
    public class ProtectMyDesktop
    {
        public static void DefendMyDesktop()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fsWatcher = new FileSystemWatcher(desktopPath) { EnableRaisingEvents = true };

            fsWatcher.Created += OnCreated;
            fsWatcher.Changed += OnChanged;
            fsWatcher.Deleted += OnDeleted;
            fsWatcher.Renamed += OnRenamed;

            while (Console.Read() == 'q')
            {
            }
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("Please, don't destroy my Desktop", "FolderShield", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("Please, don't add junk on my Desktop", "FolderShield", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            while (true)
            {
                if (File.Exists(e.FullPath))
                {
                    Thread.Sleep(3000);
                    MessageBox.Show("Dis ah nah cool. Remove dat dodo!", "FolderShield", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else break;
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show("Please, don't rename my Desktop files", "FolderShield", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            MessageBox.Show("Please, don't change anything on my Desktop", "FolderShield", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }
    }
}

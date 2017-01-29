using System;
using System.IO;
using Translator;
using DirectoryTree;
using OrganizeFolder;

namespace CreateChangeDeleteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //var text = "մենք բոլորով հավաքվել ենք բղդո ձաձայենց տանը :)";
            //var translator = new ArmenianToTranslite();
            //translator.TranslateAndWriteToFile(text);
            //translator.DeleteTranslatedFile();

            //var dt = new DirectoryTreeVisualizer();
            //dt.DirectorySearch(@"D:\screen capture\");

            //var directoryPath = @"C:\Users\HP\Desktop\Backup";
            var directoryPath = Console.ReadLine();
            var organizer = new SortFiles();
            organizer.SortFilesByExtension(directoryPath);

            Console.ReadKey();
        }
    }
}

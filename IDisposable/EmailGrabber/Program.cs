using System;
using System.IO;
using SpamSender;

namespace EmailGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputFile = @"outputtext.txt";
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var HTMLFile = Path.Combine(desktop, outputFile);
            const string site = "http://www.mail.ru/";
            using (var downloader = new HTMLDownloader(HTMLFile))
            {
                downloader.Save(site, HTMLFile); 
            }

            var mailFinder = new FindWriteEmails();
            var emailsFile = @"C:\Users\HP\Desktop\emails.txt";
            mailFinder.WriteEmailsInFile(HTMLFile, emailsFile);
        }
    }
}

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
            const string site = "https://geheniaraqel.wordpress.com/";

            using (var downloader = new HTMLDownloader(HTMLFile))
            {
                downloader.Save(site, HTMLFile);
            }

            var grabber = new Grabber();
            var emailsFile = @"C:\Users\HP\Desktop\emails.txt";
            //grabber.WriteEmailsInFile(HTMLFile, emailsFile);
            grabber.WriteUrlsInFile(HTMLFile, emailsFile);

            var links = File.ReadAllLines(emailsFile);
            var newFilePath = string.Empty;
            var newUrls = string.Empty;

            for (int i = 0; i < links.Length; i++)
            {
                newFilePath = $@"C:\Users\HP\Desktop\New folder\{i}.txt";
                using (var downloader = new HTMLDownloader(HTMLFile))
                {
                    downloader.Save(links[i], newFilePath);
                }
                newUrls = $@"C:\Users\HP\Desktop\New folder\new urls\{i}.txt";
                grabber.WriteUrlsInFile(newFilePath, newUrls);
            }
        }
    }
}

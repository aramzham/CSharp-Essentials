using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static Regex imageUrlRegex = new Regex("/upload.*?\\.jpg", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            var links = File.ReadAllLines(@"C:\Users\Aram\Desktop\atkritkas\links.txt");
            var count = 0;
            foreach (var link in links)
            {
                try
                {
                    Console.WriteLine(count);
                    var page = SendGetRequest(link);
                    var url = GetUrl(page);
                    File.AppendAllText(@"C:\Users\Aram\Desktop\atkritkas\imageLinks.txt", $"http://www.atkritka.com{url}{Environment.NewLine}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    count++;
                }
            }
        }

        private static void DownloadFile(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }

        private static string SendGetRequest(string url)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }

        private static string GetUrl(string page)
        {
            var url = imageUrlRegex.Match(page).Groups[0].Value;
            return url;
        }
    }
}

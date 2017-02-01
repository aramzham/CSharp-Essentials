using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpamSender
{
    public class Grabber
    {
        private bool IsEmail(string emailString)
        {
            return Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //return Regex.IsMatch(emailString, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);  //Van's version
        }

        private bool IsUrl(string url)
        {
            //Uri uriResult;
            //return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            //return Uri.IsWellFormedUriString(url, UriKind.Absolute);

            var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return linkParser.IsMatch(url);
        }

        public void WriteEmailsInFile(string readFilePath, string writeFilePath)
        {
            var text = File.ReadAllText(readFilePath);
            const string MatchEmailPattern =
           @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            var rx = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(text);
            var noOfMatches = matches.Count;

            using (var sw = new StreamWriter(writeFilePath))
            {
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Value.ToString());
                    sw.WriteLine(match.Value);
                }
                sw.WriteLine($"Found {noOfMatches} matches");
            }
            #region First try
            //var text = string.Empty;
            //try
            //{
            //    text = File.ReadAllText(readFilePath);
            //}
            //catch (FileLoadException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //var emails = text.Split(' ').Where(IsEmail);

            //try
            //{
            //    File.WriteAllLines(writeFilePath, emails);
            //}
            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
#endregion
        }

        public void WriteUrlsInFile(string readFilePath, string writeFilePath)
        {
            var text = string.Empty;
            try
            {
                text = File.ReadAllText(readFilePath);
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e.Message);
            }

            var urls = text.Split(' ').Where(IsUrl);

            try
            {
                File.WriteAllLines(writeFilePath, urls);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

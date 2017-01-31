using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpamSender
{
    public class FindWriteEmails
    {
        private bool IsEmail(string emailString)
        {
            return Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public void WriteEmailsInFile(string readFilePath, string writeFilePath)
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

            var emails = text.Split(' ').Where(IsEmail);

            try
            {
                File.WriteAllLines(writeFilePath, emails);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

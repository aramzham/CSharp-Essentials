using System.Net;
using System.Net.Mail;

namespace SpamSender
{
    class MailSender
    {
        public void SendMessage(string message)
        {
            var msg = new MailMessage("/*your gmail*/", "/*client mail*/", "Subject", message) { IsBodyHtml = true };
            var sc = new SmtpClient("smtp.gmail.com", 587) { UseDefaultCredentials = false };
            var cre = new NetworkCredential("/*your gmail*/", "/*your password*/");
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
        }
    }
}

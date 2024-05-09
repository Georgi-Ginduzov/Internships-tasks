using SpaceShuttleLaunch.Services.Contracts;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SpaceShuttleLaunch.Services
{
    public class EmailService : IEmail
    {
        private static readonly Regex EmailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b", RegexOptions.Compiled);
        private string senderEmail;
        private string password;
        public EmailService(string senderEmail, string senderPassword)
        {
            SenderEmail = senderEmail;
            password = senderPassword;
        }

        public string SenderEmail 
        { 
            get => senderEmail;
            set
            {
                if (ValidEmail(value))
                {
                    senderEmail = value;
                }
                else
                {
                    Console.WriteLine("Invalid email address! Please try again.");
                    SenderEmail = Console.ReadLine();
                }
            }
        }
        
        public bool Send(string recipientEmail, string subject, string body)
        {
            if(!ValidEmail(recipientEmail))
            {
                Console.WriteLine("Recipient email addres incorrect! Please try again.");
                recipientEmail = Console.ReadLine();

                Send(recipientEmail, subject, body); // or cycle with max attempts
            }

            using (var mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body))
            using (var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, password),
                EnableSsl = true,
            })
            {
                smtpClient.Send(mailMessage);
            }

            return true;
        }

        private bool ValidEmail(string email)
        {
            return EmailRegex.IsMatch(email);
        }
    }
}

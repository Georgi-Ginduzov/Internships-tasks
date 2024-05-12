using SpaceShuttleLaunch.Services.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SpaceShuttleLaunch.Services
{
    public class EmailService : IEmail
    {
        private static readonly Regex EmailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b", RegexOptions.Compiled);
        private readonly int maxTries = 5;
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
            private set
            {
                if (IsValidEmail(value))
                {
                    senderEmail = value;
                }
                else
                {
                    for (int i = 0; i < maxTries; i++)
                    {
                        Console.WriteLine(ExceptionMessages.InvalidEmail);
                        value = Console.ReadLine();
                        if (IsValidEmail(value))
                        {
                            senderEmail = value;
                            return;
                        }
                    }

                    Console.WriteLine(ExceptionMessages.MaxAttemptsReached);
                    Environment.Exit(0);
                }
            }
        }
        
        public bool Send(string recipientEmail, string subject, string text, string attachmentLocation)
        {
            if (!IsValidEmail(recipientEmail))
            {
                return false;
            }

            try
            {
                using (var mailMessage = new MailMessage(senderEmail, recipientEmail, subject, text))
                {
                    if (IsValidFile(attachmentLocation))
                    {
                        mailMessage.Attachments.Add(new Attachment(attachmentLocation));
                    }
                    else
                    {
                        return false;
                    }

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

                }

            }
            catch (SmtpException ex)
            {
                switch (ex.StatusCode)
                {
                    case SmtpStatusCode.GeneralFailure:
                        Console.WriteLine(ExceptionMessages.GeneralFailure);
                        break;
                    case SmtpStatusCode.MailboxBusy:
                    case SmtpStatusCode.MailboxUnavailable:
                        Console.WriteLine();
                        break;
                    case SmtpStatusCode.ExceededStorageAllocation:
                        Console.WriteLine(ExceptionMessages.ExceededStorageAllocation);
                        break;
                    case SmtpStatusCode.TransactionFailed:
                        Console.WriteLine(ExceptionMessages.TransactionFailed);
                        break;
                    case SmtpStatusCode.ClientNotPermitted:
                        Console.WriteLine(ExceptionMessages.ClientNotPermitted);
                        break;
                    default:
                        Console.WriteLine(ExceptionMessages.EmailNotSentError, ex.Message);
                        break;
                }

                return false;
            }
            
            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (!EmailRegex.IsMatch(email))
            {
                Console.WriteLine(ExceptionMessages.InvalidRecipientEmail);
                for (int i = 0; i < maxTries; i++)
                {
                    Console.WriteLine(ExceptionMessages.InvalidEmail);
                    email = Console.ReadLine();

                    if (EmailRegex.IsMatch(email))
                    {
                        return true;
                    }
                }

                Console.WriteLine(ExceptionMessages.MaxAttemptsReached);
            }
            return false;
        }

        private bool IsValidFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine(ExceptionMessages.InvalidRecipientEmail);
                for (int i = 0; i < maxTries; i++)
                {
                    Console.WriteLine(ExceptionMessages.PathIncorrect, path);
                    path = Console.ReadLine();

                    if (File.Exists(path))
                    {
                        return true;
                    }
                }

                Console.WriteLine(ExceptionMessages.MaxAttemptsReached);
            }

            return false;
        }

    }
}

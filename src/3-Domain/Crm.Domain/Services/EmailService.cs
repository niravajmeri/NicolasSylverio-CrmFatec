using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Crm.Domain.Services
{
    public class EmailService : IEmailService
    {
        private const string Host = "smtp.mailtrap.io";
        private const string CredencialsUserName = "9f060dd0b0263b";
        private const string CredentialsPassword = "22d02ee66e21ff";
        private const int Port = 2525;
        private const string From = "nicolas@fatec.com";

        Task IEmailService.SendEmailAsync(EmailMessage emailMessage)
        {
            return SendEmailAsync(emailMessage);
        }

        private static Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient
            {
                Host = Host,
                Credentials = new NetworkCredential(CredencialsUserName, CredentialsPassword),
                EnableSsl = true,
                Port = Port
            };

            client.Send(From, email, subject, message);

            return Task.CompletedTask;
        }

        Task IEmailService.SendEmailAsync(string email, string subject, string message)
        {
            return SendEmailAsync(email, subject, message);
        }

        private static Task SendEmailAsync(MailMessage emailMessage)
        {
            var client = new SmtpClient
            {
                Host = Host,
                Credentials = new NetworkCredential(CredencialsUserName, CredentialsPassword),

                EnableSsl = true,
                Port = Port
            };

            client.Send(emailMessage);

            return Task.CompletedTask;
        }
    }
}
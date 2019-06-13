using Crm.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Crm.Domain.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient
            {
                Host = "smtp.mailtrap.io",
                Credentials = new NetworkCredential("9f060dd0b0263b", "22d02ee66e21ff"),
                EnableSsl = true,
                Port = 2525
            };

            client.Send("from@example.com", email, subject, message);

            return Task.CompletedTask;
        }
    }
}
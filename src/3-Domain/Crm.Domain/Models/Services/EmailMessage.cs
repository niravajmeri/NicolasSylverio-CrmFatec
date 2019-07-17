using System.Net.Mail;

namespace Crm.Domain.Models.Services
{
    public class EmailMessage : MailMessage
    {
        public EmailMessage
        (
            string from,
            string to,
            string subject,
            string body
        )
            : base(from, to, subject, body)
        {
            Priority = MailPriority.Normal;
            IsBodyHtml = true;
        }
    }
}
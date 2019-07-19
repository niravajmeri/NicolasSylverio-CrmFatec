using System.Net.Mail;
using System.Threading.Tasks;
using Crm.Domain.Models.Services;

namespace Crm.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(MailMessage emailMessage);
    }
}
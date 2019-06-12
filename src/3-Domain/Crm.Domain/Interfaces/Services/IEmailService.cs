using System.Threading.Tasks;

namespace Crm.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
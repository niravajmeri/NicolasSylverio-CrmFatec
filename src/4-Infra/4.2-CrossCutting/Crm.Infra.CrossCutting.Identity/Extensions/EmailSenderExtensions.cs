using Crm.Domain.Interfaces.Services;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Crm.Infra.CrossCutting.Identity.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailService emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirme seu e-mail",
                $"Por favor confirme sua conta clicando no link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
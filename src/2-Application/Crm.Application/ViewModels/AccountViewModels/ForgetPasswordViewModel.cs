using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.AccountViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "O campo E-Mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [MaxLength(100, ErrorMessage = "O campo E-Mail deve ter menos que 100 caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}

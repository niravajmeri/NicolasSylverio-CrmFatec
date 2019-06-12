using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "nova Senha")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "A confirmação não combina com a senha digitada")]
        public string ConfirmeSenha { get; set; }

        public string StatusMessage { get; set; }
    }
}

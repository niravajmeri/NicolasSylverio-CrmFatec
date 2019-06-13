using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter pelo menos {2} e no maximo {1} caracteres no maximo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Senha", ErrorMessage = "A Senha especificada com a confirmação não batem")]
        public string ConfirmarSenha { get; set; }

        public string Code { get; set; }
    }
}
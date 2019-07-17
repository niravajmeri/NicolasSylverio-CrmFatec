using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "E-mail não informado")]
        [MinLength(5, ErrorMessage = "O campo E-Mail deve ter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo E-Mail deve ter no maximo 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha não infomada")]
        [MinLength(6, ErrorMessage = "O campo Senha deve ter no minimo 6 caracteres")]
        [MaxLength(16, ErrorMessage = "O campo Senha deve ter no maximo 16 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação não combinam.")]
        public string ConfirmarSenha { get; set; }
    }
}
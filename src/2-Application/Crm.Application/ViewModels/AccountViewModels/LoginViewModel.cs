using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "E-mail não informado")]
        [MinLength(5, ErrorMessage = "O campo Nome deve ter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no maximo 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required(ErrorMessage = "Senha não infomada")]
        [MinLength(6, ErrorMessage = "O campo Nome deve ter no minimo 6 caracteres")]
        [MaxLength(16, ErrorMessage = "O campo Nome deve ter no maximo 16 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool RememberMe { get; set; }
    }
}
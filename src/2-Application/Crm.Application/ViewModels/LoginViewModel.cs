using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail não informado")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail formato inválido")]
        [MinLength(5, ErrorMessage = "O campo Nome deve ter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no maximo 100 caracteres")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha não infomada")]
        [MinLength(6, ErrorMessage = "O campo Nome deve ter no minimo 6 caracteres")]
        [MaxLength(16, ErrorMessage = "O campo Nome deve ter no maximo 16 caracteres")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
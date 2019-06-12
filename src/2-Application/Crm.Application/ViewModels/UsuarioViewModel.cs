using Crm.Domain.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]        
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatorio")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Números e caracteres especiais não são permitidos.")]
        [MinLength(3, ErrorMessage = "O campo Nome deve ter no minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "O campo Nome deve ter no maximo 50 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo Sobrenome é Obrigatorio")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Números e caracteres especiais não são permitidos.")]
        [MinLength(3, ErrorMessage = "O campo Sobrenome deve ter no minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "O campo sobrenome deve ter no maximo 50 caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O Campo Login é Obrigatorio")]
        [MaxLength(20, ErrorMessage = "O campo Login deve ter no maximo 20 caracteres")]
        [MinLength(6, ErrorMessage = "O campo Login deve ter pelo menos 6 caracteres")]
        [DisplayName("Login")]
        public string Login { get; set; }

        [PasswordPropertyText]
        [Required(ErrorMessage = "O Campo Senha é Obrigatorio")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "O campo Senha deve ter no maximo 20 caracteres")]
        [MinLength(6, ErrorMessage = "O campo Senha deve ter pelo menos 6 caracteres")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Campo E-Mail é Obrigatorio")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "O campo E-Mail deve ter menos que 100 caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo Cpf é Obrigatorio")]
        [MaxLength(11, ErrorMessage = "O campo Cpf deve ter no maximo 11 caracteres")]
        [MinLength(10, ErrorMessage = "O campo Cpf deve ter pelo menos 10 caracteres")]
        [DisplayName("Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo Celular é Obrigatorio")]
        [MaxLength(9, ErrorMessage = "O campo Celular deve ter 9 caracteres")]
        [MinLength(9, ErrorMessage = "O campo Celular deve ter 9 caracteres")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O Campo Data Nascimento é Obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento no formato invalido")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        
        [DisplayName("Tipo Permissão")]
        [EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario TipoUsuario { get; set; }

        [DisplayName("Sexo")]
        [EnumDataType(typeof(TipoSexo))]
        public TipoSexo Sexo { get; set; }
    }
}

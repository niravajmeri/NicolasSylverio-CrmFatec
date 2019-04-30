using System;
using Crm.Domain.Enum;

namespace Crm.Domain.Models.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public TipoSexo Sexo { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
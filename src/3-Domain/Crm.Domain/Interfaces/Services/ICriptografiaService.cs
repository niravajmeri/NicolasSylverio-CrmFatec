using Crm.Domain.Models.Usuarios;

namespace Crm.Domain.Interfaces.Services
{
    public interface ICriptografiaService
    {
        string CriptografarSenha(string texto, string chave);
        bool ValidarSenha(string senha, LoginInput login);
        string Criptografar(string texto);
        string Descriptografar(string texto);
    }
}
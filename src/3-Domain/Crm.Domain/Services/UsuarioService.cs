using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Interfaces.Services;

namespace Crm.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}
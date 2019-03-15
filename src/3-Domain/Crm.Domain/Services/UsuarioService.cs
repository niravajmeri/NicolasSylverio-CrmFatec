using Crm.Domain.Entities;
using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Interfaces.Services;

namespace Crm.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}
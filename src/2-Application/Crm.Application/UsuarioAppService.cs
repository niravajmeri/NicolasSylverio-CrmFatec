using Crm.Application.Interface;
using Crm.Domain.Entities;

namespace Crm.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioAppService(IUsuarioAppService usuarioAppService)
            : base(usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }
    }
}
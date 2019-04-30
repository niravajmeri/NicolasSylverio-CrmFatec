using Crm.Application.ViewModels;
using Crm.Domain.Models;
using System.Collections.Generic;
using Crm.Domain.Models.Usuarios;

namespace Crm.Application.Interface
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario> 
    {
        void Cadastrar(UsuarioViewModel usuarioViewModel);

        IEnumerable<UsuarioViewModel> GetAllUsuarioViewModel();
    }
}
using Crm.Application.ViewModels.PermissionViewModels;
using Crm.Domain.Models.Permission;
using System.Collections.Generic;

namespace Crm.Application.Interface
{
    public interface IPermissionAppService
    {
        UserPermissionViewModel ListAllUserPermission(ApplicationUser appUser);

        IEnumerable<RoleViewModel> ListAllRoles();

        ConsultaUsuarioViewModel ListAllUsers();
    }
}
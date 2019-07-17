using AutoMapper;
using Crm.Application.ViewModels;
using Crm.Application.ViewModels.PermissionViewModels;
using Crm.Domain.Models.Permission;
using Crm.Domain.Models.Usuarios;

namespace Crm.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, ViewModels.UsuarioViewModel>();
            CreateMap<UserPermission, UserPermissionViewModel>();
            CreateMap<Role, RoleViewModel>();
        }
    }
}
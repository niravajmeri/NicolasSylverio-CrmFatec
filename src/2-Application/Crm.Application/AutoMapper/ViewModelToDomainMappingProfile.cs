using AutoMapper;
using Crm.Application.ViewModels;
using Crm.Application.ViewModels.PermissionViewModels;
using Crm.Domain.Models.Permission;
using Crm.Domain.Models.Usuarios;

namespace Crm.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ViewModels.UsuarioViewModel, Usuario>();
            CreateMap<UserPermissionViewModel, UserPermission>();
            CreateMap<RoleViewModel, Role>();
        }
    }
}
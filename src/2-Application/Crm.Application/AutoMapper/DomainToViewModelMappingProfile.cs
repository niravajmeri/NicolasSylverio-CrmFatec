using AutoMapper;
using Crm.Application.ViewModels;
using Crm.Domain.Models;
using Crm.Domain.Models.Usuarios;

namespace Crm.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
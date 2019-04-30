using AutoMapper;
using Crm.Application.ViewModels;
using Crm.Domain.Models;
using Crm.Domain.Models.Usuarios;

namespace Crm.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
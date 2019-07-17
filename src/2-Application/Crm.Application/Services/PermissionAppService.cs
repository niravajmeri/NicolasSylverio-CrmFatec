using AutoMapper;
using Crm.Application.Interface;
using Crm.Application.ViewModels.PermissionViewModels;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Permission;
using Crm.Infra.CrossCutting.Identity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Application.Services
{
    public class PermissionAppService : IPermissionAppService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionAppService
        (
            IIdentityRepository identityRepository,
            IPermissionService permissionService,
            IMapper mapper
        )
        {
            _identityRepository = identityRepository;
            _permissionService = permissionService;
            _mapper = mapper;
        }

        public UserPermissionViewModel ListAllUserPermission(ApplicationUser appUser)
        {
            var userClaims = _identityRepository.GetClaimsByUser(appUser);

            var userRoles = _identityRepository.GetPermissionsRoleByUser(appUser);

            var UserPermission = _permissionService.ComposeUserPermission(appUser, userRoles, userClaims);

            return _mapper.Map<UserPermissionViewModel>(UserPermission);
        }

        public IEnumerable<RoleViewModel> ListAllRoles()
        {
            var allRoles = _identityRepository.GetAllRoles().ToList();

            var lista = new List<RoleViewModel>();

            foreach (var item in allRoles)
            {
                var role = _permissionService.ComposeRole(item, _identityRepository.GetClaimByRole(item));

                lista.Add(_mapper.Map<RoleViewModel>(role));
            }

            return lista;
        }

        public ConsultaUsuarioViewModel ListAllUsers()
        {
            return new ConsultaUsuarioViewModel
            {
                ListaUsuarios = _identityRepository.GetAllUsers()
            };
        }
    }
}
using AutoFixture;
using AutoMapper;
using Crm.Application.Services;
using Crm.Application.ViewModels.PermissionViewModels;
using Crm.Domain.Enum;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Permission;
using Crm.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace Crm.Test
{
    public class PermissionAppServiceTest
    {
        private readonly PermissionAppService _permissionAppServiceMock;
        private readonly IPermissionService _permissionServiceMock;
        private readonly Mock<IIdentityRepository> _identityRepositoryMock;
        private readonly IMapper _mapperMock;

        private Role _role;

        private readonly Fixture _fixture;

        public PermissionAppServiceTest()
        {
            _fixture = new Fixture();

            var mapperMock = new Mock<IMapper>();
            _mapperMock = mapperMock.Object;

            ConfigureRoleList();

            var permissionServiceMock = new Mock<IPermissionService>();

            permissionServiceMock
                .Setup(x => x.ComposeRole(It.IsAny<IdentityRole>(), It.IsAny<IEnumerable<Claim>>()))
                .Returns(ConfigureRole());

            _permissionServiceMock = permissionServiceMock.Object;

            var identityRepositoryMock = new Mock<IIdentityRepository>();

            identityRepositoryMock
                .Setup(x => x.GetAllRoles())
                .Returns(ConfigureIdentityRole());

            identityRepositoryMock
                .Setup(x => x.GetAllUsers())
                .Returns(new List<ApplicationUser>());

            _identityRepositoryMock = identityRepositoryMock;

            _permissionAppServiceMock = new PermissionAppService
                (
                    identityRepositoryMock.Object,
                    _permissionServiceMock,
                    _mapperMock
                );
        }

        private void ConfigureRoleList(IEnumerable<Role> roles = null)
        {
            _role = ConfigureRole();

            if (roles == null)
            {
                roles = new List<Role>
                {
                    ConfigureRole(),
                    _role
                };
            }

            //_roleViewModel = _mapperMock.Map<IEnumerable<RoleViewModel>>(roles);
        }

        private Role ConfigureRole()
        {
            var roleClaims = new List<Claim>
            {
                new Claim(_fixture.Create<string>(), _fixture.Create<string>()),
                new Claim(CustomClaimTypes.Menu, _fixture.Create<string>())
            };

            return new Role(ConfigureIdentityRole().First(), roleClaims);
        }

        private IEnumerable<IdentityRole> ConfigureIdentityRole()
        {
            return new List<IdentityRole>
            {
                new IdentityRole(_fixture.Create<string>()),
                new IdentityRole(_fixture.Create<string>())
            };
        }

        [Fact]
        public void Deve_Retornar_Todas_As_Permissoes()
        {
            var roles = _permissionAppServiceMock.ListAllRoles();

            Assert.IsType<List<RoleViewModel>>(roles);
            _identityRepositoryMock.Verify(x => x.GetAllRoles(), Times.Once);
        }

        [Fact]
        public void Deve_Retornar_Todos_Os_Usuarios()
        {
            var users = _permissionAppServiceMock.ListAllUsers();

            Assert.IsType<ConsultaUsuarioViewModel>(users);
            _identityRepositoryMock.Verify(x => x.GetAllUsers(), Times.AtLeastOnce);
        }
    }
}
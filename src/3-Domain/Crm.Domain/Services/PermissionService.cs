using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Permission;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Domain.Services
{
    public class PermissionService : IPermissionService
    {
        public PermissionService()
        {
        }

        public Role ComposeRole
        (
            IdentityRole identityRole,
            IEnumerable<Claim> claims
        )
        {
            return new Role(identityRole, claims);
        }

        public UserPermission ComposeUserPermission
        (
            ApplicationUser appUser, 
            IEnumerable<string> roles, 
            IEnumerable<Claim> claims
        )
        {
            return new UserPermission(appUser, roles, claims);
        }
    }
}
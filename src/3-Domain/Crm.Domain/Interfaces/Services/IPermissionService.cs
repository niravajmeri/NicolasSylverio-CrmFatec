using Crm.Domain.Models.Permission;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Domain.Interfaces.Services
{
    public interface IPermissionService
    {
        UserPermission ComposeUserPermission
        (
            ApplicationUser appUser,
            IEnumerable<string> roles,
            IEnumerable<Claim> claims
        );

        Role ComposeRole
        (
            IdentityRole identityRole,
            IEnumerable<Claim> claims
        );
    }
}
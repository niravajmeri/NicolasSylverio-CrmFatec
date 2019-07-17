using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Domain.Models.Permission
{
    public class Role
    {
        public Role(IdentityRole identityRole, IEnumerable<Claim> claims)
        {
            IdentityRole = identityRole;
            RoleClaims = claims;
        }

        public IdentityRole IdentityRole { get; set; }
        public IEnumerable<Claim> RoleClaims { get; set; }
    }
}
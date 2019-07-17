using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Domain.Models.Permission
{
    public class UserPermission
    {
        public UserPermission
        (
            ApplicationUser user,
            IEnumerable<string> roles,
            IEnumerable<Claim> claims
        )
        {
            User = user;
            Roles = roles;
            Claims = claims;
        }

        public ApplicationUser User { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}
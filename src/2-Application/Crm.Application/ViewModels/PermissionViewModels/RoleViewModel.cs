using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Application.ViewModels.PermissionViewModels
{
    public class RoleViewModel
    {
        public IdentityRole IdentityRole { get; set; }
        public IEnumerable<Claim> RoleClaims { get; set; }
    }
}
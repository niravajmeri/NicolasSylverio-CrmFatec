using Crm.Domain.Models.Permission;
using Crm.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crm.Infra.CrossCutting.Identity
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityRepository
        (
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }

        public IList<Claim> GetClaimsByUser(ApplicationUser appUser)
        {
            return _userManager.GetClaimsAsync(appUser).Result;
        }

        public IEnumerable<string> GetPermissionsRoleByUser(ApplicationUser appUser)
        {
            return _userManager.GetRolesAsync(appUser).Result;
        }

        public IEnumerable<Claim> GetClaimByRole(IdentityRole appRole)
        {
            return _roleManager.GetClaimsAsync(appRole).Result;
        }

        public async Task AddRoleAsync(IdentityRole appRole)
        {
            await _roleManager.CreateAsync(appRole);
        }

        public void AddClaimToRole(IdentityRole appRole, IEnumerable<Claim> claims)
        {
            claims.ToList().ForEach(async x => await _roleManager.AddClaimAsync(appRole, x));
        }

        public async Task AddUserToRoleAsync(ApplicationUser appUser, IdentityRole appRole)
        {
            await _userManager.AddToRoleAsync(appUser, appRole.Name);
        }

        public IdentityRole GetRoleByName(string nome)
        {
            return _roleManager.Roles.FirstOrDefault(x => x.Name == nome);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public IEnumerable<ApplicationUser> GetAllUsersByName(string name)
        {
            return _userManager.Users.Where(x => x.UserName.Contains(name));
        }

        public IEnumerable<ApplicationUser> GetAllUsersByEmail(string email)
        {
            return _userManager.Users.Where(x => x.Email.Contains(email));
        }
    }
}
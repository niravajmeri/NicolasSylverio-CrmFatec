using Crm.Domain.Models.Permission;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crm.Infra.CrossCutting.Identity.Interfaces
{
    public interface IIdentityRepository
    {
        IEnumerable<IdentityRole> GetAllRoles();

        IdentityRole GetRoleByName(string nome);

        IList<Claim> GetClaimsByUser(ApplicationUser appUser);

        IEnumerable<string> GetPermissionsRoleByUser(ApplicationUser appUser);

        IEnumerable<Claim> GetClaimByRole(IdentityRole appRole);

        Task AddRoleAsync(IdentityRole appRole);

        void AddClaimToRole(IdentityRole appRole, IEnumerable<Claim> claims);

        Task AddUserToRoleAsync(ApplicationUser appUser, IdentityRole appRole);

        IEnumerable<ApplicationUser> GetAllUsers();

        IEnumerable<ApplicationUser> GetAllUsersByName(string name);

        IEnumerable<ApplicationUser> GetAllUsersByEmail(string email);
    }
}
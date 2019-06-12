using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Infra.CrossCutting.Identity.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
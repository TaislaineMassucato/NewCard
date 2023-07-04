using NewCard.Models;
using System.Security.Claims;

namespace NewCard.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this Medico medico)
        {
            var result = new List<Claim>
        {
            new(ClaimTypes.Name, medico.Email)
        };
            result.AddRange(
                medico.Email.Select(role => new Claim(ClaimTypes.Email, "taislaine.m@gmail.com"))
            );
            return result;
        }
    }
}

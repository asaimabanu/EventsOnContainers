using System.Security.Claims;
using System.Security.Principal;
using WebMvc.Models;

namespace WebMvc.Services
    {
    public class IdentityService : IIdentiyService<ApplicationUser>
        {
        public ApplicationUser Get(IPrincipal principal)
            {
            if (principal is ClaimsPrincipal claims)
                {
                var user = new ApplicationUser()
                    {
                    Email = claims.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value ?? "",
                    Id = claims.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value ?? ""
                    };
                return user;
                }
            throw new ArgumentException(message: "The Principal must be a claims principal", 
                paramName:nameof(principal));
            }
        }
    }

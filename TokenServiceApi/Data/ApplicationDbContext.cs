using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TokenService.Data
    {
    public class ApplicationDbContext : IdentityDbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        }

    /*public class ApplicationRoleManager : RoleManager<IdentityRole>
        {
        public ApplicationRoleManager(RoleStore<IdentityRole> roleStore) : base(roleStore) { }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOContext context) 
            {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            }
        }*/
    }

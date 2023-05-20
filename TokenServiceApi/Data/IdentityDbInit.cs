using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TokenService.Data
    {
    public class IdentityDbInit
        {

        private static UserManager<IdentityUser> _userManager;

        public static async Task Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager)
            {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

            //Create a new dataase when "Migrate" is used, rather than "Ensure Created"
            context.Database.Migrate();

            //If there is an administrator role, abort
            //if(context.Roles.Any(r => r.Name == "Administrator") return;

            //Create the "Administrator" role
            //await roleManager.CreateAsync(new IdentityRole("Administrator"));

            if (context.Users.Any(r => r.UserName == "me@myemail.com")) return;

            //Create the default Admin account and assign the user the "Administrator" role
            string user = "me@myemail.com";
            string password = "Password@1";

            await _userManager.CreateAsync(new IdentityUser { Email = user, UserName = user, EmailConfirmed = true}, password);
            //await _userManager.AddToRoleAsync(await userManager.FindByNameAsync(user), "Administrator");
            }
        }
    }

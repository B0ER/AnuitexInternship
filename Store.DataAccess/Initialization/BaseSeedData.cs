using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Initialization
{
    internal static class BaseSeedData
    {
        public static async void AddRoles(RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role { Name = Constants.Roles.Admin });
            await roleManager.CreateAsync(new Role { Name = Constants.Roles.User });
            await roleManager.CreateAsync(new Role { Name = Constants.Roles.Guest });
        }

        public static async void AddAdmins(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser { UserName = Constants.Roles.Admin };
            await userManager.CreateAsync(admin);
            await userManager.AddPasswordAsync(admin, "pas");
            await userManager.AddToRoleAsync(admin, Constants.Roles.Admin);
        }
    }
}

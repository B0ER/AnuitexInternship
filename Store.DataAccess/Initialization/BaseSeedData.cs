using System;
using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.DataAccess.Initialization
{
    public static class BaseSeedData
    {
        private static async Task AddRolesAsync(RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role { Name = Constants.Roles.Admin });
            await roleManager.CreateAsync(new Role { Name = Constants.Roles.User });
        }

        private static async Task AddAdminsAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser
            {
                UserName = Constants.AdminEmail,
                Email = Constants.AdminEmail,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            IdentityResult result = await userManager.CreateAsync(admin, Constants.AdminPassword);
            await userManager.AddToRoleAsync(admin, Constants.Roles.Admin);
        }

        public static async Task InitIfNotExist(RoleManager<Role> roleManager, UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.FindByEmailAsync(Constants.AdminEmail);
            if (admin == null)
            {
                await AddRolesAsync(roleManager);
                await AddAdminsAsync(userManager);
            }
        }
    }
}

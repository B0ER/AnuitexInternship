using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Initialization
{
    internal static class BaseSeedData
    {
        public static void AddRoles(ModelBuilder dbBuilder)
        {
            dbBuilder.Entity<Role>().HasData(
                new Role { Name = Constants.Roles.Admin },
                new Role { Name = Constants.Roles.User },
                new Role { Name = Constants.Roles.Guest }
            );
        }

        public static async void AddAdmins(UserManager<ApplicationUser> userManager)
        {
            //TODO: rewrite

            var admin = new ApplicationUser { UserName = Constants.Roles.Admin };
            await userManager.CreateAsync(admin);
            await userManager.AddPasswordAsync(admin, "pas");
            await userManager.AddToRoleAsync(admin, Constants.Roles.Admin);
        }
    }
}

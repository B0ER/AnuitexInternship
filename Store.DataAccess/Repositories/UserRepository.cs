using Microsoft.AspNetCore.Identity;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<Role> _roleManager;

        public UserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager) : base(db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddAsync(ApplicationUser newUser, string password)
        {
            var resultReg = await _userManager.CreateAsync(newUser, password);

            if (!resultReg.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }

        public override async Task<ApplicationUser> FindByIdAsync(long id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task AddRoleAsync(ApplicationUser user, Role roleUser)
        {
            await _userManager.AddToRoleAsync(user, roleUser.Name);
        }

        public async Task DeleteRoleAsync(ApplicationUser user, Role roleUser)
        {
            await _userManager.RemoveFromRoleAsync(user, roleUser.Name);
        }

        public async Task<bool> CheckRoleAsync(ApplicationUser user, Role roleUser)
        {
            return await _userManager.IsInRoleAsync(user, roleUser.Name);
        }
    }
}

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Model.User.Response;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task AddAsync(ApplicationUser item)
        {
            await _userRepository.AddAsync(item);
        }

        public async Task DeleteAsync(ApplicationUser item)
        {
            await _userRepository.DeleteAsync(item);
        }

        public async Task DeleteByIdAsync(long id)
        {
            await _userRepository.DeleteByIdAsync(id);
        }

        public async Task<UserItemModel> FindByIdAsync(long id)
        {
            var appUser = await _userRepository.FindByIdAsync(id);
            var userResponse = new UserItemModel { UserName = appUser.UserName };
            return userResponse;
        }

        public async Task<UserModel> GetAllAsync()
        {
            var appUsers = await _userRepository.GetAllAsync();
            var usersResponse = new UserModel();
            usersResponse.Users = appUsers.Select(user => new UserItemModel { UserName = user.UserName });
            return usersResponse;
        }

        public async Task UpdateAsync(ApplicationUser item)
        {
            await _userRepository.UpdateAsync(item);
        }

        public async Task<UserItemModel> GetProfileAsync(ClaimsPrincipal user)
        {
            var applicationUser = await _userManager.GetUserAsync(user);
            var userItem = new UserItemModel { Id = applicationUser.Id, UserName = applicationUser.UserName };
            return userItem;
        }
    }
}
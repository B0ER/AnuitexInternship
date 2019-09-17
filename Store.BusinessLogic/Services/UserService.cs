using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Model.Users.Request;
using Store.BusinessLogic.Model.Users.Response;
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

        public async Task AddAsync(UserCreateRequest userCreateRequest)
        {
            var newUser = new ApplicationUser();
            newUser.UserName = userCreateRequest.Email;
            newUser.EmailConfirmed = true;
            await _userRepository.AddAsync(newUser, userCreateRequest.Password);
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

        public async Task UpdateAsync(UserUpdateRequest item)
        {
            var userUpdateDb = await _userRepository.FindByIdAsync(item.UserId);
            userUpdateDb.UserName = item.Username;
            userUpdateDb.Email = item.Email;
            userUpdateDb.PasswordHash  =_userManager.PasswordHasher.HashPassword(userUpdateDb, item.Password);

            await _userRepository.UpdateAsync(userUpdateDb);
        }

        public async Task<UserItemModel> GetProfileAsync(ClaimsPrincipal user)
        {
            var applicationUser = await _userManager.GetUserAsync(user);
            var userItem = new UserItemModel { Id = applicationUser.Id, UserName = applicationUser.UserName };
            return userItem;
        }
    }
}
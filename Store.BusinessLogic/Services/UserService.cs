using System.Linq;
using System.Threading.Tasks;
using Store.BusinessLogic.Model.User.Response;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            var userResponse = new UserItemModel {UserName = appUser.UserName};
            return userResponse;
        }

        public async Task<UserModel> GetAllAsync()
        {
            var appUsers = await _userRepository.GetAllAsync();
            var usersResponse = new UserModel();
            usersResponse.Users = appUsers.Select(user => new UserItemModel {UserName = user.UserName});
            return usersResponse;
        }

        public async Task UpdateAsync(ApplicationUser item)
        {
            await _userRepository.UpdateAsync(item);
        }
    }
}
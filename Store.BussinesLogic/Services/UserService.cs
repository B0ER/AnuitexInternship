using Store.BussinesLogic.Model.Base;
using Store.BussinesLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BussinesLogic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

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

        public async Task<BaseItemResponse<UserItem>> FindByIdAsync(long id)
        {
            var appUser = await _userRepository.FindByIdAsync(id);
            var userItem = new UserItem { UserName = appUser.UserName };
            var userResponse = new BaseItemResponse<UserItem> { Item = userItem };
            return userResponse;
        }

        public async Task<BaseListResponse<UserItem>> GetAllAsync()
        {
            var appUsers = await _userRepository.GetAllAsync();
            var userItems = appUsers.Select((user) => new UserItem { UserName = user.UserName });
            var usersResponse = new BaseListResponse<UserItem>();
            return usersResponse;
        }

        public async Task UpdateAsync(ApplicationUser item)
        {
            await _userRepository.UpdateAsync(item);
        }
    }
}

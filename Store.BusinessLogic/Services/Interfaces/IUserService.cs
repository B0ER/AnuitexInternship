using System.Security.Claims;
using System.Threading.Tasks;
using Store.BusinessLogic.Model.User.Request;
using Store.BusinessLogic.Model.User.Response;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetAllAsync();
        Task<UserItemModel> FindByIdAsync(long id);
        Task AddAsync(UserCreateRequest userCreateRequest); 
        Task DeleteAsync(ApplicationUser item); 
        Task DeleteByIdAsync(long id);
        Task UpdateAsync(UserUpdateRequest item); 
        Task<UserItemModel> GetProfileAsync(ClaimsPrincipal user);
    }
}
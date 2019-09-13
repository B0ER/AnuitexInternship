using Store.BussinesLogic.Model.Base;
using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.BussinesLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseListResponse<UserItem>> GetAllAsync();
        Task<BaseItemResponse<UserItem>> FindByIdAsync(long id);
        Task AddAsync(ApplicationUser item); //todo: 
        Task DeleteAsync(ApplicationUser item); //todo: 
        Task DeleteByIdAsync(long id);
        Task UpdateAsync(ApplicationUser item); //todo: 
    }
}

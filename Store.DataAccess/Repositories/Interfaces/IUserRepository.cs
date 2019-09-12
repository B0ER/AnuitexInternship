using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task AddAsync(ApplicationUser newUser, string password);

        Task AddRoleAsync(ApplicationUser user, Role roleUser);
        Task DeleteRoleAsync(ApplicationUser user, Role roleUser);
        Task<bool> CheckRoleAsync(ApplicationUser user, Role roleUser);
    }
}

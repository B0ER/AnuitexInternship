using System.Threading.Tasks;
using Store.BusinessLogic.Model.Authors.Request;
using Store.BusinessLogic.Model.Authors.Response;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorModel> GetAllAsync();
        Task<AuthorItemModel> FindByIdAsync(long id);

        Task CreateAsync(AuthorCreateRequest author);
        Task UpdateAsync(AuthorUpdateRequest author);
        Task DeleteAsync(long id);
    }
}
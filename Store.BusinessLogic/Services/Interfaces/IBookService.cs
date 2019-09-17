using System.Threading.Tasks;
using Store.BusinessLogic.Model.Book.Request;
using Store.BusinessLogic.Model.Book.Response;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookModel> GetAllAsync();
        Task<BookItemModel> FindByIdAsync(long id);
        Task DeleteByIdAsync(long id);
        Task UpdateAsync(BookUpdateRequest book);
    }
}
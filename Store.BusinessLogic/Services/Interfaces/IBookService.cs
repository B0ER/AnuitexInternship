using System.Threading.Tasks;
using Store.BusinessLogic.Model.Books.Request;
using Store.BusinessLogic.Model.Books.Response;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task<BookModel> GetAllAsync();
        Task<BookItemModel> FindByIdAsync(long id);
        Task DeleteByIdAsync(long id);
        Task UpdateAsync(BookUpdateRequest book);
    }
}
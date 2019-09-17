using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorInBookRepository : IGenericRepository<AuthorInBook>
    {
        Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(long bookId);
    }
}
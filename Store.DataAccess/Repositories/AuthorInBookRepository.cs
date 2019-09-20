using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories
{
    public class AuthorInBookRepository : BaseRepository<AuthorInBook>, IAuthorInBookRepository
    {
        public AuthorInBookRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(long bookId)
        {
            return await _dbContext.AuthorInBooks.Where(aib => aib.PrintingEdition.Id == bookId)
                .Select(aib => aib.Author)
                .ToListAsync();
        }
    }
}
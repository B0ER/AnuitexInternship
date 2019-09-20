using Store.DataAccess.AppContext;
using Store.DataAccess.Entities.Interfaces;
using Store.DataAccess.Exceptions;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Store.DataAccess.Repositories.Base
{
    public class BaseRepository<TItem> : IGenericRepository<TItem> where TItem : class, IBaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(TItem item)
        {
            await _dbContext.AddAsync<TItem>(item);
        }

        public virtual async Task DeleteAsync(TItem item)
        {
            item.IsRemoved = true;
            _dbContext.Set<TItem>().Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(long id)
        {
            var deletedItem = await _dbContext.FindAsync<TItem>(id);
            deletedItem.IsRemoved = true;
            _dbContext.Set<TItem>().Update(deletedItem);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TItem> FindByIdAsync(long id)
        {
            var item = await _dbContext.FindAsync<TItem>(id);
            if (item == null)
            {
                throw new ObjectNotFoundException();
            }
            return item;
        }

        public virtual async Task<IEnumerable<TItem>> GetAllAsync()
        {
            return await _dbContext.Set<TItem>().ToListAsync();
        }

        public virtual async Task UpdateAsync(TItem item)
        {
            _dbContext.Update<TItem>(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}

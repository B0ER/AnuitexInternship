using Store.DataAccess.AppContext;
using Store.DataAccess.Entities.Interfaces;
using Store.DataAccess.Exceptions;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Base
{
    public class BaseRepository<TItem> : IGenericRepository<TItem> where TItem : class, IBaseEntity
    {
        protected ApplicationDbContext _db;
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task AddAsync(TItem item)
        {
            await _db.AddAsync<TItem>(item);
        }

        public virtual async Task DeleteAsync(TItem item)
        {
            await Task.Run(() =>
            {
                item.IsRemoved = true;
                _db.Set<TItem>().Update(item);
            });
        }

        public virtual async Task DeleteByIdAsync(long id)
        {
            var deletedItem = await _db.FindAsync<TItem>(id);
            deletedItem.IsRemoved = true;
            await Task.Run(() => _db.Set<TItem>().Update(deletedItem));
        }

        public virtual async Task<TItem> FindByIdAsync(long id)
        {
            var item = await _db.FindAsync<TItem>(id);
            if (item == null)
            {
                throw new ObjectNotFoundException();
            }
            return item;
        }

        public virtual async Task<IEnumerable<TItem>> GetAllAsync()
        {
            return await Task.Run(() => _db.Set<TItem>().ToList());
        }

        public virtual async Task UpdateAsync(TItem item)
        {
            await Task.Run(() => _db.Update<TItem>(item));
        }
    }
}

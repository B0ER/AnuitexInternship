using Store.DataAccess.AppContext;
using Store.DataAccess.Entities.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Base
{
    public class BaseRepository<TItem> : IGenericRepository<TItem> where TItem : BaseEntity
    {
        private ApplicationDbContext _db;
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(TItem item)
        {
            await _db.AddAsync<TItem>(item);
        }

        public async Task DeleteAsync(TItem item)
        {
            await Task.Run(() =>
            {
                _db.Remove<TItem>(item);
            });
        }

        public async Task DeleteByIdAsync(long id)
        {
            var deletedItem = await _db.FindAsync<TItem>(id);
            await Task.Run(() => _db.Remove<TItem>(deletedItem));
        }

        public async Task<TItem> FindByIdAsync(long id)
        {
            return await _db.FindAsync<TItem>(id);
        }

        public async Task<IEnumerable<TItem>> GetAllAsync()
        {
            return await Task.Run(() => _db.Set<TItem>().ToList());
        }

        public async Task UpdateAsync(TItem item)
        {
            await Task.Run(() => _db.Update<TItem>(item));
        }
    }
}

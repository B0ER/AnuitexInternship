using Store.DataAccess.AppContext;
using Store.DataAccess.Entities.Base;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DataAccess.Repositories.Base
{
    public abstract class BaseRepository<TItem> : IGenericRepository<TItem> where TItem : BaseEntity
    {
        private ApplicationDbContext _db;
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(TItem item)
        {
            //todo: rewrite all methods to async methods
            _db.Add<TItem>(item);
        }

        public void Delete(TItem item)
        {
            _db.Remove<TItem>(item);
        }

        public void DeleteById(long id)
        {
            var deletedItem = _db.Set<TItem>().Find(id);
            _db.Remove(deletedItem);
        }

        public TItem FindById(long id)
        {
            return _db.Set<TItem>().Find(id);
        }

        public IEnumerable<TItem> GetAll()
        {
            return _db.Set<TItem>().ToList();
        }

        public void Update(TItem item)
        {
            _db.Update<TItem>(item);
        }
    }
}

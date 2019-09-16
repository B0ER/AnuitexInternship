using Store.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.DataAccess.Entities;
using Store.DataAccess.Entities.Interfaces;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TItem> where TItem : IBaseEntity
    {
        Task<IEnumerable<TItem>> GetAllAsync();
        Task<TItem> FindByIdAsync(long id);
        Task AddAsync(TItem item);
        Task DeleteAsync(TItem item);
        Task DeleteByIdAsync(long id);
        Task UpdateAsync(TItem item);
    }
}

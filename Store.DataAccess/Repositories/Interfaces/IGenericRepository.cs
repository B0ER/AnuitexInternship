using Store.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TItem> where TItem : class
    {
        Task<IEnumerable<TItem>> GetAllAsync(); //todo: add -async names
        Task<TItem> FindByIdAsync(long id);
        Task AddAsync(TItem item);
        Task DeleteAsync(TItem item);
        Task DeleteByIdAsync(long id);
        Task UpdateAsync(TItem item);
    }
}

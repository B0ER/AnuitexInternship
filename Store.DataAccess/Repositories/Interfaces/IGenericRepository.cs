using Store.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    internal interface IGenericRepository<TItem> where TItem : BaseEntity
    {
        IEnumerable<TItem> GetAll();
        TItem FindById(long id);
        void Add(TItem item);
        void Delete(TItem item);
        void DeleteById(long id);
        void Update(TItem item);
    }
}

using System;

namespace Store.DataAccess.Entities.Interfaces
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreationDate { get; set; }
        bool IsRemoved { get; set; }
    }
}
using System;

namespace Store.DataAccess.Entities.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}

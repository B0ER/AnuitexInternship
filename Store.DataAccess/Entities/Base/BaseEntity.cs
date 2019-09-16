using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}

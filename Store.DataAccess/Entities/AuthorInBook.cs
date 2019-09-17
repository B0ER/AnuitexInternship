using Store.DataAccess.Entities.Base;
using System;

namespace Store.DataAccess.Entities
{
    public class AuthorInBook : BaseEntity
    {
        public virtual Author Author { get; set; }
        public virtual PrintingEdition PrintingEdition { get; set; }
        public DateTime Date { get; set; }
    }
}

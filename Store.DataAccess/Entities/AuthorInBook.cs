using Store.DataAccess.Entities.Base;
using System;

namespace Store.DataAccess.Entities
{
    public class AuthorInBook : BaseEntity
    {
        public Author Author { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public DateTime Date { get; set; }
    }
}

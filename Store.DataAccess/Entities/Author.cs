
using Store.DataAccess.Entities.Base;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<AuthorInBook> AuthorsBooks { get; set; }
    }
}

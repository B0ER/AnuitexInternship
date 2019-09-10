
using Store.DataAccess.Entities.Base;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public IList<AuthorInBook> AuthorsBooks { get; set; }
    }
}

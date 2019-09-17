using Store.DataAccess.Entities.Base;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public int Currency { get; set; }
        public int Type { get; set; }

        public virtual IList<AuthorInBook> AuthorsBooks { get; set; }
    }
}

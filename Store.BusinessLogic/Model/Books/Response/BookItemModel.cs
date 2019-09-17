using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Books.Response
{
    public class BookItemModel : BaseResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<DataAccess.Entities.Author> Authors { get; set; }
    }
}
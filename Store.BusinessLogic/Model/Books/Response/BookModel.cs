using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Books.Response
{
    public class BookModel : BaseResponse
    {
        public IEnumerable<BookItemModel> Items { get; set; }
    }
}
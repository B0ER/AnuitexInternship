using System.Collections;
using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Book.Response
{
    public class BookModel : BaseResponse
    {
        public IEnumerable<BookItemModel> Books { get; set; }
    }
}
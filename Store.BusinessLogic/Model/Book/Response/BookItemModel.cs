using System.Collections;
using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Model.Book.Response
{
    public class BookItemModel : BaseResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
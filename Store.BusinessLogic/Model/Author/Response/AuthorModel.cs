using System.Collections;
using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Author.Response
{
    public class AuthorModel : BaseResponse
    {
        public IEnumerable<AuthorItemModel> Authors { get; set; }
    }
}
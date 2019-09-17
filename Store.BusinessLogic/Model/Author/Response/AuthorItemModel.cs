using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Author.Response
{
    public class AuthorItemModel : BaseResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
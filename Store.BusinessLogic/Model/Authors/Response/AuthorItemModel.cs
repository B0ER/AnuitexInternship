using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Authors.Response
{
    public class AuthorItemModel : BaseResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
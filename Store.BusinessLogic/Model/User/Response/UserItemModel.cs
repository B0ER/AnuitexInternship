using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.User.Response
{
    public class UserItemModel : BaseResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
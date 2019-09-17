using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Users.Response
{
    public class UserMeModel : BaseResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
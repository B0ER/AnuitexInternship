using Store.BussinesLogic.Model.Base;

namespace Store.BussinesLogic.Model.User.Response
{
    public class UserMeModel : BaseResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}

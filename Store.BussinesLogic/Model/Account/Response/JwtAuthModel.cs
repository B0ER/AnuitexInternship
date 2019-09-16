using Store.BussinesLogic.Model.Base;

namespace Store.BussinesLogic.Model.Account.Response
{
    public class JwtAuthModel : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

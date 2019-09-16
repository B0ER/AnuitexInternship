using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Account.Response
{
    public class JwtAuthModel : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
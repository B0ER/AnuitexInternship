using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Accounts.Response
{
    public class JwtAuthModel : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
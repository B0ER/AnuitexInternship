using System.Collections;
using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Accounts.Response
{
    public class JwtAuthModel : BaseResponse
    {
        public IEnumerable<string> Roles { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
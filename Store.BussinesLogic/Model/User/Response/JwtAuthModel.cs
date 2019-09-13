using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BussinesLogic.Model.User
{
    public class JwtAuthModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

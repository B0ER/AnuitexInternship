using Store.BussinesLogic.Model.Base;
using System.Collections.Generic;

namespace Store.BussinesLogic.Model.User.Response
{
    public class UserModel : BaseResponse
    {
        public IEnumerable<UserItemModel> Users { get; set; }
    }
}


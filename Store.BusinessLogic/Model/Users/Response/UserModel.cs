using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.Users.Response
{
    public class UserModel : BaseResponse
    {
        public IEnumerable<UserItemModel> Users { get; set; }
    }
}
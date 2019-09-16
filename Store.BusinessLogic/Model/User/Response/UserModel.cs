using System.Collections.Generic;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Model.User.Response
{
    public class UserModel : BaseResponse
    {
        public IEnumerable<UserItemModel> Users { get; set; }
    }
}
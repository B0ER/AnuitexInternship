using Store.DataAccess.Entities.Base;
using System.Collections.Generic;

namespace Store.BussinesLogic.Model.Base
{
    public class BaseListResponse<TItems>
    {
        public string Message { get; set; }
        public IEnumerable<TItems> Items { get; set; }
    }
}

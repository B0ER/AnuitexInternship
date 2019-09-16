using System.Collections.Generic;

namespace Store.BussinesLogic.Model.Base
{
    public class BaseResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}

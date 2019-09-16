using System.Collections.Generic;

namespace Store.BusinessLogic.Model.Base
{
    public class BaseResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
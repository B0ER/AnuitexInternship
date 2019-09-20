using System.Collections.Generic;

namespace Store.BusinessLogic.Model.Base
{
    public class BaseResponse
    {
        public IList<string> Errors { get; set; }

        public BaseResponse()
        {
            Errors = new List<string>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BussinesLogic.Model.Base
{
    public sealed class BaseItemResponse<TItem>
    {
        public string Message { get; set; }

        public TItem Item { get; set; }

        public static BaseItemResponse<TElement> CreateResponse<TElement>(TElement element)
        {
            return new BaseItemResponse<TElement> { Item = element };
        }
    }
}

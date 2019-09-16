using System;
using Store.BusinessLogic.Model.Base;

namespace Store.BusinessLogic.Exceptions.Base
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }

        public BaseResponse ResponseModel { get; set; }
    }
}
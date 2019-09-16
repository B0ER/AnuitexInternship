using Store.BussinesLogic.Model.Base;
using System;

namespace Store.BussinesLogic.Exceptions.Base
{
    public class BaseException : Exception
    {
        public BaseResponse ResponseModel { get; set; }

        public BaseException(string message) : base(message)
        {

        }
    }
}

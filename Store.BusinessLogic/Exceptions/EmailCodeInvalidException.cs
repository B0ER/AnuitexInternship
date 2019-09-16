using Store.BusinessLogic.Exceptions.Base;

namespace Store.BusinessLogic.Exceptions
{
    public class EmailCodeInvalidException : BaseException
    {
        public EmailCodeInvalidException() : base("Code is incorrect")
        {
        }
    }
}
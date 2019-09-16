using Store.BussinesLogic.Exceptions.Base;

namespace Store.BussinesLogic.Exceptions
{
    public class EmailCodeInvalidException : BaseException
    {
        public EmailCodeInvalidException() : base("Code is incorrect")
        {

        }
    }
}

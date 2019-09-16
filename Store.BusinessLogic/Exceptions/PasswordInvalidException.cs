using Store.BusinessLogic.Exceptions.Base;

namespace Store.BusinessLogic.Exceptions
{
    public class PasswordInvalidException : BaseException
    {
        public PasswordInvalidException() : base("Password is incorrect")
        {
        }
    }
}
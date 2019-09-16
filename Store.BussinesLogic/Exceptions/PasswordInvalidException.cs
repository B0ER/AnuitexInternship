using Store.BussinesLogic.Exceptions.Base;

namespace Store.BussinesLogic.Exceptions
{
    public class PasswordInvalidException : BaseException
    {
        public PasswordInvalidException() : base("Password is incorrect")
        {

        }
    }
}

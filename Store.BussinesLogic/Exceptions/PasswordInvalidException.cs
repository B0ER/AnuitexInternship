using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BussinesLogic.Exceptions
{
    public class PasswordInvalidException : Exception
    {
        public PasswordInvalidException() : base("Password is incorrect")
        {

        }
    }
}

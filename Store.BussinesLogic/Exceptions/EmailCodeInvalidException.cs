using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BussinesLogic.Exceptions
{
    public class EmailCodeInvalidException : Exception
    {
        public EmailCodeInvalidException() : base("Code is incorrect")
        {

        }
    }
}

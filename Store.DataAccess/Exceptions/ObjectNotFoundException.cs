using System;

namespace Store.DataAccess.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base("Item not found")
        {
            
        }
    }
}
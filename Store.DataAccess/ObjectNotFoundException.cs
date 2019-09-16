using System;

namespace Store.DataAccess
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base("Item not found")
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Entities
{
    public class AuthorInBook
    {
        public Author Author { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Store.DataAccess.Entities;
using Store.DataAccess.Entities.Enums;

namespace Store.BusinessLogic.Model.Books.Request
{
    public class BookUpdateRequest
    {
        [Required]
        public long BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Currency { get; set; }
        public int? Type { get; set; }

        public void ChangePrintingEdition(PrintingEdition updatePrintingEdition)
        {
            if (BookId != updatePrintingEdition.Id)
            {
                throw new InvalidOperationException("Id is not equals"); 
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                updatePrintingEdition.Name = Name;
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                updatePrintingEdition.Description = Description;
            }

            if (Price != null && Price != 0)
            {
                updatePrintingEdition.Price = Price.Value;
            }

            if (Currency != null && Enum.IsDefined(typeof(Enums.Currency), Currency))
            {
                updatePrintingEdition.Currency = Currency.Value;
            }

            if (Type != null && Enum.IsDefined(typeof(Enums.BookType), Type))
            {
                updatePrintingEdition.Type = Type.Value;
            }
        }
    }
}
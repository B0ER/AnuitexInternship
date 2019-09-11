using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Author> Authors { get; }
        IGenericRepository<AuthorInBook> AutorInBooks { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<PrintingEdition> PrintingsEditions { get; }
    }
}

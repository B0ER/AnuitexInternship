using Microsoft.Extensions.DependencyInjection;
using Store.DataAccess.Repositories;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.DependencyInjection
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthorInBookRepository, AuthorInBookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

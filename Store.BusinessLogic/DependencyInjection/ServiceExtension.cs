using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Interfaces;

namespace Store.BusinessLogic.DependencyInjection
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}

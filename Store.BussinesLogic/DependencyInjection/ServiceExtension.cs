using Microsoft.Extensions.DependencyInjection;
using Store.BussinesLogic.Services;
using Store.BussinesLogic.Services.AccountService;
using Store.BussinesLogic.Services.Interfaces;

namespace Store.BussinesLogic.DependencyInjection
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}

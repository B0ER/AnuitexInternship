using Microsoft.Extensions.DependencyInjection;
using Store.BussinesLogic.Helpers;

namespace Store.BussinesLogic.DependencyInjection
{
    public static class HelpersExtension
    {
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<JwtManager>();
        }
    }
}

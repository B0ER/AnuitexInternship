using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Helpers;

namespace Store.BusinessLogic.DependencyInjection
{
    public static class HelpersExtension
    {
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<JwtManager>();
        }
    }
}

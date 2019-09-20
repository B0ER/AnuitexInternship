using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.DependencyInjection;
using Store.BusinessLogic.Model.Options;
using Store.DataAccess.DependencyInjection;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.Presentation.Middlewares;
using System.IO;

namespace Store.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;
        private const string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            //configure jwt setting
            services.Configure<JwtAuthOptions>(_configuration.GetSection("JwtAuthOptions"));
            var serviceProvider = services.BuildServiceProvider();
            var jwtAuthConfig = serviceProvider.GetRequiredService<IOptions<JwtAuthOptions>>().Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = jwtAuthConfig.GetTokenValidationParameters();
                });


            var logProvider = new ApplicationLoggerProvider(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
            services.AddLogging(factory => factory.AddProvider(logProvider));

            services.AddApplicationDatabase(_configuration);

            services.Configure<EmailOptions>(_configuration.GetSection("SmtpConfiguration"));
            services.AddEmailSender();

            services.AddRepository();
            services.AddHelpers();
            services.AddServices();

            services.AddCors(options =>
            {
                options.AddPolicy(_myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<Role> roleManager, UserManager<ApplicationUser> userManager)
        {
            BaseSeedData.InitIfNotExist(roleManager, userManager).Wait();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMiddleware<LoggingMiddleware>();
            app.UseAuthentication();

            app.UseCors(_myAllowSpecificOrigins);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

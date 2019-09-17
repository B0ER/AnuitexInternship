﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Helpers;

namespace Store.BusinessLogic.DependencyInjection
{
    public static class EmailSenderExtension
    {
        public static void AddEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}

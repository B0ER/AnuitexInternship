﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Store.BussinesLogic.DependencyInjection
{
    public static class EmailSenderExtension
    {
        public static void AddEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}

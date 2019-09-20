using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Store.BusinessLogic.Exceptions;

namespace Store.Presentation.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("LoggingMiddleWare");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                _logger.LogDebug($"[{DateTime.UtcNow}]: {context.Request.Path} - {context.Response.StatusCode}");
            }
            catch (PasswordInvalidException passwordEx)
            {
                //context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(passwordEx.ResponseModel));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

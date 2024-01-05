using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Middleware
{
    // Middleware defined using IMiddleware. You have to register the middleware as Transient dependency in startup.
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            _logger.LogInformation("Request received: {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);
            await next(httpContext);
            _logger.LogInformation("Response sent: {StatusCode}", httpContext.Response.StatusCode);
        }
    }
}

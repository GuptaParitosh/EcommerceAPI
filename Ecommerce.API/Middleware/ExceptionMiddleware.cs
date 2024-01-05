using Ecommerce.Domain.CustomException;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Middleware
{
    // Middleware defined with the conventional Approach. You need not have to register the middleware as Transient dependency when going with conventional approach
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware>
             logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await this._next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await this.HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            ErrorResponse response = new ErrorResponse();

            if (exception is ProductNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = exception.Message;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Failed to Process";
            }
            return context.Response.WriteAsync(response.ToString());
        }
    }
}


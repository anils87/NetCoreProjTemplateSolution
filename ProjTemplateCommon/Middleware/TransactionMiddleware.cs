using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("TransactionId"))
               httpContext.Request.Headers.Add("TransactionId", DateTime.Now.Ticks.ToString());            
            
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TransactionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCommonAppendTransactionId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransactionMiddleware>();
        }
    }
}

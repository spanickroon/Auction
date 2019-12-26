using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == 403 || context.Response.StatusCode == 500)
            {
                await context.Response.WriteAsync($"Access Denied error {context.Response.StatusCode}");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync($"Not Found error {context.Response.StatusCode}");
            }
        }
    }
}

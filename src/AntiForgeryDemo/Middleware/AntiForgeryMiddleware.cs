using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiForgeryDemo.Middleware
{
    public class AntiForgeryMiddleware
    {
        private readonly RequestDelegate next;

        public AntiForgeryMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //public async Task Invoke(HttpContext context, IAntiforgery antiforgery)
        public async Task Invoke(HttpContext context)
        {
            //if (string.Equals("GET", context.Request.Method, StringComparison.OrdinalIgnoreCase))
            //{
            //    var tokens = antiforgery.GetAndStoreTokens(context);
            //    antiforgery.GetAndStoreTokens(context);

            //    context.Response.Cookies.Append(tokens.CookieToken, tokens.RequestToken);
            //}

            context.Response.Cookies.Append("Hello", "World");

            context.Response.Headers.Add("X-BRYAN", "Hello World");

            await next.Invoke(context);
        }
    }
}

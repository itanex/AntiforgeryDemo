using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AntiForgeryDemo.Middleware
{
    public class AntiForgeryMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string[] httpVerbs = new string[] { "GET", "HEAD", "OPTIONS", "TRACE" };

        public AntiForgeryMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IAntiforgery antiforgery)
        {
            if (httpVerbs.Contains(context.Request.Method, StringComparer.OrdinalIgnoreCase))
            {
                antiforgery.GetAndStoreTokens(context);
            }

            await next.Invoke(context);
        }
    }
}

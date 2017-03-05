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
        private readonly string requestTokenCookieName;
        private readonly string[] httpVerbs = new string[] { "GET", "HEAD", "OPTIONS", "TRACE" };

        public AntiForgeryMiddleware(RequestDelegate next, string requestTokenCookieName)
        {
            this.next = next;
            this.requestTokenCookieName = requestTokenCookieName;
        }

        public async Task Invoke(HttpContext context, IAntiforgery antiforgery)
        {
            if (httpVerbs.Contains(context.Request.Method, StringComparer.OrdinalIgnoreCase))
            {
                var tokens = antiforgery.GetAndStoreTokens(context);
                
                context.Response.Cookies.Append(requestTokenCookieName, tokens.RequestToken, new CookieOptions()
                {
                    HttpOnly = false
                });
            }

            await next.Invoke(context);
        }
    }
}

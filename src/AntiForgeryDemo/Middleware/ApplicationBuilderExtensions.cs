using Microsoft.AspNetCore.Builder;

namespace AntiForgeryDemo.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAntiforgeryTokenMiddleware(this IApplicationBuilder builder, string requestTokenCookieName)
        {
            return builder.UseMiddleware<AntiForgeryMiddleware>(requestTokenCookieName);
        }
    }
}

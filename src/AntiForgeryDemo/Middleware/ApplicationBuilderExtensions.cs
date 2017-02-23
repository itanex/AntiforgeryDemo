using Microsoft.AspNetCore.Builder;

namespace AntiForgeryDemo.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAntiforgeryTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AntiForgeryMiddleware>();
        }
    }
}

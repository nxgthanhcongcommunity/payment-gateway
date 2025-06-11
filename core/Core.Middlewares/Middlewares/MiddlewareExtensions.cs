using Microsoft.AspNetCore.Builder;

namespace Core.Middlewares.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestContext(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestContextDataMiddleware>();
        }
    }
}

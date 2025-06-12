using Core.Models.GlobalModels;
using Microsoft.AspNetCore.Http;

namespace Core.Middlewares
{
    public class RequestContextDataMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestContextDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, RequestContextData requestContext)
        {
            requestContext.CurrentUTCDateTime = DateTime.UtcNow; // hoặc theo logic riêng
            await _next(context);
        }
    }
}

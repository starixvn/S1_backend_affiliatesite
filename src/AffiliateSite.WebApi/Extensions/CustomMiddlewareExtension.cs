using AffiliateSite.Extensions.Middlewares;

namespace AffiliateSite.Extensions
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<RequestLogMiddleware>();

        public static IApplicationBuilder UseResponseLogMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<ResponseLogMiddleware>();
    }
}

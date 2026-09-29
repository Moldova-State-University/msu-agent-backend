using MSUAgent.MobileBff.Middlewares;

namespace MSUAgent.MobileBff.Extensions;
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
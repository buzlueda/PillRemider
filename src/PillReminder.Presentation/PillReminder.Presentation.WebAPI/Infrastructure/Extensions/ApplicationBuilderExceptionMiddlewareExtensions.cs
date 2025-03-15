using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Middleware;

namespace PillReminder.Presentation.WebAPI.Infrastructure.Extensions;

public static class ApplicationBuilderExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
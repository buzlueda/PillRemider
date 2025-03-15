using CorePackages.Infrastructure.Security.DependencyInjections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PillReminder.Core.Application.Interfaces.Helpers;
using PillReminder.Infrastructure.Security.JWT;

namespace PillReminder.Infrastructure.Security;

public static class SecurityServiceRegistrations
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();

        JWTAuthenticationScheme.AddJWTBearerAuthentication(services, signalRHubEndpoint: "/", configuration);

        return services;
    }
}
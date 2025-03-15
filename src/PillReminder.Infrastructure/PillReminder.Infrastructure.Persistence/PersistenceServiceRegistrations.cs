using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PillReminder.Core.Application.Interfaces.Repositories.Common;
using PillReminder.Infrastructure.Persistence.Contexts;
using PillReminder.Infrastructure.Persistence.Repositories.Common;



namespace PillReminder.Infrastructure.Persistence;

public static class PersistenceServiceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PillReminderDbContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("PillReminderDbConnection")
                                            ?? configuration.GetConnectionString("PillReminderDbConnection");

            options.UseSqlServer(connectionString)
;
            options.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            options.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.CommandExecuting));
            options.LogTo(Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging(false)
                .EnableDetailedErrors(false);
        });



        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
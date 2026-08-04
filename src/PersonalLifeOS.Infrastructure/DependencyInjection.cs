using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalLifeOS.Infrastructure.Identity;
using PersonalLifeOS.Infrastructure.Persistence;

namespace PersonalLifeOS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PersonalLifeOS")
            ?? throw new InvalidOperationException(
                "Connection string 'PersonalLifeOS' is not configured. " +
                "Use .NET User Secrets for local development.");

        services.AddDbContext<FinanceDbContext>(options =>
            options.UseSqlServer(
                connectionString,
                sqlOptions => sqlOptions.MigrationsAssembly(typeof(FinanceDbContext).Assembly.FullName)));

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<FinanceDbContext>();

        return services;
    }
}

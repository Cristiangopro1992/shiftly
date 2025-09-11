using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shiftly.Infrastructure.Persistence;

namespace Shiftly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("Default")
                 ?? throw new InvalidOperationException("Missing ConnectionStrings:Default");

        services.AddDbContext<ShiftlyDbContext>(opt =>
        {
            opt.UseSqlServer(cs, sql =>
            {
                sql.MigrationsAssembly(typeof(ShiftlyDbContext).Assembly.FullName);
                sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            });
        });

        return services;
    }
}

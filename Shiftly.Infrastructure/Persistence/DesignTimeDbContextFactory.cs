using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shiftly.Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShiftlyDbContext>
{
    public ShiftlyDbContext CreateDbContext(string[] args)
    {
        var cs = Environment.GetEnvironmentVariable("SHIFTLY_CS")
                 ?? "Server=localhost,1433;Database=ShiftlyDb;User Id=sa;Password=Shiftly_Local_123!;TrustServerCertificate=True;Encrypt=False";

        var options = new DbContextOptionsBuilder<ShiftlyDbContext>()
            .UseSqlServer(cs, sql =>
            {
                sql.MigrationsAssembly(typeof(ShiftlyDbContext).Assembly.FullName);
                sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            })
            .Options;

        return new ShiftlyDbContext(options);
    }
}

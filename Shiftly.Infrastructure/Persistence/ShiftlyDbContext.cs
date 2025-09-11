using Microsoft.EntityFrameworkCore;
using Shiftly.Domain.Entities;

namespace Shiftly.Infrastructure.Persistence;

public class ShiftlyDbContext : DbContext
{
    public ShiftlyDbContext(DbContextOptions<ShiftlyDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShiftlyDbContext).Assembly);
    }
}

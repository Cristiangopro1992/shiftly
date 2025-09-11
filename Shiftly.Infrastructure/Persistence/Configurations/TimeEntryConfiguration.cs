using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiftly.Domain.Entities;

namespace Shiftly.Infrastructure.Persistence.Configurations;

public class TimeEntryConfiguration : IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.Type).HasMaxLength(20).IsRequired();
        b.Property(x => x.StartUtc).IsRequired();

        b.HasOne(x => x.Employee)
         .WithMany(e => e.TimeEntries)
         .HasForeignKey(x => x.EmployeeId)
         .OnDelete(DeleteBehavior.Cascade);

        // Índices útiles
        b.HasIndex(x => new { x.EmployeeId, x.StartUtc });
    }
}

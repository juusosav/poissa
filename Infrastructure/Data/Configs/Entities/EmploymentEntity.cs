using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Configs.Entities
{
    public static class EmploymentEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employment>()
                .HasMany(e => e.Absences)
                .WithOne(a => a.Employment)
                .HasForeignKey(a => a.EmploymentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

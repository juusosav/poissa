using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Configs.Enums
{
    public static class EmploymentEnum
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employment>()
                .Property(e => e.Type)
                .HasConversion<string>();
            modelBuilder.Entity<Employment>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}

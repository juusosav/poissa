using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Configs.Enums
{
    public static class AbsenceEnum
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>()
                .Property(a => a.Type)
                .HasConversion<string>();
            modelBuilder.Entity<Absence>()
                .Property(a => a.Status)
                .HasConversion<string>();
        }
    }
}

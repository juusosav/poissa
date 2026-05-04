using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;
using PoissaHR.Domain.Enums;

namespace PoissaHR.Infrastructure.Data.Configs.Entities
{
    public static class AbsenceEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>()
                .HasOne(a => a.ApprovedBy)
                .WithMany(e => e.ApprovedAbsences)
                .HasForeignKey(a => a.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

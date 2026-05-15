using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Configs.Entities
{
    public static class DepartmentEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employments)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

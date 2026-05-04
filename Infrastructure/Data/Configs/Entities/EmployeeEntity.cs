using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Configs.Entities
{
    public static class EmployeeEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employments)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
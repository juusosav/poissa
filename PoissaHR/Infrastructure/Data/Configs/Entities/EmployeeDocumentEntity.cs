using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Configs.Entities
{
    public static class EmployeeDocumentEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDocument>()
                .HasOne(d => d.Employee)
                .WithMany(e => e.Documents)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

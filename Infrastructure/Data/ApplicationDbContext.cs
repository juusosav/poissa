using Microsoft.EntityFrameworkCore;
using PoissaHR.Domain.Entities;
using PoissaHR.Infrastructure.Data.Configs.Enums;

namespace PoissaHR.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AbsenceEnum.Configure(modelBuilder);
            EmploymentEnum.Configure(modelBuilder);
        }
    }
}

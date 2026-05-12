using PoissaHR.Domain.Entities;

namespace PoissaHR.Infrastructure.Data.Seeds
{
    public class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Companies.Any())
            {
                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "Testi Yritys 1"
                };
                var department = new Department
                {
                    Id = Guid.NewGuid(),
                    Name = "Asiakaspalvelu",
                    CompanyId = company.Id
                };
                var employee = new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Matti",
                    LastName = "Meikäläinen",
                    Portrait = "/images/placeholder_portrait.jpg",
                    CompanyId = company.Id,
                    DepartmentId = department.Id
                };
                var employment = new Employment
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employee.Id,
                    DepartmentId = department.Id,
                    JobTitle = "Asiakaspalvelija",
                    StartDate = DateTime.UtcNow.AddYears(-1),
                    EndDate = null
                };
                var absence = new Absence
                {
                    Id = Guid.NewGuid(),
                    EmploymentId = employment.Id,
                    CompanyId = company.Id,
                    StartDate = new DateTime(2026, 4, 5),
                    EndDate = new DateTime(2026, 4, 10),
                    Type = Domain.Enums.AbsenceType.Sairausloma,
                    Status = Domain.Enums.AbsenceStatus.Hyväksytty,
                    Notes = "Sairastui flunssaan"
                };



                context.Companies.Add(company);
                context.Departments.Add(department);
                context.Employees.Add(employee);
                context.Employments.Add(employment);
                context.Absences.Add(absence);

                await context.SaveChangesAsync();
            }
        }
    }
}

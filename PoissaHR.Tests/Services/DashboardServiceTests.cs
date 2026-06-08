using PoissaHR.Application.Services.DepartmentService;
using PoissaHR.Shared.Dto;
using PoissaHR.Tests.Data;
using PoissaHR.Domain.Entities;
using PoissaHR.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoissaHR.Application.Services.DashboardService;

namespace PoissaHR.Tests.Services
{
    public class DashboardServiceTests
    {
        private readonly DashboardService _sut;
        private readonly ApplicationDbContext _context;

        public DashboardServiceTests()
        {
            _context = ApplicationDbContextFactory.Create();
            _sut = new DashboardService(_context);
        }

        [Fact]
        public async Task GetDashboardAsync_ReturnsCorrectCounts()
        {
            // Arrange
            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "Test Company"
            };
            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = "IT",
                CompanyId = company.Id
            };
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "test@email.com",
                Phone = "1234567890"
            };
            var employment = new Employment
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = department.Id,
                StartDate = DateTime.UtcNow.AddMonths(-1)
            };

            _context.Companies.Add(company);
            _context.Departments.Add(department);
            _context.Employees.Add(employee);
            _context.Employments.Add(employment);

            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await _sut.GetDashboardAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_context.Departments.Count(), result.DepartmentCount);
            Assert.Equal(_context.Employees.Count(), result.EmployeeCount);
            Assert.Equal(_context.Absences.Count(), result.AbsenceCount);
        }
    }
}

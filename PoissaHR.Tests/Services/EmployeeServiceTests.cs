using PoissaHR.Application.Services.EmployeeService;
using PoissaHR.Domain.Entities;
using PoissaHR.Infrastructure.Data;
using PoissaHR.Shared.Dto;
using PoissaHR.Tests.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PoissaHR.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService _sut;
        private readonly ApplicationDbContext _context;

        public EmployeeServiceTests()
        {
            _context = ApplicationDbContextFactory.Create();
            _sut = new EmployeeService(_context);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ReturnsEmployee_WhenEmployeeExists()
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
                CompanyId = company.Id,
                DepartmentId = department.Id
            };
            var employment = new Employment
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = department.Id,
                CompanyId = company.Id,
                JobTitle = "Developer",
                StartDate = DateTime.UtcNow
            };

            _context.Companies.Add(company);
            _context.Departments.Add(department);
            _context.Employees.Add(employee);
            _context.Employments.Add(employment);

            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await _sut.GetEmployeeByIdAsync(employee.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employee.Id, result.Id);
            Assert.Equal(employee.FirstName, result.FirstName);
            Assert.Equal(employee.LastName, result.LastName);
        }
    }
}

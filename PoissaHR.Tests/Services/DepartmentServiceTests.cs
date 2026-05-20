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

namespace PoissaHR.Tests.Services
{
    public class DepartmentServiceTests
    {
        private readonly DepartmentService _sut;
        private readonly ApplicationDbContext _context;

        public DepartmentServiceTests()
        {
            _context = ApplicationDbContextFactory.Create();
            _sut = new DepartmentService(_context);
        }

        [Fact]
        public async Task GetDepartmentByIdAsync_ReturnsDepartment_WhenDepartmentExists()
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
                Phone = "1234567890",
            };
            var employment = new Employment
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = department.Id,
                StartDate = DateTime.UtcNow.AddMonths(-1),
                
            };

            _context.Companies.Add(company);
            _context.Departments.Add(department);
            _context.Employees.Add(employee);
            _context.Employments.Add(employment);

            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await _sut.GetDepartmentByIdAsync(department.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(department.Id, result!.Id);
            Assert.Equal(department.Name, result.Name);
            Assert.Equal(company.Name, result.CompanyName);
            Assert.Equal(employee.FirstName + " " + employee.LastName, result.CurrentEmployees.First().EmployeeName);
        }
    }
}

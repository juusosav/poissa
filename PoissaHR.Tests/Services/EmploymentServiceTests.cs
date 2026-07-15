using PoissaHR.Application.Services.EmploymentService;
using PoissaHR.Shared.Dto;
using PoissaHR.Tests.Data;
using PoissaHR.Domain.Entities;
using PoissaHR.Domain.Enums;
using PoissaHR.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Frameworks;

namespace PoissaHR.Tests.Services
{
    public class EmploymentServiceTests
    {
        private readonly EmploymentService _sut;
        private readonly ApplicationDbContext _context;

        public EmploymentServiceTests()
        {
            _context = ApplicationDbContextFactory.Create();
            _sut = new EmploymentService(_context);
        }

        [Fact]
        public async Task GetEmploymentsByEmployeeIdAsync_ReturnsEmployments_WhenEmploymentsExist()
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
                Email = "john.doe@example.com",
                Phone = "1234567890"
            };

            var employment = new Employment
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = department.Id,
                Status = EmploymentStatus.Aktiivinen,
                Type = EmploymentType.OsaAikainen,
                CompanyId = company.Id,
                StartDate = DateTime.UtcNow.AddMonths(-6),
                EndDate = null
            };

            _context.Companies.Add(company);
            _context.Departments.Add(department);
            _context.Employees.Add(employee);
            _context.Employments.Add(employment);

            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await _sut.GetEmploymentsByEmployeeIdAsync(employee.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employment.EmployeeId, employee.Id);
        }

        [Fact]
        public async Task GetEmploymentForEditAsync_ReturnsEmployment_WhenEmploymentExists()
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
                Email = "john.doe@email.fi",
                Phone = "1234567890"
            };
            var employment = new Employment
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = department.Id,
                CompanyId = company.Id,
                Status = EmploymentStatus.Aktiivinen,
                Type = EmploymentType.OsaAikainen,
                StartDate = DateTime.UtcNow.AddMonths(-6),
                EndDate = null
            };

            _context.Companies.Add(company);
            _context.Departments.Add(department);
            _context.Employees.Add(employee);
            _context.Employments.Add(employment);

            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await _sut.GetEmploymentForEditAsync(employment.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employee.Id, employment.EmployeeId);
            Assert.Equal(department.Id, employment.DepartmentId);
        }

        [Fact]
        public async Task CreateEmploymentAsync_ReturnsCreatedEmployment_WhenDtoIsValid()
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
                Email = "john.doe@email.fi",
                Phone = "1234567890"
            };

            var dto = new EmploymentCreateDto
            {
                Id = Guid.NewGuid(),
                EmployeeId = employee.Id,
                DepartmentId = department.Id,
                CompanyId = company.Id,
                JobTitle = "Software Engineer",
                Status = EmploymentStatus.Aktiivinen,
                Type = EmploymentType.OsaAikainen,
                StartDate = DateTime.UtcNow.AddMonths(-6),
                EndDate = null
            };

            _context.Companies.Add(company);
            _context.Departments.Add(department);
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

            // Act
            var result = await _sut.CreateEmploymentAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dto.EmployeeId, result.EmployeeId);
            Assert.Equal(dto.DepartmentId, result.DepartmentId);
            Assert.Equal(dto.CompanyId, result.CompanyId);
        }
    }
}

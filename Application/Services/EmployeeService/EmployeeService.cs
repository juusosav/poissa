using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Where(e => !e.IsDeleted)
                .Include(e => e.Department)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Phone = e.Phone,
                    DepartmentName = e.Department != null
                        ? e.Department.Name
                        : null
                })
                .AsNoTracking()
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == id && !e.IsDeleted)
                .Include(e => e.Department)
                .Include(e => e.Employments)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Portrait = e.Portrait,
                    Email = e.Email,
                    Phone = e.Phone,
                    DepartmentName = e.Department != null
                        ? e.Department.Name
                        : null,
                    CurrentJobTitle = e.Employments
                        .OrderByDescending(e => e.StartDate)
                        .Select(e => e.JobTitle)
                        .FirstOrDefault()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<bool> EditEmployee(Guid id, EmployeeDto dto)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == id && !e.IsDeleted)
                .FirstOrDefaultAsync();

            if (employee == null)
                return false;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email ?? employee.Email;
            employee.Phone = dto.Phone ?? employee.Phone;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

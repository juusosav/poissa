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
                    CompanyId = e.CompanyId,
                    DepartmentId = e.DepartmentId,
                    BirthDate = e.BirthDate,
                    CreatedAt = e.CreatedAt,
                    IsDeleted = e.IsDeleted,
                    DeletedAt = e.DeletedAt,
                    Department = e.Department
                })
                .AsNoTracking()
                .ToListAsync();

            return employees;
        }
    }
}

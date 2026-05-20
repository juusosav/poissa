using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments
                .Where(d => !d.IsDeleted)
                .Include(d => d.Company)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    CompanyName = d.Company != null
                        ? d.Company.Name
                        : null
                })
                .AsNoTracking()
                .ToListAsync();

            return departments;
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _context.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .Include(d => d.Company)
                .Include(d => d.Employments)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    CompanyName = d.Company != null
                        ? d.Company.Name
                        : null,
                    CurrentEmployees = d.Employments.Select(e => new EmploymentDto
                    {
                        Id = e.Id,
                        EmployeeName = e.Employee != null
                            ? $"{e.Employee.FirstName} {e.Employee.LastName}"
                            : null,
                        JobTitle = e.JobTitle,
                        Type = e.Type.ToString(),
                        Status = e.Status.ToString()
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return department;
        }
    }
}

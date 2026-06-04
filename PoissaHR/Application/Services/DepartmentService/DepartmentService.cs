using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.DepartmentService
{
    public class DepartmentService(ApplicationDbContext context) : IDepartmentService
    {
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await context.Departments
                .Where(d => !d.IsDeleted)
                .Include(d => d.Company)
                .Include(d => d.Employments)
                    .ThenInclude(d => d.Employee)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    CompanyName = d.Company != null
                        ? d.Company.Name
                        : null,
                    CurrentEmployees = d.Employments.Select(e => new EmploymentDto
                    {
                        Id = e.Id
                    }).ToList()
                })
                .AsNoTracking()
                .ToListAsync();

            return departments;
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(Guid id)
        {
            var department = await context.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .Include(d => d.Company)
                .Include(d => d.Employments)
                    .ThenInclude(e => e.Employee)
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
                        EmployeeId = e.EmployeeId,
                        EmployeeName = e.Employee != null
                            ? $"{e.Employee.FirstName} {e.Employee.LastName}"
                            : null,
                        JobTitle = e.JobTitle,
                        Type = e.Type,
                        Status = e.Status
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return department;
        }

        public async Task<DepartmentEditDto?> GetDepartmentForEditAsync(Guid id)
        {
            var department = await context.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .Select(d => new DepartmentEditDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return department;
        }

        public async Task<bool> UpdateDepartmentAsync(DepartmentEditDto dto)
        {
            var department = await context.Departments
                .Where(d => d.Id == dto.Id && !d.IsDeleted)
                .FirstOrDefaultAsync();

            if (department == null)
                return false;

            department.Name = dto.Name;

            context.Departments.Update(department);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

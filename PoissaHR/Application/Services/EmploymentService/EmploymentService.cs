using PoissaHR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;
using PoissaHR.Domain.Enums;

namespace PoissaHR.Application.Services.EmploymentService
{
    public class EmploymentService(ApplicationDbContext context) : IEmploymentService
    {
        public async Task<IEnumerable<EmploymentDto>> GetEmploymentsByEmployeeIdAsync(Guid employeeId)
        {
            var employments = await context.Employments
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new EmploymentDto
                {
                    Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    DepartmentId = e.DepartmentId,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    JobTitle = e.JobTitle,
                    Status = e.Status,
                    Type = e.Type
                })
                .AsNoTracking()
                .ToListAsync();

            return employments;
        }

        public async Task<EmploymentEditDto?> GetEmploymentForEditAsync(Guid id)
        {
            var employment = await context.Employments
                .Where(e => e.Id == id)
                .Include(e => e.Employee)
                .Select(e => new EmploymentEditDto
                {
                    Id = e.Id,
                    EmployeeName =
                        e.Employee.FirstName + " " +
                        e.Employee.LastName,
                    JobTitle = e.JobTitle,
                    Status = e.Status,
                    Type = e.Type
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return employment;
        }

        public async Task<bool> UpdateEmploymentAsync(EmploymentEditDto dto)
        {
            var employment = await context.Employments
                .Where(e => e.Id == dto.Id)
                .FirstOrDefaultAsync();

            if (employment == null)
            {
                return false;
            }

            employment.JobTitle = dto.JobTitle;
            employment.Status = dto.Status;
            employment.Type = dto.Type;

            await context.SaveChangesAsync();
            return true;
        }
    }
}

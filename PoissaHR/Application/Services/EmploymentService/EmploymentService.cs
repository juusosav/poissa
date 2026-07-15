using PoissaHR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;
using PoissaHR.Domain.Enums;
using PoissaHR.Domain.Entities;

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

        public async Task<EmploymentCreateDto?> CreateEmploymentAsync(EmploymentCreateDto dto)
        {
            var employment = new Employment
            {
                Id = Guid.NewGuid(),
                EmployeeId = dto.EmployeeId,
                DepartmentId = dto.DepartmentId,
                CompanyId = dto.CompanyId,
                JobTitle = dto.JobTitle,
                Status = dto.Status,
                Type = dto.Type,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            context.Employments.Add(employment);

            await context.SaveChangesAsync();

            return new EmploymentCreateDto
            {
                Id = employment.Id,
                EmployeeId = employment.EmployeeId,
                DepartmentId = employment.DepartmentId,
                CompanyId = employment.CompanyId,
                JobTitle = employment.JobTitle,
                Status = employment.Status,
                Type = employment.Type,
                StartDate = employment.StartDate,
                EndDate = employment.EndDate
            };
        }
    }
}

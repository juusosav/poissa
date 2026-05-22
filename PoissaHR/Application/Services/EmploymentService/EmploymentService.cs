using PoissaHR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.EmploymentService
{
    public class EmploymentService : IEmploymentService
    {
        private readonly ApplicationDbContext _context;

        public EmploymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmploymentDto>> GetEmploymentsByEmployeeIdAsync(Guid employeeId)
        {
            var employments = await _context.Employments
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new EmploymentDto
                {
                    Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    DepartmentId = e.DepartmentId,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    JobTitle = e.JobTitle,
                    Status = e.Status.ToString(),
                    Type = e.Type.ToString()
                })
                .AsNoTracking()
                .ToListAsync();

            return employments;
        }
    }
}

using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;
using PoissaHR.Domain.Enums;

namespace PoissaHR.Application.Services.DashboardService
{
    public class DashboardService(ApplicationDbContext context) : IDashboardService
    {
        public async Task<DashboardDto?> GetDashboardAsync()
        {
            var dto = await context.Departments
                .Include(e => e.Employments.Where(em => em.EndDate == null))
                    .ThenInclude(e => e.Absences.Where(a => a.StartDate >= DateTime.UtcNow.AddMonths(-1) && a.EndDate <= DateTime.UtcNow))
                .Select(d => new DashboardDto
                {
                    DepartmentCount = context.Departments.Count(),
                    EmployeeCount = context.Employments.Count(e => e.EndDate == null),
                    AbsenceCount = context.Absences.Count(a => a.StartDate >= DateTime.UtcNow),
                    UpcomingVacationsCount = context.Absences.Count(a => a.StartDate >= DateTime.UtcNow
                        && a.StartDate <= DateTime.UtcNow.AddMonths(1) && a.Type == AbsenceType.Loma)
                })
                .ToListAsync();

            return dto.FirstOrDefault();
        }
    }
}

using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.AbsenceService
{
    public class AbsenceService : IAbsenceService
    {
        private readonly ApplicationDbContext _context;
        public AbsenceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AbsenceDto>> GetAllAbsencesAsync()
        {
            var absences = await _context.Absences
                .Include(a => a.Employment)
                .Select(a => new AbsenceDto
                {
                    Id = a.Id,
                    LinkedEmploymentName = a.Employment != null ? a.Employment.JobTitle : null,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    Status = a.Status.ToString(),
                    Type = a.Type.ToString(), 
                    Notes = a.Notes
                })
                .ToListAsync();

            return absences;
        }
    }
}

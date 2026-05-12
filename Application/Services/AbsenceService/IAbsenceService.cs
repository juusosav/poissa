using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.AbsenceService
{
    public interface IAbsenceService
    {
        Task<IEnumerable<AbsenceDto>> GetAllAbsencesAsync();
    }
}

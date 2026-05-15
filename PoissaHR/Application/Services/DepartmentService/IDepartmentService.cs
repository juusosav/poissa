using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
    }
}

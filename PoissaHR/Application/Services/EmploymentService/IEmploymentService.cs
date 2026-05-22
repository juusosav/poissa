using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.EmploymentService
{
    public interface IEmploymentService
    {
        Task<IEnumerable<EmploymentDto>> GetEmploymentsByEmployeeIdAsync(Guid employeeId);
    }
}

using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.EmploymentService
{
    public interface IEmploymentService
    {
        Task<IEnumerable<EmploymentDto>> GetEmploymentsByEmployeeIdAsync(Guid employeeId);
        Task<EmploymentEditDto?> GetEmploymentForEditAsync(Guid id);
        Task<bool> UpdateEmploymentAsync(EmploymentEditDto dto);
    }
}

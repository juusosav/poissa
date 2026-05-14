using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);
        Task<bool> UpdateEmployeeAsync(EmployeeEditDto dto);

        Task<EmployeeEditDto?> GetEmployeeForEditAsync(Guid id);
    }
}

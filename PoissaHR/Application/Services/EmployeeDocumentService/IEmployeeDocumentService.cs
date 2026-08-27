using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.EmployeeDocumentService
{
    public interface IEmployeeDocumentService
    {
        Task<IEnumerable<EmployeeDocumentDto>> GetAllDocumentsByEmployeeAsync(Guid employeeId);
        Task<EmployeeDocumentDto> CreateDocumentAsync(EmployeeDocumentDto employeeDocumentDto);
    }
}

using PoissaHR.Domain.Entities;

namespace PoissaHR.Shared.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Portrait { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Phone { get; set; } = "";
        public string? DepartmentName { get; set; }
        public string? CurrentJobTitle { get; set; }
        public List<AbsenceDto>? Absences { get; set; } = [];
    }
}

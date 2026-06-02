using PoissaHR.Domain.Enums;

namespace PoissaHR.Shared.Dto
{
    public class EmploymentEditDto
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public EmploymentStatus EmploymentStatus { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EmployeeName { get; set; }

    }
}

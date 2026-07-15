using PoissaHR.Domain.Enums;

namespace PoissaHR.Shared.Dto
{
    public class EmploymentEditDto
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; } = "";
        public string Description { get; set; } = "";
        public EmploymentStatus Status { get; set; }
        public EmploymentType Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EmployeeName { get; set; }

    }
}

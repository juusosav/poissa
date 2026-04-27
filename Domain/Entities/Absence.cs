using PoissaHR.Domain.Enums;

namespace PoissaHR.Domain.Entities
{
    public class Absence
    {
        public Guid Id { get; set; }
        public Guid EmploymentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AbsenceType Type { get; set; }
        public AbsenceStatus Status { get; set; }
        public Guid? ApprovedById { get; set; }
        public Employee? ApprovedBy { get; set; }
        public string Notes { get; set; } = "";

    }
}

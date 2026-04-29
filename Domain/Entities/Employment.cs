using PoissaHR.Domain.Enums;

namespace PoissaHR.Domain.Entities
{
    public class Employment
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;
        public Guid? ManagerId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
        public string JobTitle { get; set; } = "";
        public EmploymentType Type { get; set; }
        public EmploymentStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<Absence> Absences { get; set; } = [];
    }
}

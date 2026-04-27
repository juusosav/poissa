namespace PoissaHR.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public ICollection<Employment> Employments { get; set; } = [];
        public ICollection<Absence> ApprovedAbsences { get; set; } = [];
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DeletedAt { get; set; }
    }
}

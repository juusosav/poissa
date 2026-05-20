namespace PoissaHR.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;
        public string Name { get; set; } = "";
        public ICollection<Employment> Employments { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}

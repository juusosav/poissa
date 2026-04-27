namespace PoissaHR.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = "";

    }
}

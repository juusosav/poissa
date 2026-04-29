namespace PoissaHR.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Department> Departments { get; set; } = [];
        public ICollection<Employee> Employees { get; set; } = [];
    }
}

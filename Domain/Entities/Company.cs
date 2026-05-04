namespace PoissaHR.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Department> Departments { get; set; } = [];
        public Guid DepartmentId { get; set; }
        public ICollection<Employee> Employees { get; set; } = [];
        public Guid EmployeeId { get; set; }
    }
}

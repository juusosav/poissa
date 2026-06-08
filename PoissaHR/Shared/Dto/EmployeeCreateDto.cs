namespace PoissaHR.Shared.Dto
{
    public class EmployeeCreateDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CompanyId { get; set; }
        public string? Portrait { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

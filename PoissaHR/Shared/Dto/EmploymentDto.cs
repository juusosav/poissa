namespace PoissaHR.Shared.Dto
{
    public class EmploymentDto
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";

        public string? EmployeeName { get; set; }
    }
}

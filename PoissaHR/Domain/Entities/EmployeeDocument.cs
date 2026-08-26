using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PoissaHR.Domain.Entities
{
    public class EmployeeDocument
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public string FileName { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public string ContentType { get; set; } = "";
        public string FilePath { get; set; } = "";
        public DateTime? UploadedAt { get; set; }
        public string DocumentType { get; set; } = "";


    }
}

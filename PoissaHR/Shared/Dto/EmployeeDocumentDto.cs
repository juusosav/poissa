using PoissaHR.Domain.Entities;

namespace PoissaHR.Shared.Dto
{
    public class EmployeeDocumentDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string FileName { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public string ContentType { get; set; } = "";
        public string FilePath { get; set; } = "";
        public DateTime? UploadedAt { get; set; }
        public string DocumentType { get; set; } = "";
    }
}

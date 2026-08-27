using PoissaHR.Infrastructure.Data;
using PoissaHR.Shared.Dto;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PoissaHR.Application.Services.EmployeeDocumentService
{
    public class EmployeeDocumentService(ApplicationDbContext context) : IEmployeeDocumentService
    {
        public async Task<IEnumerable<EmployeeDocumentDto>> GetAllDocumentsByEmployeeAsync(Guid employeeId)
        {
            var employeeDocuments = await context.EmployeeDocument
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new EmployeeDocumentDto
                {
                    Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    FileName = e.FileName,
                    OriginalFileName = e.OriginalFileName,
                    ContentType = e.ContentType,
                    FilePath = e.FilePath,
                    UploadedAt = e.UploadedAt,
                    DocumentType = e.DocumentType
                })
                .AsNoTracking()
                .ToListAsync();

            return employeeDocuments;
        }

        public async Task<EmployeeDocumentDto> CreateDocumentAsync(EmployeeDocumentDto employeeDocumentDto)
        {
            var document = new EmployeeDocument
            {
                Id = Guid.NewGuid(),
                EmployeeId = employeeDocumentDto.EmployeeId,
                FileName = employeeDocumentDto.FileName,
                OriginalFileName = employeeDocumentDto.OriginalFileName,
                ContentType = employeeDocumentDto.ContentType,
                FilePath = employeeDocumentDto.FilePath,
                UploadedAt = employeeDocumentDto.UploadedAt,
                DocumentType = employeeDocumentDto.DocumentType
            };

            Console.WriteLine("Dokumentti luotu.");
            context.EmployeeDocument.Add(document);

            await context.SaveChangesAsync();
            Console.WriteLine("Dokumentti lisätty tietokantaan.");

            return new EmployeeDocumentDto
            {
                Id = document.Id,
                EmployeeId = document.EmployeeId,
                FileName = document.FileName,
                OriginalFileName = document.OriginalFileName,
                ContentType = document.ContentType,
                FilePath = document.FilePath,
                UploadedAt = document.UploadedAt,
                DocumentType = document.DocumentType
            };

        }
    }
}

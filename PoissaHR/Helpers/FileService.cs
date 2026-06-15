using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace PoissaHR.Helpers
{
    public class FileService(IWebHostEnvironment environment) : IFileService
    {
        public async Task<string> SaveFileAsync(IBrowserFile file)
        {
            const long MaxFileSize = 5 * 1024 * 1024;

            var uploadsFolder = Path.Combine(
                environment.WebRootPath,
                "uploads");

            Directory.CreateDirectory(uploadsFolder);

            var fileName =
                $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";

            var filePath = Path.Combine(uploadsFolder, fileName);

            await using var stream =
                new FileStream(filePath, FileMode.Create);

            await file
                .OpenReadStream(MaxFileSize)
                .CopyToAsync(stream);

            return $"/uploads/{fileName}";
        }
    }
}

using Microsoft.AspNetCore.Components.Forms;

namespace PoissaHR.Helpers
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IBrowserFile file);
    }
}

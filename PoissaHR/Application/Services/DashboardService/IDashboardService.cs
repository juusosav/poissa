using PoissaHR.Shared.Dto;

namespace PoissaHR.Application.Services.DashboardService
{
    public interface IDashboardService
    {
        Task<DashboardDto?> GetDashboardAsync();
    }
}

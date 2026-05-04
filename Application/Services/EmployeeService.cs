using PoissaHR.Infrastructure.Data;

namespace PoissaHR.Application.Services
{
    public class EmployeeService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;


    }
}

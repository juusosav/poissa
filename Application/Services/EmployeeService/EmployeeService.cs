using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PoissaHR.Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Where(e => !e.IsDeleted)
                .Include(e => e.Department)
                .AsNoTracking()
                .ToListAsync();

            return employees;
        }
    }
}

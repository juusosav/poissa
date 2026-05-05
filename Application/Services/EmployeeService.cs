using PoissaHR.Infrastructure.Data;
using PoissaHR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PoissaHR.Application.Services
{
    public class EmployeeService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();

            return employees;
        }
    }
}

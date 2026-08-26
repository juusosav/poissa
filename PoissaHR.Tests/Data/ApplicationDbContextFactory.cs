using PoissaHR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PoissaHR.Tests.Data
{
    public class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            return context;
        }
    }
}

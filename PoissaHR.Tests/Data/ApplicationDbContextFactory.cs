using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoissaHR.Infrastructure.Data;
using PoissaHR.Infrastructure.Data.Seeds;
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
            DbSeeder.SeedAsync(context).Wait();
            return context;
        }
    }
}

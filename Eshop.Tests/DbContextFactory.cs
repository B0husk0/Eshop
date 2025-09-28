using Eshop.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Tests
{
    public static class DbContextFactory
    {
        public static AppDbContext CreateInMemory()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}

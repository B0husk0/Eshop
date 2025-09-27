using Microsoft.EntityFrameworkCore;
using Eshop.Api.Models;

namespace Eshop.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Eshop.Api.Models;

namespace Eshop.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category seeding
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "CPU", ImageUrl = "https://via.placeholder.com/150?text=CPU" },
                new Category { Id = 2, Name = "Motherboards", ImageUrl = "https://via.placeholder.com/150?text=Motherboards" },
                new Category { Id = 3, Name = "GPU", ImageUrl = "https://via.placeholder.com/150?text=GPU" },
                new Category { Id = 4, Name = "RAM", ImageUrl = "https://via.placeholder.com/150?text=RAM" },
                new Category { Id = 5, Name = "Storage", ImageUrl = "https://via.placeholder.com/150?text=Storage" },
                new Category { Id = 6, Name = "Power Supplies", ImageUrl = "https://via.placeholder.com/150?text=PSU" },
                new Category { Id = 7, Name = "Cases", ImageUrl = "https://via.placeholder.com/150?text=Cases" },
                new Category { Id = 8, Name = "Cooling", ImageUrl = "https://via.placeholder.com/150?text=Cooling" },
                new Category { Id = 9, Name = "Monitors", ImageUrl = "https://via.placeholder.com/150?text=Monitors" },
                new Category { Id = 10, Name = "Peripherals", ImageUrl = "https://via.placeholder.com/150?text=Peripherals" }
            );

            // Product seeding
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "AMD Ryzen 7 7800X3D", ImageUrl = "https://picsum.photos/seed/cpu/600/400", Price = 399.99m, Description = "High-performance gaming CPU", Quantity = 10, CategoryId = 1 },
                new Product { Id = 2, Name = "ASUS ROG Strix B650-E", ImageUrl = "https://picsum.photos/seed/motherboard/600/400", Price = 249.99m, Description = "Gaming motherboard with PCIe 5.0", Quantity = 5, CategoryId = 2 },
                new Product { Id = 3, Name = "NVIDIA RTX 4080", ImageUrl = "https://picsum.photos/seed/gpu/600/400", Price = 1199.99m, Description = "High-end graphics card", Quantity = 3, CategoryId = 3 },
                new Product { Id = 4, Name = "Corsair Vengeance 32GB DDR5", ImageUrl = "https://picsum.photos/seed/ram/600/400", Price = 149.99m, Description = "Fast DDR5 RAM kit", Quantity = 20, CategoryId = 4 },
                new Product { Id = 5, Name = "Samsung 980 Pro 1TB NVMe SSD", ImageUrl = "https://picsum.photos/seed/ssd/600/400", Price = 109.99m, Description = "High-speed NVMe storage", Quantity = 50, CategoryId = 5 },
                new Product { Id = 6, Name = "Corsair RM850x 850W PSU", ImageUrl = "https://picsum.photos/seed/psu/600/400", Price = 129.99m, Description = "80+ Gold certified PSU", Quantity = 15, CategoryId = 6 },
                new Product { Id = 7, Name = "NZXT H510 Case", ImageUrl = "https://picsum.photos/seed/case/600/400", Price = 79.99m, Description = "Compact ATX case", Quantity = 8, CategoryId = 7 },
                new Product { Id = 8, Name = "Noctua NH-D15 Cooler", ImageUrl = "https://picsum.photos/seed/cooler/600/400", Price = 99.99m, Description = "Air cooler for CPUs", Quantity = 12, CategoryId = 8 },
                new Product { Id = 9, Name = "Dell Ultrasharp 27\"", ImageUrl = "https://picsum.photos/seed/monitor/600/400", Price = 499.99m, Description = "4K IPS monitor", Quantity = 6, CategoryId = 9 },
                new Product { Id = 10, Name = "Logitech G Pro X Keyboard", ImageUrl = "https://picsum.photos/seed/keyboard/600/400", Price = 129.99m, Description = "Mechanical gaming keyboard", Quantity = 25, CategoryId = 10 }
            );
        }
    }
}

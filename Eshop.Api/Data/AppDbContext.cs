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

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "CPU", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg" },
                new Category { Id = 2, Name = "Motherboards", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/motherboards.jpg" },
                new Category { Id = 3, Name = "GPU", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/gpu.jpg" },
                new Category { Id = 4, Name = "RAM", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/ram.jpg" },
                new Category { Id = 5, Name = "Storage", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/storage.jpg" },
                new Category { Id = 6, Name = "Power Supplies", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/psu.jpg" },
                new Category { Id = 7, Name = "Cases", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cases.jpg" },
                new Category { Id = 8, Name = "Cooling", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cooling.jpg" },
                new Category { Id = 9, Name = "Monitors", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/monitors.jpg" },
                new Category { Id = 10, Name = "Peripherals", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/peripherals.jpg" },
                new Category { Id = 100, Name = "Uncategorized", ImageUrl = "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/uncategorized.jpg" }
            );

            // Products
            var products = new List<Product>();
            int id = 1;

            // CPU
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"CPU {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg",
                    Price = 200 + i * 20,
                    Description = $"High performance CPU model {i}",
                    Quantity = 5 + i,
                    CategoryId = 1
                });
            }

            // Motherboards
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Motherboard {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/mb.jpg",
                    Price = 150 + i * 15,
                    Description = $"Reliable motherboard model {i}",
                    Quantity = 5 + i,
                    CategoryId = 2
                });
            }

            // GPU
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"GPU {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/gpu.jpg",
                    Price = 400 + i * 50,
                    Description = $"Powerful graphics card {i}",
                    Quantity = 3 + i,
                    CategoryId = 3
                });
            }

            // RAM
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"RAM {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/ram.jpg",
                    Price = 70 + i * 5,
                    Description = $"Fast DDR memory kit {i}",
                    Quantity = 10 + i,
                    CategoryId = 4
                });
            }

            // Storage
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Storage {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/storage.jpg",
                    Price = 90 + i * 10,
                    Description = $"Reliable SSD/HDD {i}",
                    Quantity = 20 + i,
                    CategoryId = 5
                });
            }

            // PSU
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Power Supply {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/psu.jpg",
                    Price = 80 + i * 10,
                    Description = $"Stable PSU unit {i}",
                    Quantity = 7 + i,
                    CategoryId = 6
                });
            }

            // Cases
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Case {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/case.jpg",
                    Price = 60 + i * 5,
                    Description = $"Durable PC case {i}",
                    Quantity = 5 + i,
                    CategoryId = 7
                });
            }

            // Cooling
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Cooling {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cooling.jpg",
                    Price = 50 + i * 5,
                    Description = $"Efficient cooling solution {i}",
                    Quantity = 8 + i,
                    CategoryId = 8
                });
            }

            // Monitors
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Monitor {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/monitor.jpg",
                    Price = 200 + i * 30,
                    Description = $"High-resolution monitor {i}",
                    Quantity = 4 + i,
                    CategoryId = 9
                });
            }

            // Peripherals
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product
                {
                    Id = id++,
                    Name = $"Peripheral {i}",
                    ImageUrl = $"https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/peripheral.jpg",
                    Price = 30 + i * 10,
                    Description = $"Peripheral device {i}",
                    Quantity = 15 + i,
                    CategoryId = 10
                });
            }

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}

using Eshop.Api.Controllers;
using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Eshop.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;

namespace Eshop.Tests
{
    public class ProductsControllerTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();

            // seed
            var category = new Category { Name = "CPU" };
            context.Categories.Add(category);
            context.Products.Add(new Product
            {
                Name = "Seed CPU",
                ImageUrl = "https://picsum.photos/seed/seedcpu/600/400",
                Quantity = 5,
                Category = category
            });
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetProducts_ShouldReturn_Ok_WithProducts()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);

            var result = await controller.GetProducts();

            var ok = result.Result as OkObjectResult;
            ok.Should().NotBeNull();
            var products = ok!.Value as IEnumerable<ProductDto>;
            products.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetProductById_ShouldReturn_Ok_WhenExists()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);

            var existing = await context.Products.FirstAsync();

            var result = await controller.GetProductById(existing.Id);

            var ok = result.Result as OkObjectResult;
            ok.Should().NotBeNull();
            var dto = ok!.Value as ProductDto;
            dto!.Id.Should().Be(existing.Id);
        }

        [Fact]
        public async Task GetProductById_ShouldReturn_404_WhenNotExists()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);

            var result = await controller.GetProductById(9999);

            var notFound = result.Result as NotFoundObjectResult;
            notFound.Should().NotBeNull();
            notFound!.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn_Created_WhenValid()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);

            var dto = new CreateProductDto
            {
                Name = "New GPU",
                ImageUrl = "https://picsum.photos/seed/gpu/600/400",
                CategoryId = context.Categories.First().Id
            };

            var result = await controller.CreateProduct(dto);

            var created = result.Result as CreatedAtActionResult;
            created.Should().NotBeNull();
            var product = created!.Value as ProductDto;
            product!.Name.Should().Be("New GPU");
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn_BadRequest_WhenMissingName()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);

            var dto = new CreateProductDto
            {
                Name = "", // invalid
                ImageUrl = "https://picsum.photos/seed/gpu/600/400",
                CategoryId = context.Categories.First().Id
            };

            var result = await controller.CreateProduct(dto);

            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task UpdateStock_ShouldReturn_Ok_WhenValid()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);
            var existing = await context.Products.FirstAsync();

            var dto = new UpdateStockDto { Quantity = 15 };

            var result = await controller.UpdateProductStock(existing.Id, dto);

            var ok = result.Result as OkObjectResult;
            ok.Should().NotBeNull();
            var updated = ok!.Value as ProductDto;
            updated!.Quantity.Should().Be(15);
        }

        [Fact]
        public async Task UpdateStock_ShouldReturn_BadRequest_WhenNegative()
        {
            using var context = GetDbContext();
            var controller = new ProductsController(context);
            var existing = await context.Products.FirstAsync();

            var dto = new UpdateStockDto { Quantity = -1 };

            var result = await controller.UpdateProductStock(existing.Id, dto);

            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}

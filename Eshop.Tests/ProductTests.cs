using Eshop.Api.Controllers;
using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Eshop.Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Eshop.Tests
{
    public class ProductTests
    {
        [Fact]
        public async Task Can_Create_Product_With_Valid_Data()
        {
            using var context = DbContextFactory.CreateInMemory();

            var product = new Product
            {
                Name = "Test CPU",
                ImageUrl = "https://picsum.photos/seed/test/600/400",
                Price = 199.99m,
                Description = "Unit test CPU",
                Quantity = 5,
                Category = new Category { Name = "CPU" }
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var saved = await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == product.Id);


            saved.Should().NotBeNull();
            saved!.Name.Should().Be("Test CPU");
            saved.Category!.Name.Should().Be("CPU");
        }

        [Fact]
        public async Task Creating_Product_Without_Name_Should_Return_BadRequest()
        {
            using var context = DbContextFactory.CreateInMemory();
            var controller = new ProductsController(context);

            var dto = new CreateProductDto
            {
                Name = "", // invalid
                ImageUrl = "https://picsum.photos/seed/test/600/400"
            };

            var result = await controller.CreateProduct(dto);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            badRequest.StatusCode.Should().Be(400);
        }


        [Fact]
        public async Task Can_Update_Product_Stock()
        {
            using var context = DbContextFactory.CreateInMemory();

            var product = new Product
            {
                Name = "RAM",
                ImageUrl = "https://picsum.photos/seed/ram/600/400",
                Quantity = 10,
                Category = new Category { Name = "RAM" }
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            product.Quantity = 20;
            await context.SaveChangesAsync();

            var updated = await context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            updated!.Quantity.Should().Be(20);
        }

        [Fact]
        public async Task Get_Product_By_Id_Should_Return_Product()
        {
            using var context = DbContextFactory.CreateInMemory();

            var product = new Product
            {
                Name = "GPU",
                ImageUrl = "https://picsum.photos/seed/gpu/600/400",
                Quantity = 3,
                Category = new Category { Name = "GPU" }
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var result = await context.Products.FindAsync(product.Id);

            result.Should().NotBeNull();
            result!.Name.Should().Be("GPU");
        }
    }
}

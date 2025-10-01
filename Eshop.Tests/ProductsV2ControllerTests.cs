using Eshop.Api.Controllers;
using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Eshop.Api.Models;
using Eshop.Api.Queue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Eshop.Tests
{
    public class ProductsV2ControllerTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var db = new AppDbContext(options);

            db.Categories.Add(new Category { Id = 1, Name = "CPU" });
            db.Products.Add(new Product { Id = 1, Name = "Test CPU", ImageUrl = "url", CategoryId = 1, Quantity = 5 });
            db.Products.Add(new Product { Id = 2, Name = "Another CPU", ImageUrl = "url", CategoryId = 1, Quantity = 10 });
            db.SaveChanges();

            return db;
        }

        [Fact]
        public async Task GetProducts_WithValidPagination_ReturnsOk()
        {
            var db = GetDbContext();
            var queue = new StockUpdateQueue();
            var controller = new ProductsV2Controller(db, queue);

            var result = await controller.GetProducts(page: 1, pageSize: 1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.Single(products); // Only 1 product per page
        }

        [Fact]
        public async Task GetProducts_WithInvalidPagination_ReturnsBadRequest()
        {
            var db = GetDbContext();
            var queue = new StockUpdateQueue();
            var controller = new ProductsV2Controller(db, queue);

            var result = await controller.GetProducts(page: 0, pageSize: -1);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task QueueStockUpdate_WithValidRequest_ReturnsAccepted()
        {
            var db = GetDbContext();
            var queue = new StockUpdateQueue();
            var controller = new ProductsV2Controller(db, queue);

            var dto = new UpdateStockDto { Quantity = 20 };
            var result = await controller.QueueStockUpdate(1, dto);

            Assert.IsType<AcceptedResult>(result);
        }

        [Fact]
        public async Task QueueStockUpdate_WithNegativeQuantity_ReturnsBadRequest()
        {
            var db = GetDbContext();
            var queue = new StockUpdateQueue();
            var controller = new ProductsV2Controller(db, queue);

            var dto = new UpdateStockDto { Quantity = -5 };
            var result = await controller.QueueStockUpdate(1, dto);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

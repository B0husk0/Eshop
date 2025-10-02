using Asp.Versioning;
using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Eshop.Api.Messaging;
using Eshop.Api.Models;
using Eshop.Api.Queue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsV2Controller : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStockUpdateQueue _queue;

        public ProductsV2Controller(AppDbContext context, IStockUpdateQueue queue)
        {
            _context = context;
            _queue = queue;
        }

        /// <summary>
        /// Retrieves products with pagination.
        /// </summary>
        /// <remarks>
        /// GET: api/v2/products?page=1&pageSize=10
        /// Returns a paged list of products.
        /// </remarks>
        /// <param name="page">Page number (default 1)</param>
        /// <param name="pageSize">Page size (default 10)</param>
        /// <response code="200">Returns the paginated list of products</response>
        /// <response code="400">If invalid pagination values are provided</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest(new { Message = "Page and pageSize must be positive integers." });
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Category = p.Category != null ? p.Category.Name : string.Empty
                })
                .ToListAsync();

            return Ok(products);
        }

        /// <summary>
        /// Queues a stock update request for a product.
        /// </summary>
        /// <remarks>
        /// PATCH: api/v2/products/{id}/stock
        /// This endpoint adds a stock update request into an in-memory queue.
        /// The update will be processed asynchronously by a background worker.
        /// </remarks>
        /// <param name="id">Product ID</param>
        /// <param name="dto">Stock update request</param>
        /// <response code="202">If the update was accepted into the queue</response>
        /// <response code="400">If request is invalid</response>
        [HttpPatch("{id:int}/stock")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> QueueStockUpdate(int id, [FromBody] UpdateStockDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (dto.Quantity < 0)
            {
                return BadRequest(new { Message = "Quantity cannot be negative." });
            }

            await _queue.QueueStockUpdateAsync(new StockUpdateRequest
            {
                ProductId = id,
                Quantity = dto.Quantity
            });

            return Accepted(new { Message = $"Stock update for product {id} has been queued." });
        }

        [HttpPatch("rabbit/{id:int}/stock")]
        public async Task<ActionResult> UpdateProductStock(
            int id,
            [FromBody] UpdateStockDto dto,
            [FromServices] StockUpdateProducer producer,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (dto.Quantity < 0)
            {
                return BadRequest(new { Message = "Quantity cannot be negative." });
            }

            var product = await _context.Products.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (product == null)
            {
                return NotFound(new { Message = $"Product with id {id} was not found." });
            }

            // Publish to RabbitMQ asynchronously
            await producer.PublishAsync(new StockUpdateMessage
            {
                ProductId = id,
                Quantity = dto.Quantity
            }, cancellationToken);

            return Accepted(new { Message = $"Stock update for product {id} has been queued." });
        }

    }
}

using Asp.Versioning;
using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Eshop.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <remarks>
        /// GET: api/v1/products
        /// Returns a list of all products, including their category names.
        /// </remarks>
        /// <response code="200">Returns the list of products</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
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
        /// Creates a new product.
        /// </summary>
        /// <remarks>
        /// POST: api/v1/products
        /// Requires a JSON body with product details. Fields 'Name' and 'ImageUrl' are required.
        /// If 'CategoryId' is not provided, defaults to 'Uncategorized' (ID 100).
        /// </remarks>
        /// <param name="dto">Product data to create</param>
        /// <response code="201">Returns the created product</response>
        /// <response code="400">If the request is invalid or category does not exist</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest(new { Message = "Product name cannot be empty." });
            }
            // fallback to Uncategorized if no category
            var categoryId = dto.CategoryId ?? 100;

            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category is null)
                return BadRequest(new { Message = "Invalid CategoryId." });

            var product = new Product
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Description = dto.Description,
                Quantity = dto.Quantity,
                CategoryId = categoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Category = category.Name
            };

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, result);
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <remarks>
        /// GET: api/v1/products/{id}
        /// Returns product details for the specified ID.
        /// </remarks>
        /// <param name="id">Unique product identifier</param>
        /// <response code="200">Returns the product details</response>
        /// <response code="404">If the product is not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound(new { Message = $"Product with id {id} was not found." });

            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Category = product.Category?.Name ?? string.Empty
            };

            return Ok(result);
        }

        /// <summary>
        /// Updates the stock quantity of a product.
        /// </summary>
        /// <remarks>
        /// PATCH: api/v1/products/{id}/stock
        /// Requires a JSON body with the new quantity. Quantity must be non-negative.
        /// </remarks>
        /// <param name="id">Unique product identifier</param>
        /// <param name="dto">Stock update request</param>
        /// <response code="200">Returns the updated product</response>
        /// <response code="400">If the request is invalid</response>
        /// <response code="404">If the product is not found</response>
        [HttpPatch("{id:int}/stock")]
        public async Task<ActionResult<ProductDto>> UpdateProductStock(int id, [FromBody] UpdateStockDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (dto.Quantity < 0)
            {
                return BadRequest(new { Message = "Quantity cannot be negative." });
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { Message = $"Product with id {id} was not found." });
            }

            product.Quantity = dto.Quantity;
            await _context.SaveChangesAsync();

            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Category = product.Category?.Name ?? string.Empty
            };

            return Ok(result);
        }

    }
}

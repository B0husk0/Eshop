using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Eshop.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all products.
        /// </summary>
        [HttpGet]
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


        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromQuery] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            // fallback
            var categoryId = dto.CategoryId ?? 100;

            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category is null)
                return BadRequest("Invalid CategoryId.");

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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { Message = $"Product with id {id} was not found." });
            }

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

        [HttpPatch("{id:int}/stock")]
        public async Task<ActionResult<ProductDto>> UpdateProductStock(int id, [FromBody] UpdateStockDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
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

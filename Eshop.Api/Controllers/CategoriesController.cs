using Asp.Versioning;
using Eshop.Api.Data;
using Eshop.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all categories with their associated products.
        /// </summary>
        /// <remarks>
        /// Returns a list of categories, each including its products.
        /// </remarks>
        /// <returns>
        /// A list of <see cref="CategoryDto"/> objects.
        /// </returns>
        /// <response code="200">Returns the list of categories.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();

            var result = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                Products = c.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Category = c.Name
                }).ToList()
            });

            return Ok(result);
        }

        /// <summary>
        /// Retrieves a specific category by its ID, including its products.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>
        /// The <see cref="CategoryDto"/> object for the specified category.
        /// </returns>
        /// <response code="200">Returns the category with the specified ID.</response>
        /// <response code="404">If the category is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var result = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                Products = category.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Category = category.Name
                }).ToList()
            };

            return Ok(result);
        }

    }
}

using Eshop.Api.Data;
using Eshop.Api.Dtos;
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
    }
}

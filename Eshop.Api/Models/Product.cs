using System.ComponentModel.DataAnnotations;

namespace Eshop.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        [RegularExpression(@"\S+", ErrorMessage = "Name cannot be empty or whitespace.")]
        public string Name { get; set; } = string.Empty;

        [Required, Url, MaxLength(1000)]
        public string ImageUrl { get; set; } = string.Empty;

        // optional
        [Range(0, 1_000_000)]
        public decimal? Price { get; set; }

        [MaxLength(4000)]
        public string? Description { get; set; }

        // stock – default 0
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;

        // Foreign key na Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

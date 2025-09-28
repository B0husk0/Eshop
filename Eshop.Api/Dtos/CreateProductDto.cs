using System.ComponentModel.DataAnnotations;

namespace Eshop.Api.Dtos
{
    public class CreateProductDto
    {
        [Required, MaxLength(200)]
        [RegularExpression(@"\S+", ErrorMessage = "Name cannot be empty or whitespace.")]
        public string Name { get; set; } = string.Empty;
        [Required, Url]
        public string ImageUrl { get; set; } = string.Empty;

        // optional fields
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } = 0;
        public int? CategoryId { get; set; }
    }
}

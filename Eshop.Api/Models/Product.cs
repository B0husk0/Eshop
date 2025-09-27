using System.ComponentModel.DataAnnotations;

namespace Eshop.Api.Models
{
    public class Product
    {
        public int Id { get; set; }   // Primary key

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Eshop.Api.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required, Url, MaxLength(1000)]
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

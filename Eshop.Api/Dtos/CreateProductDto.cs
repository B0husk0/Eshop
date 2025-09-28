namespace Eshop.Api.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        // optional fields
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } = 0;
        public int? CategoryId { get; set; }
    }
}

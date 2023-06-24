using System.ComponentModel.DataAnnotations;

namespace Shop.Api.DTOs
{
    public class ProductInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? PhotoUrl { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryInfoDto? Category { get; set; }

        public List<ProductDetailsDto>? ProductDetails { get; set; }
    }
}

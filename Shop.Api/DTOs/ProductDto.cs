namespace Shop.Api.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? PhotoUrl { get; set; }

        public CategoryDto Category { get; set; }

        public List<DetailDto> Details { get; set; }
    }
}
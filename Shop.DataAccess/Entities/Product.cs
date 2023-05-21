namespace Shop.DataAccess.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? PhotoUrl { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Detail> Details { get; } = new();
        
        public List<ProductDetail> ProductDetails { get; } = new();
    }
}
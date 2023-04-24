namespace Shop.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Details> Details { get; } = new();
        
        public List<ProductDetails> ProductDetails { get; } = new();
    }
}
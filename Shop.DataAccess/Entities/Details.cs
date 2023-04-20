namespace Shop.DataAccess.Entities
{
    public class Details
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public List<Product> Products { get; } = new();
        public List<ProductDetails> ProductDetails { get; } = new();
    }
}
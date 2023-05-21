namespace Shop.DataAccess.Entities
{
    public class Detail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DetailType Type { get; set; }

        public List<Product> Products { get; } = new();
        
        public List<ProductDetail> ProductDetails { get; } = new();
    }
}
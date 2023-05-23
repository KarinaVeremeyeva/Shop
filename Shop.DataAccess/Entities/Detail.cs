namespace Shop.DataAccess.Entities
{
    public class Detail : Entity
    {
        public string Name { get; set; }

        public DetailType Type { get; set; }

        public List<Product> Products { get; } = new();
        
        public List<ProductDetail> ProductDetails { get; } = new();
    }
}
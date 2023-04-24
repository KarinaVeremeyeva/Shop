namespace Shop.DataAccess.Entities
{
    public class ProductDetails
    {
        public int ProductId { get; set; }

        public int DetailsId { get; set; }

        public string Value { get; set; }

        public Product Product { get; set; } = null!;
        
        public Details Detail { get; set; } = null!;
    }
}
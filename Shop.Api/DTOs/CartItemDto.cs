namespace Shop.Api.DTOs
{
    public class CartItemDto
    {
        public Guid Id { get; set; }

        public string UserEmail { get; set; }

        public int Quantity { get; set; }

        public ProductDto Product { get; set; }
    }
}

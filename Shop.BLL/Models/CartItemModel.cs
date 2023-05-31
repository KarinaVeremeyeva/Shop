namespace Shop.BLL.Models
{
    public class CartItemModel
    {
        public Guid Id { get; set; }

        public string UserEmail { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        public ProductModel Product { get; set; }
    }
}

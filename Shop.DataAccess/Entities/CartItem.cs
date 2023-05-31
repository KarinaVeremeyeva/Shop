namespace Shop.DataAccess.Entities
{
    public class CartItem : Entity
    {
        public string UserEmail { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}

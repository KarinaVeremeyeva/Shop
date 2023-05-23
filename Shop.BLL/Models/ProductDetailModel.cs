namespace Shop.BLL.Models
{
    public class ProductDetailModel
    {
        public Guid ProductId { get; set; }

        public Guid DetailId { get; set; }

        public string Value { get; set; }
    }
}
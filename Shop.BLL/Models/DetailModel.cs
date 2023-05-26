using Shop.DataAccess.Entities;

namespace Shop.BLL.Models
{
    public class DetailModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DetailType Type { get; set; }

        public IEnumerable<ProductDetailModel> ProductDetails { get; set;}
    }
}
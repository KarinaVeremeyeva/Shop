using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DataAccess.Entities
{
    public class ProductDetail
    {
        public Guid ProductId { get; set; }

        public Guid DetailId { get; set; }

        public string Value { get; set; }

        public Product Product { get; set; }
        
        public Detail Detail { get; set; }
    }
}
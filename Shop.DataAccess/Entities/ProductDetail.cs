using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DataAccess.Entities
{
    public class ProductDetail
    {
        public Guid ProductId { get; set; }

        [Column("DetailId")]
        public Guid DetailsId { get; set; }

        public string Value { get; set; }

        public Product Product { get; set; } = null!;
        
        public Detail Detail { get; set; } = null!;
    }
}
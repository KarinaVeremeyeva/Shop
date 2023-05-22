namespace Shop.BLL.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? PhotoUrl { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryModel Category { get; set; }

        public List<DetailModel> Details { get; set; }
    }
}
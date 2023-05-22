namespace Shop.BLL.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<CategoryModel> ChildCategories { get; set; }
    }
}
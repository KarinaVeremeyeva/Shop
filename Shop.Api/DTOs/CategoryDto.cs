namespace Shop.Api.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<CategoryDto>? ChildCategories { get; set; }
    }
}
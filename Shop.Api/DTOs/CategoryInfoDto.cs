using System.ComponentModel.DataAnnotations;

namespace Shop.Api.DTOs
{
    public class CategoryInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}

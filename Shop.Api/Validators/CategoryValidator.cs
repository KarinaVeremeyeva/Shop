using Shop.Api.DTOs;

namespace Shop.Api.Validators
{
    public class CategoryValidator : IValidator<CategoryInfoDto>
    {
        public string Validate(CategoryInfoDto entity)
        {
            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(entity.Name))
            {
                validationErrors.Add("Category name should not be empty");
            }

            return string.Join(", ", validationErrors);
        }
    }
}
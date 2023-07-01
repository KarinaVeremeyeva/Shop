using Shop.Api.DTOs;

namespace Shop.Api.Validators
{
    public class CategoryValidator : IValidator<CategoryInfoDto>
    {
        public Task<string> ValidateAsync(CategoryInfoDto entity)
        {
            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(entity.Name))
            {
                validationErrors.Add("Category name should not be empty");
            }

            return Task.FromResult(string.Join(", ", validationErrors));
        }
    }
}
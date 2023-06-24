using Shop.BLL.Models;
using Shop.BLL.Services;

namespace Shop.Api.Validators
{
    public class ProductValidator : IValidator<ProductModel>
    {
        private readonly IDetailsService _detailsService;
        private readonly ICategoriesService _categoriesService;

        public ProductValidator(IDetailsService detailsService, ICategoriesService categoriesService)
        {
            _detailsService = detailsService;
            _categoriesService = categoriesService;
        }

        public string Validate(ProductModel entityModel)
        {
            var validationErrors = new List<string>();
            if (!_detailsService.ValidateProductDetails(entityModel.ProductDetails))
            {
                validationErrors.Add("Product detail does not exist");
            }

            if (!_categoriesService.ValidateCategory(entityModel.CategoryId))
            {
                validationErrors.Add("Category does not exist");
            }

            if (string.IsNullOrEmpty(entityModel.Name))
            {
                validationErrors.Add("Name should not be empty");
            }

            if (entityModel.Price <= 0)
            {
                validationErrors.Add("Price should be greater than 0");
            }

            return string.Join(", ", validationErrors);
        }
    }
}
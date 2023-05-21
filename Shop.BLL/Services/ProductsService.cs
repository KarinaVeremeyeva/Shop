using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class ProductsService : IProductsService
    {
        private ICategoriesService _categoriesService;
        private IProductRepository _productRepository;

        public ProductsService(
            ICategoriesService categoriesService,
            IProductRepository productRepository)
        {
            _categoriesService = categoriesService;
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductByCategoryId(Guid categoryId)
        {
            var categoryAndChildrenIds = _categoriesService.GetCategoryAndChildrenIds(categoryId);

            return _productRepository.GetProductsByCategoryIds(categoryAndChildrenIds);
        }
    }
}

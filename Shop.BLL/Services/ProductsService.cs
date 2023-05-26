using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class ProductsService : IProductsService
    {
        private ICategoriesService _categoriesService;
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductsService(
            ICategoriesService categoriesService,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _categoriesService = categoriesService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductModel? GetProduct(Guid productId)
        {
            var product = _productRepository.GetById(productId);

            return _mapper.Map<ProductModel>(product);
        }

        public IEnumerable<ProductModel> GetProductByCategoryId(Guid categoryId)
        {
            var categoryAndChildrenIds = _categoriesService.GetCategoryAndChildrenIds(categoryId);

            var productsByCategoryIds = _productRepository.GetProductsByCategoryIds(categoryAndChildrenIds);

            var productModels = _mapper.Map<List<ProductModel>>(productsByCategoryIds);
            productModels.ForEach(p => p.Details.ForEach(d => d.ProductDetails = d.ProductDetails.Where(pd => pd.ProductId == p.Id)));

            return productModels;
        }
    }
}

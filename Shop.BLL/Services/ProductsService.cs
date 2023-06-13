using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

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
            if (product == null)
            {
                throw new ArgumentException($"Product {productId} was not found");
            }
            
            return _mapper.Map<ProductModel>(product);
        }

        public IEnumerable<ProductModel> GetProductByCategoryId(Guid categoryId, List<SelectedFilterModel>? selectedFilters = null)
        {
            var categoryAndChildrenIds = _categoriesService.GetCategoryAndChildrenIds(categoryId);

            var productsByCategoryIds = _productRepository.GetProductsByCategoryIds(categoryAndChildrenIds);
            var productModels = _mapper.Map<List<ProductModel>>(productsByCategoryIds);
            var result = GetDetailsForEachProduct(productModels).ToList();

            var filteredProducts = new List<ProductModel>();
            foreach (var product in result)
            {
                var shouldBeAdded = true;
                foreach (var filter in selectedFilters)
                {
                    if (!filter.Values.Any())
                    {
                        continue;
                    }

                    if (filter.DetailId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    {
                        var minValue = decimal.Parse(filter.Values.First().Replace(".", ","));
                        var maxValue = decimal.Parse(filter.Values.Last().Replace(".", ","));
                        shouldBeAdded = product.Price >= minValue && product.Price <= maxValue;
                        continue;
                    }

                    var detail = product.Details.FirstOrDefault(d => d.Id == filter.DetailId);
                    if (detail == null)
                    {
                        shouldBeAdded = false;
                        break;
                    }

                    var detailType = detail.Type;
                    var detailValue = detail.ProductDetails.Single().Value;
                    switch (detailType)
                    {
                        case DetailType.String:
                            shouldBeAdded = filter.Values.Contains(detailValue);
                            break;
                        case DetailType.Number:
                            var minValue = double.Parse(filter.Values.First().Replace(".", ","));
                            var maxValue = double.Parse(filter.Values.Last().Replace(".", ","));
                            var numeralDetailValue = double.Parse(detailValue.Replace(".", ","));
                            shouldBeAdded = numeralDetailValue >= minValue && numeralDetailValue <= maxValue;
                            break;
                        case DetailType.Boolean:
                            shouldBeAdded = filter.Values.Contains(detailValue);
                            break;
                    }

                    if (!shouldBeAdded)
                    {
                        break;
                    }
                }

                if (shouldBeAdded)
                {
                    filteredProducts.Add(product);
                }

            }
            
            return filteredProducts;
        }

        public PaginatedListModel<ProductModel> GetProductByCategoryId(Guid categoryId, int pageNumber, List<SelectedFilterModel>? selectedFilters = null)
        {
            var products = GetProductByCategoryId(categoryId, selectedFilters);

            const int pageSize = 2;
            var paginatedList = PaginatedListModel<ProductModel>.Create(products, pageNumber, pageSize);

            return paginatedList;
        }

        private IEnumerable<ProductModel> GetDetailsForEachProduct(List<ProductModel> productModels)
        {
            productModels.ForEach(p => p.Details
                .ForEach(d => d.ProductDetails = d.ProductDetails.Where(pd => pd.ProductId == p.Id)));

            return productModels;
        }
    }
}

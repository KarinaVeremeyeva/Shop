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
            var productsWithDetails = GetDetailsForEachProduct(productModels).ToList();

            if (selectedFilters == null)
            {
                return productsWithDetails;
            }

            var filteredProducts = productsWithDetails.Where(product =>
            {
                return selectedFilters
                    .Where(filter => filter.Values.Any())
                    .All(filter =>
                    {
                        if (filter.DetailId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                        {
                            return CheckDetailValueType(DetailType.Number, product.Price.ToString(), filter.Values);
                        }

                        var detail = product.Details.FirstOrDefault(d => d.Id == filter.DetailId);
                        if (detail == null)
                        {
                            return false;
                        }

                        var detailType = detail.Type;
                        var detailValue = detail.ProductDetails.Single().Value;

                        return CheckDetailValueType(detailType, detailValue, filter.Values);
                    });
            });
            
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

        private static bool CheckDetailValueType(DetailType detailType, string detailValue, List<string> filterValues)
        {
            switch (detailType)
            {
                case DetailType.String:
                    return filterValues.Contains(detailValue);
                case DetailType.Number:
                    var minValue = double.Parse(filterValues.First().Replace(".", ","));
                    var maxValue = double.Parse(filterValues.Last().Replace(".", ","));
                    var numericDetailValue = double.Parse(detailValue.Replace(".", ","));
                    return numericDetailValue >= minValue && numericDetailValue <= maxValue;
                case DetailType.Boolean:
                    return filterValues.Contains(detailValue);
            }

            return false;
        }
    }
}

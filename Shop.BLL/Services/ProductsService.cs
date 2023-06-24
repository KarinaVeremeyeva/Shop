using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;
using System.Globalization;

namespace Shop.BLL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        private const string PriceId = "00000000-0000-0000-0000-000000000000";
        private const string PriceFilter = "Price";

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
                    .All(filter => CheckDetailValueType(filter, product));
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

        public IEnumerable<ProductModel> GetProducts()
        {
            var products = _productRepository.GetAll();
            var productsModels = _mapper.Map<List<ProductModel>>(products);
            var productsWithDetails = GetDetailsForEachProduct(productsModels);

            return productsWithDetails;
        }

        public ProductModel AddProduct(ProductModel product)
        {
            var productToAdd = _mapper.Map<Product>(product);
            var productDetails = productToAdd.ProductDetails.ToList();
            productToAdd.ProductDetails.Clear();

            var addedProduct = _productRepository.Add(productToAdd);
            if (productDetails.Any())
            {
                productDetails.ForEach(pd => pd.ProductId = productToAdd.Id);
                productToAdd.ProductDetails.AddRange(productDetails);
                _productRepository.Update(addedProduct);
            }

            var result = _productRepository.GetById(addedProduct.Id);
            var productModel = _mapper.Map<ProductModel>(result);

            return productModel;
        }

        public void RemoveProduct(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                return;
            }

            _productRepository.Remove(product.Id);
        }

        public ProductModel UpdateProduct(ProductModel product)
        {
            var productToUpdate = _mapper.Map<Product>(product);
            var existingProduct = _productRepository.GetById(product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product {product.Id} was not found");
            }

            existingProduct.Name = productToUpdate.Name;
            existingProduct.Description = productToUpdate.Description;
            existingProduct.Price = productToUpdate.Price;
            existingProduct.CategoryId = productToUpdate.CategoryId;

            existingProduct.ProductDetails.RemoveAll(pd => true);

            var productDetails = productToUpdate.ProductDetails.ToList();
            productDetails.ForEach(pd => pd.ProductId = productToUpdate.Id);
            existingProduct.ProductDetails.AddRange(productDetails);

            _productRepository.Update(existingProduct);

            var productModel = _mapper.Map<ProductModel>(existingProduct);

            return productModel;
        }

        public IEnumerable<FilterModel> GetFiltersByCategoryId(Guid categoryId)
        {
            var products = GetProductByCategoryId(categoryId, new List<SelectedFilterModel>());
            var details = products.SelectMany(p => p.Details);

            var commonDetailIds = details
                .Where(detail => products.All(p => p.Details.Any(d => d.Id == detail.Id)))
                .Select(d => d.Id)
                .Distinct()
                .ToHashSet();

            var commonFilters = details.Where(d => commonDetailIds.Contains(d.Id));

            var priceFilter = new FilterModel
            {
                DetailId = Guid.Parse(PriceId),
                Name = PriceFilter,
                Type = DetailType.Number,
                Values = products.Select(p => p.Price.ToString("F", CultureInfo.InvariantCulture)).Distinct().ToList()
            };

            var selectedFilters = commonFilters
                .GroupBy(d => d.Id)
                .Select(d => new FilterModel
                {
                    DetailId = d.Key,
                    Name = d.First().Name,
                    Type = d.First().Type,
                    Values = d.Select(x => x.ProductDetails.Single().Value).Distinct().ToList()
                });

            var filters = new List<FilterModel> { priceFilter }.Concat(selectedFilters).Where(f => f.Values.Count > 1);

            return filters;
        }

        private IEnumerable<ProductModel> GetDetailsForEachProduct(List<ProductModel> productModels)
        {
            productModels.ForEach(p => p.Details
                .ForEach(d => d.ProductDetails = d.ProductDetails.Where(pd => pd.ProductId == p.Id)));

            return productModels;
        }

        private static bool CheckDetailValueType(SelectedFilterModel filter, ProductModel product)
        {
            if (filter.DetailId == Guid.Parse(PriceId))
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

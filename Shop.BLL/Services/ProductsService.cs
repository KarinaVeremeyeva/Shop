﻿using AutoMapper;
using Shop.BLL.Models;
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

        public PaginatedListModel<ProductModel> GetProductByCategoryId(Guid categoryId, int pageNumber)
        {
            var categoryAndChildrenIds = _categoriesService.GetCategoryAndChildrenIds(categoryId);

            var productsByCategoryIds = _productRepository.GetProductsByCategoryIds(categoryAndChildrenIds);

            var productModels = _mapper.Map<List<ProductModel>>(productsByCategoryIds);
            var result = GetDetailsForEachProduct(productModels);

            var pageSize = 2;
            var paginatedList = PaginatedListModel<ProductModel>.Create(result, pageNumber, pageSize);

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

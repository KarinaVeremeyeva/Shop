using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Models;
using Shop.BLL.Services;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductsService productsService,
            IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<ProductDto> GetProductsByCategoryId([FromRoute] Guid categoryId, int? pageNumber)
        {
            var products = _productsService.GetProductByCategoryId(categoryId);
            var result = _mapper.Map<List<ProductDto>>(products);

            var pageSize = 2;
            var paginatedList = PaginatedList<ProductDto>.Create(result, pageNumber ?? 1, pageSize);

            return paginatedList;
        }

        [HttpGet("{productId}")]
        public ProductDto GetProductsById([FromRoute] Guid productId)
        {
            var product = _productsService.GetProduct(productId);

            return _mapper.Map<ProductDto>(product);
        }
    }
}

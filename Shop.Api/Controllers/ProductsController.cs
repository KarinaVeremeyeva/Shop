using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Services;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productsService;
        private IMapper _mapper;

        public ProductsController(
            IProductsService productsService,
            IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<ProductDto> GetProductsByCategoryId([FromRoute] Guid categoryId)
        {
            var products = _productsService.GetProductByCategoryId(categoryId);

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpGet("{productId}")]
        public ProductDto GetProductsById([FromRoute] Guid productId)
        {
            var product = _productsService.GetProduct(productId);

            return _mapper.Map<ProductDto>(product);
        }
    }
}

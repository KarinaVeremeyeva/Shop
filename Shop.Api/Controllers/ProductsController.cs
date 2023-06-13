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
        private readonly IProductsService _productsService;
        private readonly IDetailsService _detailsService;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductsService productsService,
            IDetailsService detailsService,
            IMapper mapper)
        {
            _productsService = productsService;
            _detailsService = detailsService;
            _mapper = mapper;
        }

        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResultDto))]
        public IActionResult GetProductsByCategoryId([FromRoute] Guid categoryId, int pageNumber = 1)
        {
            var productsPaginatedModels = _productsService.GetProductByCategoryId(categoryId, pageNumber);
            var productResultDto = _mapper.Map<ProductResultDto>(productsPaginatedModels);

            var filters = _detailsService.GetFiltersByCategoryId(categoryId);
            var filtersDto = _mapper.Map<List<FilterDto>>(filters);
            productResultDto.Filters = filtersDto;

            return Ok(productResultDto);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        public IActionResult GetProductsById([FromRoute] Guid productId)
        {
            var product = _productsService.GetProduct(productId);
            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }
    }
}

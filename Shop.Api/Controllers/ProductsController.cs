using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResultDto))]
        public IActionResult GetProductsByCategoryId([FromRoute] Guid categoryId,
            int pageNumber = 1,
            [FromBody] List<SelectedFilterDto>? selectedFilters = null)
        {
            var selectedFiltersModels = _mapper.Map<List<SelectedFilterModel>>(selectedFilters);
            var productsPaginatedModels = _productsService.GetProductByCategoryId(categoryId, pageNumber, selectedFiltersModels);
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

        [HttpGet("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductInfoDto>))]

        public IActionResult GetProducts()
        {
            var products = _productsService.GetProducts();
            var productsDto = _mapper.Map<List<ProductInfoDto>>(products);

            return Ok(productsDto);
        }

        [HttpPost("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductInfoDto))]
        public IActionResult AddProduct(ProductInfoDto productDto)
        {
            var productModel = _mapper.Map<ProductModel>(productDto);
            var addedProduct = _productsService.AddProduct(productModel);
            var result = _mapper.Map<ProductInfoDto>(addedProduct);

            return Ok(result);
        }

        [HttpDelete("{productId}/admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveProduct(Guid productId)
        {
            _productsService.RemoveProduct(productId);

            return Ok();
        }

        [HttpPut("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductInfoDto))]
        public IActionResult UpdateProduct(ProductInfoDto productDto)
        {
            var productModel = _mapper.Map<ProductModel>(productDto);
            var updatedProduct = _productsService.UpdateProduct(productModel);
            var result = _mapper.Map<ProductInfoDto>(updatedProduct);

            return Ok(result);
        }
    }
}

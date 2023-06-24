using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.Api.Validators;
using Shop.BLL.Models;
using Shop.BLL.Services;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryInfoDto> _validator;

        public CategoriesController(
            ICategoriesService categoriesService,
            IMapper mapper,
            IValidator<CategoryInfoDto> validator)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategoriesTree()
        {
            var categories = _categoriesService.GetCategoriesTree();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            
            return Ok(categoriesDto);
        }

        [HttpGet("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryInfoDto>))]
        public IActionResult GetCategoriesList()
        {
            var categories = _categoriesService.GetCategoriesList();
            var categoriesDto = _mapper.Map<List<CategoryInfoDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpPost("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryInfoDto))]
        public IActionResult AddCategory(CategoryInfoDto categoryDto)
        {
            var validationErrors = _validator.Validate(categoryDto);
            if (!string.IsNullOrEmpty(validationErrors))
            {
                return BadRequest(validationErrors);
            }

            var categoryModel = _mapper.Map<CategoryModel>(categoryDto);
            var addedCategory = _categoriesService.AddCategory(categoryModel);
            var result = _mapper.Map<CategoryInfoDto>(addedCategory);

            return Ok(result);
        }

        [HttpDelete("{categoryId}/admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveCategory(Guid categoryId)
        {
            _categoriesService.RemoveCategory(categoryId);

            return Ok();
        }

        [HttpPut("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryInfoDto))]
        public IActionResult UpdateCategory(CategoryInfoDto categoryDto)
        {
            var validationErrors = _validator.Validate(categoryDto);
            if (!string.IsNullOrEmpty(validationErrors))
            {
                return BadRequest(validationErrors);
            }

            var categoryModel = _mapper.Map<CategoryModel>(categoryDto);
            var updatedCategory = _categoriesService.UpdateCategory(categoryModel);
            var result = _mapper.Map<CategoryInfoDto>(updatedCategory);
            
            return Ok(result);
        }
    }
}

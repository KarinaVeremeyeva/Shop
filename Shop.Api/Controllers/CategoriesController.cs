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
        public async Task<IActionResult> GetCategoriesTreeAsync()
        {
            var categories = await _categoriesService.GetCategoriesTreeAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            
            return Ok(categoriesDto);
        }

        [HttpGet("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryInfoDto>))]
        public async Task<IActionResult> GetCategoriesListAsync()
        {
            var categories = await _categoriesService.GetCategoriesListAsync();
            var categoriesDto = _mapper.Map<List<CategoryInfoDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpPost("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryInfoDto))]
        public async Task<IActionResult> AddCategoryAsync(CategoryInfoDto categoryDto)
        {
            var validationErrors = await _validator.ValidateAsync(categoryDto);
            if (!string.IsNullOrEmpty(validationErrors))
            {
                return BadRequest(validationErrors);
            }

            var categoryModel = _mapper.Map<CategoryModel>(categoryDto);
            var addedCategory = await _categoriesService.AddCategoryAsync(categoryModel);
            var result = _mapper.Map<CategoryInfoDto>(addedCategory);

            return Ok(result);
        }

        [HttpDelete("{categoryId}/admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveCategoryAsync(Guid categoryId)
        {
            await _categoriesService.RemoveCategoryAsync(categoryId);

            return Ok();
        }

        [HttpPut("admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryInfoDto))]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryInfoDto categoryDto)
        {
            var validationErrors = await _validator.ValidateAsync(categoryDto);
            if (!string.IsNullOrEmpty(validationErrors))
            {
                return BadRequest(validationErrors);
            }

            var categoryModel = _mapper.Map<CategoryModel>(categoryDto);
            var updatedCategory = await _categoriesService.UpdateCategoryAsync(categoryModel);
            var result = _mapper.Map<CategoryInfoDto>(updatedCategory);
            
            return Ok(result);
        }
    }
}

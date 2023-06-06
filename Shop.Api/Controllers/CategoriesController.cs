using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Services;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesController(
            ICategoriesService categoriesService,
            IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = _categoriesService.GetCategories();

            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}

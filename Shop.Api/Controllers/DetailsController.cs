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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminsOnly")]
    [ApiController]
    [Route("api/[controller]")]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsService _detailService;
        private readonly IMapper _mapper;
        private readonly IValidator<DetailInfoDto> _validator;

        public DetailsController(
            IDetailsService detailService,
            IMapper mapper,
            IValidator<DetailInfoDto> validator)
        {
            _detailService = detailService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DetailInfoDto>))]
        public IActionResult GetDetails()
        {
            var details = _detailService.GetDetails();
            var result = _mapper.Map<List<DetailInfoDto>>(details);

            return Ok(result);
        }

        [HttpPost("admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetailInfoDto))]
        public IActionResult AddDetail(DetailInfoDto detailDto)
        {
            var validationErrors = _validator.Validate(detailDto);
            if (!string.IsNullOrEmpty(validationErrors))
            {
                return BadRequest(validationErrors);
            }

            var detailModel = _mapper.Map<DetailModel>(detailDto);
            var addedDetail = _detailService.AddDetail(detailModel);
            var result = _mapper.Map<DetailInfoDto>(addedDetail);

            return Ok(result);
        }

        [HttpDelete("{detailId}/admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveDetail(Guid detailId)
        {
            _detailService.RemoveDetail(detailId);

            return Ok();
        }

        [HttpPut("admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetailInfoDto))]
        public IActionResult UpdateDetail(DetailInfoDto detailDto)
        {
            var validationErrors = _validator.Validate(detailDto);
            if (!string.IsNullOrEmpty(validationErrors))
            {
                return BadRequest(validationErrors);
            }

            var detailModel = _mapper.Map<DetailModel>(detailDto);
            var updatedDetail = _detailService.UpdateDetail(detailModel);
            var result = _mapper.Map<DetailInfoDto>(updatedDetail);

            return Ok(result);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Models;
using Shop.BLL.Services;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsService _detailService;
        private readonly IMapper _mapper;

        public DetailsController(IDetailsService detailService, IMapper mapper)
        {
            _detailService = detailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            var details = _detailService.GetDetails();
            var result = _mapper.Map<List<DetailInfoDto>>(details);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDetail(DetailInfoDto detailDto)
        {
            var detailModel = _mapper.Map<DetailModel>(detailDto);
            var addedDetail = _detailService.AddDetail(detailModel);
            var result = _mapper.Map<DetailInfoDto>(addedDetail);

            return Ok(result);
        }

        [HttpDelete("{detailId}")]
        public IActionResult RemoveDetail(Guid detailId)
        {
            _detailService.RemoveDetail(detailId);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDetail(DetailInfoDto detailDto)
        {
            var detailModel = _mapper.Map<DetailModel>(detailDto);
            var updatedDetail = _detailService.UpdateDetail(detailModel);
            var result = _mapper.Map<DetailInfoDto>(updatedDetail);

            return Ok(result);
        }
    }
}

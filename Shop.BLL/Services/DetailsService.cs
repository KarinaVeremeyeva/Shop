using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly IDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        public DetailsService(
            IDetailRepository detailRepository,
            IMapper mapper)
        {
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<DetailModel> AddDetailAsync(DetailModel detail)
        {
            var detailToAdd = _mapper.Map<Detail>(detail);
            var addedDetail = await _detailRepository.AddAsync(detailToAdd);
            var detailModel = _mapper.Map<DetailModel>(addedDetail);

            return detailModel;
        }

        public async Task RemoveDetailAsync(Guid detailId)
        {
            var detail = await _detailRepository.GetByIdAsync(detailId);
            if (detail == null)
            {
                return;
            }

            await _detailRepository.RemoveAsync(detail.Id);
        }

        public async Task<DetailModel> UpdateDetailAsync(DetailModel detail)
        {
            var detailToUpdate = _mapper.Map<Detail>(detail);
            var updatedDetail = await _detailRepository.UpdateAsync(detailToUpdate);
            var detailModel = _mapper.Map<DetailModel>(updatedDetail);

            return detailModel;
        }

        public async Task<List<DetailModel>> GetDetailsAsync()
        {
            var details = await _detailRepository.GetAllAsync();
            var detailsModels = _mapper.Map<List<DetailModel>>(details);
            
            return detailsModels;
        }

        public async Task<bool> ValidateProductDetailsAsync(List<ProductDetailModel> productDetails)
        {
            var productDetailsIds = productDetails.Select(pd => pd.DetailId);
            var details = await GetDetailsAsync();

            var isValid = productDetails.All(productDetail =>
            {
                var detail = details.SingleOrDefault(d => d.Id == productDetail.DetailId);
                if (detail == null)
                {
                    return false;
                }

                return detail.Type switch
                {
                    DetailType.String => !string.IsNullOrEmpty(productDetail.Value),
                    DetailType.Number => double.TryParse(productDetail.Value.Replace(".", ","), out _),
                    DetailType.Boolean => bool.TryParse(productDetail.Value, out _),
                    _ => false,
                };
            });

            return isValid;
        }
    }
}

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

        public DetailModel AddDetail(DetailModel detail)
        {
            var detailToAdd = _mapper.Map<Detail>(detail);
            var addedDetail = _detailRepository.Add(detailToAdd);
            var detailModel = _mapper.Map<DetailModel>(addedDetail);

            return detailModel;
        }

        public void RemoveDetail(Guid detailId)
        {
            var detail = _detailRepository.GetById(detailId);
            if (detail == null)
            {
                return;
            }

            _detailRepository.Remove(detail.Id);
        }

        public DetailModel UpdateDetail(DetailModel detail)
        {
            var detailToUpdate = _mapper.Map<Detail>(detail);
            var updatedDetail = _detailRepository.Update(detailToUpdate);
            var detailModel = _mapper.Map<DetailModel>(updatedDetail);

            return detailModel;
        }

        public List<DetailModel> GetDetails()
        {
            var details = _detailRepository.GetAll();
            var detailsModels = _mapper.Map<List<DetailModel>>(details);
            
            return detailsModels;
        }

        public bool ValidateProductDetails(List<ProductDetailModel> productDetails)
        {
            var productDetailsIds = productDetails.Select(pd => pd.DetailId);
            var details = GetDetails();

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

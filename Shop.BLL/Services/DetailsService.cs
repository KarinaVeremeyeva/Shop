using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;
using System.Globalization;

namespace Shop.BLL.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly IProductsService _productsService;
        private readonly IDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        private const string PriceFilter = "Price";
        private const string PriceId = "00000000-0000-0000-0000-000000000000";

        public DetailsService(
            IDetailRepository detailRepository,
            IProductsService productsService,
            IMapper mapper)
        {
            _detailRepository = detailRepository;
            _productsService = productsService;
            _mapper = mapper;
        }

        public IEnumerable<FilterModel> GetFiltersByCategoryId(Guid categoryId)
        {
            var products = _productsService.GetProductByCategoryId(categoryId, new List<SelectedFilterModel>());
            var details = products.SelectMany(p => p.Details);

            var commonDetailIds = details
                .Where(detail => products.All(p => p.Details.Any(d => d.Id == detail.Id)))
                .Select(d => d.Id)
                .Distinct()
                .ToHashSet();

            var commonFilters = details.Where(d => commonDetailIds.Contains(d.Id));

            var priceFilter = new FilterModel
            {
                DetailId = Guid.Parse(PriceId),
                Name = PriceFilter,
                Type = DetailType.Number,
                Values = products.Select(p => p.Price.ToString("F", CultureInfo.InvariantCulture)).Distinct().ToList()
            };

            var selectedFilters = commonFilters
                .GroupBy(d => d.Id)
                .Select(d => new FilterModel
                {
                    DetailId = d.Key,
                    Name = d.First().Name,
                    Type = d.First().Type,
                    Values = d.Select(x => x.ProductDetails.Single().Value).Distinct().ToList()
                });

            var filters = new List<FilterModel> { priceFilter }.Concat(selectedFilters).Where(f => f.Values.Count > 1);

            return filters;
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
    }
}

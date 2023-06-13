using Shop.BLL.Models;
using Shop.DataAccess.Entities;

namespace Shop.BLL.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly IProductsService _productsService;
        private const string PriceFilter = "Price";

        public DetailsService(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public IEnumerable<FilterModel> GetFiltersByCategoryId(Guid categoryId)
        {
            var products = _productsService.GetProductByCategoryId(categoryId);
            var details = products.SelectMany(p => p.Details);

            var commonDetailIds = details
                .Where(detail => products.All(p => p.Details.Any(d => d.Id == detail.Id)))
                .Select(d => d.Id)
                .Distinct()
                .ToList();

            var commonFilters = details.Where(d => commonDetailIds.Contains(d.Id));

            var priceFilter = new FilterModel
            {
                DetailId = Guid.NewGuid(),
                Name = PriceFilter,
                Type = DetailType.Number,
                Values = products.Select(p => p.Price.ToString()).ToList()
            };

            var selectedFilters = commonFilters
                .GroupBy(d => d.Id)
                .Select(d => new FilterModel
                {
                    DetailId = d.Key,
                    Name = d.First().Name,
                    Type = d.First().Type,
                    Values = d.Select(x => x.ProductDetails.Single().Value).ToList()
                })
                .Where(f => f.Values.Count > 1);

            var result = new List<FilterModel> { priceFilter }.Concat(selectedFilters);

            return result;
        }
    }
}

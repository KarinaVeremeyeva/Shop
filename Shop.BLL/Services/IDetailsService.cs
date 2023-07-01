using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IDetailsService
    {
        Task<DetailModel> AddDetailAsync(DetailModel detail);

        Task RemoveDetailAsync(Guid id);

        Task<DetailModel> UpdateDetailAsync(DetailModel detail);

        Task<List<DetailModel>> GetDetailsAsync();

        Task<bool> ValidateProductDetailsAsync(List<ProductDetailModel> productDetails);
    }
}

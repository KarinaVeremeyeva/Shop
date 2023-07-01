using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface ICartItemsService
    {
        Task<CartItemModel> AddToCartAsync(Guid productId, string email);

        Task RemoveFromCardAsync(Guid productId, string email);

        Task ReduceProductCountAsync(Guid productId, string email);

        Task<List<CartItemModel>> GetCartItemsAsync(string email);

        Task<decimal> GetTotalPriceAsync(string email);

        Task<int> GetTotalCountAsync(string email);
    };
}

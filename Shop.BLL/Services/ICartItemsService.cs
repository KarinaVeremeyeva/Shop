using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface ICartItemsService
    {
        void AddToCart(Guid productId, string email);

        void RemoveFromCard(Guid productId, string email);

        List<CartItemModel> GetCartItems(string email);

        decimal GetTotalPrice(string email);

        int GetTotalCount(string email);
    };
}

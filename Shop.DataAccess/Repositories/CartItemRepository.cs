using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemsRepository
    {
        public CartItemRepository(ShopContext dbContext)
            : base(dbContext)
        {
        }

        public override CartItem? GetById(Guid id)
        {
            var cartItem = _context.ShoppingCartItems
               .Include(c => c.Product)
               .SingleOrDefault(p => p.Id == id);

            return cartItem;
        }

        public override IEnumerable<CartItem> GetAll()
        {
            var cartItems = _context.ShoppingCartItems
                .Include(c => c.Product)
                .ToList();

            return cartItems;
        }
    }
}

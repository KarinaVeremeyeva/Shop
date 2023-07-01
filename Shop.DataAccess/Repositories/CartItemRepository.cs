using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;
using System.Linq.Expressions;

namespace Shop.DataAccess.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemsRepository
    {
        public CartItemRepository(ShopContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<CartItem?> GetByIdAsync(Guid id)
        {
            var cartItem = await _context.ShoppingCartItems
               .Include(c => c.Product)
               .SingleOrDefaultAsync(p => p.Id == id);

            return cartItem;
        }

        public override async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            var cartItems = await _context.ShoppingCartItems
                .Include(c => c.Product)
                .ToListAsync();

            return cartItems;
        }

        public async Task<IEnumerable<CartItem>> GetWhereAsync(Expression<Func<CartItem, bool>> predicate)
        {
            return await base.GetWhereAsync(predicate, q => q.Product);
        }
    }
}

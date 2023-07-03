using Shop.DataAccess.Entities;
using System.Linq.Expressions;

namespace Shop.DataAccess.Repositories
{
    public interface ICartItemsRepository : IRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetWhereAsync(Expression<Func<CartItem, bool>> predicate);
    }
}

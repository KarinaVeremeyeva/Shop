using Shop.DataAccess.Entities;
using System.Linq.Expressions;

namespace Shop.DataAccess.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetWhereAsync(Expression<Func<Category, bool>> predicate);
    }
}

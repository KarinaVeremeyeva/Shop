using Shop.DataAccess.Entities;
using System.Linq.Expressions;

namespace Shop.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity?> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task RemoveAsync(Guid id);

        Task<IEnumerable<TEntity>> GetWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] loadStrategies);
    }
}

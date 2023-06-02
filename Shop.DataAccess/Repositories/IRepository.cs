using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity? GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(Guid id);
    }
}

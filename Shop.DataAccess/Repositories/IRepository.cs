using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity? GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(Guid id);
    }
}

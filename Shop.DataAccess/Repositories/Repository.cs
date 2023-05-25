using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ShopContext _context;
        protected DbSet<TEntity> _entities;

        public Repository(ShopContext dbContext)
        {
            _context = dbContext;
            _entities = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Remove(Guid id)
        {
            var entity = _entities.SingleOrDefault(entity => entity.Id == id);
            if (entity == null)
            {
                return;
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual TEntity? GetById(Guid id)
        {
            return _entities.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;
using System;
using System.Linq.Expressions;

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

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var entity = await _entities.SingleOrDefaultAsync(entity => entity.Id == id);
            if (entity == null)
            {
                return;
            }
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var entity = await _entities.FirstOrDefaultAsync(entity => entity.Id == id);
            
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>> [] loadStrategies)
        {
            var query = _entities.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var loadStrategy in loadStrategies)
            {
                query = query.Include(loadStrategy);
            }

            return await query.ToListAsync();
        }

        protected IQueryable<TEntity> GetEntityQuery() => _entities.AsQueryable();
    }
}

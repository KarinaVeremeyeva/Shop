using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;
using System.Linq.Expressions;

namespace Shop.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Category>> GetAllAsync() 
        {
            var categories = await _context.Categories
                .Include(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ToListAsync();

            return categories;
        }

        public override async Task<Category?> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories
                .Include(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .SingleOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<IEnumerable<Category>> GetWhereAsync(Expression<Func<Category, bool>> predicate)
        {
            return await GetEntityQuery()
                .Where(predicate)
                .Include(q => q.ChildCategories)
                .ThenInclude(q => q.ChildCategories)
                .ThenInclude(q => q.ChildCategories)
                .ToListAsync();
        }
    }
}

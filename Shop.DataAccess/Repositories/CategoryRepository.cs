using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context)
            : base(context)
        {
        }

        public override IEnumerable<Category> GetAll() 
        {
            var categories = _context.Categories
                .Include(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ToList();

            return categories;
        }

        public override Category? GetById(Guid id)
        {
            var category = _context.Categories
                .Include(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .SingleOrDefault(c => c.Id == id);

            return category;
        }
    }
}

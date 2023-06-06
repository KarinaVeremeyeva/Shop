using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext dbContext) : base(dbContext)
        {
        }

        public override Product? GetById(Guid id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Details)
                .ThenInclude(d => d.ProductDetails.Where(pd => pd.ProductId == id))
                .SingleOrDefault(p => p.Id == id);

            return product;
        }

        public IEnumerable<Product> GetProductsByCategoryIds(IEnumerable<Guid> categoryIds)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Details)
                .ThenInclude(d => d.ProductDetails)
                .Where(p => categoryIds.Contains(p.CategoryId));

            return products;
        }
    }
}

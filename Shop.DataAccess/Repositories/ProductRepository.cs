using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(d => d.ProductDetails)
                .ToListAsync();

            return products;
        }

        public override async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Details)
                .ThenInclude(d => d.ProductDetails.Where(pd => pd.ProductId == id))
                .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdsAsync(IEnumerable<Guid> categoryIds)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Details)
                .ThenInclude(d => d.ProductDetails)
                .Where(p => categoryIds.Contains(p.CategoryId))
                .ToListAsync();

            return products;
        }
    }
}

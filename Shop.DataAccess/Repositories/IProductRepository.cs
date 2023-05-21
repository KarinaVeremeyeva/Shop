using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        public IEnumerable<Product> GetProductsByCategoryIds(IEnumerable<Guid> categoryIds);
    }
}

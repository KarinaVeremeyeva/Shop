using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdsAsync(IEnumerable<Guid> categoryIds);
    }
}

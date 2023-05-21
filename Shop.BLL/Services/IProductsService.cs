using Shop.DataAccess.Entities;

namespace Shop.BLL.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProductByCategoryId(Guid categoryId);
    }
}
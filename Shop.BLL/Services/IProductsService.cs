using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductModel> GetProductByCategoryId(Guid categoryId);

        ProductModel? GetProduct(Guid productId);
    }
}
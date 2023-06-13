using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductModel> GetProductByCategoryId(Guid categoryId);

        PaginatedListModel<ProductModel> GetProductByCategoryId(Guid categoryId, int pageNumber);

        ProductModel? GetProduct(Guid productId);
    }
}
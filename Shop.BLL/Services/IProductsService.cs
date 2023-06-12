using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IProductsService
    {
        PaginatedListModel<ProductModel> GetProductByCategoryId(Guid categoryId, int pageNumber);

        ProductModel? GetProduct(Guid productId);
    }
}
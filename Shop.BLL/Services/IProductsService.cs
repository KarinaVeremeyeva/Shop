using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductModel> GetProductByCategoryId(Guid categoryId, List<SelectedFilterModel>? selectedFilters = null);

        PaginatedListModel<ProductModel> GetProductByCategoryId(Guid categoryId, int pageNumber, List<SelectedFilterModel>? selectedFilters = null);

        ProductModel? GetProduct(Guid productId);
    }
}
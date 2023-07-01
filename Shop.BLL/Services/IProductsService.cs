using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductModel>> GetProductByCategoryIdAsync(Guid categoryId, List<SelectedFilterModel>? selectedFilters = null);

        Task<PaginatedListModel<ProductModel>> GetProductByCategoryIdAsync(Guid categoryId, int pageNumber, List<SelectedFilterModel>? selectedFilters = null);

        Task<IEnumerable<FilterModel>> GetFiltersByCategoryIdAsync(Guid categoryId);

        Task<ProductModel?> GetProductAsync(Guid productId);

        Task<IEnumerable<ProductModel>> GetProductsAsync();

        Task<ProductModel> AddProductAsync(ProductModel product);

        Task RemoveProductAsync(Guid productId);

        Task<ProductModel> UpdateProductAsync(ProductModel product);
    }
}
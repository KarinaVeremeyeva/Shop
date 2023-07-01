using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Guid>> GetCategoryAndChildrenIdsAsync(Guid categoryId);

        Task<IEnumerable<CategoryModel>> GetCategoriesListAsync();

        Task<IEnumerable<CategoryModel>> GetCategoriesTreeAsync();

        Task<CategoryModel> AddCategoryAsync(CategoryModel category);

        Task RemoveCategoryAsync(Guid categoryId);

        Task<CategoryModel> UpdateCategoryAsync(CategoryModel category);

        Task<bool> ValidateCategoryAsync(Guid categoryId);
    }
}

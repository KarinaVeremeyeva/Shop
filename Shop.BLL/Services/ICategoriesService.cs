using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface ICategoriesService
    {
        IEnumerable<Guid> GetCategoryAndChildrenIds(Guid categoryId);

        IEnumerable<CategoryModel> GetCategoriesList();

        IEnumerable<CategoryModel> GetCategoriesTree();

        CategoryModel AddCategory(CategoryModel category);

        void RemoveCategory(Guid categoryId);

        CategoryModel UpdateCategory(CategoryModel category);
    }
}

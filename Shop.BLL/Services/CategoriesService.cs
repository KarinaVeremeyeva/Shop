using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Guid> GetCategoryAndChildrenIds(Guid categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                throw new ArgumentException(nameof(category), "Entity was not found");
            }
            var categoryAndChildrenIds = GetCategoryAndChildrenIds(category);

            return categoryAndChildrenIds;
        }

        private IEnumerable<Guid> GetCategoryAndChildrenIds(Category category)
        {
            var categoryId = category.Id;

            var childrenIds = category.ChildCategories.SelectMany(x => GetCategoryAndChildrenIds(x));

            return childrenIds.Concat(new List<Guid> { categoryId });
        }
    }
}

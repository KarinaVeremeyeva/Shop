using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetCategoriesList()
        {
            var categories = _categoryRepository.GetAll();
            
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public IEnumerable<CategoryModel> GetCategoriesTree()
        {
            var categories = _categoryRepository.GetAll().Where(c => c.ParentCategoryId == null);

            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public IEnumerable<Guid> GetCategoryAndChildrenIds(Guid categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                return new List<Guid>();
            }

            var categoryAndChildrenIds = GetCategoryAndChildrenIds(category);

            return categoryAndChildrenIds;
        }

        public CategoryModel AddCategory(CategoryModel category)
        {
            var categoryToAdd = _mapper.Map<Category>(category);
            var addedCategory = _categoryRepository.Add(categoryToAdd);
            var categoryModel = _mapper.Map<CategoryModel>(addedCategory);
            
            return categoryModel;
        }

        public void RemoveCategory(Guid categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                return;
            }

            _categoryRepository.Remove(category.Id);
        }

        public CategoryModel UpdateCategory(CategoryModel category)
        {
            var categoryToUpdate = _mapper.Map<Category>(category);
            var updatedCategory = _categoryRepository.Update(categoryToUpdate);
            var categotyModel = _mapper.Map<CategoryModel>(updatedCategory);

            return categotyModel;
        }

        public bool ValidateCategory(Guid categoryId)
        {
            var categoriesIds = GetCategoriesList().Select(c => c.Id);
            var isValid = categoriesIds.Contains(categoryId);

            return isValid;
        }

        private IEnumerable<Guid> GetCategoryAndChildrenIds(Category category)
        {
            var categoryId = category.Id;

            var childrenIds = category.ChildCategories.SelectMany(x => GetCategoryAndChildrenIds(x));

            return childrenIds.Concat(new List<Guid> { categoryId });
        }
    }
}

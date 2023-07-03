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

        public async Task<IEnumerable<CategoryModel>> GetCategoriesListAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesTreeAsync()
        {
            var categories = await _categoryRepository.GetWhereAsync(c => c.ParentCategoryId == null);

            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<IEnumerable<Guid>> GetCategoryAndChildrenIdsAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return new List<Guid>();
            }

            var categoryAndChildrenIds = GetCategoryAndChildrenIds(category);

            return categoryAndChildrenIds;
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel category)
        {
            var categoryToAdd = _mapper.Map<Category>(category);
            var addedCategory = await _categoryRepository.AddAsync(categoryToAdd);
            var categoryModel = _mapper.Map<CategoryModel>(addedCategory);
            
            return categoryModel;
        }

        public async Task RemoveCategoryAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return;
            }

            await _categoryRepository.RemoveAsync(category.Id);
        }

        public async Task<CategoryModel> UpdateCategoryAsync(CategoryModel category)
        {
            var categoryToUpdate = _mapper.Map<Category>(category);
            var updatedCategory = await _categoryRepository.UpdateAsync(categoryToUpdate);
            var categotyModel = _mapper.Map<CategoryModel>(updatedCategory);

            return categotyModel;
        }

        public async Task<bool> ValidateCategoryAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            
            return category != null;
        }

        private IEnumerable<Guid> GetCategoryAndChildrenIds(Category category)
        {
            var categoryId = category.Id;

            var childrenIds = category.ChildCategories.SelectMany(x => GetCategoryAndChildrenIds(x));

            return childrenIds.Concat(new List<Guid> { categoryId });
        }
    }
}

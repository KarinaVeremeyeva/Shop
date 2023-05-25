using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoriesService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var categories = _categoryRepository.GetAll();
            
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

        private IEnumerable<Guid> GetCategoryAndChildrenIds(Category category)
        {
            var categoryId = category.Id;

            var childrenIds = category.ChildCategories.SelectMany(x => GetCategoryAndChildrenIds(x));

            return childrenIds.Concat(new List<Guid> { categoryId });
        }
    }
}

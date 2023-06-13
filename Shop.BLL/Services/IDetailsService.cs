using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IDetailsService
    {
        IEnumerable<FilterModel> GetFiltersByCategoryId(Guid categoryId);
    }
}
